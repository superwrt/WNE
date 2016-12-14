using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using wne.UI;

namespace wne.Services
{
    class NginxService : Service
    {
        public NginxService()
        {
            this.serviceName = "Nginx";
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/nginx/nginx.exe";
            this.procName = "nginx";
            this.progName = "Nginx";
            this.startArgs = "-c \"" + Main.StartupPath + "/conf/nginx/nginx.conf\"";
            this.stopArgs = "-s stop " + this.startArgs;
            this.killStop = false;
            this.confDir = Main.StartupPath + "/conf/nginx/";
            this.logDir = Main.StartupPath + "/logs/nginx/";
            this.tmpDir = Main.StartupPath + "/tmp/nginx/";
        }
    }
}
