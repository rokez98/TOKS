using System;
using System.Collections.Generic;
using System.Text;

namespace TOKS.SerialPortCommunicator.Models
{
    public class Package
    {
        public byte DestinationAddress { get; set; }
        public byte SenderAddress { get; set; }
        public short Length { get; set; }
        public byte[] Message { get; set; }
        public long FCS { get; set; }

        public static byte[] ToByteArray(Package package)
        {
            var bytes = new List<byte>();

            bytes.Add(package.DestinationAddress);
            bytes.Add(package.SenderAddress);

            bytes.AddRange(BitConverter.GetBytes(package.Length));

            bytes.AddRange(package.Message);

            return bytes.ToArray();
        }

        public static Package ToPackage(byte[] bytes)
        {
            var package = new Package();

            package.DestinationAddress = bytes[0];
            package.SenderAddress = bytes[1];



            return package;
        }
    }
}
