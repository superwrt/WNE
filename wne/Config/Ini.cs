using System;
using System.Collections.Generic;
using System.IO;
using wne.UI;

namespace wne.Config
{
    public class Ini
    {
        public Config<string> Editor = new Config<string>
        {
            Section = "WNE",
            Name = "editor",
            Description = "Editor Path",
            Value = "notepad.exe",
        };
        public Config<string> WnePath = new Config<string>
        {
            Section = "WNE",
            Name = "wnepath",
            Description = "WNE Path",
            Value = "",
        };
        public Config<ushort> HttpPort = new Config<ushort>
        {
            Section = "WNE",
            Name = "httpport",
            Description = "Http Port",
            Value = 80,
        };
        public Config<bool> StartWithWindows = new Config<bool>
        {
            Section = "WNE",
            Name = "startupwithwindows",
            Description = "Start Wne with Windows",
            Value = false,
        };
        public Config<bool> AutoCheckForUpdates = new Config<bool>
        {
            Section = "WNE",
            Name = "autocheckforupdates",
            Description = "Automatically check for updates",
            Value = true,
        };

        public Config<bool> UseServiceScript = new Config<bool>
        {
            Section = "WNE",
            Name = "useservicescript",
            Description = "If start other service script",
            Value = true,
        };
        public Config<bool> UseServiceNginx = new Config<bool>
        {
            Section = "WNE",
            Name = "useservicenginx",
            Description = "If start nginx service",
            Value = true,
        };
        public Config<bool> UseServicePhp = new Config<bool>
        {
            Section = "WNE",
            Name = "useservicephp",
            Description = "If start php service",
            Value = true,
        };
        public Config<bool> UseServiceMariaDb = new Config<bool>
        {
            Section = "WNE",
            Name = "useservicemariadb",
            Description = "If start MariaDB service",
            Value = true,
        };
        public Config<bool> UseServiceMongoDb = new Config<bool>
        {
            Section = "WNE",
            Name = "useservicemongodb",
            Description = "If start MongoDB service",
            Value = true,
        };
        public Config<bool> UseServiceRedis = new Config<bool>
        {
            Section = "WNE",
            Name = "useserviceredis",
            Description = "If start Redis service",
            Value = true,
        };

        public Config<string> PhpVersionDir = new Config<string>
        {
            Section = "WNE-PHP",
            Name = "versiondir",
            Description = "PHP version direcotry",
            Value = "php7.0",
        };
        public Config<ushort> PhpPort = new Config<ushort>
        {
            Section = "WNE-PHP",
            Name = "port",
            Description = "PHP Port",
            Value = 9000,
        };
        public Config<ushort> PhpProcesses = new Config<ushort>
        {
            Section = "WNE-PHP",
            Name = "processes",
            Description = "PHP Processes",
            Value = 2,
        };

        public Config<string> MariaDbBind = new Config<string>
        {
            Section = "WNE-MARIADB",
            Name = "bind",
            Description = "MariaDB bind address",
            Value = "127.0.0.1",
        };
        public Config<ushort> MariaDbPort = new Config<ushort>
        {
            Section = "WNE-MARIADB",
            Name = "port",
            Description = "MariaDB listen port",
            Value = 3306,
        };
        public Config<string> MariaDbCharset = new Config<string>
        {
            Section = "WNE-MARIADB",
            Name = "charset",
            Description = "MariaDB default charset",
            Value = "utf8",
        };

        public Config<string> MongoDbBind = new Config<string>
        {
            Section = "WNE-MONGODB",
            Name = "bind",
            Description = "MongoDB bind address",
            Value = "127.0.0.1",
        };
        public Config<ushort> MongoDbPort = new Config<ushort>
        {
            Section = "WNE-MONGODB",
            Name = "port",
            Description = "MongoDB listen port",
            Value = 27017,
        };

        public Config<string> RedisBind = new Config<string>
        {
            Section = "WNE-REDIS",
            Name = "bind",
            Description = "Redis bind address",
            Value = "127.0.0.1",
        };
        public Config<ushort> RedisPort = new Config<ushort>
        {
            Section = "WNE-REDIS",
            Name = "port",
            Description = "Redis listen port",
            Value = 6379,
        };
        public Config<string> RedisLogLevel = new Config<string>
        {
            Section = "WNE-REDIS",
            Name = "loglevel",
            Description = "Redis log level",
            Value = "warning",
        };

        private readonly string iniFileName = Main.StartupPath + @"\wne.ini";
        public Dictionary<string, string> EnverionmentValues = new Dictionary<string, string>();
        private List<IConfig> options = new List<IConfig>();

        public Ini()
        {
            options.Add(Editor);
            options.Add(WnePath);
            options.Add(HttpPort);
            options.Add(StartWithWindows);
            options.Add(AutoCheckForUpdates);

            options.Add(UseServiceScript);
            options.Add(UseServiceNginx);
            options.Add(UseServicePhp);
            options.Add(UseServiceMariaDb);
            options.Add(UseServiceMongoDb);
            options.Add(UseServiceRedis);

            options.Add(PhpVersionDir);
            options.Add(PhpPort);
            options.Add(PhpProcesses);

            options.Add(MariaDbBind);
            options.Add(MariaDbPort);
            options.Add(MariaDbCharset);

            options.Add(MongoDbBind);
            options.Add(MongoDbPort);

            options.Add(RedisBind);
            options.Add(RedisPort);
            options.Add(RedisLogLevel);
        }


