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
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

using wne.Config;

namespace wne.UI
{
    public partial class ConfigEnv : Form
    {
        public Main mainForm;
        public Ini Settings;

        private PhpConfig phpConfig = new PhpConfig();
        private Dictionary<string, string> nginxConfig;
        private string currNginxConfName = "";

        public ConfigEnv()
        {
            InitializeComponent();
        }
    
        private Dictionary<string, string> DirFileRead(string path, string GetFiles)
        {
            var ctxs = new Dictionary<string, string>();
            var dinfo = new DirectoryInfo(Main.StartupPath + path);

            if (!dinfo.Exists)
                return ctxs;

            var files = dinfo.GetFiles(GetFiles);
            foreach (var file in files)
            {
                ctxs.Add(file.Name, File.ReadAllText(file.FullName));
            }
            return ctxs;
        }

        private void DirFileSync(string path, string GetFiles, Dictionary<string, string> ctxs)
        {
            var dinfo = new DirectoryInfo(Main.StartupPath + path);

            if (!dinfo.Exists)
                return;

            var files = dinfo.GetFiles(GetFiles);
            foreach (var file in files)
            {
                if (!ctxs.ContainsKey(file.Name))
                {
                    File.Delete(file.Name);
                }
            }

            foreach (var ctx in ctxs)
            {
                File.WriteAllText(ctx.Key, ctx.Value);
            }
        }

        private void UpdateOptions()
        {
            checkBoxUseScript.Checked = Settings.UseServiceScript.Value;
            checkBoxUsePHP.Checked = Settings.UseServicePhp.Value;
            checkBoxUseNginx.Checked = Settings.UseServiceNginx.Value;
            checkBoxUseMariaDb.Checked = Settings.UseServiceMariaDb.Value;
            checkBoxUseMongoDb.Checked = Settings.UseServiceMongoDb.Value;
            checkBoxUseRedis.Checked = Settings.UseServiceRedis.Value;

            textBoxMariaDbBind.Text = Settings.MariaDbBind.Value;
            numericUpDownMariaDbPort.Value = Settings.MariaDbPort.Value;
            comboBoxMariaDbDefCharset.Text = Settings.MariaDbCharset.Value;

            textBoxMongoDbBind.Text = Settings.MongoDbBind.Value;
            numericUpDownMongoDbPort.Value = Settings.MongoDbPort.Value;

            textBoxRedisBind.Text = Settings.RedisBind.Value;
            numericUpDownRedisPort.Value = Settings.RedisPort.Value;
            comboBoxRedisLogLevel.Text = Settings.RedisLogLevel.Value;
        }

        private void SaveOptions()
        {
            Settings.UseServiceScript.Value = checkBoxUseScript.Checked;
            Settings.UseServicePhp.Value = checkBoxUsePHP.Checked;
            Settings.UseServiceNginx.Value = checkBoxUseNginx.Checked;
            Settings.UseServiceMariaDb.Value = checkBoxUseMariaDb.Checked;
            Settings.UseServiceMongoDb.Value = checkBoxUseMongoDb.Checked;
            Settings.UseServiceRedis.Value = checkBoxUseRedis.Checked;

            Settings.PhpVersionDir.Value = comboBoxPhpVersion.Text;
            Settings.PhpPort.Value = (ushort)numericUpDownPhpPort.Value;
            Settings.PhpProcesses.Value = (ushort)numericUpDownPhpProces.Value;

            Settings.MariaDbBind.Value = textBoxMariaDbBind.Text;
            Settings.MariaDbPort.Value = (ushort)numericUpDownMariaDbPort.Value;
            Settings.MariaDbCharset.Value = comboBoxMariaDbDefCharset.Text;

            Settings.MongoDbBind.Value = textBoxMongoDbBind.Text;
            Settings.MongoDbPort.Value = (ushort)numericUpDownMongoDbPort.Value;

            Settings.RedisBind.Value = textBoxRedisBind.Text;
            Settings.RedisPort.Value = (ushort)numericUpDownRedisPort.Value;
            Settings.RedisLogLevel.Value = comboBoxRedisLogLevel.Text;
        }

        private void SaveSettings()
        {
            SavePHPExtOptions();

            SaveOptions();
            SaveEnvironment();
            Settings.UpdateSettings();
        }

        private void ConfigEnv_Load(object sender, EventArgs e)
        {
            UpdateEnvironment();
            UpdateNginxConfig();
            UpdatePhpOptions();
            UpdateOptions();
        }

