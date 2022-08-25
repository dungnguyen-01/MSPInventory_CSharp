using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSPInventory
{
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();

            // get server from settings file
            SettingsFile fSettings = new SettingsFile(string.Format("{0}\\{1}_settings.txt",
                Application.StartupPath, Application.ProductName.ToLower()));
            txtDbServer.Text = fSettings.GetParam("server");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // get server from UI
            string strServer = txtDbServer.Text;

            // check if valid
            if (strServer.Trim() == "")
            {
                MessageBox.Show("Please enter a database server.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // save to settings file
            SettingsFile fSettings = new SettingsFile(string.Format("{0}\\{1}_settings.txt",
                Application.StartupPath, Application.ProductName.ToLower()));
            fSettings.SetParam("server", strServer);
            fSettings.Save();

            // close window with OK result
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
