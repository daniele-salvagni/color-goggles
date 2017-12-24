using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using igfxDHLib;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ColorGoggles
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
 
        public Form1()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------------- DEFINITIONS //

        private static String webURL = "https://github.com/daniele-salvagni/color-goggles";
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private bool isGameRunning = false;
        private bool isGameForeground = false;
        private int oldStatus = -1;
        private int status = -1;

        // ---------------------------------------------------------------------- INITIALIZATION //

        private void Form1_Load(object sender, EventArgs e)
        {

            String comboText = "";
            comboText += Saturation.GetAdapterName();
            comboText += (comboText.Length > 0) ? " - " : "";
            comboText += Saturation.getMainDisplayName();
            comboBox1.Items.Add(comboText);
            comboBox1.SelectedIndex = 0;

            // Load configuration
            foreach (String game in Properties.Settings.Default.Games)
            {
                listBox1.Items.Add(game);
            }

            checkBox1.Checked = Properties.Settings.Default.Check1;
            checkBox2.Checked = Properties.Settings.Default.Check2;

            // Set autostart
            if (checkBox2.Checked)
                rkApp.SetValue("ColorGoggles", Application.ExecutablePath + " -minimized");

            if (rkApp.GetValue("ColorGoggles") == null)
                checkBox2.Checked = false;

            checkBox3.Checked = Properties.Settings.Default.Check3;


            if (checkBox1.Checked)
                toolStripMenuItem3.Text = "Disable";
            else
                toolStripMenuItem3.Text = "Enable";


            trackBar1.Value = Properties.Settings.Default.GameSat;
            label1.Text = trackBar1.Value.ToString("D2");
            trackBar2.Value = Properties.Settings.Default.WinSat;
            label2.Text = trackBar2.Value.ToString("D2");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("-minimized"))
            {
                Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        // ------------------------------------------------------------------- SATURATION LEVELS //

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Ingame Trackbar
            label1.Text = trackBar1.Value.ToString("D2");
            Properties.Settings.Default.GameSat = trackBar1.Value;
            Properties.Settings.Default.Save();

            if (isGameRunning) {
                Saturation.SetSaturation(trackBar1.Value);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            // Windows Trackbar
            label2.Text = trackBar2.Value.ToString("D2");
            Properties.Settings.Default.WinSat = trackBar2.Value;
            Properties.Settings.Default.Save();

            if (!isGameRunning) {
                Saturation.SetSaturation(trackBar2.Value);
            }
        }

        // ----------------------------------------------------------------------------- OPTIONS //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // OPTION: Enable
            if (checkBox1.Checked)
                toolStripMenuItem3.Text = "Disable";
            else
                toolStripMenuItem3.Text = "Enable";

            Saturation.SetSaturation(trackBar2.Value);
            Properties.Settings.Default.Check1 = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // OPTION: Autostart
            if (checkBox2.Checked)
                rkApp.SetValue("ColorGoggles", Application.ExecutablePath + " -minimized");
            else
                rkApp.DeleteValue("ColorGoggles", false);

            Properties.Settings.Default.Check2 = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            // OPTION: Alt+Tab
            Properties.Settings.Default.Check3 = checkBox3.Checked;
            Properties.Settings.Default.Save();
        }

        // ------------------------------------------------------------------------ PROCESS LIST //

        private void button2_Click(object sender, EventArgs e)
        {
            // Add process to list
            String game = textBox1.Text;

            if (game.Length  != 0 && !listBox1.Items.Contains(game))
            {
                listBox1.Items.Add(game);
                int gameIndex = listBox1.Items.IndexOf(game);
                listBox1.SetSelected(gameIndex, true);
                Properties.Settings.Default.Games.Add(game);
                Properties.Settings.Default.Save();
            }

            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Remove process from list
            Properties.Settings.Default.Games.Remove(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem);
            Properties.Settings.Default.Save();
        }

        // -------------------------------------------------------------------------------- TEST //

        private async void button1_Click(object sender, EventArgs e)
        {
            // TEST Button
            timer1.Stop();
            int currentSat = Saturation.GetSaturation();
            Saturation.SetSaturation(-100);
            await Task.Delay(800);
            Saturation.SetSaturation(100);
            await Task.Delay(800);
            Saturation.SetSaturation(currentSat);
            timer1.Start();
        }

        // ------------------------------------------------------------------------------- TIMER //

        private void timer1_Tick(object sender, EventArgs e)
        {
            isGameRunning = false;
            isGameForeground = false;

            if (checkBox1.Checked) { // If Enabled

                foreach (var item in listBox1.Items) {
                    Process[] processes = Process.GetProcessesByName(item.ToString().Replace(".exe", ""));
                    isGameRunning |= (processes.Length > 0) ? true : false;

                    if (processes.Length > 0)
                        isGameForeground |= processes[0].MainWindowHandle == GetForegroundWindow(); // Foreground
                }

                if (isGameRunning) {
                    status = (checkBox3.Checked || isGameForeground) ? 1 : 2; // 1 Apply : 2 Just a new status
                } else {
                    status = 3;
                }

                if (oldStatus != status) {
                    Saturation.SetSaturation((status == 1) ? trackBar1.Value : trackBar2.Value);
                    oldStatus = status;
                }

            }

        }

        // ------------------------------------------------------------------------ TASKBAR ICON //

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Show Form on double-click
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Enable - Disable
            if (toolStripMenuItem3.Text == "Disable")
            {
                checkBox1.Checked = false;
                toolStripMenuItem3.Text = "Enable";
            } else
            {
                checkBox1.Checked = true;
                toolStripMenuItem3.Text = "Disable";
            }

            Properties.Settings.Default.Check1 = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Exit
            timer1.Stop();
            Saturation.SetSaturation(trackBar2.Value);
            notifyIcon1.Dispose();
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Show
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        // -------------------------------------------------------------------------------- HELP //

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(webURL);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(webURL);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/sdlnv");
        }
    }
}
