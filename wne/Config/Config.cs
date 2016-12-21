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
using System.ComponentModel;
using System.Windows.Forms;

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
            iniValue = iniFile.Section(Section).Get(Name);
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
