using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using TOKS.Logger;
using TOKS.SerialPortCommunicator.Enums;
using TOKS.SerialPortCommunicator.Models;

namespace TOKS.SerialPortCommunicator.Core
{
    public class SerialPortCommunicator
    {
        private SerialPort _serialPort;

        public delegate void ReceivedEventHandler(object sender, EventArgs e);

        public bool IsOpen => _serialPort != null;

        /// <summary>
        /// Open port with settings
        /// </summary>
        /// <param name="config">Serial port configuration</param>
        /// <param name="messageReceivedEventHandler">Callback to run to when something is received</param>
        public void Open(SerialPortConfig config, ReceivedEventHandler messageReceivedEventHandler)
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
            InternalLogger.Log.Debug($"Message in bytes: {buffer}");

            var message = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
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
            _serialPort.Write(message.ToArray(), 0, message.Length);
        }
    }
}