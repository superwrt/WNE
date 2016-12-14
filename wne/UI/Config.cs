using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using wne.Config;
using Microsoft.Win32;

namespace wne.UI
{
    public partial class Config : Form
    {
        public Main mainForm;
        public Ini Settings;

        public Config()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the options with there saved values
        /// </summary>
        private void LoadSettings()
        {
            checkBoxStartWithWin.Checked = Settings.StartWithWindows.Value;
            checkBoxAutoUpdate.Checked = Settings.AutoCheckForUpdates.Value;
        }

        private void SetSettings()
        {
            Settings.StartWithWindows.Value = checkBoxStartWithWin.Checked;
            Settings.AutoCheckForUpdates.Value = checkBoxAutoUpdate.Checked;
        }

        private void SaveHttpConfig()
        {
        }

        private void StartWithWindows()
        {
            var root = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (root == null)
                return;
            if (checkBoxStartWithWin.Checked)
            {
                if (root.GetValue("Wne") == null)
                    root.SetValue("Wne", "\"" + Application.ExecutablePath + "\" /start");
            }
            else
            {
                if (root.GetValue("Wne") != null)
                    root.DeleteValue("Wne");
            }
        }

        private void Config_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        /// <summary>
        /// Takes a form and displays it
        /// </summary>
        private void ShowForm(Form form)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            form.Focus();
        }

        private void buttonConfigEnv_Click(object sender, EventArgs e)
        {
            var form = new ConfigEnv {
                mainForm = mainForm,
                Settings = Settings
            };
            ShowForm(form);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveHttpConfig();

            SetSettings();
            Settings.UpdateSettings();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
