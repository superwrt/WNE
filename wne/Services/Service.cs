using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using wne.Config;
using wne.UI;
using System.IO;

namespace wne.Services
{
    class Service
    {
        public string serviceName = "Service";
        public Label statusLabel { get; set; } // Label that shows the programs status
        public string exeName { get; set; }    // Location of the executable file
        public string procName { get; set; }   // Name of the process
        public string progName { get; set; }   // User-friendly name of the program 
        public string startArgs { get; set; }  // Start Arguments
        public string stopArgs { get; set; }   // Stop Arguments if KillStop is false
        public bool killStop { get; set; }     // Kill process instead of stopping it gracefully
        public string confDir { get; set; }    // Directory where all the programs configuration files are
        public string logDir { get; set; }     // Directory where all the programs log files are
        public string dataDir { get; set; }
        public string tmpDir { get; set; }
        protected Ini Settings;

        private Stack<Process> procs = new Stack<Process>();
        private Dictionary<string, string> envs = new Dictionary<string, string>();

        public Service()
        {
        }

        public virtual void Setup(Ini Settings)
        {
            this.Settings = Settings;
            if (dataDir != null && !Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }
            if (logDir != null && !Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }
            if (tmpDir != null && !Directory.Exists(tmpDir))
            {
                Directory.CreateDirectory(tmpDir);
            }
        }

        protected void StartProcess(string exe, string args, bool wait = false, bool push = true)
        {
            var ps = new Process();
            ps.StartInfo.FileName = exe;
            ps.StartInfo.Arguments = args;
            ps.StartInfo.UseShellExecute = false;
            ps.StartInfo.RedirectStandardOutput = true;
            ps.StartInfo.WorkingDirectory = Main.StartupPath;
            ps.StartInfo.CreateNoWindow = true;
            ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            foreach (KeyValuePair<string, string> item in envs)
                ps.StartInfo.EnvironmentVariables.Add(item.Key, item.Value);

            ps.Start();

            if (wait)
                ps.WaitForExit();
            if (push)
                procs.Push(ps);
        }
        public virtual void Start()
        {
            try
            {
                StartProcess(exeName, startArgs);
                Main.Notice("Started " + progName, serviceName);
            }
            catch (Exception ex)
            {
                Main.Error("Start(): " + ex.Message, serviceName);
            }
        }

        public virtual void Stop()
        {
            if (killStop == false)
                StartProcess(exeName, stopArgs, true, false);
            while (procs.Count > 0)
            {
                var ps = procs.Pop();
                if (killStop && !ps.HasExited)
                {
                    ps.Kill();
                }
            }
            Main.Notice("Stopped " + progName, serviceName);
        }

        public void forceStop()
        {
            var processes = Process.GetProcessesByName(procName);
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        public void Restart()
        {
            this.Stop();
            this.forceStop();
            this.Start();
            Main.Notice("Restarted " + progName, serviceName);
        }

        public bool IsRunning()
        {
            return (procs.Count != 0);
        }

        public void setEnverionments(Dictionary<string, string> sets)
        {
            envs = new Dictionary<string, string>(sets);
        }
    }
}
