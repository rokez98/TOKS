using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOKS.SerialPortCommunicator.Models
{
    public class Package
    {
        public byte DestinationAddress { get; set; }
        public byte SenderAddress { get; set; }
        public short Length { get; set; }
        public byte[] Message { get; set; }
        public int FCS { get; set; }
    }

    public static class Extensions
    {
        public static byte[] ToByteArray(this Package package)
        {
            var bytes = new List<byte>();

            bytes.Add(package.DestinationAddress);
            bytes.Add(package.SenderAddress);

            bytes.AddRange(BitConverter.GetBytes(package.Length));

            bytes.AddRange(package.Message);

            bytes.AddRange(BitConverter.GetBytes(package.FCS));

            return bytes.ToArray();
        }

        public static Package ToPackage(this byte[] bytes)
        {
            var package = new Package();

            package.DestinationAddress = bytes[0];
            package.SenderAddress = bytes[1];
            package.Length = BitConverter.ToInt16(bytes, 2);
            package.Message = bytes.Skip(4).Take(package.Length).ToArray();
            package.FCS = BitConverter.ToInt32(bytes, 4 + package.Length);

            return package;
        }
    }
}
