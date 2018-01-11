using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using color_goggles.View;
using color_goggles.Model;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace color_goggles.Presenter
{
    public class GogglesPresenter {

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        // ------------------------------------------------------------------------- DEFINITIONS //

        private RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private int VERSION = 100;

        private readonly IGogglesView _view;
        private readonly IDisplay _display;

        private bool startup = true;
        private bool isGameRunning = false;
        private bool isGameForeground = false;
        private int oldStatus = -1;
        private int status = -1;

        // ------------------------------------------------------------------------- CONSTRUCTOR //

        public GogglesPresenter(IGogglesView view, IDisplay display) {
            _view = view;
            view.Presenter = this;
            _display = display;

            _view.DisplayName = _display.DeviceName;
            LoadSettings();
        }

        // ---------------------------------------------------------------------------- SETTINGS //

        public void LoadSettings() {
            _view.RemoveLimits   = Properties.Settings.Default.RemoveLimits;
            _view.WinSaturation  = Properties.Settings.Default.WinSat;
            _view.GameSaturation = Properties.Settings.Default.GameSat;
            _view.AppEnabled     = Properties.Settings.Default.Enabled;
            _view.IgnoreFocus    = Properties.Settings.Default.IgnoreFocus;
            _view.Autostart      = Properties.Settings.Default.Autostart;
            ManageAutostart();
            // Load game list
            foreach (String processName in Properties.Settings.Default.Games) {
                _view.AddGame(processName);
            }
            startup = false;
        }

        public void SaveSettings() {
            if (startup) return; // Skip events triggered while restoring settings
            Properties.Settings.Default.RemoveLimits = _view.RemoveLimits;
            Properties.Settings.Default.WinSat       = _view.WinSaturation;
            Properties.Settings.Default.GameSat      = _view.GameSaturation;
            Properties.Settings.Default.Enabled      = _view.AppEnabled;
            Properties.Settings.Default.IgnoreFocus  = _view.IgnoreFocus;
            Properties.Settings.Default.Autostart    = _view.Autostart;
            Properties.Settings.Default.Save();
            ManageAutostart();
        }

        private void ManageAutostart() {
            if (_view.Autostart)
                rkApp.SetValue("ColorGoggles", Application.ExecutablePath + " -minimized");
            else
                rkApp.DeleteValue("ColorGoggles", false);
        }

        // --------------------------------------------------------------------------- GAME LIST //

        public void AddGame(string processName) {
            if (processName.Length != 0 && !_view.GameList.Contains(processName)) {
                _view.AddGame(processName);
                Properties.Settings.Default.Games.Add(processName);
                Properties.Settings.Default.Save();
            }
        }

        public void RemoveGame(string processName) {
            if (_view.GameList.Contains(processName)) {
                _view.RemoveGame(processName);
                Properties.Settings.Default.Games.Remove(processName);
                Properties.Settings.Default.Save();
            }
        }

        // -------------------------------------------------------------------------- SATURATION //

        public void ApplySaturation() {
            _display.SetSaturation((isGameRunning && (_view.IgnoreFocus || isGameForeground))
                ? _view.GameSaturation : _view.WinSaturation);
        }

        public async void TestSaturationAsync() {
            int currentSat = _display.GetSaturation();
            _display.SetSaturation(-100);
            await Task.Delay(800);
            _display.SetSaturation(100);
            await Task.Delay(800);
            _display.SetSaturation(currentSat);
        }

        public void ExecuteDaemon() {
            isGameRunning = false;
            isGameForeground = false;

            if (_view.AppEnabled) {
                foreach (var item in _view.GameList) {
                    Process[] processes = Process.GetProcessesByName(item.Replace(".exe", "").Replace(".bin", ""));
                    isGameRunning |= (processes.Length > 0) ? true : false;
                    if (processes.Length > 0)
                        isGameForeground |= processes[0].MainWindowHandle == GetForegroundWindow(); // Foreground
                }

                if (isGameRunning) {
                    status = (_view.IgnoreFocus || isGameForeground) ? 1 : 2; // 1 Apply : 2 Just a new status
                } else {
                    status = 3;
                }

                if (oldStatus != status) {
                    ApplySaturation();
                    oldStatus = status;
                }
            }
        }

        // ------------------------------------------------------------------------ UPDATE CHECK //

        private int GetLatestVersion() {
                string baseURL = "https://api.github.com/repos/daniele-salvagni/color-goggles";
                string param = "/releases/latest";
                try {
                    HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(baseURL + param);
                    webReq.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 " + 
                        "(KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10136";
                    WebResponse webResp = webReq.GetResponse();

                    string response = new System.IO.StreamReader(webResp.GetResponseStream()).ReadToEnd();

                    // Get the tag_name version from GitHub
                    var regex = new Regex("\"tag_name\":\"(.*?)\",");
                    string match = regex.Match(response).Value;
                    // Keep only numbers, convert to int
                    return Int32.Parse(new String(match.Where(Char.IsDigit).ToArray()));

                } catch (Exception) { return 0; /* Shhh bby its ok */ }
        }

        public async void CheckUpdatesAsync() {
            int vNumber = await Task.Run(() => GetLatestVersion());
            if (VERSION < vNumber) _view.NotifyNewVersion();
        }

    }
}
