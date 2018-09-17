using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOKS.SerialPortCommunicator.Core;

namespace TOKS.UnitTests
{
    [TestClass]
    public class BitstuffingCoderTests
    {
        public string GenerateRandomMessage()
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        [TestMethod]
        public void EncodeDecode()
        {
            for (int i = 0; i < 1000; i++)
            {
                var message = GenerateRandomMessage();
                var coder = new BitstuffCoder(new BaseCoder());

                var res = coder.Decode(coder.Encode(message));

                Assert.AreEqual(message, res);
            }
        }

        [TestMethod]
        public void EncodeBitstuffDecode()
        {
            var message = "???";
            var coder = new BitstuffCoder(new BaseCoder());

            var res = coder.Decode(coder.Encode(message));

            Assert.AreEqual(message, res);
        }

    }
}
