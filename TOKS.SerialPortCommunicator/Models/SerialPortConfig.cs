using System.IO.Ports;
using TOKS.SerialPortCommunicator.Enums;

namespace TOKS.SerialPortCommunicator.Models
{
    public class SerialPortConfig
    {
        public string PortName { get; set; }
        public EBaudRate BaudRate { get; set; }
        public Parity Parity { get; set; }
        public EDataBits DataBits { get; set; }
        public StopBits StopBits { get; set; }
    }
}
