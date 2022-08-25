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
    public partial class ShipInFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;

        public ShipInFrm(MainFrm frmMain, DatabaseMgr dbMgr, string strSerialNo, string strModel)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;

            LoadItemNos();

            // load serial nos
            LoadSerialNos();

            // load equipment models
            LoadEquipmentModels();

            // load locations from outside
            LoadLocationsFromOutside();

            // load persons in charge
            LoadPersonsInCharge();

            //Load location
            //LoadLocation();

            //Load Project
            LoadProject();

            // auto-select
            if (strSerialNo != "")
                cboSerialNo.SelectedIndex = cboSerialNo.FindString(strSerialNo);
            // auto-select
            if (strModel != "")
                cboModel.SelectedIndex = cboModel.FindString(strModel);

            dtPurchaseDate.Value  = m_frmMain.m_dtMinDate ;
            dtLastCalibrationDate.Value = m_frmMain.m_dtMinDate;
            dtNextCalibrationDate.Value = m_frmMain.m_dtMinDate;

            chkAdd.Text = "Add same serial \n with different Model";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // check if serial no. is not empty
            if (cboItem.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Item No.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if serial no. is not empty
            if (!cboItem.Text.ToLower().Contains("prism"))
            {
                if (cboSerialNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the Serial No.", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // check if model is not empty
            if (cboModel.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Model.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if from-location is not empty
            if (cboFrom.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the From field.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if by (person in charge) is not empty
            if (cboBy.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the By field (person-in-charge).", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // save activity/instrument
            try
            {
                int iShipID = -1;
                string strModel = "";
                string strCurrentLoc = "";
                string strDesc = "";
                DateTime datePurchase = new DateTime();
                DateTime dateLastCalibration = new DateTime();
                DateTime dateNextCalibration = new DateTime();
                int IBalIn = 0;
                int IBalOut = 0;
                // get the LocationID 
                //int iLocationID = -1;
                //if (cboLocation.Text.Trim() != "")
                //{
                //    if (!m_frmMain.IsLocationExists(cboLocation.Text.Trim(), ref iLocationID))
                //    {
                //        m_frmMain.AddLocation(cboLocation.Text.Trim(), ref iLocationID);
                //    }
                //}
                int iLocationFromID = -1;
                if (cboFrom.Text.Trim() != "")
                {
                    if (!m_frmMain.IsLocationExists(cboFrom.Text.Trim(), ref iLocationFromID))
                    {
                        m_frmMain.AddLocation(cboFrom.Text.Trim(), ref iLocationFromID);
                    }
                }

                // get the ProjectID 
                int iProjectID = -1;
                if (cboProject.Text.Trim() != "")
                {
                    if (!m_frmMain.IsProjectExists(cboProject.Text.Trim(), ref iProjectID))
                    {
                        m_frmMain.AddProject(cboProject.Text.Trim(), ref iProjectID);
                    }
                }
                int iItemID = -1;
                if (cboItem.Text.Trim() != "")
                {
                    if (!m_frmMain.IsItemNameExists(cboItem.Text.Trim(), ref iItemID))
                    {
                        m_frmMain.AddItem(cboItem.Text.Trim(), ref iItemID);
                    }
                }

                //if (chkAdd.Checked)
                //{
                //    // get the EquipmentModelID of the Model
                //    int iEquipmentModelID = -1;
                //    if (MessageBox.Show(string.Format("Are you sure want to insert the '{0}' with serial no. '{1}'?" + "\n" + "This Serial is already exists with another '{0}'.",cboItem.Text, cboSerialNo.Text), this.Text,
                //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                //        {
                //            m_frmMain.AddEquipmentModel(cboModel.Text.Trim(),iItemID, ref iEquipmentModelID);
                //        }

                //        // if instrument not yet in Equipments table, insert record
                //        m_frmMain.AddEquipment(iItemID, iEquipmentModelID,cboSerialNo.Text.Trim(), cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                //            txtRemarks.Text, dtPurchaseDate.Value, dtLastCalibrationDate.Value, dtNextCalibrationDate.Value,txtDesc.Text,iLocationID,iProjectID,txtStation.Text,numQuantity.Value,0, ref iShipID);

                //        // insert event in Activities record
                //        m_frmMain.AddActivity(iShipID,iItemID, iEquipmentModelID, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                //    }
                //}
                //else
                //{
                //    // get the EquipmentModelID of the Model
                //    int iEquipmentModelID = -1;
                //    if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                //    {
                //        m_frmMain.AddEquipmentModel(cboModel.Text.Trim(),iItemID, ref iEquipmentModelID);
                //    }

                //    // check if serial no. exists
                //    if (m_frmMain.IsSerialNoExists(cboSerialNo.Text.Trim(), ref iShipID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration,ref strDesc,ref IBalIn,ref IBalOut, iEquipmentModelID,iItemID))
                //    {
                //        // if instrument already in Equipments table, update record
                //        string strSQL = string.Format("UPDATE Shipping SET LocationFrom = '{0}', LocationTo = '{1}', PersonInCharge = '{2}', " +
                //            "DateTimeStamp = '{3}', Remarks = '{4}', LastCalibrationDate = '{5}', NextCalibrationDate = '{6}',Description='{7}', " +
                //            "LocationID={8},ProjectID={9},StationName='{10}',QtyIn={11},QtyOut=0,[User]='{12}' WHERE SerialNo = '{13}' and ModelID='{14}' and ItemID={15}",
                //            cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value.ToString(), txtRemarks.Text,
                //            dtLastCalibrationDate.Value.ToString(), dtNextCalibrationDate.Value.ToString(), txtDesc.Text, iLocationID, iProjectID, txtStation.Text, numQuantity.Value + IBalIn, m_frmMain.m_strDisplayName, cboSerialNo.Text.Trim(), iEquipmentModelID, iItemID);
                //        int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                //        // close connection
                //        m_dbMgr.Close();
                //    }
                //    else
                //    {

                //        // if instrument not yet in Equipments table, insert record
                //        m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                //            txtRemarks.Text, dtPurchaseDate.Value, dtLastCalibrationDate.Value, dtNextCalibrationDate.Value,txtDesc.Text,iLocationID,iProjectID,txtStation.Text,numQuantity.Value,0, ref iShipID);
                //    }

                //    // insert event in Activities record
                //    m_frmMain.AddActivity(iShipID,iItemID, iEquipmentModelID, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                //}

                //if (chkAdd.Checked)
                //{
                //    // get the EquipmentModelID of the Model
                //    int iEquipmentModelID = -1;
                //    if (MessageBox.Show(string.Format("Are you sure want to insert the '{0}' with serial no. '{1}'?" + "\n" + "This Serial is already exists with another '{0}'.", cboItem.Text, cboSerialNo.Text), this.Text,
                //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                //        {
                //            m_frmMain.AddEquipmentModel(cboModel.Text.Trim(), iItemID, ref iEquipmentModelID);
                //        }

                //        // if instrument not yet in Equipments table, insert record
                //        m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                //            txtRemarks.Text, dtPurchaseDate.Value, dtLastCalibrationDate.Value, dtNextCalibrationDate.Value, txtDesc.Text, iLocationID, iProjectID, txtStation.Text, numQuantity.Value, 0, ref iShipID);

                //        // insert event in Activities record
                //        //m_frmMain.AddActivity(iShipID, iItemID, iEquipmentModelID, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                //    }
                //}
                //else
                //{
                    // get the EquipmentModelID of the Model
                    int iEquipmentModelID = -1;
                    if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                    {
                        m_frmMain.AddEquipmentModel(cboModel.Text.Trim(), iItemID, ref iEquipmentModelID);
                    }
                    // check if serial no. exists
                    //if (m_frmMain.IsSerialNoExists(cboSerialNo.Text.Trim(), ref iShipID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration, ref strDesc, ref IBalIn, ref IBalOut, iEquipmentModelID, iItemID))
                    //{
                    //    // if instrument already in Equipments table, update record
                    //    string strSQL = string.Format("UPDATE Shipping SET LocationFrom = '{0}', LocationTo = '{1}', PersonInCharge = '{2}', " +
                    //        "DateTimeStamp = '{3}', Remarks = '{4}', LastCalibrationDate = '{5}', NextCalibrationDate = '{6}',Description='{7}', " +
                    //        "LocationID={8},ProjectID={9},StationName='{10}',QtyIn={11},QtyOut=0,[User]='{12}' WHERE SerialNo = '{13}' and ModelID='{14}' and ItemID={15}",
                    //        cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value.ToString(), txtRemarks.Text,
                    //        dtLastCalibrationDate.Value.ToString(), dtNextCalibrationDate.Value.ToString(), txtDesc.Text, iLocationID, iProjectID, txtStation.Text, numQuantity.Value + IBalIn, m_frmMain.m_strDisplayName, cboSerialNo.Text.Trim(), iEquipmentModelID, iItemID);
                    //    int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                    //    // close connection
                    //    m_dbMgr.Close();
                    //}
                    //else
                    //{

                        // if instrument not yet in Equipments table, insert record
                    if (rdoShipIn.Checked)
                    {
                        m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                            txtRemarks.Text,chkPurchase.Checked? dtPurchaseDate.Value: DateTime.MinValue,chkLastCali.Checked? dtLastCalibrationDate.Value:DateTime.MinValue,chkNextCali.Checked? dtNextCalibrationDate.Value:DateTime.MinValue, txtDesc.Text, iProjectID, txtStation.Text, numQuantity.Value, 0, ref iShipID);
                    }
                    if (rdoShipOut.Checked)
                    {
                        string strPDate="";
                        string strLCliDate="";
                        string strNextCliDate="";
                        SelectPurchaseDate(ref strPDate, ref strLCliDate, ref strNextCliDate);
                        m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), Program.m_strMSPOffice, cboFrom.Text.Trim(), cboBy.Text.Trim(), dtDateIn.Value,
                            txtRemarks.Text, strPDate == null ? DateTime.MinValue : Convert.ToDateTime(strPDate), strLCliDate == null ? DateTime.MinValue : Convert.ToDateTime(strLCliDate), strNextCliDate == null ? DateTime.MinValue : Convert.ToDateTime(strNextCliDate), txtDesc.Text, iProjectID, txtStation.Text, 0, numQuantity.Value, ref iShipID);
                    }
                    //}

                    // insert event in Activities record
                    //m_frmMain.AddActivity(iShipID, iItemID, iEquipmentModelID, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
        private void SelectPurchaseDate(ref string strdatePurchase, ref string strdateLastCalibration, ref string strdateNextCalibration)
        {
            try
            {
                string strFilter="";
                int iItemID = -1;
                if (cboItem.Text.Trim() != "")
                {
                    if (m_frmMain.IsItemNameExists(cboItem.Text.Trim(), ref iItemID))
                    {
                        strFilter = strFilter + string.Format(" And S.ItemID={0}",iItemID); 
                    }
                }
                int iEquipmentModelID = -1;
                if (m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                {
                    strFilter = strFilter + string.Format(" And S.ModelID={0}", iEquipmentModelID); 
                }
                if (cboSerialNo.Text.Trim() != "")
                {
                    strFilter = strFilter + string.Format(" And S.SerialNo='{0}'", cboSerialNo.Text.Trim()); 
                }
                string strSQL = string.Format("select max(S.DateTimeStamp) as DateTimeStamp,max(S.purchaseDate) as purchaseDate,max(S.LastCalibrationDate) as LastCalibrationDate," +
                "max(S.NextCalibrationDate) as NextCalibrationDate,I.Name as Item,M.Model,SerialNo from Shipping S left join Item I on S.ItemID=I.ItemID " +
                "left join Model M on S.modelID=M.ModelID where QtyIn >0 {0} group by I.Name,M.Model,serialno", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        strdatePurchase = Convert.ToDateTime(dbRdr["PurchaseDate"]) !=m_frmMain.m_dtMinDate ? Convert.ToString(dbRdr["PurchaseDate"]) : null;
                        strdateLastCalibration = Convert.ToDateTime(dbRdr["LastCalibrationDate"]) != m_frmMain.m_dtMinDate ? Convert.ToString(dbRdr["LastCalibrationDate"]) : null;
                        strdateNextCalibration =Convert.ToDateTime( dbRdr["NextCalibrationDate"]) != m_frmMain.m_dtMinDate ? Convert.ToString(dbRdr["NextCalibrationDate"]) : null;
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

        private void LoadSerialNos()
        {
            try
            {
                // clear equipments list
                cboSerialNo.BeginUpdate();
                cboSerialNo.Items.Clear();

                // check if user exists
                string strSQL = "";
                int iItemID = -1;
                m_frmMain.SelectItem(cboItem.Text, ref iItemID);
                if (rdoShipIn.Checked)
                {
                    strSQL = string.Format("select * from shipping  S where S.LocationTo<>'{0}' and S.ItemID={1} and SerialNo <>'' ", Program.m_strMSPOffice, iItemID);
                }
                else
                {
                    strSQL = string.Format("select * from shipping  S where S.LocationTo='{0}' and S.ItemID={1} and SerialNo <>'' ", Program.m_strMSPOffice, iItemID);
                }
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add serial no
                        cboSerialNo.Items.Add(Convert.ToString(dbRdr["SerialNo"]));
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

        private void LoadItemNos()
        {
            try
            {
                // clear Item list
                cboItem.BeginUpdate();
                cboItem.Items.Clear();

                // check if user exists
                string strSQL = "SELECT Name FROM Item";
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

        private void LoadEquipmentModels()
        {
            try
            {
                // clear equipments list
                cboModel.BeginUpdate();
                cboModel.Items.Clear();

                // check if user exists
                int iItemID = -1;
                m_frmMain.SelectItem(cboItem.Text, ref iItemID);
                string strSQL = string.Format("SELECT Model FROM Model where ItemID={0} ORDER BY Model", iItemID);
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

        //private void LoadLocation()
        //{
        //    try
        //    {
        //        // clear Location list
        //        cboLocation.BeginUpdate();
        //        cboLocation.Items.Clear();

        //        // check if location exists
        //        string strSQL = string.Format("SELECT Name FROM Location ORDER BY Name");
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // add location
        //                cboLocation.Items.Add(Convert.ToString(dbRdr["Name"]));
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh Location list
        //        cboLocation.EndUpdate();
        //        cboLocation.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void LoadProject()
        {
            try
            {
                // clear Project list
                cboProject.BeginUpdate();
                cboProject.Items.Clear();

                // check if Project exists
                string strSQL = string.Format("SELECT Name FROM Project ORDER BY Name");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add Project
                        cboProject.Items.Add(Convert.ToString(dbRdr["Name"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh Project list
                cboProject.EndUpdate();
                cboProject.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadLocationsFromOutside()
        {
            try
            {
                // clear equipments list
                cboFrom.BeginUpdate();
                cboFrom.Items.Clear();

                // check if user exists
                //string strSQL = string.Format("SELECT DISTINCT LocationFrom as Location FROM Activities WHERE LocationFrom <> '{0}' UNION " +
                //    "SELECT DISTINCT LocationTo as Location FROM Activities WHERE LocationTo <> '{0}'", Program.m_strMSPOffice);
                string strSQL = string.Format("SELECT * from Location where Name<>'{0}'", Program.m_strMSPOffice);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add location
                        //cboFrom.Items.Add(Convert.ToString(dbRdr["Location"]));
                        cboFrom.Items.Add(Convert.ToString(dbRdr["Name"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                cboFrom.EndUpdate();
                cboFrom.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadPersonsInCharge()
        {
            try
            {
                // clear equipments list
                cboBy.BeginUpdate();
                cboBy.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT DISTINCT PersonInCharge FROM Activities");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add person in charge
                        cboBy.Items.Add(Convert.ToString(dbRdr["PersonInCharge"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                cboBy.EndUpdate();
                cboBy.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSerialNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboModel.SelectedIndex = -1;
            cboBy.SelectedIndex = -1;
            cboModel.Text = "";
            //cboModel.SelectedIndex = -1;
            cboFrom.SelectedIndex = -1;
            cboBy.SelectedIndex = -1;
            txtRemarks.Text = "";
            cboProject.SelectedIndex = -1;
            txtStation.Text = "";
            txtDesc.Text = "";
            //dtPurchaseDate.Checked = false;
            //dtPurchaseDate.CustomFormat = " ";
            //dtLastCalibrationDate.Checked = false;
            //dtLastCalibrationDate.CustomFormat = " ";
            //dtNextCalibrationDate.Checked = false;
            //dtNextCalibrationDate.CustomFormat = " ";

            if (cboSerialNo.SelectedIndex >= 0 && cboSerialNo.Text.Trim() != "")
            {
                LoadEquipmentInfo(cboSerialNo.Text);
            }

        }

        private void cboSerialNo_Leave(object sender, EventArgs e)
        {
            if (cboSerialNo.Text.Trim() != "")
            {
                LoadEquipmentInfo(cboSerialNo.Text);
            }
        }
        private void SelectModel(string strModel, ref int iEquipmentModelID)
        {
            try
            {
                iEquipmentModelID = -1;
                // check if model exists
                //string strSQL = string.Format("SELECT EquipmentModelID FROM EquipmentModels where model='{0}'", strModel);
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
        public void SelectItem(string strItem, ref int iItemID)
        {
            try
            {
                iItemID = -1;
                // check if model exists
                string strSQL = string.Format("SELECT * FROM Item where Name='{0}'", strItem);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr.Read())
                {
                    //if (dbRdr != null && dbRdr.HasRows)
                    //{
                    iItemID = Convert.ToInt16(dbRdr["ItemID"]);
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

        private void LoadEquipmentInfo(string strSerialNo)
        {
            int iShipID = -1;
            string strModel = "";
            string strCurrentLoc = "";
            string strDesc = "";
            DateTime datePurchase = new DateTime();
            DateTime dateLastCalibration = new DateTime();
            DateTime dateNextCalibration = new DateTime();
            string strdtPurchase="";
            string strdtLastCalibration="";
            string strdtNextCalibration="";
            int IBalIn = 0;
            int IBalOut = 0;
            int iEquipmentModelID = -1;
            SelectModel(cboModel.Text, ref iEquipmentModelID);
            int iItem = -1;
            SelectItem(cboItem.Text.Trim(), ref iItem);

            // check if serial no. exists
            if (m_frmMain.IsSerialNoExists(strSerialNo, ref iShipID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration,ref strDesc,ref IBalIn,ref IBalOut, iEquipmentModelID, iItem))
            {
                cboModel.SelectedIndex = cboModel.FindString(strModel);
                cboFrom.SelectedIndex = cboFrom.FindString(strCurrentLoc);
                txtDesc.Text = strDesc;

                //if (datePurchase != dtPurchaseDate.MinDate)
                //{
                //    if (dtPurchaseDate.Checked) { dtPurchaseDate.Checked = false; }
                //    dtPurchaseDate.Checked = true;
                //    dtPurchaseDate.Value = datePurchase;
                //}
                //else
                //{
                //    dtPurchaseDate.Checked = false;
                //}
                //if (dateLastCalibration != dtLastCalibrationDate.MinDate)
                //{
                //    //if (dtLastCalibrationDate.Checked) { dtLastCalibrationDate.Checked = false; }
                //    //dtLastCalibrationDate.Checked = true;
                //    dtLastCalibrationDate.Value = dateLastCalibration;
                //}
                //else
                //{
                //    dtLastCalibrationDate.Checked = false;
                //}
                //if (dateNextCalibration != dtNextCalibrationDate.MinDate)
                //{
                //    //if (dtNextCalibrationDate.Checked) { dtNextCalibrationDate.Checked = false; }
                //    //dtNextCalibrationDate.Checked = true;
                //    dtNextCalibrationDate.Value = dateNextCalibration;
                //}
                //else
                //{
                //    dtNextCalibrationDate.Checked = false;
                //}

                //dtPurchaseDate.Value = datePurchase;
                //dtLastCalibrationDate.Value = dateLastCalibration;
                //dtNextCalibrationDate.Value = dateNextCalibration;
                
            }
            SelectPurchaseDate(ref strdtPurchase, ref strdtLastCalibration, ref strdtNextCalibration);
            if (strdtPurchase == null || strdtPurchase == "")
            {
                strdtPurchase=m_frmMain.m_dtMinDate.ToString();
            }
            if (strdtLastCalibration == null || strdtLastCalibration == "")
            {
                strdtLastCalibration = m_frmMain.m_dtMinDate.ToString();
            }
            if (strdtNextCalibration == null || strdtNextCalibration == "")
            {
                strdtNextCalibration = m_frmMain.m_dtMinDate.ToString();
            }
            //strdtLastCalibration = strdtLastCalibration == null ? m_frmMain.m_dtMinDate.ToString() : strdtLastCalibration;
            //strdtNextCalibration = strdtNextCalibration == null ? m_frmMain.m_dtMinDate.ToString() : strdtNextCalibration;
            dtPurchaseDate.Value = Convert.ToDateTime(strdtPurchase);
            dtLastCalibrationDate.Value = Convert.ToDateTime(strdtLastCalibration);
            dtNextCalibrationDate.Value = Convert.ToDateTime(strdtNextCalibration);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // get the LocationID 
            //int iLocationID = -1;
            //if (cboLocation.Text.Trim() != "")
            //{
            //    if (!m_frmMain.IsLocationExists(cboLocation.Text.Trim(), ref iLocationID))
            //    {
            //        m_frmMain.AddLocation(cboLocation.Text.Trim(), ref iLocationID);
            //    }
            //}
            // get the ProjectID 
            int iProjectID = -1;
            if (cboProject.Text.Trim() != "")
            {
                if (!m_frmMain.IsProjectExists(cboProject.Text.Trim(), ref iProjectID))
                {
                    m_frmMain.AddProject(cboProject.Text.Trim(), ref iProjectID);
                }
            }
            int iItemID=-1;
            SelectItem(cboItem.Text.Trim(), ref iItemID);

            // if Same serial no with different model, insert record
            int iShipID = -1;
            if (MessageBox.Show(string.Format("Are you sure want to insert the equipment with serial no. '{0}'?" + "\n" + "This Serial is already exists with another equipment.", cboSerialNo.Text), this.Text,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            {
                // get the EquipmentModelID of the Model
                int iEquipmentModelID = -1;
                if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                {
                    m_frmMain.AddEquipmentModel(cboModel.Text.Trim(),iItemID, ref iEquipmentModelID);
                }

                m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                    txtRemarks.Text, chkPurchase.Checked ? dtPurchaseDate.Value : DateTime.MinValue, chkLastCali.Checked ? dtLastCalibrationDate.Value : DateTime.MinValue, chkNextCali.Checked ? dtNextCalibrationDate.Value : DateTime.MinValue, txtDesc.Text, iProjectID, txtStation.Text, numQuantity.Value, 0, ref iShipID);
                // insert event in Activities record
                //m_frmMain.AddActivity(iShipID,iItemID, iEquipmentModelID, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                btnOK.Enabled = false;
            }

        }

        private void LoadData(int iModelID,int iItemID)
        {
            try
            {
                string strLocation = "";
                string strProject = "";

                // check if Project exists
                //string strSQL = string.Format("SELECT E.Description,E.StationName,L.Name as Location,P.Name as Project FROM Equipments E " +
                //    " left join Location L on E.LocationID=L.LocationID left join Project P on E.ProjectID=P.ProjectID where serialNo='{0}' and equipmentModelID='{1}'", cboSerialNo.Text, iEquipmentID);
                //string strSQL = string.Format("SELECT * FROM Equipments E " +
                //    "  where serialNo='{0}' and equipmentModelID='{1}'", cboSerialNo.Text, iEquipmentID);
                string strSQL = string.Format("SELECT * FROM Shipping S " +
                    "  where serialNo='{0}' and ModelID='{1}' and ItemID={2}", cboSerialNo.Text, iModelID, iItemID);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr.Read())
                {
                    //if (dbRdr != null && dbRdr.HasRows)
                    //{
                    txtDesc.Text = Convert.ToString(dbRdr["Description"]);
                    strLocation = Convert.ToString(dbRdr["LocationID"]);
                    strProject = Convert.ToString(dbRdr["ProjectID"]);
                    txtStation.Text = Convert.ToString(dbRdr["StationName"]);
                    //}
                }
                if (dbRdr != null) dbRdr.Close();


                //if (strLocation != "")
                //{
                //    strSQL = string.Format("SELECT * FROM Location " +
                //        "  where LocationID='{0}'", strLocation);
                //    dbRdr = m_dbMgr.ExecuteReader(strSQL);
                //    if (dbRdr.Read())
                //    {
                //        cboLocation.Text = Convert.ToString(dbRdr["Name"]);
                //    }
                //    if (dbRdr != null) dbRdr.Close();
                //}
                if (strProject != "")
                {
                    strSQL = string.Format("SELECT * FROM Project " +
                        "  where ProjectID='{0}'", strProject);
                    dbRdr = m_dbMgr.ExecuteReader(strSQL);
                    if (dbRdr.Read())
                    {
                        cboProject.Text = Convert.ToString(dbRdr["Name"]);
                    }
                }

                // close connection
                m_dbMgr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSerialNo.Text.Trim() != "" && cboModel.Text.Trim() != "" && cboItem.Text.Trim() != "")
            //if (cboModel.Text.Trim() != "" && cboItem.Text.Trim() != "")
            {
                int iItemID = -1;
                SelectItem(cboItem.Text.Trim(),ref iItemID);
                int iEquipmentModelID = -1;
                SelectModel(cboModel.Text, ref iEquipmentModelID);
                //Load Input Data
                LoadData(iEquipmentModelID, iItemID);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load serial nos
            //if (cboItem.Text.Trim().ToLower().Contains("prism"))
            //{
            //    dtLastCalibrationDate.Value = DateTime.MinValue;
            //    dtNextCalibrationDate.Value = DateTime.MinValue ;
            //}
            //cboSerialNo.SelectedIndex = -1;
            //cboModel.SelectedIndex = -1;
            //cboFrom.SelectedIndex = -1;
            //cboBy.SelectedIndex = -1;
            //dtPurchaseDate.Checked = false;
            //dtPurchaseDate.CustomFormat = " ";
            //dtLastCalibrationDate.Checked = false;
            //dtLastCalibrationDate.CustomFormat = " ";
            //dtNextCalibrationDate.Checked = false;
            //dtNextCalibrationDate.CustomFormat = " ";
            //ClearData();
            LoadSerialNos();
            LoadEquipmentModels();
            ClearData(false);
        }
        private void ClearData(bool bItem)
        {
            if (bItem) { cboItem.SelectedIndex = -1; }
            //cboSerialNo.SelectedIndex = -1;
            cboSerialNo.Text = "";
            cboModel.Text = "";
            //cboModel.SelectedIndex = -1;
            cboFrom.SelectedIndex = -1;
            cboBy.SelectedIndex = -1;
            txtRemarks.Text = "";
            cboProject.SelectedIndex = -1;
            txtStation.Text = "";
            txtDesc.Text = "";
            dtPurchaseDate.Value  = m_frmMain.m_dtMinDate;
            dtLastCalibrationDate.Value = m_frmMain.m_dtMinDate;
            dtNextCalibrationDate.Value = m_frmMain.m_dtMinDate;
        }

        private void rdoShipIn_CheckedChanged(object sender, EventArgs e)
        {
            lblLocation.Text = "From";
            groupBox2.Enabled = true;
            ClearData(true);
        }

        private void rdoShipOut_CheckedChanged(object sender, EventArgs e)
        {
            lblLocation.Text = "To";
            groupBox2.Enabled = false;
            ClearData(true);
        }

        private void dtPurchaseDate_ValueChanged(object sender, EventArgs e)
        {
            if (sender != null && sender.GetType() == typeof(DateTimePicker))
            //if (sender.GetType() == typeof(DateTimePicker))
            {
                if (dtPurchaseDate.Value!=m_frmMain.m_dtMinDate)
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
                    chkLastCali.Checked = false;
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

        private void cboModel_Enter(object sender, EventArgs e)
        {
            LoadEquipmentInfo(cboSerialNo.Text);
        }

        private void chkPurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkPurchase.Checked)
            {
                dtPurchaseDate.Value = m_frmMain.m_dtMinDate;
            }
            else
            {
                if (dtPurchaseDate.Value == m_frmMain.m_dtMinDate)
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
