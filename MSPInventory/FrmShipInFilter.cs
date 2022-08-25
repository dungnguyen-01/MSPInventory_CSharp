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
    public partial class FrmShipInFilter : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;
        public FrmShipInFilter(MainFrm frmMain, DatabaseMgr dbMgr)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;
            LoadItems();
            LoadModels();
            LoadLocations();
            LoadProject();

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
            strFilter = string.Format("WHERE a.DateTimeStamp >= '{0}' AND a.DateTimeStamp < '{1}'",
                dtFrom.Value.ToShortDateString(), dtTo.Value.AddDays(1).ToShortDateString());

            //if (m_frmMain.m_strAction == "shipin")
            //{
            //    strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationTo = '{0}' ", Program.m_strMSPOffice);
            //}
            //if (m_frmMain.m_strAction == "shipout")
            //{
            //    strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationTo <> '{0}' ", Program.m_strMSPOffice);
            //}

            int iItemID = -1;
            m_frmMain.SelectItem(cboItem.Text.Trim(), ref iItemID);
            if (cboItem.Text.Trim() != "" && cboItem.SelectedIndex != -1 && iItemID != -1)
            {
                //m_frmMain.SelectItem(cboItem.Text,ref iItemID);
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" S.ItemID = '{0}' ", iItemID);
            }

            if (cboInOut.Text.Trim() != "" && cboInOut.SelectedIndex != -1 )
            {
                if (cboInOut.Text.Trim().ToLower() == "in")
                {
                    strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" S.LocationTo = '{0}' ", Program.m_strMSPOffice);
                }
                else
                {
                    strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" S.LocationTo <> '{0}' ", Program.m_strMSPOffice);
                }
            }

            // check if serial no. is not empty
            if (txtSerialNo.Text.Trim() != "")
            {
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.SerialNo LIKE '%{0}%' ", txtSerialNo.Text.Trim());
            }

            int iModelID = -1;
            m_frmMain.SelectModel(cboModel.Text,iItemID, ref iModelID);
            // check if model is not empty
            if (cboModel.Text.Trim() != "" && cboModel.SelectedIndex != -1 && iModelID != -1)
            {
                //strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" b.Model LIKE '%{0}%' ", cboModel.Text.Trim());
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.ModelID = '{0}' ", iModelID);
            }

            //int iLocationID = -1;
            //m_frmMain.SelectLocation(cboLocationFrom.Text.Trim(), ref iLocationID);
            // check if location is selected
            //if (cboLocationFrom.Text.Trim() != "" && cboLocationFrom.SelectedIndex != -1 )
            //{
            //    strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationFrom = '{0}' ", cboLocationFrom.Text.Trim());
            //}

            if (cboLocTo.Text.Trim() != "" && cboLocTo.SelectedIndex != -1)
            {
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" S.LocationTo = '{0}' ", cboLocTo.Text.Trim());
            }

            int iProjectID = -1;
            m_frmMain.SelectProject(cboProject.Text.Trim(), ref iProjectID);

            if (cboProject.Text.Trim() != "" && cboProject.SelectedIndex != -1 && iProjectID != -1)
            {
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" S.ProjectID = '{0}' ", iProjectID);
            }

            if (txtStation.Text.Trim() != "" )
            {
                strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" S.StationName = '{0}' ", txtStation.Text.Trim());
            }
            m_frmMain.m_strFilter = "";
            m_frmMain.m_strFilter = strFilter;

            // close window with OK result
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //m_frmMain.LoadShipping(strFilter);

        }
        private void LoadModels()
        {
            try
            {
                // clear equipments list
                cboModel.BeginUpdate();
                cboModel.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT Model FROM Model ORDER BY ItemID,ModelID");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add model
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

        private void LoadLocations()
        {
            try
            {
                         
                // clear equipments list
                //cboLocationFrom.BeginUpdate();
                //cboLocationFrom.Items.Clear();
                
                cboLocTo.BeginUpdate();
                //cboLocationFrom.Items.Clear();
                //if (m_frmMain.m_strAction == "ship")
                //{
                //    cboLocTo.Items.Add(Program.m_strMSPOffice);
                //}
                //else
                //{
                //    //cboLocationFrom.Items.Add(Program.m_strMSPOffice);
                //}
                // add ALL and MSP Office
                //cboLocations.Items.Add("ALL");
                //cboLocations.Items.Add(Program.m_strMSPOffice);

                // check if user exists
                //string strSQL = string.Format("SELECT DISTINCT LocationFrom as Location FROM Activities WHERE LocationFrom <> '{0}' UNION " +
                //    "SELECT DISTINCT LocationTo as Location FROM Activities WHERE LocationTo <> '{0}' ORDER BY Location", Program.m_strMSPOffice);
                //string strSQL = string.Format("select * from Location where Name<>'{0}'", Program.m_strMSPOffice);
                string strSQL = string.Format("select * from Location");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add location
                        //if (m_frmMain.m_strAction == "shipin")
                        //{

                        //    cboLocationFrom.Items.Add(Convert.ToString(dbRdr["Name"]));
                        //}
                        //else
                        //{
                        //    cboLocTo.Items.Add(Convert.ToString(dbRdr["Name"]));
                        //}
                        cboLocTo.Items.Add(Convert.ToString(dbRdr["Name"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                //cboLocationFrom.EndUpdate();
                //cboLocationFrom.Refresh();
                
                cboLocTo.EndUpdate();
                cboLocTo.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadProject()
        {
            try
            {
                // clear equipments list
                cboProject.BeginUpdate();
                cboProject.Items.Clear();

                // add ALL and MSP Office
                //cboLocations.Items.Add("ALL");
                //cboLocations.Items.Add(Program.m_strMSPOffice);

                // check if user exists
                //string strSQL = string.Format("SELECT DISTINCT LocationFrom as Location FROM Activities WHERE LocationFrom <> '{0}' UNION " +
                //    "SELECT DISTINCT LocationTo as Location FROM Activities WHERE LocationTo <> '{0}' ORDER BY Location", Program.m_strMSPOffice);
                string strSQL = "select * from Project";
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add location
                        cboProject.Items.Add(Convert.ToString(dbRdr["Name"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                cboProject.EndUpdate();
                cboProject.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
