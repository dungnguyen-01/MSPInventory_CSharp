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
    public partial class ModelFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;
        string m_strAction = "";
        string m_TableName = "";
        bool m_bEdit = false;
        public ModelFrm(MainFrm frmMain, DatabaseMgr dbMgr, string strModel,string strItem, string strAction)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;
            cboModel.Text = "";
            cboItem.Text = "";
            txtRemarks.Text = "";
            m_strAction = strAction;

            LoadItems();
            LoadModels("");
            if (strModel != "")
            {
                cboModel.Text = strModel;
                cboItem.Text = strItem;
                cboModel.Enabled = false;
                cboItem.Enabled = false;
                m_bEdit = true;
                SelectData(strItem, strModel);
            }
            else
            {
                cboModel.Enabled = true;
                cboItem.Enabled = true;
                m_bEdit = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!m_bEdit)
            {
                try
                {

                    if (cboModel.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter the Model", this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    int iModelID = -1;
                    if (!m_frmMain.IsModelNameExists(cboModel.Text, ref iModelID))
                    {
                        AddModelName(cboItem.Text);
                    }
                    else
                    {
                        MessageBox.Show("Same Model is already exists.", this.Text,
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
                    EditModelName();
                }
                catch { }
            }
            // close window with OK result
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void SelectData(string strItem,string strModel)
        {
            try
            {
                int iItemID = -1;
                //SelectItem(strItem, ref iItemID);
                m_frmMain.IsItemNameExists(cboItem.Text, ref iItemID);
                string strSQL = string.Format("SELECT * FROM Model where Model='{0}' and ItemID={1}",strModel, iItemID);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {

                    if (dbRdr.Read())
                    {
                        txtRemarks.Text = Convert.ToString(dbRdr["Remarks"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool AddModelName(string strItem)
        {
            try
            {
                int iItemID = -1;
                if (!m_frmMain.IsItemNameExists(strItem, ref iItemID))
                {
                    m_frmMain.AddItem(strItem, ref iItemID);
                }
                // insert Models
                string strSQL = string.Format("INSERT INTO Model (ItemID,Model,Remarks,DateTimeStamp,[User]) VALUES ({0},'{1}','{2}','{3}','{4}')", iItemID, cboModel.Text, txtRemarks.Text, DateTime.Now,m_frmMain.m_strDisplayName);
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
        private bool EditModelName()
        {
            try
            {
                // Edit items
                int iItemID = -1;
                m_frmMain.IsItemNameExists(cboItem.Text, ref iItemID);
                string strSQL = string.Format("Update Model Set Remarks='{0}',DateTimeStamp='{1}',[User]='{2}' where Model='{3}' and ItemID={4} ", txtRemarks.Text, DateTime.Now, m_frmMain.m_strDisplayName, cboModel.Text, iItemID);
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
        //private void LoadSerialNo(string strFilter)
        //{
        //    try
        //    {
        //        // clear equipments list
        //        cboSerial.BeginUpdate();
        //        cboSerial.Items.Clear();

        //        // check if user exists
        //        string strSQL = string.Format("SELECT Distinct SerialNo FROM Model {0}", strFilter);
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // add serial no
        //                cboSerial.Items.Add(Convert.ToString(dbRdr["SerialNo"]));
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh equipments list
        //        cboSerial.EndUpdate();
        //        cboSerial.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void LoadItems()
        {
            try
            {
                // clear equipments list
                cboItem.BeginUpdate();
                cboItem.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT Name FROM Item ");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add serial no
                        cboItem.Items.Add(Convert.ToString(dbRdr["Name"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                cboItem.EndUpdate();
                cboItem.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadModels(string strFilter)
        {
            try
            {
                // clear equipments list
                cboModel.BeginUpdate();
                cboModel.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT Model FROM Model {0}", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add serial no
                        cboModel.Items.Add(Convert.ToString(dbRdr["Model"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                cboModel.EndUpdate();
                cboModel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void cboSerial_Enter(object sender, EventArgs e)
        //{
        //    m_strSerial = cboSerial.Text;
        //}

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {       
            string strFilter = "";
            int iItemID = -1;
            //SelectItem(cboItem.Text,ref iItemID);
            m_frmMain.IsItemNameExists(cboItem.Text, ref iItemID);
            strFilter = string.Format("where ItemID={0}", iItemID);
            LoadModels(strFilter);
            //LoadSerialNo(strFilter);
        }

    }
}
