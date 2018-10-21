namespace TOKS.SerialPortCommunicator.Models
{
    public class Package
    {
        public AccessControlByte AccessControl { get; set; }

        public DataBlock Data { get; set; }

        public FrameControlByte FrameControl { get; set; }

        public class AccessControlByte
        {
            public byte PriorityBits { get; set; }
            public bool TokenBit { get; set; }
            public bool MonitorBit { get; set; }
            public byte ReservationBits { get; set; }
        }

        public class DataBlock
        {
            public byte DestinationAddress { get; set; }
            public byte SenderAddress { get; set; }
            public short Length { get; set; }
            public byte[] Message { get; set; }
            public int FCS { get; set; }
        }

        public class FrameControlByte
        {
            public bool AddressRecognized { get; set; }
            public bool FrameCopied { get; set; }
        }
    }
}
