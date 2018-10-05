using System;
using System.Collections.Generic;
using System.Linq;
using TOKS.SerialPortCommunicator.Models;

namespace TOKS.SerialPortCommunicator.Extensions
{
    public static class PackageExtensions
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
            package.FCS = BitConverter.ToInt32(bytes.Skip(Math.Max(0, bytes.Count() - 4)).ToArray(), 0);

            return package;
        }
    }
}
