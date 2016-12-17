
using wne.UI;

namespace wne.Services
{
    class RedisService : Service
    {
        public RedisService()
        {
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

    }
}
