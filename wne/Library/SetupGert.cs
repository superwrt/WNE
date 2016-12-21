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
