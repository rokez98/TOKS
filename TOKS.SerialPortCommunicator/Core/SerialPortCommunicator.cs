using System;
using System.IO.Ports;
using System.Linq;
using TOKS.Logger;
using TOKS.SerialPortCommunicator.Interfaces;
using TOKS.SerialPortCommunicator.Models;

namespace TOKS.SerialPortCommunicator.Core
{
    public class SerialPortCommunicator
    {
        private SerialPort _serialPort;
        private readonly IMessageCoder _coder;

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
            InternalLogger.Log.Debug("Opening serial port");
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
            InternalLogger.Log.Debug("Closing serial port");

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
            InternalLogger.Log.Debug("Reading message from port");

            var buffer = new byte[_serialPort.BytesToRead];
            _serialPort.Read(buffer, 0, buffer.Length);
            InternalLogger.Log.Debug($"Message in bytes: {String.Join(" ", buffer.ToArray())}");

            var message = _coder.Decode(buffer);
            InternalLogger.Log.Debug($"Message text: {message}");
            return message;
        }

        /// <summary>
        /// Sending message to serial port
        /// </summary>
        /// <param name="message">Sending message</param>
        public void Send(string message)
        {
            InternalLogger.Log.Debug($"Sending message: {message}");
            var encoded = _coder.Encode(message);
            _serialPort.Write(encoded, 0, encoded.Length);
        }
    }
}