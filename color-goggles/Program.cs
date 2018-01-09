using color_goggles.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace color_goggles
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // DPI Fix
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();

            // Allow only one instance
            String thisprocessname = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                return;

            // Check for igfxDHLib
            string dllPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "igfxDHLib.dll");
            if (!System.IO.File.Exists(dllPath)) {
                MessageBox.Show("Library `igfxDHLib.dll` not found. Please follow installation instructions in README.txt",
                    "Library not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialization
            var display = new Model.Display(IgfxDH.DataHandler.BrandInfo.wcBrandName + " - "
                + IgfxDH.DataHandler.BrandInfo.wcAdapterName);
            var view = new GogglesForm();
            var presenter = new Presenter.GogglesPresenter(view, display);
            Application.Run(view);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

    }
}
