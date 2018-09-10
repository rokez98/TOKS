using System.Collections;
using System.Text;
using TOKS.SerialPortCommunicator.Extensions;
using TOKS.SerialPortCommunicator.Interfaces;

namespace TOKS.SerialPortCommunicator.Core
{
    public class BaseCoder : IMessageCoder
    {
        protected IMessageCoder _coder;

        public BaseCoder()
        {
        }

        public BaseCoder(IMessageCoder coder) => _coder = coder;

        protected string BitsToString(BitArray bitArray)
        {
            var result = string.Empty;
            foreach (var bit in bitArray)
                result += (bool)bit == true ? "1" : "0";
            return result;
        }

        protected BitArray StringToBits(string text)
        {
            var bitArray = new BitArray(text.Length);

            for (int i = 0; i < text.Length; i++)
                bitArray[i] = text[i] == '1';

            var bytes = new byte[(bitArray.Length + 8 - 1) / 8];
            bitArray.CopyTo(bytes, 0);

            return bitArray;
        }

        public virtual string Decode(byte[] message) => Encoding.Default.GetString(message).Trim('\0');

        public virtual byte[] Encode(string message) => Encoding.Default.GetBytes(message);
    }
}
