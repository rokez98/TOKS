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
            var baseDecoded = Encoding.Default.GetBytes(_coder.Decode(message));

            var bitString = BitsToString(new BitArray(baseDecoded));
            var unbitstuffedString = bitString.Replace(afterBitstuff, beforeBitstuff);
            var unbitstuffedBytes = StringToBits(unbitstuffedString).ToByteArray();

            return Encoding.Default.GetString(unbitstuffedBytes).Trim('\0');
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
