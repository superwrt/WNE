using wne.UI;

namespace wne.Services
{
    class MongoDbService : Service
    {
        public MongoDbService()
        {
            this.serviceName = "MongoDB";
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/mongodb/mongod.exe";
            this.procName = "mongodb";
            this.progName = "MongoDB";
            this.startArgs = "-config \""+ Main.StartupPath.Replace(@"\", "/") + "/conf/mongodb/mongodb.conf\"";
            this.stopArgs = "";
            this.killStop = true;
            this.confDir = Main.StartupPath + "/conf/mongodb/";
            this.dataDir = Main.StartupPath + "/data/mongodb/";
            this.logDir = Main.StartupPath + "/logs/mongodb/";
        }
    }
}
