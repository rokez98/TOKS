using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using TOKS.SerialPortCommunicator.Interfaces;
using TOKS.SerialPortCommunicator.Models;

namespace TOKS.SerialPortCommunicator.Core
{
    public class SerialPortCommunicator
    {
        private int SECOND_DELAY = 1000;

        private const byte JAM_SIGNAL = 125;
        private const byte END_OF_MESSAGE = 126;

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
                BaudRate = (int) config.BaudRate,
                Parity = config.Parity,
                DataBits = (int) config.DataBits,
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

            var receiveBuffer = new List<Byte>();

            byte[] destinationAddress = new byte[1];
            _serialPort.Read(destinationAddress, 0, 1);
            if (destinationAddress.First() != _portId) return String.Empty;


            while (true)
            {
                byte[] b = new byte[1];
                if (_serialPort.BytesToRead == 0)
                {
                    continue;
                }
                _serialPort.Read(b, 0, 1);
                if (b[0] == END_OF_MESSAGE) break;

                if (b[0] == JAM_SIGNAL)
                {
                    receiveBuffer.RemoveAt(receiveBuffer.Count - 1);
                    continue;
                }
                receiveBuffer.Add(b[0]);
            }


            var message = _coder.Decode(receiveBuffer.ToArray());

            return message;
        }

        /// <summary>
        /// Sending message to serial port
        /// </summary>
        /// <param name="message">Sending message</param>
        public void Send(string message, byte destinationAddress)
        {
            var msgArray = _coder.Encode(message).ToList();
            msgArray.Insert(0, destinationAddress);

            foreach (Byte item in msgArray)
            {
                for (int numberOfAttempt = 0; ; numberOfAttempt++)
                {
                    _serialPort.Write(new byte[] { item }, 0, 1);
                    
                    Thread.Sleep(10);

                    if (isCollide())
                    {
                        _serialPort.Write(new byte[] { JAM_SIGNAL }, 0, 1);

                        delaySending(numberOfAttempt);
                    }
                    else break;
                }
            }
            _serialPort.Write(new byte[] { END_OF_MESSAGE }, 0, 1);
        }

        public bool isCollide() => timeOdd();

        public bool isChannelBusy() => timeOdd();

        public void waitFree()
        {
            if (isChannelBusy())
            {
                Thread.Sleep(SECOND_DELAY);
            }
        }

        public void delaySending(int number) => Thread.Sleep(new Random().Next((int)Math.Pow(2, Math.Min(10, number))) * 10);

        private bool timeOdd() => DateTime.Now.Second % 2 == 0;
    }
}