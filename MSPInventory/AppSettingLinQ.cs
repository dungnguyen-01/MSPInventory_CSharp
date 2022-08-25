using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSPInventory
{
    public class AppSettingLinQ 
    {

        Configuration config;

        public AppSettingLinQ()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {
            try
            {
                config.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
                config.ConnectionStrings.ConnectionStrings[key].ProviderName = "System.Data.SqlClient";
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                MessageBox.Show("Connect Faild");
            }
            
        }
        

    }
}
