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
    public partial class ShipOutFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;

        public ShipOutFrm(MainFrm frmMain, DatabaseMgr dbMgr, string strSerialNo, string strModel)
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
            LoadLocation();

            //Load Project
            LoadProject();

            // auto-select
            if (strSerialNo != "")
                cboSerialNo.SelectedIndex = cboSerialNo.FindString(strSerialNo);
            // auto-select
            if (strModel != "")
                cboModel.SelectedIndex = cboModel.FindString(strModel);


            //chkAdd.Text = "Add same serial \n with different Model";
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
            if (cboTo.Text.Trim() == "")
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
                int iBal_In = 0;
                int iBal_Out = 0;
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
                if (cboTo.Text.Trim() != "")
                {
                    if (!m_frmMain.IsLocationExists(cboTo.Text.Trim(), ref iLocationFromID))
                    {
                        m_frmMain.AddLocation(cboTo.Text.Trim(), ref iLocationFromID);
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
                        MessageBox.Show("This is new item.Please check it.", this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        //m_frmMain.AddItem(cboItem.Text.Trim(), ref iItemID);
                    }
                }
                // get the EquipmentModelID of the Model
                int iEquipmentModelID = -1;
                if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                {
                    MessageBox.Show("This is new model.Please check it.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                    //m_frmMain.AddEquipmentModel(cboModel.Text.Trim(),iItemID, ref iEquipmentModelID);
                }

                // check if serial no. exists
                //if (m_frmMain.IsSerialNoExists(cboSerialNo.Text.Trim(), ref iShipID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration,ref strDesc,ref iBal_In,ref iBal_Out, iEquipmentModelID,iItemID))
                //{
                //    // if instrument already in Equipments table, update record
                //    string strSQL = string.Format("UPDATE Shipping SET LocationFrom = '{0}', LocationTo = '{1}', PersonInCharge = '{2}', " +
                //        "DateTimeStamp = '{3}', Remarks = '{4}',Description='{5}', " +
                //        "LocationID={6},ProjectID={7},StationName='{8}',QtyIn=0,QtyOut={9},[User]='{10}' WHERE SerialNo = '{11}' and ModelID='{12}' and ItemID={13}",
                //        Program.m_strMSPOffice,cboTo.Text.Trim(), cboBy.Text.Trim(), dtDateOut.Value.ToString(), txtRemarks.Text,
                //        txtDesc.Text, iLocationID, iProjectID, txtStation.Text,iBal_Out-numQuantity.Value, m_frmMain.m_strDisplayName, cboSerialNo.Text.Trim(), iEquipmentModelID, iItemID);
                //    int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                //    // close connection
                //    m_dbMgr.Close();
                //}
                //else
                //{
                //    // if instrument not yet in Equipments table, insert record
                //    m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), cboTo.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateOut.Value,
                //        txtRemarks.Text, dtDateOut.Value, dtDateOut.Value, dtDateOut.Value, txtDesc.Text, iLocationID, iProjectID, txtStation.Text, numQuantity.Value, 0, ref iShipID);
                //}

                //// insert event in Activities record
                //m_frmMain.AddActivity(iShipID,iItemID, iEquipmentModelID, 1, cboTo.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateOut.Value, txtRemarks.Text);

                // if instrument not yet in Equipments table, insert record
                m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), Program.m_strMSPOffice,cboTo.Text.Trim(), cboBy.Text.Trim(), dtDateOut.Value,
                    txtRemarks.Text, dtDateOut.Value, dtDateOut.Value, dtDateOut.Value, txtDesc.Text, iProjectID, txtStation.Text, 0,numQuantity.Value, ref iShipID);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void LoadSerialNos()
        {
            try
            {
                // clear equipments list
                cboSerialNo.BeginUpdate();
                cboSerialNo.Items.Clear();

                // check if user exists
                int iItemID = -1;
                m_frmMain.SelectItem(cboItem.Text, ref iItemID);
                string strSQL = string.Format("select * from shipping  S where S.LocationTo='{0}' and S.ItemID={1} and SerialNo <>'' ", Program.m_strMSPOffice, iItemID);
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

        private void LoadLocation()
        {
            try
            {
                // clear Location list
                cboLocation.BeginUpdate();
                cboLocation.Items.Clear();

                // check if location exists
                string strSQL = string.Format("SELECT Name FROM Location ORDER BY Name");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add location
                        cboLocation.Items.Add(Convert.ToString(dbRdr["Name"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh Location list
                cboLocation.EndUpdate();
                cboLocation.Refresh();
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
                cboTo.BeginUpdate();
                cboTo.Items.Clear();

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
                        cboTo.Items.Add(Convert.ToString(dbRdr["Name"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                cboTo.EndUpdate();
                cboTo.Refresh();
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
                string strSQL = string.Format("SELECT EquipmentModelID FROM EquipmentModels where model='{0}'", strModel);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr.Read())
                {
                    //if (dbRdr != null && dbRdr.HasRows)
                    //{
                    iEquipmentModelID = Convert.ToInt16(dbRdr["EquipmentModelID"]);
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
            int iBal_In = 0;
            int iBal_Out = 0;
            DateTime datePurchase = new DateTime();
            DateTime dateLastCalibration = new DateTime();
            DateTime dateNextCalibration = new DateTime();
            int iEquipmentModelID = -1;
            SelectModel(cboModel.Text, ref iEquipmentModelID);
            int iItem = -1;
            SelectItem(cboItem.Text.Trim(), ref iItem);

            // check if serial no. exists
            if (m_frmMain.IsSerialNoExists(strSerialNo, ref iShipID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration,ref strDesc,ref iBal_In,ref iBal_Out, iEquipmentModelID, iItem))
            {
                cboModel.SelectedIndex = cboModel.FindString(strModel);
                //cboTo.SelectedIndex = cboTo.FindString(strCurrentLoc);
                //dtPurchaseDate.Value = datePurchase;
                //dtLastCalibrationDate.Value = dateLastCalibration;
                //dtNextCalibrationDate.Value = dateNextCalibration;
                txtDesc.Text = strDesc;
            }
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
            //if (MessageBox.Show(string.Format("Are you sure want to insert the equipment with serial no. '{0}'?" + "\n" + "This Serial is already exists with another equipment.", cboSerialNo.Text), this.Text,
            //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    // get the EquipmentModelID of the Model
            //    int iEquipmentModelID = -1;
            //    if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
            //    {
            //        m_frmMain.AddEquipmentModel(cboModel.Text.Trim(),iItemID, ref iEquipmentModelID);
            //    }

            //    m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), cboTo.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateOut.Value,
            //        txtRemarks.Text, dtDateOut.Value, dtDateOut.Value, dtDateOut.Value, txtDesc.Text, iLocationID, iProjectID, txtStation.Text, numQuantity.Value, 0, ref iShipID);
            //    // insert event in Activities record
            //    m_frmMain.AddActivity(iShipID,iItemID, iEquipmentModelID, 1, cboTo.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateOut.Value, txtRemarks.Text);
            //    btnOK.Enabled = false;
            //}
            int iEquipmentModelID = -1;
            if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
            {
                m_frmMain.AddEquipmentModel(cboModel.Text.Trim(), iItemID, ref iEquipmentModelID);
            }

            m_frmMain.AddEquipment(iItemID, iEquipmentModelID, cboSerialNo.Text.Trim(), Program.m_strMSPOffice, cboTo.Text.Trim(), cboBy.Text.Trim(), dtDateOut.Value,
                txtRemarks.Text, dtDateOut.Value, dtDateOut.Value, dtDateOut.Value, txtDesc.Text,  iProjectID, txtStation.Text, 0, numQuantity.Value, ref iShipID);

        }

        private void LoadData(int iEquipmentID)
        {
            try
            {
                string strLocation = "";
                string strProject = "";

                // check if Project exists
                //string strSQL = string.Format("SELECT E.Description,E.StationName,L.Name as Location,P.Name as Project FROM Equipments E " +
                //    " left join Location L on E.LocationID=L.LocationID left join Project P on E.ProjectID=P.ProjectID where serialNo='{0}' and equipmentModelID='{1}'", cboSerialNo.Text, iEquipmentID);
                string strSQL = string.Format("SELECT * FROM Equipments E " +
                    "  where serialNo='{0}' and equipmentModelID='{1}'", cboSerialNo.Text, iEquipmentID);
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


                if (strLocation != "")
                {
                    strSQL = string.Format("SELECT * FROM Location " +
                        "  where LocationID='{0}'", strLocation);
                    dbRdr = m_dbMgr.ExecuteReader(strSQL);
                    if (dbRdr.Read())
                    {
                        cboLocation.Text = Convert.ToString(dbRdr["Name"]);
                    }
                    if (dbRdr != null) dbRdr.Close();
                }
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
            if (cboSerialNo.Text.Trim() != "" && cboModel.Text.Trim() != "")
            {
                int iEquipmentModelID = -1;
                SelectModel(cboModel.Text, ref iEquipmentModelID);
                //Load Input Data
                LoadData(iEquipmentModelID);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load serial nos
            cboSerialNo.SelectedIndex = -1;
            cboModel.SelectedIndex = -1;
            LoadSerialNos();
            LoadEquipmentModels();
        }


    }
}