        private void ReadEnverionments(IniFile.IniFile iniFile)
        {
            Dictionary<string, string> envs = new Dictionary<string, string>();
            var section = iniFile.Section("WNE-ENV");
            foreach (var prop in section.Properties)
            {
                envs.Add(prop.Name, prop.Value);
            }
            EnverionmentValues = envs;
        }
  
        private void UpdateEnverionments(IniFile.IniFile iniFile)
        {
            var section = iniFile.Section("WNE-ENV");
            foreach (var val in EnverionmentValues)
            {
                section.Set(val.Key, val.Value);
            }
        }

        /// <summary>
        /// Reads the settings from the ini
        /// </summary>
        public void ReadSettings()
        {
            var iniFile = new IniFile.IniFile(iniFileName);

            foreach (var option in options)
            {
                option.ReadIniValue(iniFile);
                option.Convert();
            }

            if (WnePath.Value != Main.StartupPath)
            {
                UpdateSettings();
            }
            
            ReadEnverionments(iniFile);
        }

        /// <summary>
        /// Updates the settings to the ini
        /// </summary>
        public void UpdateSettings()
        {
            var iniFile = new IniFile.IniFile();
            foreach (var option in options)
            {
                option.PrintIniOption(iniFile);
            }
            UpdateEnverionments(iniFile);
            iniFile.Save(iniFileName);

            if (!Directory.Exists(Main.StartupPath + "/conf"))
            {
                Directory.CreateDirectory(Main.StartupPath + "/conf");
            }

            SaveNginxPHPConfig();
            SaveMariaDbConfig();
            SaveMongoDbConfig();
            SaveRedisConfig();
            new PhpConfig().CheckExtensions(Main.StartupPath + "/php/" + PhpVersionDir.Value, Main.StartupPath + "/conf/php", Main.StartupPath);
        }

        private void SaveNginxPHPConfig()
        {
            ushort port = PhpPort.Value;
            uint PHPProcesses = PhpProcesses.Value;
            try
            {
                using (var sw = new StreamWriter(Main.StartupPath + "/conf/nginx/gen/php_processes.conf"))
                {
                    sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNE.\r\n");
                    sw.WriteLine("upstream php_processes {");
                    for (var i = 1; i <= PHPProcesses; i++)
                    {
                        sw.WriteLine("    server 127.0.0.1:" + port + " weight=1;");
                        port++;
                    }
                    sw.WriteLine("}");
                }
            }
            catch (Exception ex) { }
        }

        private void SaveMariaDbConfig()
        {
            try
            {
                var basePath = Main.StartupPath.Replace(@"\", "/");
                var confPath = Main.StartupPath + "/conf/mariadb/my.ini";
                var iniFile = new IniFile.IniFile(confPath);
                var port = MariaDbPort.Value.ToString();

                //iniFile.Section("mysqld").Set("basedir", Main.StartupPath);
                iniFile.Section("mysqld").Set("datadir", basePath + "/data/mariadb");
                iniFile.Section("mysqld").Set("tmpdir", basePath + "/tmp");
                iniFile.Section("mysqld").Set("innodb_data_home_dir", basePath + "/data/mariadb");
                iniFile.Section("mysqld").Set("innodb_log_group_home_dir", basePath + "/data/mariadb");

                iniFile.Section("client").Set("port", port);
                iniFile.Section("mysqld").Set("port", port);

                iniFile.Section("mysqld").Set("character_set_server", MariaDbCharset.Value.ToString());
                iniFile.Section("mysqld").Set("bind-address", MariaDbBind.Value.ToString());

                iniFile.Save(confPath);
            }
            catch (Exception ex) { }
        }

        private void SaveMongoDbConfig()
        {
            var basePath = Main.StartupPath.Replace(@"\", "/");
            try {
                using (var sw = new StreamWriter(Main.StartupPath + "/conf/mongodb/mongodb.conf"))
                {
                    sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNE.\r\n");
                    sw.WriteLine("dbpath=" + basePath + "/data/mongodb/");
                    sw.WriteLine("logpath=" + basePath + "/logs/mongodb/mongodb.log");
                    if (MongoDbBind.Value.Length > 0)
                        sw.WriteLine("bind_ip=" + MongoDbBind.Value);
                    sw.WriteLine("port=" + MongoDbPort.Value);
                }
            }
            catch (Exception ex) { }
        }

        private void SaveRedisConfig()
        {
            var basePath = Main.StartupPath.Replace(@"\", "/");
            try {
                using (var sw = new StreamWriter(basePath + "/conf/redis/gen.conf"))
                {
                    sw.WriteLine("# DO NOT MODIFY!!! THIS FILE IS MANAGED BY THE WNE.\r\n");
                    sw.WriteLine("logfile \"" + basePath + "/logs/redis/def.log\"");
                    if (RedisLogLevel.Value.Length > 0)
                        sw.WriteLine("loglevel " + RedisLogLevel.Value);

                    if (RedisBind.Value.Length > 0)
                        sw.WriteLine("bind " + RedisBind.Value);
                    sw.WriteLine("port " + RedisPort.Value);

                    sw.WriteLine("dir \"" + basePath + "/data/redis/\"");
                    sw.WriteLine("pidfile \"" + basePath + "/tmp/redis.pid\"");

                    sw.WriteLine("include \"" + basePath + "/conf/redis/redis.conf\"");
                }
            }
            catch (Exception ex) { }
        }
    }
}
