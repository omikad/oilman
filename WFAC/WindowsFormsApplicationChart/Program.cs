using System;
using System.Windows.Forms;

namespace WindowsFormsApplicationChart
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
	        AppDomain.CurrentDomain.UnhandledException +=
				(sender, args) => MessageBox.Show(args.ExceptionObject == null ? "null" : args.ExceptionObject.ToString());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