        private void EditFile(string path)
        {
            try
            {
                Process.Start(Settings.Editor.Value, Main.StartupPath + path);
            }
            catch (Exception ex)
            {
                Main.Error(ex.Message, "Config");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /* For script */

        private void buttonOtherServStartEdit_Click(object sender, EventArgs e)
        {
            EditFile("/conf/others/start.bat");
        }

        private void buttonOtherServStopEdit_Click(object sender, EventArgs e)
        {
            EditFile("/conf/others/stop.bat");
        }

        /* For env */

        private void UpdateEnvironment()
        {
            listViewEnvValues.Items.Clear();
            foreach (var env in Settings.EnverionmentValues)
            {
                ListViewItem li = new ListViewItem(env.Key);
                li.SubItems.Add(env.Value);
                listViewEnvValues.Items.Add(li);
            }
        }

        private void SaveEnvironment()
        {
            var envs = new Dictionary<string, string>();
            foreach (ListViewItem it in listViewEnvValues.Items)
            {
                if (it.SubItems[0].Text.Length == 0 || envs.ContainsKey(it.SubItems[0].Text))
                {
                    continue;
                }
                envs.Add(it.SubItems[0].Text, it.SubItems[1].Text);
            }
            Settings.EnverionmentValues = envs;
        }

        private void ChangeEnvrionment(int idx)
        {
            ListViewItem item;
            if (idx >= 0)
            {
                item = listViewEnvValues.Items[idx];
            }
            else
            {
                item = new ListViewItem("");
                item.SubItems.Add("");
            }

            var form = new EditNameValue
            {
                name = item.SubItems[0].Text,
                value = item.SubItems[1].Text
            };

            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
            form.Focus();

            if (form.name.Length == 0 || !form.ifSave())
            {
                return;
            }

            item.SubItems[0].Text = form.name;
            item.SubItems[1].Text = form.value;

            if (idx < 0)
            {
                listViewEnvValues.Items.Add(item);
            }
        }

        private void buttonEnvValAdd_Click(object sender, EventArgs e)
        {
            ChangeEnvrionment(-1);
        }

        private void buttonEnvValEdit_Click(object sender, EventArgs e)
        {
            if (listViewEnvValues.SelectedIndices.Count <= 0)
            {
                return;
            }
            ChangeEnvrionment(listViewEnvValues.SelectedIndices[0]);
        }

        private void buttonEnvValDel_Click(object sender, EventArgs e)
        {
            if (listViewEnvValues.SelectedIndices.Count <= 0)
            {
                return;
            }
            listViewEnvValues.Items.RemoveAt(listViewEnvValues.SelectedIndices[0]);
        }

        /* For PHP */

        private string[] PhpVersions()
        {
            if (Directory.Exists(Main.StartupPath + "/php") == false)
                return new string[0];
            return Directory.GetDirectories(Main.StartupPath + "/php").Select(d => new DirectoryInfo(d).Name).ToArray();
        }

        private void UpdatePhpOptions()
        {
            foreach (var str in PhpVersions())
            {
                comboBoxPhpVersion.Items.Add(str);
            }
            comboBoxPhpVersion.SelectedIndex = comboBoxPhpVersion.Items.IndexOf(Settings.PhpVersionDir.Value);
        }

        private void SavePHPExtOptions()
        {
            for (var i = 0; i < checkedListBoxPhpExts.Items.Count; i++)
            {
                phpConfig.UserPHPExtentionValues[i] = checkedListBoxPhpExts.GetItemChecked(i);
            }
            phpConfig.PHPExtensionDir = Main.StartupPath + "/php/" + comboBoxPhpVersion.Text + "/ext";
            phpConfig.SaveIniOptions();
        }

        private void LoadPhpExtsConfig()
        {
            checkedListBoxPhpExts.Items.Clear();
            phpConfig.LoadExtensions(Main.StartupPath + "/php/" + comboBoxPhpVersion.Text, Main.StartupPath + "/conf/php");

            for (var i = 0; i < phpConfig.phpExtName.Length; i++)
            {
                checkedListBoxPhpExts.Items.Add(phpConfig.phpExtName[i],
                    phpConfig.PHPExtensions[i].HasFlag(PhpConfig.PHPExtension.Enabled));
            }
        }

        private void CopyPhpDefaultConfig(string type)
        {
            if (type.Length > 0)
            {
                File.Copy(Main.StartupPath + "/php/" + comboBoxPhpVersion.Text + "/php.ini-" + type,
                    Main.StartupPath + "/conf/php/php.ini", true);
                LoadPhpExtsConfig();
            }
        }


        private void comboBoxPhpVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhpExtsConfig();
        }

        private void buttonPhpDefConfPro_Click(object sender, EventArgs e)
        {
            CopyPhpDefaultConfig("development");
        }

        private void buttonPhpDefConfDev_Click(object sender, EventArgs e)
        {
            CopyPhpDefaultConfig("production");
        }


        /* For Nginx */
        private void UpdateNginxConfig()
        {
            nginxConfig = DirFileRead("/conf/nginx/sites", "*.conf");
            foreach (var conf in nginxConfig)
            {
                var name = conf.Key.Substring(0, conf.Key.LastIndexOf("."));
                comboBoxNginxSite.Items.Add(name);
            }
        }

        private void comboBoxNginxSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNginxSite_TextUpdate(sender, e);
        }

        private void buttonNginxSiteAdd_Click(object sender, EventArgs e)
        {
            var name = comboBoxNginxSite.Text;
            var confName = name + ".conf";
            if (confName.Length <= 5 ||
                nginxConfig.ContainsKey(confName))
            {
                return;
            }
            nginxConfig.Add(confName, "");
            comboBoxNginxSite.Items.Add(name);
            comboBoxNginxSite_TextUpdate(sender, e);
        }

        private void buttonNginxSiteDel_Click(object sender, EventArgs e)
        {
            var name = comboBoxNginxSite.Text;
            var confName = name + ".conf";
            if (nginxConfig.ContainsKey(confName))
            {
                nginxConfig.Remove(confName);
                comboBoxNginxSite.Items.Remove(name);
            }
            comboBoxNginxSite.Text = "";
            comboBoxNginxSite_TextUpdate(sender, e);
        }

        private void comboBoxNginxSite_TextUpdate(object sender, EventArgs e)
        {
            string name = comboBoxNginxSite.Text + ".conf";
            if (currNginxConfName.Length > 5)
            {
                nginxConfig[currNginxConfName] = textBoxNginxSiteConf.Text;
            }
            if (nginxConfig.ContainsKey(name))
            {
                textBoxNginxSiteConf.Text = nginxConfig[name];
                textBoxNginxSiteConf.Enabled = true;
                currNginxConfName = name;
            }
            else
            {
                textBoxNginxSiteConf.Text = "";
                textBoxNginxSiteConf.Enabled = false;
                currNginxConfName = "";
            }
        }

    }
}
