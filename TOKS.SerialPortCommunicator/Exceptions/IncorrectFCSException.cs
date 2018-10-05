using System;

namespace TOKS.SerialPortCommunicator.Exceptions
{
    public class IncorrectFCSException : Exception
    {
        public IncorrectFCSException(string message) : base(message)
        {
        }
    }
}
