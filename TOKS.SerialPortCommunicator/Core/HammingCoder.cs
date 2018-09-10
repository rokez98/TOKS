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

        public int GetNumberOfBits(string text) => (int) Math.Ceiling(Math.Log(text.Length, 2));

        public List<string> GetControlLines(string code)
        {
            var length = GetNumberOfBits(code);
            return Enumerable.Range(1, length).Select(i => CalculateControlLine(i, code.Length)).ToList();
        }

        public string CalculateControlLine(int number, int length)
        {
            var line = string.Empty;
            for (var i = 0; i < length; i++)
            {
                if ((i + 1) / (int)Math.Pow(2, number - 1) % 2 == 0) line += "0";
                else line += "1";
            }

            return line;
        }

        public string InitializeControlBits(string bits)
        {
            var numberOfBits = (int)Math.Ceiling(Math.Log(bits.Length, 2)) + 1;

            for (var i = 0; i < numberOfBits; i++)
            {
                var n = (int) Math.Pow(2, i) - 1;
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

        public string ExtractControlBits(string bitsString)
        {
            var numberOfBits = GetNumberOfBits(bitsString);

            if ((int)Math.Ceiling(Math.Log(bitsString.Length, 2)) != numberOfBits) numberOfBits--;

            for (int i = 0; i < numberOfBits; i++)
            {
                var n = (int)Math.Pow(2, i) - 1;
                bitsString = bitsString.Remove(n - i, 1);
            }

            return bitsString;
        }

        public List<bool> CalculateControlBits(string controlCode, List<string> controlLines)
        {
            return controlLines.Select(line => CalculateBit(controlCode, line)).ToList();
        }

        public bool CalculateBit(string controlCode, string controlLine)
        {
            var res = controlCode.Where((t, i) => t == '1' && controlLine[i] == '1').Count();

            return res % 2 == 1;
        }

        public override byte[] Encode(string message)
        {
            var bytes = Encoding.Default.GetBytes(message);
            var bitString = BitsToString(new BitArray(bytes));
            bitString = InitializeControlBits(bitString);

            var controlLines = GetControlLines(bitString);
            var bits = CalculateControlBits(bitString, controlLines);

            bitString = InsertControlBits(bitString, bits);
            var encodedBytes = StringToBits(bitString).ToByteArray();

            return _coder.Encode(Encoding.Default.GetString(encodedBytes));

            return encodedBytes;
        }

        public override string Decode(byte[] message)
        {
            var bitString = BitsToString(new BitArray(message));
            var controlLines = GetControlLines(bitString);

            var sindromBits = CalculateControlBits(bitString, controlLines);
            // check for 0

            var decodedBitsString = ExtractControlBits(bitString);
            var decodedBytes = StringToBits(decodedBitsString).ToByteArray();

            return _coder.Decode(decodedBytes);
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
