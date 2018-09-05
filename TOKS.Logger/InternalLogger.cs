using log4net;

namespace TOKS.Logger
{
    /// <summary>
    /// log4net wrapper
    /// </summary>
    public static class InternalLogger
    {
        public static ILog Log => LogManager.GetLogger(typeof(InternalLogger));
    }
}