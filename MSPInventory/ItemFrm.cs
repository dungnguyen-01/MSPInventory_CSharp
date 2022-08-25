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
    public partial class ItemFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;
        string m_strAction = "";
        string m_TableName = "";
        bool m_bEdit = false;
        public ItemFrm(MainFrm frmMain, DatabaseMgr dbMgr,string strItem,string strRemark,string strAction)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;
            txtItem.Text = "";
            cboItem.Text = "";
            txtRemarks.Text = "";
            m_strAction = strAction;
            cboItem.Enabled = false;
            if (m_strAction == "item")
            {
                m_TableName = "Item";
                label1.Text = "Item Name";
            }
            if (m_strAction == "location")
            {
                m_TableName = "Location";
                label1.Text = "Location";
            }
            if (m_strAction == "project")
            {
                m_TableName = "Project";
                label1.Text = "Project";
            }

            if (strItem !="")
            {
                cboItem.Visible = true;
                txtItem.Visible = false;
                cboItem.Text = strItem;
                txtRemarks.Text = strRemark;
                m_bEdit = true;
            }
            else
            {
                cboItem.Visible = false;
                txtItem.Visible = true;
                m_bEdit = false;
            }
            if (m_bEdit)
            {
                this.Text = strAction + " Edit";
            }
            else
            {
                this.Text = strAction + " Entry";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!m_bEdit)
            {
                try
                {

                    if (txtItem.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter the Name", this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int iItemID = -1;
                    if (!m_frmMain.IsItemExists(txtItem.Text, ref iItemID))
                    {
                        AddItems();
                    }
                    else
                    {
                        MessageBox.Show("Name is already exists.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch { }
            }
            else if (m_bEdit)
            {

                try
                {
                    EditItems();
                }
                catch { }
            }
            // close window with OK result
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }
        private bool AddItems()
        {
            try
            {
                // insert equipment
                string strSQL = string.Format("INSERT INTO {0} (Name,Remarks,DateTimeStamp,[user]) VALUES ('{1}','{2}','{3}','{4}')",m_TableName,txtItem.Text,txtRemarks.Text,DateTime.Now,m_frmMain.m_strDisplayName);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);

                // close connection
                m_dbMgr.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;

        }
        private bool EditItems()
        {
            try
            {
                // Edit items
                string strSQL = string.Format("Update {0} Set Remarks='{1}',DateTimeStamp='{2}',[user]='{3}'  where Name='{4}'", m_TableName, txtRemarks.Text, DateTime.Now,m_frmMain.m_strDisplayName, cboItem.Text);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);

                // close connection
                m_dbMgr.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
