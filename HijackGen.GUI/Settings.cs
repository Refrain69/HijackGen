using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace HijackGen.GUI
{
    internal class Settings : ApplicationSettingsBase
    {
        public static Settings Default { get; } = (Settings)Synchronized(new Settings());

        public static readonly string DefaultDir = Environment.GetFolderPath(Environment.SpecialFolder.System);

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string DllPathInternal
        {
            get => (string)this[nameof(DllPathInternal)];
            set => this[nameof(DllPathInternal)] = value;
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string SaveDirInternal
        {
            get => (string)this[nameof(SaveDirInternal)];
            set => this[nameof(SaveDirInternal)] = value;
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("true")]
        public bool GenerateHeaderInternal
        {
            get => (bool)this[nameof(GenerateHeaderInternal)];
            set => this[nameof(GenerateHeaderInternal)] = value;
        }

        public static string DllPath
        {
            get
            {
                return Default.DllPathInternal;
            }
            set
            {
                Default.DllPathInternal = value;
                Default.Save();
            }
        }

        public static string SaveDir
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Default.SaveDirInternal))
                {
                    Default.SaveDirInternal = Path.GetDirectoryName(DllPath);
                    Default.Save();
                    return Path.GetDirectoryName(DllPath);
                }
                else
                {
                    return Default.SaveDirInternal;
                }
            }
            set
            {
                Default.SaveDirInternal = value;
                Default.Save();
            }
        }

        public static bool GenerateHeader
        {
            get
            {
                return Default.GenerateHeaderInternal;
            }
            set
            {
                Default.GenerateHeaderInternal = value;
                Default.Save();
            }
        }
    }
}
