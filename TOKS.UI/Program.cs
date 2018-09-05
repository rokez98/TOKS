using System;
using System.Windows.Forms;
using TOKS.Logger;

namespace TOKS.UI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            InternalLogger.Log.Info("Application was started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
            InternalLogger.Log.Info("Application was finished");
        }
    }
}
