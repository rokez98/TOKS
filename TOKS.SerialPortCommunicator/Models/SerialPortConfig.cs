using System.IO.Ports;
using TOKS.SerialPortCommunicator.Enums;

namespace TOKS.SerialPortCommunicator.Models
{
    public class SerialPortConfig
    {
        public string RecieverPortName { get; set; }
        public string SenderPortName { get; set; }
        public byte PortId { get; set; }
        public EBaudRate BaudRate { get; set; }
        public Parity Parity { get; set; }
        public EDataBits DataBits { get; set; }
        public StopBits StopBits { get; set; }
        public bool IsMonitorStation { get; set; }
    }
}
