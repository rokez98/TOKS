using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using TOKS.SerialPortCommunicator.Exceptions;
using TOKS.SerialPortCommunicator.Extensions;
using TOKS.SerialPortCommunicator.Interfaces;
using TOKS.SerialPortCommunicator.Models;
using static TOKS.SerialPortCommunicator.Models.Package;

namespace TOKS.SerialPortCommunicator.Core
{
    public class SerialPortCommunicator
    {
        private DateTime _lastTokenRecieved;

        private SerialPort _recieverSerialPort;
        private SerialPort _senderSerialPort;

        private Queue<DataBlock> messageQueue = new Queue<DataBlock>();

        private byte _portId;

        private readonly IMessageCoder _coder;

        public delegate void ReceivedEventHandler(object sender, EventArgs e);

        public delegate void ErrorEventHandler(object sender, EventArgs e);

        public bool IsOpen => _recieverSerialPort?.IsOpen ?? false;

        public SerialPortCommunicator(IMessageCoder coder) => _coder = coder;

        /// <summary>
        /// Open port with settings
        /// </summary>
        /// <param name="config">Serial port configuration</param>
        /// <param name="messageReceivedEventHandler">Callback to run to when something is received</param>
        public void Open(SerialPortConfig config, ReceivedEventHandler messageReceivedEventHandler, ErrorEventHandler errorEventHandler)
        {
            if (IsOpen) return;

            _recieverSerialPort = new SerialPort()
            {
                PortName = config.RecieverPortName,
                BaudRate = (int)config.BaudRate,
                Parity = config.Parity,
                DataBits = (int)config.DataBits,
                StopBits = config.StopBits
            };

            _senderSerialPort = new SerialPort()
            {
                PortName = config.SenderPortName,
                BaudRate = (int)config.BaudRate,
                Parity = config.Parity,
                DataBits = (int)config.DataBits,
                StopBits = config.StopBits
            };

            _portId = config.PortId;

            _recieverSerialPort.Open();
            _senderSerialPort.Open();

            if (config.IsMonitorStation) Task.Run(() => WatchTokenRestore());

            if (messageReceivedEventHandler != null)
            {
                _recieverSerialPort.DataReceived += (sender, args) => messageReceivedEventHandler(sender, args);
                if (config.IsMonitorStation) _recieverSerialPort.DataReceived += (s, e) => UpdateTokenRecievedDate();
            }

            if (errorEventHandler != null)
            {
                _recieverSerialPort.ErrorReceived += (sender, args) => errorEventHandler(sender, args);
            }
        }

        public void UpdateTokenRecievedDate()
        {
            _lastTokenRecieved = DateTime.Now;
        }

        /// <summary>
        /// Restores token if it has been lost
        /// </summary>
        public async Task WatchTokenRestore()
        {
            while (IsOpen)
            {
                if (DateTime.Now > _lastTokenRecieved.AddSeconds(2))
                {
                    Package package = new Package()
                    {
                        AccessControl = new AccessControlByte()
                        {
                            MonitorBit = true,
                            TokenBit = true,
                            PriorityBits = 0,
                            ReservationBits = 0
                        }
                    };
                    _senderSerialPort.Write(package);
                }
                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// Closing current connection
        /// </summary>
        public void Close()
        {
            if (!IsOpen) return;
            _recieverSerialPort.Close();
            _recieverSerialPort.Dispose();
            _recieverSerialPort = null;

            _senderSerialPort.Close();
            _senderSerialPort.Dispose();
            _senderSerialPort = null;
        }

        /// <summary>
        /// Read message from serial port
        /// </summary>
        /// <returns>Existing string</returns>
        public void Read(out string message)
        {
            message = String.Empty;

            var package = _recieverSerialPort.Read();

            if (package.AccessControl.TokenBit == true)
            {
                if (messageQueue.Any())
                {
                    package.AccessControl.TokenBit = false;
                    package.FrameControl = new FrameControlByte()
                    {
                        AddressRecognized = false,
                        FrameCopied = false
                    };
                    package.Data = messageQueue.Dequeue();
                }

                _senderSerialPort.Write(package);
                return;
            }

            if (package.Data.SenderAddress == _portId)
            {
                package.AccessControl.TokenBit = true;

                _senderSerialPort.Write(package);
                return;
            }

            if (package.Data.DestinationAddress == _portId)
            {
                if (package.Data.FCS != CalculateFcs(package.Data.Message)) throw new IncorrectFCSException("FCS is incorrect!");

                package.FrameControl.AddressRecognized = true;
                package.FrameControl.FrameCopied = true;

                message = _coder.Decode(package.Data.Message);

                _senderSerialPort.Write(package);
                return;
            }

            _senderSerialPort.Write(package);
        }

        /// <summary>
        /// Sending message to serial port
        /// </summary>
        /// <param name="message">Sending message</param>
        /// <param name="destinationAddress">Destination address</param>
        public void Send(string message, byte destinationAddress)
        {
            var byteMessage = _coder.Encode(message);

            var data = new DataBlock()
            {
                DestinationAddress = destinationAddress,
                SenderAddress = _portId,
                Length = (short)byteMessage.Length,
                Message = byteMessage,
                FCS = CalculateFcs(byteMessage)
            };

            messageQueue.Enqueue(data);
        }

        /// <summary>
        /// Calculate Fcs info
        /// </summary>
        /// <param name="message">Message to calculate FCS</param>
        /// <returns>
        /// File control sum
        /// </returns>
        private int CalculateFcs(IEnumerable<byte> message) => message.Aggregate(0, (fcs, b) => (byte)fcs ^ b);
    }
}