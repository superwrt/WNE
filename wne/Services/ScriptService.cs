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

using wne.UI;

namespace wne.Services
{
    class ScriptService : Service
    {
        public string binDir { get; set; }

        public ScriptService()
        {
            this.binDir = Main.StartupPath.Replace(@"\", "/") + "/conf/scripts/";
            this.procName = "scripts";
            this.progName = "Scripts";
            this.useShell = true;
        }

        public override void Start()
        {
            try
            {
                StartProcess(binDir + "start.bat", startArgs, true, false);
                Main.Notice("Started " + progName, serviceName);
            }
            catch (Exception ex)
            {
                Main.Error("Start(): " + ex.Message, serviceName);
            }
        }

        public override void Stop()
        {
            try
            {
                StartProcess(binDir + "stop.bat", stopArgs, true, false);
                Main.Notice("Stopped " + progName, serviceName);
            }
            catch (Exception ex)
            {
                Main.Error("Stop(): " + ex.Message, serviceName);
            }

        }
    }
}
