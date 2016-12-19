using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace wne
{
    static class Program
    {
        public static EventWaitHandle ProgramStarted;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool createNew;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "WNE-SuperWRT", out createNew);
            if (!createNew)
            {
                ProgramStarted.Set();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OSVersionCheck();

            bool start = false;
            foreach (String s in args){
                if (string.Compare(s, "/start") == 0)
                    start = true;
            }
            Application.Run(new UI.Main(start));
        }

        /// <summary>
        /// Checks if the OS is Vista+
        /// </summary>
        private static void OSVersionCheck()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                return;
            MessageBox.Show("Windows Vista+ is required to run WNE");
            Process process = Process.GetCurrentProcess();
            process.Kill();
        }
    }
}
