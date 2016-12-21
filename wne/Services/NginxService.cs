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
