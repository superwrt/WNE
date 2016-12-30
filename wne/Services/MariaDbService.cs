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
using System.Diagnostics;

using wne.UI;
using System.IO;
using wne.Config;

namespace wne.Services
{
    class MariaDbService : Service
    {
        public string binDir { get; set; }

        public MariaDbService()
        {
            //Run in --standalone mode. Must stop by mysqladmin -u root (-p) shutdown;
            this.serviceName = "MariaDB";
            this.binDir = Main.StartupPath.Replace(@"\", "/") + "/mariadb/bin/";
            this.exeName = binDir + "mysqld.exe";
            this.procName = "mysqld";
            this.progName = "MariaDB";
            this.startArgs = "--defaults-file=\""+Main.StartupPath+ "/conf/mariadb/my.ini\" --standalone";
            this.stopArgs = "";
            this.killStop = true;
            this.waitStop = true;
            this.confDir = Main.StartupPath + "/conf/mariadb/";
            this.dataDir = Main.StartupPath + "/data/mariadb/";
            this.logDir = Main.StartupPath + "/logs/mariadb/";
        }

        public override void Stop()
        {
            using (var ps = new Process())
            {
                ps.StartInfo.FileName = binDir + "mysqladmin.exe";
                ps.StartInfo.WorkingDirectory = Main.StartupPath;
                ps.StartInfo.Arguments = "--defaults-file=\"" + Main.StartupPath + "/conf/mariadb/my.ini\" -uroot shutdown";
                ps.StartInfo.UseShellExecute = false;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.CreateNoWindow = true;
                ps.StartInfo.ErrorDialog = false;
                ps.Start();
                if (!ps.WaitForExit(60000))
                    ps.Kill();
            }

            base.Stop();
        }

        public override void Setup(Ini Settings)
        {
            if (!Directory.Exists(dataDir+"mysql/"))
            {
                try
                {
                    if (!Directory.Exists(dataDir))
                        Directory.CreateDirectory(dataDir);

                    using (var ps = new Process())
                    {
                        ps.StartInfo.FileName = binDir + "mysql_install_db.exe";
                        ps.StartInfo.WorkingDirectory = Main.StartupPath;
                        ps.StartInfo.Arguments = "-D -d \"" + dataDir + "\"";
                        ps.StartInfo.UseShellExecute = false;
                        ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        ps.StartInfo.CreateNoWindow = true;
                        ps.Start();
                        ps.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Main.Error("Setup(): " + ex.Message, serviceName);
                }
            }
            base.Setup(Settings);

        }
    }
}
