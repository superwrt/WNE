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
using System.IO;

namespace wne.Config
{
    class PhpConfig
    {
        [Flags]
        public enum PHPExtension
        {
            Disabled = 1,
            Enabled = 2,
            ZendExt = 3,
        }
        public bool[] UserPHPExtentionValues;
        public string[] phpExtName;
        public PHPExtension[] PHPExtensions;
        public string PHPExtensionDir;
        private string PHPExtensionDirOld;

        private string ExtensionPath;
        private string IniFilePath;
        private string TmpIniFile;

        private void LoadIni()
        {
            TmpIniFile = File.ReadAllText(IniFilePath);
        }

        public void CheckExtensions(string phpBinPath, string phpConfigPath, string startUpPath)
        {
            if (!Directory.Exists(phpBinPath))
                return;

            LoadExtensions(phpBinPath, phpConfigPath);
            if (PHPExtensionDir == null ||
                PHPExtensionDir.IndexOf(startUpPath) != 0)
            {
                PHPExtensionDir = phpBinPath + "/ext";
                SaveIniOptions();
            } 
        }

        public void LoadExtensions(string phpBinPath, string phpConfigPath)
        {
            ExtensionPath = phpBinPath + "/ext/";
            IniFilePath = phpConfigPath + "/php.ini";

            if (!Directory.Exists(ExtensionPath))
                return;
            phpExtName = Directory.GetFiles(ExtensionPath, "*.dll");
            PHPExtensions = new PHPExtension[phpExtName.Length];
            UserPHPExtentionValues = new bool[phpExtName.Length];

            for (var i = 0; i < phpExtName.Length; i++)
            {
                phpExtName[i] = phpExtName[i].Remove(0, ExtensionPath.Length);
            }

            LoadIni();
            ParseIni();
        }

        public void ParseIni()
        {
            using (var sr = new StringReader(TmpIniFile))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    for (var i = 0; i < phpExtName.Length; i++)
                    {
                        if (str.StartsWith(";extension=" + phpExtName[i]))
                        {
                            PHPExtensions[i] = PHPExtension.Disabled;
                            break;
                        }
                        if (str.StartsWith("extension=" + phpExtName[i]))
                        {
                            PHPExtensions[i] = PHPExtension.Enabled;
                            break;
                        }
                        if (str.StartsWith(";zend_extension=" + phpExtName[i]))
                        {
                            PHPExtensions[i] = PHPExtension.Disabled | PHPExtension.ZendExt;
                            break;
                        }
                        if (str.StartsWith("zend_extension=" + phpExtName[i]))
                        {
                            PHPExtensions[i] = PHPExtension.Enabled | PHPExtension.ZendExt;
                            break;
                        }
                    }
                    if (str.StartsWith("extension_dir"))
                    {
                        PHPExtensionDir = str.Substring(str.IndexOf("=")+1).Trim();
                        if (PHPExtensionDir[0] == '\"')
                        {
                            PHPExtensionDir = str.Substring(1, str.Length-2);
                        }
                        PHPExtensionDirOld = str;
                    } else if (PHPExtensionDirOld == null &&
                        str.Length > 13 &&
                        str[0] == ';' &&
                        str.Substring(1).TrimStart().StartsWith("extension_dir"))
                    {
                        PHPExtensionDirOld = str;
                    }
                }
            }
        }

        public void SaveIniOptions()
        {
            for (var i = 0; i < phpExtName.Length; i++)
            {
                if (!PHPExtensions[i].HasFlag(PHPExtension.ZendExt))
                {
                    if (UserPHPExtentionValues[i])
                    {
                        if (PHPExtensions[i].HasFlag(PHPExtension.Disabled))
                            TmpIniFile = TmpIniFile.Replace(";extension=" + phpExtName[i], "extension=" + phpExtName[i]);
                    }
                    else
                    {
                        if (PHPExtensions[i].HasFlag(PHPExtension.Enabled))
                            TmpIniFile = TmpIniFile.Replace("extension=" + phpExtName[i], ";extension=" + phpExtName[i]);
                    }
                }
                else
                { // Special case zend_extension
                    if (UserPHPExtentionValues[i])
                    {
                        if (PHPExtensions[i].HasFlag(PHPExtension.Disabled))
                            TmpIniFile = TmpIniFile.Replace(";zend_extension=" + phpExtName[i], "zend_extension=" + phpExtName[i]);
                    }
                    else
                    {
                        if (PHPExtensions[i].HasFlag(PHPExtension.Enabled))
                            TmpIniFile = TmpIniFile.Replace("zend_extension=" + phpExtName[i], ";zend_extension=" + phpExtName[i]);
                    }
                }
            }
            if (PHPExtensionDir != null && PHPExtensionDirOld != null)
                TmpIniFile = TmpIniFile.Replace(PHPExtensionDirOld, "extension_dir = \"" + PHPExtensionDir + "\"");
            File.WriteAllText(IniFilePath, TmpIniFile);
        }
    }
}
