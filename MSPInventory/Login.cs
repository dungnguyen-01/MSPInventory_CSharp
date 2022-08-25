using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MSPInventory
{
    public partial class Login : Form
    {
        private string m_strServer = "";
        public int m_iUserID = 0;
        public int m_bIsAdmin = 3;

        public Login(string strServer)
        {
            InitializeComponent();
            m_strServer = strServer;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // check if valid database server
            DatabaseMgr dbMgr = new DatabaseMgr(m_strServer);
            if (!dbMgr.Open())
            {
                MessageBox.Show("Could not open the database. Please check the database server name.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // set database server
                AppSettings appSettings = new AppSettings();
                if (appSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("You have successfully changed the database server.  Please restart the application.",
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // return abort
                this.DialogResult = DialogResult.Abort;
                return;
            }
            dbMgr.Close(); // close opened connection

            // get username and password from UI
            string strUsername = txtUsername.Text;
            string strPassword = txtPassword.Text;

            // encrypt password
            strPassword = Program.Encrypt(strPassword);

            // check if valid login
            if (IsLoginValid(strUsername, strPassword))
            {
                // return OK
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // invalid login
                MessageBox.Show("Invalid username/password.", Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool IsLoginValid(string strUsername, string strPassword)
        {
            bool bRet = false;
            try
            {
                // initialize db connection
                DatabaseMgr dbMgr = new DatabaseMgr(m_strServer);

                // check if user exists
                string strSQL = string.Format("SELECT a.UserID, a.DisplayName, b.IsAdmin FROM Users a " +
                    "INNER JOIN UserRoles b ON a.UserRoleID = b.UserRoleID " +
                    "WHERE UserName = '{0}' AND Password = '{1}'", strUsername, strPassword);

                //strSQL = string.Format("SELECT a.UserID, a.DisplayName, b.IsAdmin FROM Users a " +
                    //"INNER JOIN UserRoles b ON a.UserRoleID = b.UserRoleID ");

                SqlDataReader dbRdr = dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get user info
                        m_iUserID = Convert.ToInt32(dbRdr["UserID"]);
                        m_bIsAdmin = Convert.ToInt32(dbRdr["IsAdmin"]);

                        bRet = true;
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                dbMgr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bRet;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
