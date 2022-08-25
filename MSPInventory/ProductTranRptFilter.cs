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
    public partial class ProductTranRptFilter : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;
        public ProductTranRptFilter(MainFrm frmMain, DatabaseMgr dbMgr)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;
            LoadItems();
            LoadSerialNo();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            if (dtFrom.Value.Date > dtTo.Value.Date)
            {
                MessageBox.Show("From-Date cannot be later than To-Date.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // get from-date and to-date
            strFilter = string.Format("WHERE Date >= '{0}' AND Date < '{1}'",
                dtFrom.Value.ToShortDateString(), dtTo.Value.AddDays(1).ToShortDateString());


            int iItemID = -1;
            m_frmMain.SelectItem(cboItem.Text.Trim(), ref iItemID);
            if (cboItem.Text.Trim() != "" && cboItem.SelectedIndex != -1 && iItemID != -1)
            {
                //m_frmMain.SelectItem(cboItem.Text,ref iItemID);
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" ItemID = '{0}' ", iItemID);
            }

            if (cboSerialNo.Text.Trim() != "" && cboSerialNo.SelectedIndex != -1)
            {
                //m_frmMain.SelectItem(cboItem.Text,ref iItemID);
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" SerialNo = '{0}' ", cboSerialNo.Text);
            }

            m_frmMain.m_strFilter = "";
            m_frmMain.m_strFilter = strFilter;

            // close window with OK result
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //m_frmMain.LoadShipping(strFilter);

        }
        private void LoadItems()
        {
            try
            {
                // clear equipments list
                cboItem.BeginUpdate();
                cboItem.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT Name FROM Item ORDER BY ItemID");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add model
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
        private void LoadSerialNo()
        {
            try
            {
                // clear equipments list
                cboSerialNo.BeginUpdate();
                cboSerialNo.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT distinct SerialNo FROM Shipping ORDER BY SerialNo");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add model
                        if (Convert.ToString(dbRdr["SerialNo"]) != "")
                        {
                            cboSerialNo.Items.Add(Convert.ToString(dbRdr["SerialNo"]));
                        }
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                cboSerialNo.EndUpdate();
                cboSerialNo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
