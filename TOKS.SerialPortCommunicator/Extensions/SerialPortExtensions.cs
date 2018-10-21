using System.IO.Ports;
using TOKS.SerialPortCommunicator.Models;

namespace TOKS.SerialPortCommunicator.Extensions
{
    public static class SerialPortExtensions
    {
        public static void Write(this SerialPort serialPort, Package package)
        {
            var bytes = package.ToByteArray();
            serialPort.Write(bytes, 0, bytes.Length);
        }

        public static Package Read(this SerialPort serialPort)
        {
            var buffer = new byte[serialPort.BytesToRead];
            serialPort.Read(buffer, 0, buffer.Length);

            var package = buffer.ToPackage();
            return package;
        }
    }
}