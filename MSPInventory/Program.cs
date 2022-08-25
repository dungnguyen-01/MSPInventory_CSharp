using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.Data.Linq;

namespace MSPInventory
{
    static class Program
    {
        public static string m_strMSPOffice = "MSP Office";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // get server name from settings file
            SettingsFile fSettings = new SettingsFile(string.Format("{0}\\{1}_settings.txt",
                Application.StartupPath, Application.ProductName.ToLower()));
            string strServer = fSettings.GetParam("server");

            AppSettingLinQ setting = new AppSettingLinQ();
            setting.SaveConnectionString("MSPInventory.Properties.Settings.MSPInventory_NewConnectionString",strServer);

            

            // show login dialog
            Login frmLogin = new Login(strServer);
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                // show main form if valid login
                Application.Run(new MainFrm(strServer, frmLogin.m_iUserID, frmLogin.m_bIsAdmin));
            }
        }

       
        public static string Encrypt(string strText)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(strText);
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(bytes));
        }
    }
}
