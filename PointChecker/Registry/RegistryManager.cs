using Microsoft.Win32;
using System;

namespace PointChecker.Registry
{
    internal sealed class RegistryManager
    {
        const string path = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        const string keyName = "PointCheckerLaunching";

        public static void SetAutoRun(string appPaht)
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            using (var key = hklm.OpenSubKey(path, true))
            {
                try
                {
                    if (key != null)
                    {
                        key.CreateSubKey(keyName);
                    }

                    using (var subKey = key.OpenSubKey(keyName, true))
                    {
                        key.SetValue(keyName, appPaht);
                    }
                }
                catch
                {
                    //TODO: Show a warning message
                }
            }
        }

        public static void RemoveAutoRun()
        {
            try
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                using (var key = hklm.OpenSubKey(path, true))
                {
                    if (key != null) key.DeleteValue(keyName);
                }
            }
            catch
            {
                //TODO: Show a warning message
            }
        }

        public static bool IsAutoRunOn()
        {
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            using (var key = hklm.OpenSubKey(path))
            {
                try
                {
                    if (key != null)
                    {
                        var record = key.GetValue(keyName);

                        if (record is not null && record.ToString().Length > 0)
                        { 
                            return true;
                        }
                    }
                }
                catch
                { 
                    return false;
                }
                
            }

            return false;
        }
    }
}
