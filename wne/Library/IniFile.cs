/*
 * Get from https://github.com/janerist/IniFile
 * 
 * Using:
 * 
 * Reading an INI file
 * [foo]
 * bar=1
 * baz=qux
 * [foo2]
 * bar=2
 * 
 * var iniFile = new IniFile("foo.ini");
 * iniFile.Section("foo").Get<int>("bar"); // 1
 * iniFile.Section("foo").Get("baz"); // "qux"
 *
 * foreach (var section in iniFile.Sections)
 *    Console.WriteLine(section.Name); // foo
                                     // foo2
 * 
 * Writing an INI file
 * 
 * var iniFile = new IniFile();
 * 
 * iniFile.Section("foo").Comment = "This is foo";
 * iniFile.Section("foo").Set("bar", "1");
 * iniFile.Section("foo").Set("baz", "qux", comment: "baz is qux");
 * 
 * iniFile.Section("foo2").Set("bar", "2");
 * 
 * iniFile.Save("foo.ini");
 *
 * // # This is foo
 * // [foo]
 * // bar=1
 * // # baz is qux
 * // baz=qux
 * //
 * // [foo2]
 * // bar=2
 * 
 * iniFile.Section("foo").RemoveProperty("bar"); // or iniFile.Section("foo").Set("bar", null);
 * iniFile.RemoveSection("foo2");
 * iniFile.Save("foo.ini");
 *
 * // # This is foo
 * // [foo]
 * // # baz is qux
 * // baz=qux
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace wne.IniFile
{
    /// <summary>
    /// Represents a property in an INI file.
    /// </summary>
    public class IniProperty
    {
        /// <summary>
        /// Property name (key).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Property value.
        /// </summary>
        public bool NoValue { get; set; }

        /// <summary>
        /// Set the comment to display above this property.
        /// </summary>
        public string Comment { get; set; }
    }

    /// <summary>
    /// Represents a section in an INI file.
    /// </summary>
    public class IniSection
    {
        private readonly IDictionary<string, IniProperty> _properties;

        /// <summary>
        /// Section name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Set the comment to display above this section.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Get the properties in this section.
        /// </summary>
        public IniProperty[] Properties => _properties.Values.ToArray();

        /// <summary>
        /// Create a new IniSection.
        /// </summary>
        /// <param name="name"></param>
        public IniSection(string name)
        {
            Name = name;
            _properties = new Dictionary<string, IniProperty>();
        }

        /// <summary>
        /// Get a property value.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        /// <returns>Value of the property or null if it doesn't exist.</returns>
        public string Get(string name)
        {
            if (_properties.ContainsKey(name))
                return _properties[name].Value;

            return null;
        }

        /// <summary>
        /// Get a property value, coercing the type of the value
        /// into the type given by the generic parameter.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        /// <typeparam name="T">The type to coerce the value into.</typeparam>
        /// <returns></returns>
        public T Get<T>(string name)
        {
            if (_properties.ContainsKey(name))
                return (T)Convert.ChangeType(_properties[name].Value, typeof(T));

            return default(T);
        }

        /// <summary>
        /// Set a property value.
        /// </summary>
        /// <param name="name">Name of the property.</param>
        /// <param name="value">Value of the property.</param>
        /// <param name="comment">A comment to display above the property.</param>
        public void Set(string name, string value, string comment = null)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                RemoveProperty(name);
                return;
            }

            if (!_properties.ContainsKey(name))
                _properties.Add(name, new IniProperty { Name = name, Value = value, Comment = comment });
            else
            {
                _properties[name].Value = value;
                if (comment != null)
                    _properties[name].Comment = comment;
            }
        }

        public void SetNoValue(string name, string comment = null)
        {
            if (!_properties.ContainsKey(name))
                _properties.Add(name, new IniProperty { Name = name, NoValue = true, Comment = comment });
            else
            {
                _properties[name].NoValue = true;
                if (comment != null)
                    _properties[name].Comment = comment;
            }
        }

        /// <summary>
        /// Check if has a property in section
        /// </summary>
        /// <param name="propertyName">The property name to check.</param>
        /// <returns></returns>
        public bool HasProperty(string propertyName)
        {
            return _properties.ContainsKey(propertyName);
        }

        /// <summary>
        /// Remove a property from this section.
        /// </summary>
        /// <param name="propertyName">The property name to remove.</param>
        public void RemoveProperty(string propertyName)
        {
            if (_properties.ContainsKey(propertyName))
                _properties.Remove(propertyName);
        }
    }

    /// <summary>
    /// Represenst an INI file that can be read from or written to.
    /// </summary>
    public class IniFile
    {
        private readonly IDictionary<string, IniSection> _sections;

        /// <summary>
        /// If True, writes extra spacing between the property name and the property value.
        /// (foo=bar) vs (foo = bar)
        /// </summary>
        public bool WriteSpacingBetweenNameAndValue { get; set; }

        /// <summary>
        /// The character a comment line will begin with. Default '#'.
        /// </summary>
        public char CommentChar { get; set; }

        /// <summary>
        /// Get the sections in this IniFile.
        /// </summary>
        public IniSection[] Sections => _sections.Values.ToArray();

        /// <summary>
        /// Create a new IniFile instance.
        /// </summary>
        public IniFile()
        {
            _sections = new Dictionary<string, IniSection>();
            CommentChar = '#';
        }

        /// <summary>
        /// Load an INI file from the file system.
        /// </summary>
        /// <param name="path">Path to the INI file.</param>
        public IniFile(string path) : this()
        {
            try
            {
                Load(path);
            }catch(Exception ex)
            {
                _sections = new Dictionary<string, IniSection>();
                CommentChar = '#';
            }
        }

        /// <summary>
        /// Load an INI file.
        /// </summary>
        /// <param name="reader">A TextReader instance.</param>
        public IniFile(TextReader reader) : this()
        {
            Load(reader);
        }

        private void Load(string path)
        {
            using (var file = new StreamReader(path))
                Load(file);
        }

        private void Load(TextReader reader)
        {
            IniSection section = null;

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();

                // skip empty lines
                if (line == string.Empty)
                    continue;

                // skip comments
                if (line.StartsWith(";") || line.StartsWith("#"))
                    continue;

                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    var sectionName = line.Substring(1, line.Length - 2);
                    if (!_sections.ContainsKey(sectionName))
                    {
                        section = new IniSection(sectionName);
                        _sections.Add(sectionName, section);
                    }
                    continue;
                }

                if (section != null)
                {
                    var keyValue = line.Split(new[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);
                    switch(keyValue.Length)
                    {
                    case 1:
                        section.SetNoValue(line.Trim());
                        break;
                    case 2:
                        section.Set(keyValue[0].Trim(), keyValue[1].Trim());
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Get a section by name. If the section doesn't exist, it is created.
        /// </summary>
        /// <param name="sectionName">The name of the section.</param>
        /// <returns>A section. If the section doesn't exist, it is created.</returns>
        public IniSection Section(string sectionName)
        {
            IniSection section;
            if (!_sections.TryGetValue(sectionName, out section))
            {
                section = new IniSection(sectionName);
                _sections.Add(sectionName, section);
            }

            return section;
        }

        /// <summary>
        /// Remove a section.
        /// </summary>
        /// <param name="sectionName">Name of the section to remove.</param>
        public void RemoveSection(string sectionName)
        {
            if (_sections.ContainsKey(sectionName))
                _sections.Remove(sectionName);
        }

        /// <summary>
        /// Create a new INI file.
        /// </summary>
        /// <param name="path">Path to the INI file to create.</param>
        public void Save(string path)
        {
            using (var file = new StreamWriter(path))
                Save(file);
        }

        /// <summary>
        /// Create a new INI file.
        /// </summary>
        /// <param name="writer">A TextWriter instance.</param>
        public void Save(TextWriter writer)
        {
            foreach (var section in _sections.Values)
            {
                if (section.Properties.Length == 0)
                    continue;

                if (section.Comment != null)
                    writer.WriteLine($"{CommentChar} {section.Comment}");

                writer.WriteLine($"[{section.Name}]");

                foreach (var property in section.Properties)
                {
                    if (property.Comment != null)
                        writer.WriteLine($"{CommentChar} {property.Comment}");

                    if (property.NoValue)
                    {
                        writer.WriteLine($"{property.Name}");
                        continue;
                    }

                    var format = WriteSpacingBetweenNameAndValue ? "{0} = {1}" : "{0}={1}";
                    writer.WriteLine(format, property.Name, property.Value);
                }

                writer.WriteLine();
            }
        }

        /// <summary>
        /// Returns the content of this INI file as a string.
        /// </summary>
        /// <returns>The text content of this INI file.</returns>
        public override string ToString()
        {
            using (var sw = new StringWriter())
            {
                Save(sw);
                return sw.ToString();
            }
        }
    }
}
