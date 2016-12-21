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
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

using wne.UI;

namespace wne.Services
{
    class PhpService : Service
    {
        public string verDir { get; set; }
    
        public PhpService(string verDir="default")
        {
            this.serviceName = "PHP";
            this.verDir = Main.StartupPath.Replace(@"\", "/") + "/php/" + verDir + "/";
            this.exeName = this.verDir + "/php-cgi.exe";
            this.procName = "php-cgi";
            this.progName = "PHP"; 
            this.killStop = true;
            this.startArgs = "";
            this.stopArgs = "-s stop";
            this.confDir = Main.StartupPath + "/conf/php/";
            this.logDir = Main.StartupPath + "/logs/php/";
        }

        private void setVersionDir(string verDir)
        {
            this.verDir = Main.StartupPath.Replace(@"\", "/") + "/php/" + verDir +"/";
            this.exeName = this.verDir + "/php-cgi.exe";
        }

        private void setCurlCAPath()
        {
            string phpini = confDir + "/php.ini";
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
                    StartProcess(exeName, $"-b localhost:{port} -c \"{phpini}\"");
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
