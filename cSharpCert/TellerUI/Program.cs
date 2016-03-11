using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EffinghamLibrary;
using SimpleInjector;

namespace TellerUI
{
    static class Program
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            container = new Container();
            container.RegisterSingleton<IVault>(EFVault.Instance);
            container.Register<MainForm>();

            Application.Run(container.GetInstance<MainForm>());
        }
    }
}
