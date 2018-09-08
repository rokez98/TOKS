using System.Text;
using TOKS.SerialPortCommunicator.Interfaces;

namespace TOKS.SerialPortCommunicator.Core
{
    public class BaseCoder : IMessageCoder
    {
        protected IMessageCoder _coder;

        public BaseCoder() { }
        public BaseCoder(IMessageCoder coder) => _coder = coder;

        public virtual string Decode(byte[] message) => Encoding.UTF8.GetString(message);

        public virtual byte[] Encode(string message) => Encoding.UTF8.GetBytes(message);

        public byte[] Encode(byte[] message) => message;
    }
}
