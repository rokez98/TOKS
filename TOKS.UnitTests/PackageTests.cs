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
        public void PackUnpack()
        {
            byte senderAddress = 1;
            byte destinationAddress = 2;
            int fcs = 1;
            var message = new BaseCoder().Encode("sampletext");

            Package package = new Package()
            {
                AccessControl = new Package.AccessControlByte()
                {
                    PriorityBits = 1,
                    TokenBit = false,
                    MonitorBit = false,
                    ReservationBits = 2
                },
                FrameControl = new Package.FrameControlByte()
                {
                    AddressRecognized = false,
                    FrameCopied = true
                },
                Data = new Package.DataBlock()
                {
                    DestinationAddress = destinationAddress,
                    SenderAddress = senderAddress,
                    Length = (short)message.Length,
                    Message = message,
                    FCS = fcs
                }
            };

            var result = package.ToByteArray().ToPackage();

            Assert.AreEqual(result.AccessControl.PriorityBits, 1);
            Assert.AreEqual(result.AccessControl.TokenBit, false);
            Assert.AreEqual(result.AccessControl.MonitorBit, false);
            Assert.AreEqual(result.AccessControl.ReservationBits, 2);

            Assert.AreEqual(result.FrameControl.AddressRecognized, false);
            Assert.AreEqual(result.FrameControl.FrameCopied, true);

            CollectionAssert.AreEqual(package.Data.Message, result.Data.Message);
        }

        [TestMethod]
        public void AccessControlPackUnpack()
        {
            Package.AccessControlByte accessControl = new Package.AccessControlByte()
            {
                PriorityBits = 1,
                TokenBit = true,
                MonitorBit = false,
                ReservationBits = 2
            };

            var result = accessControl.ToByte().ToAccessControl();

            Assert.AreEqual(result.PriorityBits, 1);
            Assert.AreEqual(result.TokenBit, true);
            Assert.AreEqual(result.MonitorBit, false);
            Assert.AreEqual(result.ReservationBits, 2);
        }
    }
}
