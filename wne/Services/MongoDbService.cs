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
    class MongoDbService : Service
    {
        public MongoDbService()
        {
            //Stop >use admin  > db.shutdownServer()
            this.serviceName = "MongoDB";
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/mongodb/mongod.exe";
            this.procName = "mongodb";
            this.progName = "MongoDB";
            this.startArgs = "-config \""+ Main.StartupPath.Replace(@"\", "/") + "/conf/mongodb/mongodb.conf\"";
            this.stopArgs = "";
            this.killStop = true;
            this.intStop = true;
            this.confDir = Main.StartupPath + "/conf/mongodb/";
            this.dataDir = Main.StartupPath + "/data/mongodb/";
            this.logDir = Main.StartupPath + "/logs/mongodb/";
        }
    }
}
