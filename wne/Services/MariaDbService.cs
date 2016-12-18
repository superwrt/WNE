using System;
using System.Diagnostics;

using wne.UI;
using System.IO;
using wne.Config;

namespace wne.Services
{
    class MariaDbService : Service
    {
        public MariaDbService()
        {
            
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/mariadb/bin/mysqld.exe";
            this.procName = "mysqld";
            this.progName = "MariaDB";
            this.startArgs = "--defaults-file=\""+Main.StartupPath+"/conf/mariadb/my.ini\"";
            this.stopArgs = "";
            this.killStop = true;
            this.confDir = Main.StartupPath + "/conf/mariadb/";
            this.dataDir = Main.StartupPath + "/data/mariadb/";
            this.logDir = Main.StartupPath + "/logs/mariadb/";
        }

        public override void Setup(Ini Settings)
        {
            var binDir = Main.StartupPath.Replace(@"\", "/") + "/mariadb/bin/";
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
