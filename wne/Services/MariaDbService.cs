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
            this.exeName = binDir + "/mysqld.exe";
            this.procName = "mysqld";
            this.progName = "MariaDB";
            this.startArgs = "--defaults-file=\""+Main.StartupPath+"/conf/mariadb/my.ini\"";
            this.stopArgs = "";
            this.killStop = true;
            this.confDir = Main.StartupPath + "/conf/mariadb/";
            this.dataDir = Main.StartupPath + "/data/mariadb/";
            this.logDir = Main.StartupPath + "/logs/mariadb/";
            
        }

        public override void Stop()
        {
            try
            {
                Process ps = new Process();
                ps.StartInfo.FileName = binDir + "mysqladmin.exe";
                ps.StartInfo.WorkingDirectory = Main.StartupPath;
                ps.StartInfo.Arguments = "--defaults-file=\"" + Main.StartupPath + "/conf/mariadb/my.ini\" -u root shutdown";
                ps.StartInfo.UseShellExecute = false;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.CreateNoWindow = true;
                ps.Start();
                if (!ps.WaitForExit(60000))
                    ps.Kill();
            }
            catch (Exception ex) { }
            base.Stop();
        }

        public override void Setup(Ini Settings)
        {
            try
            {
                if (!Directory.Exists(dataDir+"mysql/"))
                {
                    if (!Directory.Exists(dataDir))
                        Directory.CreateDirectory(dataDir);

                    Process ps = new Process();
                    ps.StartInfo.FileName = binDir + "mysql_install_db.exe";
                    ps.StartInfo.WorkingDirectory = Main.StartupPath ;
                    ps.StartInfo.Arguments = "-D -d \"" + dataDir + "\"";
                    ps.StartInfo.UseShellExecute = false;
                    ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.StartInfo.CreateNoWindow = true;
                    ps.Start();
                    ps.WaitForExit();
                }
            }
            catch (Exception ex) { }
            base.Setup(Settings);

        }
    }
}
