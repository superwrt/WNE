using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using wne.UI;

namespace wne.Services
{
    class PhpService : Service
    {
        public PhpService(string verDir="default")
        {
            this.serviceName = "PHP";
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/php/"+ verDir + "/php-cgi.exe";
            this.procName = "php-cgi";
            this.progName = "PHP"; 
            this.killStop = true;
            this.startArgs = "";
            this.stopArgs = "-s stop";
            this.confDir = "/conf/php/";
            this.logDir = "/logs/php/";
        }

        private void setVersionDir(string verDir)
        {
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/php/" + verDir + "/php-cgi.exe";
        }

        private void setCurlCAPath()
        {
            string phpini = Main.StartupPath + "/php/php.ini";
            if (!File.Exists(phpini))
                return;

            string[] file = File.ReadAllLines(phpini);
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains("curl.cainfo") == false)
                    continue;

                Regex reg = new Regex("\".*?\"");
                string orginal = reg.Match(file[i]).ToString();
                if (orginal == String.Empty)
                    continue;
                string replace = "\"" + Main.StartupPath + @"\contrib\cacert.pem" + "\"";
                file[i] = file[i].Replace(orginal, replace);
            }
            using (var sw = new StreamWriter(phpini))
            {
                foreach (var line in file)
                    sw.WriteLine(line);
            }
        }

        private void InitEnverionment()
        {
            Dictionary<string, string> envs = new Dictionary<string, string>(Settings.EnverionmentValues);

            if (!envs.ContainsKey("PHP_FCGI_MAX_REQUESTS"))
                envs.Add("PHP_FCGI_MAX_REQUESTS", "0"); // Disable auto killing PHP
            setEnverionments(Settings.EnverionmentValues);
        }

        public override void Start()
        {
            ushort ProcessCount = Settings.PhpProcesses.Value;
            ushort port = Settings.PhpPort.Value;
            string phpini = confDir+"/php.ini";

            setVersionDir(Settings.PhpVersionDir.Value);
            InitEnverionment();

            try
            {
                for (var i = 1; i <= ProcessCount; i++)
                {
                    StartProcess(exeName, $"-b localhost:{port} -c {phpini}");
                    Main.Notice("Starting PHP " + i + "/" + ProcessCount + " on port: " + port, serviceName);
                    port++;
                }
                Main.Notice("PHP started", serviceName);
            }
            catch (Exception ex)
            {
                Main.Error("StartPHP(): " + ex.Message, serviceName);
            }
        }
    }
}
