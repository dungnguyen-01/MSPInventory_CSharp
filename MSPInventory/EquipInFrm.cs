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
    public partial class EquipInFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;

        public EquipInFrm(MainFrm frmMain, DatabaseMgr dbMgr, string strSerialNo,string strModel)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;

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


            chkAdd.Text = "Add same serial \n with different Model";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // check if serial no. is not empty
            if (cboSerialNo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Serial No. of the instrument.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if model is not empty
            if (cboModel.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Model of the instrument.", this.Text,
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
                int iEquipmentID = -1;
                string strModel = "";
                string strCurrentLoc = "";
                DateTime datePurchase = new DateTime();
                DateTime dateLastCalibration = new DateTime();
                DateTime dateNextCalibration = new DateTime();
                // get the LocationID 
                int iLocationID = -1;
                if (cboLocation.Text.Trim() != "")
                {
                    if (!m_frmMain.IsLocationExists(cboLocation.Text.Trim(), ref iLocationID))
                    {
                        m_frmMain.AddLocation(cboLocation.Text.Trim(), ref iLocationID);
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

                if (chkAdd.Checked)
                {
                    // get the EquipmentModelID of the Model
                    int iEquipmentModelID = -1;
                    if (MessageBox.Show(string.Format("Are you sure want to insert the equipment with serial no. '{0}'?" + "\n" + "This Serial is already exists with another equipment.", cboSerialNo.Text), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                        {
                            m_frmMain.AddEquipmentModel(cboModel.Text.Trim(),iit ref iEquipmentModelID);
                        }

                        // if instrument not yet in Equipments table, insert record
                        m_frmMain.AddEquipment(cboSerialNo.Text.Trim(), iEquipmentModelID, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                            txtRemarks.Text, dtPurchaseDate.Value, dtLastCalibrationDate.Value, dtNextCalibrationDate.Value,txtDesc.Text,iLocationID,iProjectID,txtStation.Text,1,0, ref iEquipmentID);

                        // insert event in Activities record
                        m_frmMain.AddActivity(iEquipmentID, -1, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                    }
                }
                else
                {
                    // get the EquipmentModelID of the Model
                    int iEquipmentModelID = -1;
                    if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                    {
                        m_frmMain.AddEquipmentModel(cboModel.Text.Trim(), ref iEquipmentModelID);
                    }

                    // check if serial no. exists
                    if (m_frmMain.IsSerialNoExists(cboSerialNo.Text.Trim(), ref iEquipmentID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration, iEquipmentModelID))
                    {
                        // if instrument already in Equipments table, update record
                        string strSQL = string.Format("UPDATE Equipments SET LocationFrom = '{0}', LocationTo = '{1}', PersonInCharge = '{2}', " +
                            "DateTimeStamp = '{3}', Remarks = '{4}', LastCalibrationDate = '{5}', NextCalibrationDate = '{6}',Description='{8}', " +
                            "LocationID={9},ProjectID={10},StationName='{11}',QtyIn=1,QtyOut=0,[User]='{12}' WHERE SerialNo = '{7}' and EquipmentModelID='{13}'",
                            cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value.ToString(), txtRemarks.Text,
                            dtLastCalibrationDate.Value.ToString(), dtNextCalibrationDate.Value.ToString(), cboSerialNo.Text.Trim(), txtDesc.Text, iLocationID, iProjectID, txtStation.Text, m_frmMain.m_strDisplayName, iEquipmentModelID);
                        int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                        // close connection
                        m_dbMgr.Close();
                    }
                    else
                    {

                        // if instrument not yet in Equipments table, insert record
                        m_frmMain.AddEquipment(cboSerialNo.Text.Trim(), iEquipmentModelID, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                            txtRemarks.Text, dtPurchaseDate.Value, dtLastCalibrationDate.Value, dtNextCalibrationDate.Value,txtDesc.Text,iLocationID,iProjectID,txtStation.Text,1,0, ref iEquipmentID);
                    }

                    // insert event in Activities record
                    m_frmMain.AddActivity(iEquipmentID, -1, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                }
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
                string strSQL = string.Format("SELECT SerialNo FROM Equipments WHERE LocationTo <> '{0}'", Program.m_strMSPOffice);
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

        private void LoadEquipmentModels()
        {
            try
            {
                // clear equipments list
                cboModel.BeginUpdate();
                cboModel.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT Model FROM EquipmentModels ORDER BY Model");
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
                cboFrom.BeginUpdate();
                cboFrom.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT DISTINCT LocationFrom as Location FROM Activities WHERE LocationFrom <> '{0}' UNION " +
                    "SELECT DISTINCT LocationTo as Location FROM Activities WHERE LocationTo <> '{0}'", Program.m_strMSPOffice);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add location
                        cboFrom.Items.Add(Convert.ToString(dbRdr["Location"]));
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

        private void LoadEquipmentInfo(string strSerialNo)
        {
            int iEquipmentID = -1;
            string strModel = "";
            string strCurrentLoc = "";
            DateTime datePurchase = new DateTime();
            DateTime dateLastCalibration = new DateTime();
            DateTime dateNextCalibration = new DateTime();
            int iEquipmentModelID = -1;
            SelectModel(cboModel.Text, ref iEquipmentModelID);
            // check if serial no. exists
            if (m_frmMain.IsSerialNoExists(strSerialNo, ref iEquipmentID, ref strModel, ref strCurrentLoc, ref datePurchase, ref dateLastCalibration, ref dateNextCalibration, iEquipmentModelID))
            {
                cboModel.SelectedIndex = cboModel.FindString(strModel);
                cboFrom.SelectedIndex = cboFrom.FindString(strCurrentLoc);
                dtPurchaseDate.Value = datePurchase;
                dtLastCalibrationDate.Value = dateLastCalibration;
                dtNextCalibrationDate.Value = dateNextCalibration;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // get the LocationID 
            int iLocationID = -1;
            if (cboLocation.Text.Trim() != "")
            {
                if (!m_frmMain.IsLocationExists(cboLocation.Text.Trim(), ref iLocationID))
                {
                    m_frmMain.AddLocation(cboLocation.Text.Trim(), ref iLocationID);
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

            // if Same serial no with different model, insert record
            int iEquipmentID = -1;
            if (MessageBox.Show(string.Format("Are you sure want to insert the equipment with serial no. '{0}'?" + "\n" + "This Serial is already exists with another equipment.", cboSerialNo.Text), this.Text,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
            {
                // get the EquipmentModelID of the Model
                int iEquipmentModelID = -1;
                if (!m_frmMain.IsModelExists(cboModel.Text.Trim(), ref iEquipmentModelID))
                {
                    m_frmMain.AddEquipmentModel(cboModel.Text.Trim(), ref iEquipmentModelID);
                }

                m_frmMain.AddEquipment(cboSerialNo.Text.Trim(), iEquipmentModelID, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value,
                    txtRemarks.Text, dtPurchaseDate.Value, dtLastCalibrationDate.Value, dtNextCalibrationDate.Value,txtDesc.Text,iLocationID,iProjectID,txtStation.Text,1,0, ref iEquipmentID);
                // insert event in Activities record
                m_frmMain.AddActivity(iEquipmentID, -1, 1, cboFrom.Text.Trim(), Program.m_strMSPOffice, cboBy.Text.Trim(), dtDateIn.Value, txtRemarks.Text);
                btnOK.Enabled = false;
            }

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


    }
}
