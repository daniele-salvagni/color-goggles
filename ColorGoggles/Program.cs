using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorGoggles
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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
            if (!System.IO.File.Exists("igfxDHLib.dll")) {
                MessageBox.Show("Library `igfxDHLib.dll` not found. Please follow installation instructions in README.txt",
                    "Library not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

    }
}
