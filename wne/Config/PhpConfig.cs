using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private string ExtensionPath;
        private string IniFilePath;
        private string TmpIniFile;

        private void LoadIni()
        {
            TmpIniFile = File.ReadAllText(IniFilePath);
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
            File.WriteAllText(IniFilePath, TmpIniFile);
        }
    }
}
