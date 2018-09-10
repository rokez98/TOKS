using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOKS.SerialPortCommunicator.Core;
using TOKS.SerialPortCommunicator.Interfaces;

namespace TOKS.UnitTests
{
    [TestClass]
    public class HammingCoderTests
    {
        public string GenerateRandomMessage()
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        [TestMethod]
        public void InitializeControlBits()
        {
            var coder = new HammingCoder(new BaseCoder());

            var res = coder.InitializeControlBits("1111111");

            Assert.AreEqual("00101110111", res);
        }

        [TestMethod]
        public void CalculateControlLine1()
        {
            var coder = new HammingCoder(new BaseCoder());
            var res = coder.CalculateControlLine(1, 20);

            Assert.AreEqual("10101010101010101010", res);
        }

        [TestMethod]
        public void CalculateControlLine2()
        {
            var coder = new HammingCoder(new BaseCoder());
            var res = coder.CalculateControlLine(2, 20);

            Assert.AreEqual("01100110011001100110", res);
        }

        [TestMethod]
        public void CalculateControlLine5()
        {
            var coder = new HammingCoder(new BaseCoder());
            var res = coder.CalculateControlLine(5, 20);

            Assert.AreEqual("00000000000000011111", res);
        }

        [TestMethod]
        public void CalculateControlBit()
        {
            var coder = new HammingCoder(new BaseCoder());
            var res = coder.CalculateBit("10101010", "11001100");

            Assert.AreEqual(false, res);
        }

        [TestMethod]
        public void GetControlLines()
        {
            var coder = new HammingCoder(new BaseCoder());
            var res = coder.GetControlLines("00100010001011100001");

            Assert.AreEqual("10101010101010101010", res[0]);
            Assert.AreEqual("01100110011001100110", res[1]);
            Assert.AreEqual("00000000000000011111", res[4]);
        }

        [TestMethod]
        public void CalculateControlBits()
        {
            var coder = new HammingCoder(new BaseCoder());
            var res = coder.CalculateControlBits("00100010001011100001", coder.GetControlLines("00100010001011100001"));

            Assert.AreEqual(true, res[0]);
            Assert.AreEqual(true, res[1]);
            Assert.AreEqual(false, res[3]);
        }

        [TestMethod]
        public void ExtractControlBits()
        {
            var coder = new HammingCoder(new BaseCoder());
            var res = coder.ExtractControlBits("00101110111");

            Assert.AreEqual("1111111", res);
        }

        [TestMethod]
        public void EncodeMessage()
        {
            for (int i = 0; i < 1000; i++)
            {
                var coder = new HammingCoder(new BaseCoder());
                var message = GenerateRandomMessage();

                var encoded = coder.Encode(message);

                var res = coder.Decode(coder.Encode(message));


                Assert.AreEqual(message + "\0", res);
            }
        }
    }
}
