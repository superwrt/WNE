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

namespace wne.Services
{
    class RedisService : Service
    {
        public RedisService()
        {
            //Stop: redis-cli SHUTDOWN
            this.serviceName = "Redis";
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/redis/redis-server.exe";
            this.procName = "redis";
            this.progName = "Redis";
            this.startArgs = "\""+Main.StartupPath + "/conf/redis/gen.conf\"";
            this.stopArgs = "";
            this.killStop = true;
            this.confDir = Main.StartupPath + "/conf/redis/";
            this.dataDir = Main.StartupPath + "/data/redis/";
            this.logDir = Main.StartupPath + "/logs/redis/";
        }

        public override void Stop()
        {
            var binDir = Main.StartupPath.Replace(@"\", "/") + "/redis/";
            try
            {
                Process ps = new Process();
                ps.StartInfo.FileName = binDir + "redis-cli.exe";
                ps.StartInfo.WorkingDirectory = Main.StartupPath;
                ps.StartInfo.Arguments = "-p " + Settings.RedisPort.Value + " SHUTDOWN";
                ps.StartInfo.UseShellExecute = false;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.CreateNoWindow = true;
                ps.Start();
                if (!ps.WaitForExit(10000))
                    ps.Kill();
            }
            catch (Exception ex) { }
            base.Stop();
        }

    }
}
