using System.Collections;
using System.Text;
using TOKS.SerialPortCommunicator.Interfaces;
using TOKS.SerialPortCommunicator.Extensions;

namespace TOKS.SerialPortCommunicator.Core
{
    public class BitstuffCoder : BaseCoder
    {
        private const string beforeBitstuff = "11111";
        private const string afterBitstuff = "111110";

        public BitstuffCoder(IMessageCoder coder) : base(coder) { }

        public override string Decode(byte[] message)
        {
            var bitString = BitsToString(new BitArray(message));
            var unbitstuffedString = bitString.Replace(afterBitstuff, beforeBitstuff);
            var unbitstuffedBytes = StringToBits(unbitstuffedString).ToByteArray();

            return _coder.Decode(unbitstuffedBytes);
        }

        public override byte[] Encode(string message)
        {
            var bytes = Encoding.Default.GetBytes(message);

            var bitString = BitsToString(new BitArray(bytes));
            var bitsuffedString = bitString.Replace(beforeBitstuff, afterBitstuff);
            var bitsuffedBytes = StringToBits(bitsuffedString).ToByteArray();

            return _coder.Encode(Encoding.Default.GetString(bitsuffedBytes));
        }

        private string BitsToString(BitArray bitArray)
        {
            var result = string.Empty;
            foreach (var bit in bitArray)
                result += (bool)bit == true ? "1" : "0"; 
            return result;
        }

        private BitArray StringToBits(string text)
        {
            var bitArray = new BitArray(text.Length);

            for (int i = 0; i < text.Length; i++)
                bitArray[i] = text[i] == '1';

            var bytes = new byte[(bitArray.Length + 8 - 1) / 8];
            bitArray.CopyTo(bytes, 0);

            return bitArray;
        }
    }
}
