using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TOKS.SerialPortCommunicator.Core;
using TOKS.SerialPortCommunicator.Interfaces;

namespace TOKS.UnitTests
{
    [TestClass]
    public class CoderTests
    {
        public string GenerateRandomMessage()
        {
            var path = Path.GetRandomFileName();
            path = path.Replace(".", "");
            return path;
        }

        [TestMethod]
        public void CodersIntegration()
        {
            IMessageCoder coder = new BaseCoder();

            coder = new BitstuffCoder(coder);
            coder = new HammingCoder(coder);

            var message = GenerateRandomMessage();

            var res = coder.Decode(coder.Encode(message));

            Assert.AreEqual(message, res);
        }

        [TestMethod]
        public void CodersIntegrationWithBitstuffing()
        {
            IMessageCoder coder = new BaseCoder();

            coder = new BitstuffCoder(coder);
            coder = new HammingCoder(coder);

            var message = "???";

            var res = coder.Decode(coder.Encode(message));

            Assert.AreEqual(message, res);
        }
    }
}
