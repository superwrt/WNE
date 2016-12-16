using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                    Process.Start(binDir +
                        "mysql_install_db  -D -d \"" +
                        Main.StartupPath + "/data/mariadb/\"");
                }
            }
            catch (Exception ex) { }
            base.Setup(Settings);

        }
    }
}
