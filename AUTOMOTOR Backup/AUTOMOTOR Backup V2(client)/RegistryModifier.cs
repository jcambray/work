using System;
using System.Net;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace clientbackup
{

    class RegistryModifier
    {
        
        public static void enableAutoLogon(string password)
        {
            RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            regKey = regKey.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon");
            regKey.SetValue("AutoAdminLogon", 1);
            regKey.SetValue("DefaultPassword", ConfigurationManager.AppSettings["password"]);
            regKey.SetValue("DefaultDomainName", Dns.GetHostName());
            regKey.SetValue("DefaultUserName", Environment.UserName);
            regKey.Close();
        }

        public static void disableAutoLogon()
        {
            RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            regKey = regKey.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon");
            regKey.SetValue("AutoAdminLogon", 0);
            regKey.Close();
        }

        public static void StartWithWindows()
        {
            RegistryKey regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            regKey = regKey.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            regKey.SetValue(@"AUTOMOTOR Backup",Application.ExecutablePath);
            regKey.Close();
        }
    }
}
