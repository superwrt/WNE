using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

using wne.IniFile;

namespace wne.Config
{
    public interface IConfig
    {
        void ReadIniValue(IniFile.IniFile iniFile);
        void Convert();
        void PrintIniOption(IniFile.IniFile iniFile);
    }

    public class Config<T> : IConfig
    {
        public string Name;
        public string Description;
        public string iniValue;
        public string Section;
        public T Value;

        public void ReadIniValue(IniFile.IniFile iniFile)
        {
            iniValue = iniFile.Section("foo").Get("baz");
        }

        public void PrintIniOption(IniFile.IniFile iniFile)
        {
            iniFile.Section(Section).Set(Name, Value.ToString(), Description);
        }

        public void Convert()
        {
            if (iniValue == null || iniValue == "")
                return;
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    Value = (T)converter.ConvertFromString(iniValue);
                }
                catch (Exception ex)
                {
                    // Could be made a bit more elegant but considering its a rare user-caused exception....
                    var message =
                        $"{Name}={iniValue}\n{ex.Message}\n\nThe Default Value '{Value.ToString()}' will be used instead.";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
