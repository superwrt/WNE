/*
 * Copyright SuperWRT.com Terra Yang <terra@superwrt.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Windows.Forms;
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
            StartWithWindows();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
