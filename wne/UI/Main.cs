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
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

using wne.Config;
using wne.Services;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace wne.UI
{
    public partial class Main : Form
    {
        public static string StartupPath { get { return Application.StartupPath; } }
        private static RichTextBox rtfLog;
        bool autoStart;
        bool servsRunning;

        public Ini Settings = new Ini();

        private PhpService phpServ = new PhpService();
        private NginxService nginxServ = new NginxService();
        private MariaDbService mariaServ = new MariaDbService();
        private MongoDbService mongoServ = new MongoDbService();
        private RedisService redisServ = new RedisService();
        private ScriptService scriptServ = new ScriptService();

        public Main(bool start)
        {
            InitializeComponent();
            autoStart = start;
            rtfLog = richTextBoxLog;
        }

        private void InitServices()
        {
            phpServ.Setup(Settings);
            nginxServ.Setup(Settings);
            mariaServ.Setup(Settings);
            mongoServ.Setup(Settings);
            redisServ.Setup(Settings);
            scriptServ.Setup(Settings);
        }

        //http://blogs.msdn.com/b/oldnewthing/archive/2012/06/14/10319617.aspx
        //http://bartdesmet.net/blogs/bart/archive/2006/10/25/Windows-Vista-_2D00_-ShutdownBlockReasonCreate-in-C_2300_.aspx
        [DllImport("user32.dll")]
        public extern static bool ShutdownBlockReasonCreate(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string pwszReason);

        [DllImport("user32.dll")]
        public extern static bool ShutdownBlockReasonDestroy(IntPtr hWnd);

        private void StartServices()
        {
            buttonStartStop.Enabled = false;

            ShutdownBlockReasonCreate(this.Handle, "Services are running");

            if (Settings.UseServicePhp.Value)
                phpServ.Start();
            if (Settings.UseServiceMariaDb.Value)
                mariaServ.Start();
            if (Settings.UseServiceMongoDb.Value)
                mongoServ.Start();
            if (Settings.UseServiceRedis.Value)
                redisServ.Start();
            if (Settings.UseServiceNginx.Value)
                nginxServ.Start();
            if (Settings.UseServiceScript.Value)
                scriptServ.Start();

            servsRunning = true;
            buttonStartStop.Text = "Stop";

            buttonStartStop.Enabled = true;
        }

        private void StopServices()
        {
            buttonStartStop.Enabled = false;

            scriptServ.Stop();
            nginxServ.Stop();
            redisServ.Stop();
            mongoServ.Stop();
            mariaServ.Stop();
            phpServ.Stop();

            ShutdownBlockReasonDestroy(this.Handle);

            servsRunning = false;
            buttonStartStop.Text = "Start";

            buttonStartStop.Enabled = true;
        }

        private void RestartServices()
        {
            StopServices();
            StartServices();
        }

        private void HideMainForm()
        {
            this.Hide();
            this.ShowInTaskbar = false;
            this.notifyIconCtrl.Visible = true;
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideMainForm();
            }
        }

        private void notifyIconCtrl_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        void OnProgramStarted(object state, bool timeout)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
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

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (servsRunning)
                StopServices();
            else
                StartServices();
        }

        private void CheckEnverionment()
        {
            Settings.ReadSettings();

            if (File.Exists(StartupPath + "/CertGen.exe") &&
                !File.Exists(StartupPath + "/conf/keys/cert.pem"))
            {
                using (var ps = new Process())
                {
                    ps.StartInfo.FileName = StartupPath + "/CertGen.exe";
                    ps.StartInfo.WorkingDirectory = StartupPath + "/conf/keys/";
                    ps.StartInfo.Arguments = "y";
                    ps.StartInfo.UseShellExecute = false;
                    ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.StartInfo.CreateNoWindow = true;
                    ps.Start();
                }
            }
            if (Settings.WnePath.Value != StartupPath)
            {
                Settings.WnePath.Value = StartupPath;
                Settings.UpdateSettings();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;//FIXME
            ThreadPool.RegisterWaitForSingleObject(Program.ProgramStarted, OnProgramStarted, null, -1, false);
            CheckEnverionment();
            InitServices();
            try
            {
                pictureBoxLogo.Image = Image.FromFile("mainlogo.png");
            } catch(Exception ex) {
            }
            if (autoStart) {
                StartServices();
                HideMainForm();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (servsRunning)
                StopServices();
            notifyIconCtrl.Visible = false;
        }

        private static void printLog(string message, Color color, string sectionName)
        {
            var DateNow = DateTime.Now.ToString();
            var str = $"{DateNow} [{sectionName}] - {message}";
            var textLength = rtfLog.TextLength;
            rtfLog.AppendText(str + "\n");
            if (rtfLog.Find(sectionName, textLength, RichTextBoxFinds.MatchCase) != -1)
            {
                rtfLog.SelectionLength = sectionName.Length;
                rtfLog.SelectionColor = color;
            }

            rtfLog.ScrollToCaret();
            rtfLog.SelectionStart = rtfLog.TextLength;
        }

        public static void Error(string message, string sectionName)
        {
            printLog(message, Color.Red, sectionName);
        }

        public static void Notice(string message, string sectionName)
        {
            printLog(message, Color.DarkBlue, sectionName);
        }
    
        // Main menu functions
        private void editConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Config
            {
                mainForm = this,
                Settings = Settings
            };
            ShowForm(form);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutfrm = new About();
            ShowForm(aboutfrm);
        }

        private void enterDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath);
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Library.Constants.WneSupportUrl); 
        }

        private void forceRestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestartServices();
        }

        private void webpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost:"+Settings.HttpPort.Value);
        }


    }
}
