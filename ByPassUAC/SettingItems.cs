using System;
using System.Runtime.InteropServices;


namespace ByPaSsuAc
{
    class SettingItems
    {
        [DllImport("shell32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsUserAnAdmin();

        public static void CheckA()
        {
            Console.WriteLine(IsUserAnAdmin());

            //Console.ReadKey(); //
        }

    }
}
