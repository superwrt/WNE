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
