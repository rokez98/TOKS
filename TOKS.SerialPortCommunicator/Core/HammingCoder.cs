using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TOKS.SerialPortCommunicator.Extensions;
using TOKS.SerialPortCommunicator.Interfaces;

namespace TOKS.SerialPortCommunicator.Core
{
    public class HammingCoder : BaseCoder
    {
        public HammingCoder(IMessageCoder coder) : base(coder)
        {
        }

        public int GetNumberOfBitsToInsert(int length) => Enumerable.Range(0, length).First(i => length + i <= Math.Pow(2, i));

        public int GetNumberOfContainedBits(int length) => Enumerable.Range(0, length).First(i => length - i < Math.Pow(2, i));

        public List<string> CalculateControlLines(string code)
        {
            var length = GetNumberOfContainedBits(code.Length);
            return Enumerable.Range(1, length).Select(i => CalculateControlLine(i, code.Length)).ToList();
        }

        public string CalculateControlLine(int number, int length)
        {
            var line = string.Empty;
            for (var i = 0; i < length; i++)
            {
                line += ((i + 1) / (int)Math.Pow(2, number - 1) % 2 == 0) ? "0" : "1";
            }

            return line;
        }

        public List<bool> CalculateControlBits(string controlCode, List<string> controlLines)
        {
            return controlLines.Select(line => CalculateControlBit(controlCode, line)).ToList();
        }

        public bool CalculateControlBit(string controlCode, string controlLine)
        {
            var res = controlCode.Where((s, i) => s == '1' && controlLine[i] == '1').Count();

            return res % 2 == 1;
        }

        #region Encoding

        public override byte[] Encode(string message)
        {
            var bytes = Encoding.Default.GetBytes(message);
            var bitString = BitsToString(new BitArray(bytes));
            bitString = InitializeControlBits(bitString);

            var controlLines = CalculateControlLines(bitString);
            var bits = CalculateControlBits(bitString, controlLines);

            bitString = InsertControlBits(bitString, bits);
            var encodedBytes = StringToBits(bitString).ToByteArray();

            return _coder.Encode(Encoding.Default.GetString(encodedBytes));
        }

        public string InitializeControlBits(string bits)
        {
            var numberOfBits = GetNumberOfBitsToInsert(bits.Length);

            for (var i = 0; i < numberOfBits; i++)
            {
                var n = (int)Math.Pow(2, i) - 1;
                if (n <= bits.Length) bits = bits.Insert(n, "0");
                else bits += "0";
            }

            return bits;
        }

        public string InsertControlBits(string bitsString, List<bool> bits)
        {
            var chars = bitsString.ToCharArray();

            for (int i = 0; i < bits.Count; i++)
            {
                var n = (int)Math.Pow(2, i) - 1;
                chars[n] = bits[i] ? '1' : '0';
            }

            return new string(chars);
        }

        #endregion

        #region Decoding

        public override string Decode(byte[] message)
        {
            var baseDecoded = Encoding.Default.GetBytes(_coder.Decode(message));

            var bitString = BitsToString(new BitArray(baseDecoded));
            var controlLines = CalculateControlLines(bitString);

            var sindromBits = CalculateControlBits(bitString, controlLines);
            
            if (!sindromBits.All(bit => bit == false))
            {
                var errorBit = GetErrorBitNumber(sindromBits);
                bitString = FixBit(bitString, errorBit);
            }

            var decodedBitsString = ExtractControlBits(bitString);
            var decodedBytes = StringToBits(decodedBitsString).ToByteArray();

            return Encoding.Default.GetString(decodedBytes).Trim('\0');
        }

        public string FixBit(string bitString, int errorBit)
        {
            var b = bitString[errorBit];
            bitString = bitString.Remove(errorBit - 1, 1);
            bitString = bitString.Insert(errorBit - 1, b == '1' ? "0" : "1");
            return bitString;
        }

        public int GetErrorBitNumber(List<bool> bits)
        {
            var res = 0;
            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i] == true) res += (int)Math.Pow(2, i);
            }
            return res;
        }

        public string ExtractControlBits(string bitsString)
        {
            var numberOfBits = GetNumberOfContainedBits(bitsString.Length);

            for (int i = 0; i < numberOfBits; i++)
            {
                var n = (int)Math.Pow(2, i) - 1;
                bitsString = bitsString.Remove(n - i, 1);
            }

            return bitsString;
        }

        #endregion
    }
}
