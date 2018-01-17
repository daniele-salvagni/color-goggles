using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using color_goggles.View;

namespace color_goggles
{
    public partial class GogglesForm : Form, IGogglesView
    {
        public GogglesForm() {
            InitializeComponent();
        }

        // --------------------------------------------------------- IGogglesView IMPLEMENTATION //

        public Presenter.GogglesPresenter Presenter {
            private get;
            set;
        }

        public int WinSaturation {
            get { return this.windowsBar.Value; }
            set { this.windowsBar.Value = value; }
        }

        public int GameSaturation {
            get { return this.ingameBar.Value; }
            set { this.ingameBar.Value = value; }
        }

        public bool AppEnabled {
            get { return this.checkEnable.Checked; }
            set { this.checkEnable.Checked = value; }
        }

        public bool Autostart {
            get { return this.checkAutostart.Checked; }
            set { this.checkAutostart.Checked = value; }
        }

        public bool IgnoreFocus {
            get { return this.checkIgnoreFocus.Checked; }
            set { this.checkIgnoreFocus.Checked = value; }
        }

        public bool RemoveLimits {
            get { return this.checkRemoveLimits.Checked; }
            set { this.checkRemoveLimits.Checked = value; }
        }

        public IList<string> GameList {
            get { return this.processList.Items.OfType<string>().ToList(); }
        }

        public void AddGame(string processName) {
            this.processList.Items.Add(processName);
        }

        public void RemoveGame(string processName) {
            this.processList.Items.RemoveAt(processList.FindStringExact(processName));
        }

        public String DisplayName {
            set { this.displayList.Items.Add(value); this.displayList.SelectedIndex = 0; }
        }

        public void NotifyNewVersion() {
            this.updateLbl.Show();
        }

        // ---------------------------------------------------------------------------- SETTINGS //

        private void checkEnable_CheckedChanged(object sender, EventArgs e) {
            disableToolStripMenuItem.Text = (checkEnable.Checked) ? "Disable" : "Enable";
            Presenter.SaveSettings();
        }

        private void checkAutostart_CheckedChanged(object sender, EventArgs e) {
            Presenter.SaveSettings();
        }

        private void checkIgnoreFocus_CheckedChanged(object sender, EventArgs e) {
            Presenter.SaveSettings();
        }

        private void checkRemoveLimits_CheckedChanged(object sender, EventArgs e) {
            ingameBar.Maximum = (checkRemoveLimits.Checked) ? 320 : 100;
            ingameBar.TickFrequency = (checkRemoveLimits.Checked) ? 21 : 10;
            windowsBar.Maximum = (checkRemoveLimits.Checked) ? 320 : 100;
            windowsBar.TickFrequency = (checkRemoveLimits.Checked) ? 21 : 10;

            ingameLbl.Text = ingameBar.Value.ToString();
            windowsLbl.Text = windowsBar.Value.ToString();

            Presenter.SaveSettings();
        }

        // ------------------------------------------------------------------- SATURATION LEVELS //

        private void ingameBar_ValueChanged(object sender, EventArgs e) {
            ingameLbl.Text = ingameBar.Value.ToString();
            Presenter.SaveSettings();
            Presenter.ApplySaturation();
        }

        private void windowsBar_ValueChanged(object sender, EventArgs e) {
            windowsLbl.Text = windowsBar.Value.ToString();
            Presenter.SaveSettings();
            Presenter.ApplySaturation();
        }

        // --------------------------------------------------------------------------- GAME LIST //

        private void addBtn_Click(object sender, EventArgs e) {
            Presenter.AddGame(processBox.Text);
            processList.SetSelected(processList.Items.Count - 1, true);
            processBox.Clear();
        }

        private void remBtn_Click(object sender, EventArgs e) {
            if (processList.SelectedIndex != -1)
                Presenter.RemoveGame(processList.SelectedItem.ToString());
        }

        // ------------------------------------------------------------------------------ DAEMON //

        private void daemon_Tick(object sender, EventArgs e) {
            Presenter.ExecuteDaemon();
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            daemon.Stop();
            Presenter.TestSaturationAsync();
            daemon.Start();
        }

        // ------------------------------------------------------------------------------- OTHER //

        private void GogglesForm_Load(object sender, EventArgs e) {
            updateLbl.Hide();
            Presenter.CheckUpdatesAsync();
        }

         private void GogglesForm_Shown(object sender, EventArgs e) {
            disableToolStripMenuItem.Text = (checkEnable.Checked) ? "Disable" : "Enable";
            string[] args = Environment.GetCommandLineArgs();
            // Minimized on Autostart
            if (args.Contains("-minimized")) {
                Hide();
            }
        }

        private void GogglesForm_FormClosing(object sender, FormClosingEventArgs e) {
            // Minimize instead of closing
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }

        // ------------------------------------------------------------------------------- LINKS //

        private void githubLbl_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/daniele-salvagni/color-goggles");
        }

        private void twiterLbl_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://twitter.com/sdlnv");
        }

        private void logoBox_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://dan.salvagni.io/s/color-goggles/");
        }

        // --------------------------------------------------------------------------- TOOLSTRIP //

        private void disableToolStripMenuItem_Click(object sender, EventArgs e) {
            if (disableToolStripMenuItem.Text == "Disable") {
                checkEnable.Checked = false;
                disableToolStripMenuItem.Text = "Enable";
            } else {
                checkEnable.Checked = true;
                disableToolStripMenuItem.Text = "Disable";
            }
        }

        private void updateLbl_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/daniele-salvagni/color-goggles/releases");
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e) {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }
        
        private void notifyIcon_DoubleClick(object sender, EventArgs e) {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("http://dan.salvagni.io/s/color-goggles/");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            daemon.Stop();
            notifyIcon.Dispose();
            Application.Exit();
        }

    }
}
