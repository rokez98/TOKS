using System.Text;
using TOKS.SerialPortCommunicator.Interfaces;

namespace TOKS.SerialPortCommunicator.Core
{
    public class BaseCoder : IMessageCoder
    {
        protected IMessageCoder _coder;

        public BaseCoder()
        {
        }

        public BaseCoder(IMessageCoder coder) => _coder = coder;

        public virtual string Decode(byte[] message) => Encoding.Default.GetString(message);

        public virtual byte[] Encode(string message) => Encoding.Default.GetBytes(message);
    }
}
