using System;
using System.Collections.Generic;
using System.Linq;
using TOKS.SerialPortCommunicator.Models;
using static TOKS.SerialPortCommunicator.Models.Package;

namespace TOKS.SerialPortCommunicator.Extensions
{
    public static class PackageExtensions
    {
        public static byte ToByte(this AccessControlByte package)
        {
            byte acByte = 0;

            acByte = (byte)(acByte | package.ReservationBits);
            if (package.TokenBit) acByte = (byte)(acByte | 0b00010000);
            if (package.MonitorBit) acByte = (byte)(acByte | 0b00001000);
            acByte = (byte)(acByte | (package.PriorityBits << 5));

            return acByte;
        }

        public static AccessControlByte ToAccessControl(this byte acByte)
        {
            var accessControl = new AccessControlByte();

            accessControl.PriorityBits = (byte)((acByte & 0b11100000) >> 5);
            accessControl.TokenBit = (acByte & 0b00010000) > 0;
            accessControl.MonitorBit = (acByte & 0b00001000) > 0;
            accessControl.ReservationBits = (byte)(acByte & 0b00000111);

            return accessControl;
        }


        public static byte ToByte(this FrameControlByte package)
        {
            byte acByte = 0;

            if (package.AddressRecognized) acByte = (byte)(acByte | 0b10001000);
            if (package.FrameCopied) acByte = (byte)(acByte | 0b01000100);

            return acByte;
        }

        public static FrameControlByte ToFrameControl(this byte acByte)
        {
            var frameControl = new FrameControlByte();

            frameControl.AddressRecognized = (acByte & 0b10001000) > 0;
            frameControl.FrameCopied = (acByte & 0b01001000) > 0;

            return frameControl;
        }

        public static byte[] ToBytes(this DataBlock package)
        {
            var bytes = new List<byte>();

            bytes.Add(package.DestinationAddress);
            bytes.Add(package.SenderAddress);

            bytes.AddRange(BitConverter.GetBytes(package.Length));
            bytes.AddRange(package.Message);
            bytes.AddRange(BitConverter.GetBytes(package.FCS));

            return bytes.ToArray();
        }

        public static DataBlock ToDataBlock(this byte[] bytes)
        {
            var package = new DataBlock();

            package.DestinationAddress = bytes[0];
            package.SenderAddress = bytes[1];
            package.Length = BitConverter.ToInt16(bytes, 2);
            package.Message = bytes.Skip(4).Take(package.Length).ToArray();
            package.FCS = BitConverter.ToInt32(bytes.Skip(Math.Max(0, bytes.Count() - 4)).ToArray(), 0);

            return package;
        }


        public static byte[] ToByteArray(this Package package)
        {
            var bytes = new List<byte>();

            bytes.Add(package.AccessControl.ToByte());

            if (package.AccessControl.TokenBit == false)
            {
                bytes.Add(package.FrameControl.ToByte());
                bytes.AddRange(package.Data.ToBytes());
            }

            return bytes.ToArray();
        }

        public static Package ToPackage(this byte[] bytes)
        {
            var package = new Package();

            package.AccessControl = bytes[0].ToAccessControl();
            if (package.AccessControl.TokenBit == false)
            {
                package.FrameControl = bytes[1].ToFrameControl();
                package.Data = bytes.Skip(2).ToArray().ToDataBlock();
            }

            return package;
        }
    }
}
