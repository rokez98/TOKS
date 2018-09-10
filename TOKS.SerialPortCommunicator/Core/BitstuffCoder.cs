using System.Collections;
using System.Text;
using TOKS.SerialPortCommunicator.Interfaces;
using TOKS.SerialPortCommunicator.Extensions;

namespace TOKS.SerialPortCommunicator.Core
{
    public class BitstuffCoder : BaseCoder
    {
        private const string beforeBitstuff = "111111";
        private const string afterBitstuff = "1111101";

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
    }
}
