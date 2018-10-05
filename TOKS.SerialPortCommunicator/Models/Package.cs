namespace TOKS.SerialPortCommunicator.Models
{
    public class Package
    {
        public byte DestinationAddress { get; set; }
        public byte SenderAddress { get; set; }
        public short Length { get; set; }
        public byte[] Message { get; set; }
        public int FCS { get; set; }
    }
}
