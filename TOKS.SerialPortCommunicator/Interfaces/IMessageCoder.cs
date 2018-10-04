namespace TOKS.SerialPortCommunicator.Interfaces
{
    public interface IMessageCoder
    {
        string Decode(byte[] message);
        byte[] Encode(string message);
    }
}
