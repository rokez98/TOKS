using System;
using System.IO.Ports;
using System.Threading;
using TOKS.SerialPortCommunicator.Extensions;
using TOKS.SerialPortCommunicator.Interfaces;
using TOKS.SerialPortCommunicator.Models;

namespace TOKS.SerialPortCommunicator.Core
{
    public class SerialPortCommunicator
    {
        private const byte JAM_SIGNAL = 125;
        private const byte COUNT = 125;

        private SerialPort _serialPort;
        private readonly IMessageCoder _coder;

        public byte _portId { get; set; }

        public delegate void ReceivedEventHandler(object sender, EventArgs e);

        public delegate void ErrorEventHandler(object sender, EventArgs e);

        public bool IsOpen => _serialPort != null;

        public SerialPortCommunicator(IMessageCoder coder)
        {
            _coder = coder;
        }

        /// <summary>
        /// Open port with settings
        /// </summary>
        /// <param name="config">Serial port configuration</param>
        /// <param name="messageReceivedEventHandler">Callback to run to when something is received</param>
        public void Open(SerialPortConfig config, ReceivedEventHandler messageReceivedEventHandler, ErrorEventHandler errorEventHandler)
        {
            if (IsOpen) return;

            _serialPort = new SerialPort()
            {
                PortName = config.PortName,
                BaudRate = (int)config.BaudRate,
                Parity = config.Parity,
                DataBits = (int)config.DataBits,
                StopBits = config.StopBits
            };
            _serialPort.Open();

            if (messageReceivedEventHandler != null) _serialPort.DataReceived += (sender, args) => messageReceivedEventHandler(sender, args);
            if (errorEventHandler != null) _serialPort.ErrorReceived += (sender, args) => errorEventHandler(sender, args);
        }

        /// <summary>
        /// Closing current connection
        /// </summary>
        public void Close()
        {
            if (!IsOpen) return;
            _serialPort.Close();
            _serialPort = null;
        }

        /// <summary>
        /// Read message from serial port
        /// </summary>
        /// <returns>Existing string</returns>
        public string Read()
        {
            var buffer = new byte[_serialPort.BytesToRead];

            _serialPort.Read(buffer, 0, buffer.Length);

            if (isJamSignalRecieved(buffer)) return String.Empty;

            var package = buffer.ToPackage();

            if (package.DestinationAddress != _portId) return String.Empty;

            var message = _coder.Decode(package.Message);
            return message;
        }

        /// <summary>
        /// Sending message to serial port
        /// </summary>
        /// <param name="message">Sending message</param>
        public void Send(string message, byte destinationAddress)
        {
            var byteMessage = _coder.Encode(message);

            var package = new Package()
            {
                DestinationAddress = destinationAddress,
                SenderAddress = _portId,
                Length = (short)byteMessage.Length,
                Message = byteMessage,
                FCS = 1
            };

            var msgArray = package.ToByteArray();

            for (int numberOfAttempt = 0; ; numberOfAttempt++)
            {
                waitFree();

                if (!isCollide())
                {
                    _serialPort.Write(msgArray, 0, msgArray.Length);
                    break;
                }
                else
                {
                    _serialPort.Write(new byte[] { JAM_SIGNAL }, 0, 1);
                    delaySending(numberOfAttempt);
                }
            }
        }

        public bool isCollide() => timeOdd();

        public bool isChannelBusy() => timeOdd();

        public bool isJamSignalRecieved(byte[] message) => message.Length == 1 && message[0] == JAM_SIGNAL;

        public void waitFree()
        {
            if (isChannelBusy())
            {
                Thread.Sleep(100);
            }
        }

        public void delaySending(int number) => Thread.Sleep(new Random().Next((int)Math.Pow(2, Math.Min(10, number))) * 10);

        private bool timeOdd() => DateTime.Now.Millisecond % 2 == 0;
    }
}