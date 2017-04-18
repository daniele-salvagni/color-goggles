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

        private static String donateUrl = "https://steamcommunity.com/tradeoffer/new/?partner=50965864&token=xjMXVe8m";
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public Form1()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(donateUrl);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString("D2");
            Properties.Settings.Default.GameSat = trackBar1.Value;
            Properties.Settings.Default.Save();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString("D2");
            Properties.Settings.Default.WinSat = trackBar2.Value;
            Properties.Settings.Default.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                rkApp.SetValue("ColorGoggles", Application.ExecutablePath + " -minimized");
            else
                rkApp.DeleteValue("ColorGoggles", false);

            Properties.Settings.Default.Check2 = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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

        private async void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            int currentSat = Saturation.GetSaturation();
            Saturation.SetSaturation(-100);
            await Task.Delay(800);
            Saturation.SetSaturation(100);
            await Task.Delay(800);
            Saturation.SetSaturation(currentSat);
            timer1.Start();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                toolStripMenuItem3.Text = "Disable";
            else
                toolStripMenuItem3.Text = "Enable";

            Saturation.SetSaturation(trackBar2.Value);
            Properties.Settings.Default.Check1 = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }


        bool isGameRunning = false;
        bool isGameForeground = false;
        int oldStatus = -1;
        int status = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {

            isGameRunning = false;
            isGameForeground = false;

            if (checkBox1.Checked) { 

                


                foreach (var item in listBox1.Items)
                {
                    Process[] processes = Process.GetProcessesByName(item.ToString().Replace(".exe", ""));
                    isGameRunning |= (processes.Length > 0) ? true : false;

                    if (processes.Length > 0)
                        isGameForeground |= processes[0].MainWindowHandle == GetForegroundWindow();
                }


                if (isGameRunning)
                {
                    if (checkBox3.Checked || isGameForeground)
                        status = 1;
                    else
                        status = 2;
                }
                else
                {
                    status = 3;
                }



                if (oldStatus != status) {
                    if (status == 1)
                        Saturation.SetSaturation(trackBar1.Value);
                    else
                        Saturation.SetSaturation(trackBar2.Value);

                    oldStatus = status;
                }



            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            String comboText = "";
            comboText += Saturation.GetAdapterName();
            comboText += (comboText.Length > 0) ? " - " : "";
            comboText += Saturation.getMainDisplayName();
            comboBox1.Items.Add(comboText);
            comboBox1.SelectedIndex = 0;

            foreach (String game in Properties.Settings.Default.Games)
            {
                listBox1.Items.Add(game);
            }

            checkBox1.Checked = Properties.Settings.Default.Check1;
            checkBox2.Checked = Properties.Settings.Default.Check2;

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

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Check3 = checkBox3.Checked;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Games.Remove(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem);
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
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
            timer1.Stop();
            Saturation.SetSaturation(trackBar2.Value);
            notifyIcon1.Dispose();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(donateUrl);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Contains("-minimized"))
            {
                Hide();
            }
        }
    }
}
