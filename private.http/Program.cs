using System;
using System.Windows.Forms;

namespace @private.http
{
    static internal class Program
    {
        internal static HttpItem.HttpItemApplication CurrentApplication = new HttpItem.HttpItemApplication() { Name = "root", VirtualPath = "/" };
        internal static string CurrentAppFileName = "";


        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

    }



}