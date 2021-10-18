using bntu.vsrpp.vmilyuk.Core;
using bntu.vsrpp.vmilyuk.lab1.Process;
using System;
using System.Windows.Forms;

namespace bntu.vsrpp.vmilyuk.lab1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XMLReader reader = new XMLReader();
            XMLEditor editor = new XMLEditor(reader);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainWindowProcess = new MainWindowProcess(reader, editor);
            Application.Run(mainWindowProcess.Start());
        }
    }
}
