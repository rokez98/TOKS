using System.Collections;

namespace TOKS.SerialPortCommunicator.Extensions
{
    public static class BitArrayExtensions
    {
        public static byte[] ToByteArray(this BitArray bitArray)
        {
            var bytes = new byte[(bitArray.Length + 8 - 1) / 8];
            bitArray.CopyTo(bytes, 0);
            return bytes;
        }
    }
}
