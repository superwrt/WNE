using System;

using wne.UI;

namespace wne.Services
{
    class ScriptService : Service
    {
        public ScriptService()
        {
            this.exeName = Main.StartupPath.Replace(@"\", "/") + "/scripts/";
            this.procName = "scripts";
            this.progName = "Scripts";
        }

        public override void Start()
        {
            try
            {
                StartProcess(exeName + "start.bat", startArgs, true, false);
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
                StartProcess(exeName + "stop.bat", stopArgs, true, false);
                Main.Notice("Stopped " + progName, serviceName);
            }
            catch (Exception ex)
            {
                Main.Error("Stop(): " + ex.Message, serviceName);
            }

        }
    }
}
