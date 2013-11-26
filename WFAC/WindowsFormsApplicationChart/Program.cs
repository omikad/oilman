using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApplicationChart
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
	        AppDomain.CurrentDomain.UnhandledException += (sender, args) => OnException(args.ExceptionObject);
	        Application.ThreadException += (sender, args) => OnException(args.Exception);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

	        var container = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));

			container.ComposeExportedValue<Func<Cut>>(container.GetExportedValue<Cut>);

	        var mainForm = container.GetExportedValue<MainForm>();

			Application.Run(mainForm);
        }

	    private static DialogResult OnException(object exception)
	    {
		    return MessageBox.Show(exception == null ? "null" : exception.ToString());
	    }
    }
}
