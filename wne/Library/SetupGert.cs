using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace wne.Library
{
    class SetupGert
    {
        public void GenerateGert(string projPath)
        {
            if (!File.Exists(projPath + "/CertGen.exe"))
                return;
            if (!Directory.Exists(projPath + "/conf"))
                Directory.CreateDirectory(projPath + "/conf");

            using (var ps = new Process())
            {
                ps.StartInfo.FileName = projPath + "/CertGen.exe";
                ps.StartInfo.UseShellExecute = false;
                ps.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ps.StartInfo.CreateNoWindow = true;
                ps.Start();
            }
        }
    }
}
