using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;

namespace NotificationClient
{
    static class Program
    {
        public static string Email;
        public static string CStr = "server=googlecloudzone.net;Database=pubsubnotification;user Id=sa;Password=unlock";
        public static Db obj;
        public static string DeviceId;
        public static ArrayList PubList = new ArrayList();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UserStateForm());
            Application.Run(new Login());
        }
    }
}
