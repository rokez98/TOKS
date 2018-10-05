using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOKS.SerialPortCommunicator.Core;
using TOKS.SerialPortCommunicator.Models;
using TOKS.SerialPortCommunicator.Extensions;

namespace TOKS.UnitTests
{
    [TestClass]
    public class PackageTests
    {
        [TestMethod]
        public void PackTest()
        {
            byte senderAddress = 1;
            byte destinationAddress = 2;
            int fcs = 1;
            var message = new BaseCoder().Encode("sampletext");

            Package package = new Package()
            {
                DestinationAddress = destinationAddress,
                SenderAddress = senderAddress,
                Length = (short)message.Length,
                Message = message,
                FCS = fcs
            };

            var result = package.ToByteArray();

            Assert.AreEqual(result[0], destinationAddress);
            Assert.AreEqual(result[1], senderAddress);
            Assert.AreEqual(BitConverter.ToInt16(result, 2) , message.Length);
            CollectionAssert.AreEqual(result.Skip(4).Take(message.Length).ToArray() , message);
            Assert.AreEqual(BitConverter.ToInt32(result.Reverse().Take(4).Reverse().ToArray() , 0), fcs);
        }

        [TestMethod]
        public void PackUnpack()
        {
            byte senderAddress = 1;
            byte destinationAddress = 2;
            int fcs = 1;
            var message = new BaseCoder().Encode("sampletext");

            Package package = new Package()
            {
                DestinationAddress = destinationAddress,
                SenderAddress = senderAddress,
                Length = (short)message.Length,
                Message = message,
                FCS = fcs
            };

            CollectionAssert.AreEqual(package.Message, package.ToByteArray().ToPackage().Message);
        }
    }
}
