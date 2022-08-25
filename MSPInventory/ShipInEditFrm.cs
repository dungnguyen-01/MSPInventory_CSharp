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
    public partial class ShipInEditFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;
        int m_iActivityID = -1;
        string m_strModel = "";
        string m_ShipID = "";

        public ShipInEditFrm(MainFrm frmMain, DatabaseMgr dbMgr,string strShipID, string strItem, string strSerialNo,int iEquipmentModelID,int iItemID,string strItemName)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;
            m_ShipID = strShipID;
            // load equipment models
            LoadEquipmentModels(iItemID);
            LoadProject();
            // show serial no
            txtSerialNo.Text = strSerialNo;
            txtItem.Text = strItemName;
            LoadEquipmentInfo(strShipID,txtSerialNo.Text, iEquipmentModelID, iItemID);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // check if model is not empty
            if (cboModel.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Model of the Item.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // save update
            try
            {
                int iShipID = -1;
                string strModel = "";
                string strCurrentLoc = "";
                string strDesc = "";
                string strProject = "";
                string strStation = "";
                string strRemarks = "";

                DateTime datePurchase = new DateTime();
                DateTime dateLastCalibration = new DateTime();
                DateTime dateNextCalibration = new DateTime();
                // check if serial no. exists

                int iItemID = -1;
                m_frmMain.SelectItem(txtItem.Text, ref iItemID);
                // get the EquipmentModelID of the Model
                int iEquipmentModelID = -1;
                if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                {
                    m_frmMain.AddEquipmentModel(cboModel.Text.Trim(),iItemID, ref iEquipmentModelID);
                }
                if (m_strModel == "")
                {
                    m_strModel = cboModel.Text;
                }
                //get the Old EquipmentModelID
                int iOldEquipmentModelID = -1;
                SelectModel(m_strModel, ref iOldEquipmentModelID);
                int iProjectID = -1;
                m_frmMain.SelectProject(cboProject.Text.Trim(), ref iProjectID);

                if (IsSerialNoExists(m_ShipID,txtSerialNo.Text.Trim(), ref iShipID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration, ref strDesc, ref strProject, ref strStation, ref strRemarks, iOldEquipmentModelID, iItemID))
                {
                    string strdtPurchase = "";
                    string strdtLastCalibration = "";
                    string strdtNextCalibration = "";
                    //if (!dtPurchaseDate.Checked)
                    //{
                    //    strdtPurchase = null;
                    //}
                    //else
                    //{
                    //    strdtPurchase = dtPurchaseDate.Value.ToString();
                    //}
                    //if (!dtLastCalibrationDate.Checked)
                    //{
                    //    strdtLastCalibration = null;
                    //}
                    //else
                    //{
                    //    strdtLastCalibration = dtLastCalibrationDate.Value.ToString();
                    //}
                    //if (!dtNextCalibrationDate.Checked)
                    //{
                    //    strdtNextCalibration = null;
                    //}
                    //else
                    //{
                    //    strdtNextCalibration = dtNextCalibrationDate.Value.ToString();
                    //}
                    if (!chkPurchase.Checked)
                    {
                        strdtPurchase = null;
                    }
                    else
                    {
                        strdtPurchase = dtPurchaseDate.Value.ToString();
                    }
                    if (!chkLastCali.Checked)
                    {
                        strdtLastCalibration = null;
                    }
                    else
                    {
                        strdtLastCalibration = dtLastCalibrationDate.Value.ToString();
                    }
                    if (!chkNextCali.Checked)
                    {
                        strdtNextCalibration = null;
                    }
                    else
                    {
                        strdtNextCalibration = dtNextCalibrationDate.Value.ToString();
                    }

                    string strSQL = "";
                    // if instrument already in Equipments table, update record
                    strSQL = string.Format("UPDATE Shipping SET ModelID = {0}, PurchaseDate = '{1}', " +
                    "LastCalibrationDate = '{2}', NextCalibrationDate = '{3}', Description='{4}',ProjectID={5},StationName='{6}',Remarks='{7}' WHERE SerialNo = '{8}' and ItemID={9} and ModelID={10} and ShipID={11}",
                    iEquipmentModelID, strdtPurchase, strdtLastCalibration,
                    strdtNextCalibration, txtDesc.Text.Trim(), iProjectID, txtStation.Text.Trim(), txtRemarks.Text.Trim(), txtSerialNo.Text.Trim(), iItemID, iOldEquipmentModelID, iShipID);


                    int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                    // close connection
                    m_dbMgr.Close();

                    // update last remarks
                    //m_frmMain.UpdateLastRemarks(iShipID, m_iActivityID, txtRemarks.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
        private void SelectModel(string strModel, ref int iEquipmentModelID)
        {
            try
            {
                iEquipmentModelID = -1;
                // check if model exists
                string strSQL = string.Format("SELECT ModelID FROM Model where model='{0}'", strModel);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr.Read())
                {
                    //if (dbRdr != null && dbRdr.HasRows)
                    //{
                    iEquipmentModelID = Convert.ToInt16(dbRdr["ModelID"]);
                    //}
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

        private void LoadEquipmentModels(int iItemID)
        {
            try
            {
                // clear equipments list
                cboModel.BeginUpdate();
                cboModel.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT Model FROM Model where ItemID='{0}' ORDER BY ItemID", iItemID);
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

        private void LoadEquipmentInfo(string strShipID, string strSerialNo,int iEquipmentModelID,int iItemID)
        {
            int iEquipmentID = -1;
            int iShipID = -1;
            string strModel = "";
            string strCurrentLoc = "";
            string strDesc = "";
            string strProject = "";
            string strStation = "";
            string strRemarks = "";
            DateTime datePurchase = new DateTime();
            DateTime dateLastCalibration = new DateTime();
            DateTime dateNextCalibration = new DateTime();
            // check if serial no. exists
            if (IsSerialNoExists(strShipID,strSerialNo, ref iShipID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration, ref strDesc, ref strProject, ref strStation, ref strRemarks, iEquipmentModelID, iItemID))
            {
                cboModel.SelectedIndex = cboModel.FindString(strModel);
                dtPurchaseDate.Value = datePurchase;
                dtLastCalibrationDate.Value = dateLastCalibration;
                dtNextCalibrationDate.Value = dateNextCalibration;
                txtDesc.Text = strDesc;
                if(strProject!="")
                cboProject.SelectedIndex = cboProject.FindString(strProject);
                txtStation.Text = strStation;
                //string strRemarks = "";
                //m_frmMain.GetLastRemarks(iShipID, ref m_iActivityID, ref strRemarks);
                txtRemarks.Text = strRemarks;
            }
        }
        private bool IsSerialNoExists(string strShipID, string strSerialNo, ref int iShipID, ref string strModel, ref string strCurrentLoc,
    ref DateTime datePurchase, ref DateTime dateLastCalibration, ref DateTime dateNextCalibration, ref string strDesc,ref string strProject,ref string strStation,ref string strRemarks, int iEquipmentModelID, int iItemID)
        {
            bool bRet = false;
            try
            {
                // check if instrument exists
                string strSQL = "";
                //if (iEquipmentModelID != -1 || iEquipmentModelID != null)
                if (iEquipmentModelID != -1)
                {
                    strSQL = string.Format("SELECT ShipID,S.ModelID, M.Model, LocationTo, PurchaseDate, LastCalibrationDate, NextCalibrationDate,Description,P.Name as Project,S.StationName,S.Remarks " +
                    "FROM Shipping  S left join Model M on S.ModelID=M.ModelID Left Join Project P on S.ProjectID=P.ProjectID" +
                    " WHERE ShipID={0} and SerialNo = '{1}' and S.ModelID={2} and S.ItemID={3} ",strShipID, strSerialNo, iEquipmentModelID, iItemID);
                }
                else
                {
                    strSQL = string.Format("SELECT ShipID,S.ModelID, M.Model, LocationTo, PurchaseDate, LastCalibrationDate, NextCalibrationDate,Description,P.Name as Project,S.StationName,S.Remarks " +
                    "FROM Shipping S INNER JOIN Model M ON S.ModelID = M.ModelID Left Join Project P on S.ProjectID=P.ProjectID" +
                    "WHERE ShipID={0} and SerialNo = '{1}' and S.ItemID={2}", strShipID, strSerialNo, iItemID);
                }
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iShipID = Convert.ToInt32(dbRdr["ShipID"]);
                        strModel = Convert.ToString(dbRdr["Model"]);
                        strCurrentLoc = Convert.ToString(dbRdr["LocationTo"]);
                        datePurchase = Convert.ToDateTime(dbRdr["PurchaseDate"]) != m_frmMain.m_dtMinDate ? Convert.ToDateTime(dbRdr["PurchaseDate"]) : m_frmMain.m_dtMinDate;
                        dateLastCalibration = Convert.ToDateTime(dbRdr["LastCalibrationDate"]) != m_frmMain.m_dtMinDate ? Convert.ToDateTime(dbRdr["LastCalibrationDate"]) : m_frmMain.m_dtMinDate;
                        dateNextCalibration = Convert.ToDateTime(dbRdr["NextCalibrationDate"]) != m_frmMain.m_dtMinDate ? Convert.ToDateTime(dbRdr["NextCalibrationDate"]) : m_frmMain.m_dtMinDate;
                        strDesc = Convert.ToString(dbRdr["Description"]);
                        strProject = Convert.ToString(dbRdr["Project"]);
                        strStation = Convert.ToString(dbRdr["StationName"]);
                        strRemarks = Convert.ToString(dbRdr["Remarks"]);

                        bRet = true; // serial no. exists
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
            return bRet;
        }

        private void cboModel_Enter(object sender, EventArgs e)
        {
            m_strModel = cboModel.Text;
        }

        private void dtPurchaseDate_ValueChanged(object sender, EventArgs e)
        {
            
            if (sender != null && sender.GetType() == typeof(DateTimePicker))
            //if (sender.GetType() == typeof(DateTimePicker))
            {
                if (dtPurchaseDate.Value != m_frmMain.m_dtMinDate)
                {
                    //dtPurchaseDate.Checked = true;
                    chkPurchase.Checked = true;
                    ((DateTimePicker)(sender)).CustomFormat = "dd/MM/yyyy hh:mm tt";
                }
                else
                {
                    //dtPurchaseDate.Checked = false;
                    chkPurchase.Checked = false;
                    ((DateTimePicker)(sender)).CustomFormat = " ";
                }
                //if (((DateTimePicker)(sender)).Value == DateTime.MinValue)
                //{
                //    ((DateTimePicker)(sender)).CustomFormat = " ";
                //    //checkBoxDate.Checked = false;
                //    dtPurchaseDate.Checked = false;
                //}
                //else
                //{
                //    ((DateTimePicker)(sender)).CustomFormat = "dd/MM/yyyy hh:mm tt";
                //    //checkBoxDate.Checked = true;
                //    dtPurchaseDate.Checked = true;
                //}
            }
        }

        private void dtLastCalibrationDate_ValueChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(DateTimePicker))
            {
                if (dtLastCalibrationDate.Value != m_frmMain.m_dtMinDate)
                {
                    //dtLastCalibrationDate.Checked = true;
                    chkLastCali.Checked = true;
                    ((DateTimePicker)(sender)).CustomFormat = "dd/MM/yyyy hh:mm tt";
                }
                else
                {
                    //dtLastCalibrationDate.Checked = false;
                    chkLastCali.Checked = false ;
                    ((DateTimePicker)(sender)).CustomFormat = " ";
                }
            }

        }

        private void dtNextCalibrationDate_ValueChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(DateTimePicker))
            {
                if (dtNextCalibrationDate.Value != m_frmMain.m_dtMinDate)
                {
                    //dtNextCalibrationDate.Checked = true;
                    chkNextCali.Checked = true;
                    ((DateTimePicker)(sender)).CustomFormat = "dd/MM/yyyy hh:mm tt";
                }
                else
                {
                    //dtNextCalibrationDate.Checked = false;
                    chkNextCali.Checked = false;
                    ((DateTimePicker)(sender)).CustomFormat = " ";
                }
            }

        }

        private void chkPurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPurchase.Checked)
            {
                dtPurchaseDate.Value = m_frmMain.m_dtMinDate;
            }
            else
            {
                if(dtPurchaseDate.Value==m_frmMain.m_dtMinDate)
                dtPurchaseDate.Value = DateTime.Now;// "dd/MM/yyyy hh:mm tt";
            }
        }

        private void chkLastCali_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkLastCali.Checked)
            {
                dtLastCalibrationDate.Value = m_frmMain.m_dtMinDate;
            }
            else
            {
                if (dtLastCalibrationDate.Value == m_frmMain.m_dtMinDate)
                dtLastCalibrationDate.Value = DateTime.Now;// "dd/MM/yyyy hh:mm tt";
            }

        }

        private void chkNextCali_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNextCali.Checked)
            {
                dtNextCalibrationDate.Value = m_frmMain.m_dtMinDate;
            }
            else
            {
                if (dtNextCalibrationDate.Value == m_frmMain.m_dtMinDate)
                dtNextCalibrationDate.Value = DateTime.Now;// "dd/MM/yyyy hh:mm tt";
            }
        }

    }
}
