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
    public partial class UserFrm : Form
    {
        

        bool m_bAdd = true;
        int m_iUserID = -1;
        DatabaseMgr m_dbMgr = null;
        bool m_bPwdChanged = false;

        public UserFrm(bool bAdd, int iUserID, DatabaseMgr dbMgr)
        {
            InitializeComponent();
            m_bAdd = bAdd;
            m_iUserID = iUserID;
            m_dbMgr = dbMgr;

            // load user info if editing
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            if (!m_bAdd)
            {
                try
                {
                    // check if user exists
                    string strSQL = string.Format("SELECT UserName, DisplayName, FirstName, LastName, UserRoleID FROM Users " +
                        "WHERE UserID = {0}", m_iUserID);
                    SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                    if (dbRdr != null && dbRdr.HasRows)
                    {
                        if (dbRdr.Read())
                        {
                            // get user info
                            txtFirstName.Text = Convert.ToString(dbRdr["FirstName"]);
                            txtLastName.Text = Convert.ToString(dbRdr["LastName"]);
                            txtDisplayName.Text = Convert.ToString(dbRdr["DisplayName"]);
                            cboUserRole.SelectedIndex = Convert.ToInt32(dbRdr["UserRoleID"])-1;
                            txtUsername.Text = Convert.ToString(dbRdr["UserName"]);
                            txtPassword.Text = "88888888";
                            txtConfirmPassword.Text = txtPassword.Text;
                        }
                    }
                    if (dbRdr != null) dbRdr.Close();

                    // close connection
                    m_dbMgr.Close();

                    // reset password changed flag
                    m_bPwdChanged = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                cboUserRole.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // check if display name is empty
            if (txtDisplayName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Display Name.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if username is empty
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Username.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if password is empty and if matching
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a Password.", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password does not match confirmed password.  Please re-enter password.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // encrypt password
            string strPassword = Program.Encrypt(txtPassword.Text);

            // save user info
            try
            {
                // form sql string for updating user
                string strSQL = string.Format("UPDATE Users SET UserName = '{0}', " +
                    (m_bPwdChanged ? "Password = '{6}', " : "") + "DisplayName = '{1}', " +
                    "FirstName = '{2}', LastName = '{3}', UserRoleID = {4} WHERE UserID = {5}", txtUsername.Text,
                    txtDisplayName.Text, txtFirstName.Text, txtLastName.Text, getUserRoleIsAdmin(cboUserRole.SelectedIndex),
                    m_iUserID, strPassword);
                if (m_bAdd)
                {
                    // form sql string for adding user
                    strSQL = string.Format("INSERT INTO Users (UserName, Password, DisplayName, FirstName, LastName, UserRoleID) " +
                        "values ('{0}', '{1}', '{2}', '{3}', '{4}', {5})", txtUsername.Text, strPassword,
                        txtDisplayName.Text, txtFirstName.Text, txtLastName.Text, getUserRoleIsAdmin(cboUserRole.SelectedIndex));
                }
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);

                // close connection
                m_dbMgr.Close();

                // reset password changed flag
                m_bPwdChanged = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private object getUserRoleIsAdmin(int selectedIndex)
        {
            if (selectedIndex ==0)
            {
                return (int)UserRoles.SuperAdmin;
            }else if (selectedIndex == 1)
            {
                return (int)UserRoles.Administrator;
            }
            else
            {
                return UserRoles.Viewer;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            m_bPwdChanged = true;
        }

        private void UserFrm_Load(object sender, EventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            cboUserRole.DataSource = db.UserRoles;
            cboUserRole.DisplayMember = "UserRoleID";
        }

        private void cboUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
