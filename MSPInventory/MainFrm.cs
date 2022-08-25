using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using OutlookBarLibrary.Controls;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Globalization;

namespace MSPInventory
{
    public partial class MainFrm : Form
    {
        private string m_strServer = "";
        private int m_iUserID = 0;
        private int m_bIsAdmin = 3;
        DatabaseMgr m_dbMgr = null;
        public string m_strDisplayName = "";
        private bool m_bForceClose = false;
        public string m_strAction = "item";
        public string m_strFilter = "";
        public DateTime m_dtMinDate = Convert.ToDateTime("1/1/1900");

        public MainFrm(string strServer, int iUserID, int bIsAdmin)
        {
            InitializeComponent();

            // show splash screen
            tmrSplash.Start();

            // get server name
            m_strServer = strServer;
            m_iUserID = iUserID;
            m_bIsAdmin = bIsAdmin;

            // initialize db connection
            m_dbMgr = new DatabaseMgr(m_strServer);

            // get user info
            GetUserInfo();

            // initialize views
            InitializeViews();

            // load users
            LoadUsers();

            // load equipments
            //LoadEquipments("");
            //LoadEquipmentModels();
            //LoadLocations();
            LoadItem("");

            // load prisms
            //LoadPrisms("");
            //LoadPrismTypes();

            // load activities
            //LoadActivities("");
            //LoadActsSerialNos();
            //LoadActsPrismTypes();

           
        }

        private void GetUserInfo()
        {
            try
            {
                // check if user exists
                string strSQL = string.Format("SELECT DisplayName, FirstName, LastName FROM Users " +
                    "WHERE UserID = '{0}'", m_iUserID);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get user info
                        m_strDisplayName = Convert.ToString(dbRdr["DisplayName"]);

                        // show display name in title
                        this.Text = string.Format("{0} - {1}", m_strDisplayName, Application.ProductName);
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

        private void InitializeViews()
        {
            lstUsers.Dock = DockStyle.Fill;
            //lstEquipments.Dock = DockStyle.Fill;
            //lstPrisms.Dock = DockStyle.Fill;
            //lstActivities.Dock = DockStyle.Fill;
            lstItem.Dock = DockStyle.Fill;
            lstModel.Dock = DockStyle.Fill;
            lstShipIn.Dock = DockStyle.Fill;
            lstReport.Dock = DockStyle.Fill;
            gbButtonBar.Dock = DockStyle.Fill;
            gbReport.Dock = DockStyle.Fill;
            lstActivities.Dock = DockStyle.Fill;
            
            splitItems.Visible = false;
            gbReport.Visible = false;
            gbButtonBar.Visible = true;
            btnAdd.Enabled = true;
            // if non-admin user, hide the Users view/functions
            if (m_bIsAdmin == 3)
            {
                // remove/hide users
                outlookBarMain.Items.Remove(outlookBarItemUsers);
                lstUsers.Visible = false;

                // show items view by default
                splitItems.Visible = true;
                lstItem.Visible = true;
                lblRight.Text = "List of Items";

                // also... hide the IN/OUT functions on equipments/prisms
                EnableButton(false);
            }

            if (m_bIsAdmin == 2)
            {
                outlookBarMain.Items.Remove(outlookBarItemUsers);
                lstUsers.Visible = false;
                outlookBarMain.SelectedItem = outlookBarItem;
                splitItems.Visible = true;
            }

            // select default view
            outlookBarMain.SelectedItem = m_bIsAdmin == 1 ? outlookBarItemUsers : outlookBarItem;
        }
        private void EnableButton(bool bEnable)
        {
            // also... unable the Add/Edit/Delete functions on everythings because it is not Admin Account.
            btnAdd.Enabled = bEnable;
            btnEdit.Enabled = bEnable;
            btnDelete.Enabled = bEnable;
        }
        private void outlookBarMain_SelectedItemChanged(object sender, EventArgs e)
        {
            OutlookBar objOutlookBar = (OutlookBar)sender;

            // hide the views first
            lstUsers.Visible = false;
            //lstEquipments.Visible = false;
            //lstPrisms.Visible = false;
            //lstActivities.Visible = false;
            lstItem.Visible = false;
            lstModel.Visible = false;
            lstShipIn.Visible = false;
            lstReport.Visible = false;
            lstActivities.Visible = false;

            lstUsers.Dock = DockStyle.Fill;
            //lstEquipments.Dock = DockStyle.Fill;
            //lstPrisms.Dock = DockStyle.Fill;
            //lstActivities.Dock = DockStyle.Fill;
            lstItem.Dock = DockStyle.Fill;
            lstModel.Dock = DockStyle.Fill;
            lstShipIn.Dock = DockStyle.Fill;
            lstReport.Dock = DockStyle.Fill;
            lstActivities.Dock = DockStyle.Fill;
            gbItems.Dock = DockStyle.Fill;


            // show selected view
            if (objOutlookBar.SelectedItem == outlookBarItemUsers)
            {
                splitItems.Visible = false;
                lstUsers.Visible = true;
                lblRight.Text = "List of Users";
            }
            else if (objOutlookBar.SelectedItem == outlookBarItem)
            {
                splitItems.Visible = true;
                lstItem.Visible = true;
                lblRight.Text = "List of Items";
                gbButtonBar.Visible = true;
                btnAdd.Enabled = true;
                gbReport.Visible = false;
                LoadItem("");
                if (m_bIsAdmin == 3)
                {
                    // also... hide the Add/Edit/Delete functions on everythings.
                    EnableButton(false);
                }
            }
            //else if (objOutlookBar.SelectedItem == outlookBarItemReport)
            //{
            //    lstPrisms.Visible = true;
            //    lblRight.Text = "List of Report";
            //}
            //else if (objOutlookBar.SelectedItem == outlookBarItemActivities)
            //{
            //    lstActivities.Visible = true;
            //    lblRight.Text = "List of Activities";
            //}
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            AppSettings appSettings = new AppSettings();
            if (appSettings.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("You have successfully changed the database server.  Please restart the application.",
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_bForceClose = true;
                this.Close();
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            // show splash screen
            if (!hSplash.IsBusy)
                hSplash.RunWorkerAsync();
        }

        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            // show splash screen
            tmrSplash.Stop();
            mnuAbout_Click(mnuAbout, e);
        }

        private void hSplash_DoWork(object sender, DoWorkEventArgs e)
        {
            // show splash screen
            Splash wndSplash = new Splash();
            wndSplash.ShowDialog();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_bForceClose)
            {
                if (MessageBox.Show("Are you sure you want to close the application?", Application.ProductName,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                {
                    // abort closing
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void LoadUsers()
        {
            try
            {
                // clear users list
                lstUsers.BeginUpdate();
                lstUsers.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT a.UserID, a.DisplayName, a.FirstName, a.LastName, " +
                    "b.UserRoleName, b.IsAdmin FROM Users a " +
                    "INNER JOIN UserRoles b ON a.UserRoleID = b.UserRoleID");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["DisplayName"]);
                        lvItem.Tag = Convert.ToInt32(dbRdr["UserID"]);
                        lvItem.SubItems.Add(string.Format("{0} {1}", Convert.ToString(dbRdr["FirstName"]),
                            Convert.ToString(dbRdr["LastName"])));
                        lvItem.Group = lstUsers.Groups[Convert.ToInt32(dbRdr["IsAdmin"])-1];
                        lvItem.ImageIndex = Convert.ToInt32(dbRdr["IsAdmin"])-1;
                        lstUsers.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh users list
                lstUsers.EndUpdate();
                lstUsers.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadEquipments(string strFilter)
        {
            try
            {
                // clear equipments list
                //lstEquipments.BeginUpdate();
                //lstEquipments.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT a.EquipmentID, a.SerialNo, b.Model, a.LocationFrom, a.LocationTo, a.PersonInCharge, a.DateTimeStamp, " +
                    "a.PurchaseDate, a.LastCalibrationDate, a.NextCalibrationDate, a.Remarks,a.Description,a.StationName,L.Name as Location,P.Name as Project " +
                    "FROM Equipments a INNER JOIN EquipmentModels b ON a.EquipmentModelID = b.EquipmentModelID " + 
                    "Left join Location L on a.locationID=L.LocationID Left join Project P on a.projectID=P.ProjectID {0} ORDER BY a.SerialNo", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["SerialNo"]);
                        lvItem.Tag = Convert.ToInt32(dbRdr["EquipmentID"]);
                        lvItem.ImageIndex = 0;
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Model"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["LocationTo"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["PersonInCharge"])));
                        lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        lvItem.SubItems.Add(dbRdr["PurchaseDate"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["PurchaseDate"])) : "");
                        lvItem.SubItems.Add(dbRdr["LastCalibrationDate"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["LastCalibrationDate"])) : "");
                        lvItem.SubItems.Add(dbRdr["NextCalibrationDate"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["NextCalibrationDate"])) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Description"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Location"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Project"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["StationName"])));
                        //lstEquipments.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                //lstEquipments.EndUpdate();
                //lstEquipments.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadShipping(string strFilter)
        {
            try
            {
                string strName = "";
                int IImangeIndex = 0;
                // clear equipments list
                lstShipIn.BeginUpdate();
                lstShipIn.Items.Clear();

                // check if user exists
                //string strSQL = string.Format("SELECT a.ShipID,I.Name as ItemName, a.SerialNo,a.[user], b.Model, a.LocationFrom, a.LocationTo, a.PersonInCharge, a.DateTimeStamp, " +
                //    "a.PurchaseDate, a.LastCalibrationDate, a.NextCalibrationDate, a.Remarks,a.Description,a.StationName,a.QtyIn,a.QtyOut,L.Name as Location,P.Name as Project " +
                //    "FROM Shipping a INNER JOIN Model b ON a.ModelID = b.ModelID " +
                //    "Left join Location L on a.locationID=L.LocationID Left join Project P on a.projectID=P.ProjectID " +
                //    "Left Join Item I on a.ItemID=I.ItemID  {0} ORDER BY a.SerialNo", strFilter);

                //string strSQL = string.Format("Select a.*,S.LocationTo,S.Remarks,S.[User],S.[Description],P.Name as Project,S.StationName,S.PersonInCharge,S.PurchaseDate,S.LastCalibrationDate,S.NextCalibrationDate From " +
                //"(SELECT  max(a.ShipID) as ShipID,I.Name as ItemName, a.SerialNo, b.Model,max( a.DateTimeStamp) as DateTimeStamp,a.modelID " +
                //"FROM Shipping a Left JOIN Model b ON a.ModelID = b.ModelID Left Join Item I on a.ItemID=I.ItemID  group by I.Name, a.SerialNo, b.Model,a.modelID) a " +
                //"Left join Shipping S on a.ShipID=S.ShipID left join Project P on S.ProjectID=P.ProjectID {0} ORDER BY ItemName,SerialNo,Model", strFilter);
                
                string strSQL = string.Format("Select a.*,S.LocationTo,S.Remarks,S.[User],S.[Description],P.Name as Project," +
                "S.StationName,S.PersonInCharge,S.PurchaseDate,S.LastCalibrationDate,S.NextCalibrationDate From (select A.ShipID,I.Name as ItemName, " +
                "A.SerialNo,b.Model, A.DateTimeStamp,A.ModelID from (select ItemID , SerialNo, ModelID,ShipID ,DateTimeStamp from Shipping E where (select max( DateTimeStamp) " +
                "from Shipping as B where B.ItemID = E.ItemID and B.SerialNo=E.SerialNo and B.ModelID =E.ModelID ) = E.DateTimeStamp) A  Left JOIN Model b " +
                "ON A.ModelID = b.ModelID Left Join Item I on A.ItemID=I.ItemID  group by A.ItemID , A.SerialNo, A.ModelID,A.ShipID ,A.DateTimeStamp,I.Name,b.Model) a " +
                "Left join Shipping S on a.ShipID=S.ShipID left join Project P on S.ProjectID=P.ProjectID {0}  ORDER BY ItemName,SerialNo,Model  ", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["ShipID"]);
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["ItemName"])));
                        strName=string.Format("{0}", Convert.ToString(dbRdr["ItemName"]));
                        lvItem.Tag = Convert.ToInt32(dbRdr["ShipID"]);
                        if (strName.ToLower().Contains("total station"))
                        {
                            IImangeIndex = 0;
                        }
                        else if (strName.ToLower().Contains("prism"))
                        {
                            IImangeIndex = 1;
                        }
                        else if (strName.ToLower().Contains("battery"))
                        {
                            IImangeIndex = 2;
                        }
                        else
                        {
                            IImangeIndex = 3;
                        }
                        lvItem.ImageIndex = IImangeIndex;
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Model"])));
                        lvItem.SubItems.Add(dbRdr["SerialNo"] != DBNull.Value ? Convert.ToString(dbRdr["SerialNo"]) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["LocationTo"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["PersonInCharge"])));
                        //lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        lvItem.SubItems.Add( Convert.ToDateTime( dbRdr["DateTimeStamp"]) != m_dtMinDate ? string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        //lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        lvItem.SubItems.Add(Convert.ToDateTime(dbRdr["PurchaseDate"]) != m_dtMinDate ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["PurchaseDate"])) : "");
                        lvItem.SubItems.Add(Convert.ToDateTime(dbRdr["LastCalibrationDate"]) != m_dtMinDate ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["LastCalibrationDate"])) : "");
                        lvItem.SubItems.Add(Convert.ToDateTime(dbRdr["NextCalibrationDate"]) != m_dtMinDate ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["NextCalibrationDate"])) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["user"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Project"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["StationName"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Description"])));
                        lstShipIn.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                lstShipIn.EndUpdate();
                lstShipIn.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadActivities(string strFilter)
        {
            try
            {
                string strName = "";
                int IImangeIndex = 0;
                // clear equipments list
                lstActivities.BeginUpdate();
                lstActivities.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT a.ShipID,I.Name as ItemName, a.SerialNo,a.[user], b.Model, a.LocationFrom, a.LocationTo, a.PersonInCharge, a.DateTimeStamp, " +
                    "a.PurchaseDate, a.LastCalibrationDate, a.NextCalibrationDate, a.Remarks,a.Description,a.StationName,a.QtyIn,a.QtyOut,L.Name as Location,P.Name as Project " +
                    "FROM Shipping a INNER JOIN Model b ON a.ModelID = b.ModelID " +
                    "Left join Location L on a.locationID=L.LocationID Left join Project P on a.projectID=P.ProjectID " +
                    "Left Join Item I on a.ItemID=I.ItemID  {0} ORDER BY I.Name,b.Model,a.SerialNo,a.DateTimeStamp", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["ShipID"]);
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["ItemName"])));
                        strName = string.Format("{0}", Convert.ToString(dbRdr["ItemName"]));
                        lvItem.Tag = Convert.ToInt32(dbRdr["ShipID"]);
                        if (strName.ToLower().Contains("total station"))
                        {
                            IImangeIndex = 0;
                        }
                        else if (strName.ToLower().Contains("prism"))
                        {
                            IImangeIndex = 1;
                        }
                        else if (strName.ToLower().Contains("battery"))
                        {
                            IImangeIndex = 2;
                        }
                        else
                        {
                            IImangeIndex = 3;
                        }
                        lvItem.ImageIndex = IImangeIndex;
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Model"])));
                        lvItem.SubItems.Add(dbRdr["SerialNo"] != DBNull.Value ? Convert.ToString(dbRdr["SerialNo"]) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["LocationFrom"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["LocationTo"])));
                        if (Convert.ToString(dbRdr["LocationTo"]).Trim() == Program.m_strMSPOffice)
                        {
                            lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["QtyIn"])));
                        }
                        else
                        {
                            lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["QtyOut"])));
                        }
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["PersonInCharge"])));
                        lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        //lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        //lvItem.SubItems.Add(dbRdr["PurchaseDate"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["PurchaseDate"])) : "");
                        lvItem.SubItems.Add(Convert.ToDateTime(dbRdr["PurchaseDate"]) != m_dtMinDate ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["PurchaseDate"])) : "");
                        lvItem.SubItems.Add(Convert.ToDateTime(dbRdr["LastCalibrationDate"]) != m_dtMinDate ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["LastCalibrationDate"])) : "");
                        lvItem.SubItems.Add(Convert.ToDateTime(dbRdr["NextCalibrationDate"]) != m_dtMinDate ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["NextCalibrationDate"])) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Description"])));
                        //lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Location"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Project"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["StationName"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["user"])));
                        lstActivities.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                lstActivities.EndUpdate();
                lstActivities.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadProductTransactionReport(string strFilter)
        {
            try
            {
                string strName = "";
                int IImangeIndex = 0;
                // clear equipments list
                lstReport.BeginUpdate();
                lstReport.Items.Clear();

                // check if user exists
                string strSQL = string.Format("Select * from Product_Transaction_VW {0} order by Name,Model,[date]", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["Name"]);
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Model"])));
                        lvItem.Tag = Convert.ToInt32(dbRdr["ShipID"]);
                        if (lvItem.Text.ToLower().Contains("total station"))
                        {
                            IImangeIndex = 0;
                        }
                        else if (lvItem.Text.ToLower().Contains("prism"))
                        {
                            IImangeIndex = 1;
                        }
                        else if (lvItem.Text.ToLower().Contains("battery"))
                        {
                            IImangeIndex = 2;
                        }
                        else
                        {
                            IImangeIndex = 3;
                        }
                        lvItem.ImageIndex = IImangeIndex;
                        lvItem.SubItems.Add(dbRdr["SerialNo"] != DBNull.Value ? Convert.ToString(dbRdr["SerialNo"]) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Location"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["QtyIn"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["QtyOut"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Balance"])));
                        lvItem.SubItems.Add(dbRdr["Date"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", Convert.ToDateTime(dbRdr["Date"])) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Description"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Project"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["StationName"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["user"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["RequestedBy"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));                        
                        lstReport.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                lstReport.EndUpdate();
                lstReport.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void LoadEquipmentModels()
        //{
        //    try
        //    {
        //        // clear equipments list
        //        cboModel.BeginUpdate();
        //        cboModel.Items.Clear();

        //        // check if user exists
        //        string strSQL = string.Format("SELECT Model FROM EquipmentModels ORDER BY Model");
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // add model
        //                cboModel.Items.Add(Convert.ToString(dbRdr["Model"]));
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh equipments list
        //        cboModel.EndUpdate();
        //        cboModel.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void LoadLocations()
        //{
        //    try
        //    {
        //        // clear equipments list
        //        cboLocations.BeginUpdate();
        //        cboLocations.Items.Clear();

        //        // add ALL and MSP Office
        //        cboLocations.Items.Add("ALL");
        //        cboLocations.Items.Add(Program.m_strMSPOffice);

        //        // check if user exists
        //        string strSQL = string.Format("SELECT DISTINCT LocationFrom as Location FROM Activities WHERE LocationFrom <> '{0}' UNION " +
        //            "SELECT DISTINCT LocationTo as Location FROM Activities WHERE LocationTo <> '{0}' ORDER BY Location", Program.m_strMSPOffice);
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // add location
        //                cboLocations.Items.Add(Convert.ToString(dbRdr["Location"]));
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh equipments list
        //        cboLocations.EndUpdate();
        //        cboLocations.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void LoadPrisms(string strFilter)
        {
            try
            {
                // clear equipments list
                //lstPrisms.BeginUpdate();
                //lstPrisms.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT a.PrismID, b.PrismType, a.Quantity, a.LocationTo, a.PersonInCharge, a.DateTimeStamp " +
                    "FROM Prisms a INNER JOIN PrismTypes b ON a.PrismTypeID = b.PrismTypeID {0}", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["PrismType"]);
                        lvItem.Tag = Convert.ToInt32(dbRdr["PrismID"]);
                        lvItem.ImageIndex = 0;
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Quantity"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["LocationTo"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["PersonInCharge"])));
                        lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        //lstPrisms.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh equipments list
                //lstPrisms.EndUpdate();
                //lstPrisms.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadItem(string strFilter)
        {
            try
            {
                // clear Items list
                lstItem.BeginUpdate();
                lstItem.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT * from Item {0}", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["Name"]);
                        lvItem.Tag = Convert.ToInt32(dbRdr["ItemID"]);
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));
                        lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy hh:mm:ss tt }", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["User"])));
                        lstItem.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh items list
                lstItem.EndUpdate();
                lstItem.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadLocProj(string strFilter)
        {
            try
            {
                // clear Items list
                lstItem.BeginUpdate();
                lstItem.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT * from {0} {1}",m_strAction, strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["Name"]);
                        lvItem.Tag = Convert.ToInt32(dbRdr[m_strAction+ "ID"]);
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));
                        lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy hh:mm:ss tt }", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["User"])));
                        lstItem.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh items list
                lstItem.EndUpdate();
                lstItem.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadModel(string strFilter)
        {
            try
            {
                // clear Items list
                lstModel.BeginUpdate();
                lstModel.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT M.*,I.Name from Model M left join Item I on M.ItemID=I.ItemID {0}", strFilter);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // get user info and add to users list
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = Convert.ToString(dbRdr["Model"]);
                        lvItem.Tag = Convert.ToInt32(dbRdr["ModelID"]);
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Name"])));
                        //lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["SerialNo"])));
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));
                        lvItem.SubItems.Add(dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "");
                        lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["User"])));
                        lstModel.Items.Add(lvItem);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh items list
                lstModel.EndUpdate();
                lstModel.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void LoadPrismTypes()
        //{
        //    try
        //    {
        //        // clear prism type list
        //        cboPrismType.BeginUpdate();
        //        cboPrismType.Items.Clear();

        //        // add a none-selected item
        //        cboPrismType.Items.Add("ALL");

        //        // check if user exists
        //        string strSQL = string.Format("SELECT PrismType FROM PrismTypes");
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // add prism type
        //                cboPrismType.Items.Add(Convert.ToString(dbRdr["PrismType"]));
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh prism type list
        //        cboPrismType.EndUpdate();
        //        cboPrismType.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void LoadActivities(string strFilter)
        //{
        //    try
        //    {
        //        // clear activities list
        //        lstActivities.BeginUpdate();
        //        lstActivities.Items.Clear();

        //        // check if user exists
        //        string strSQL = string.Format("SELECT a.ActivityID, b.SerialNo, d.Model, c.PrismType, a.Quantity, a.LocationFrom, " +
        //            "a.LocationTo, a.PersonInCharge, a.DateTimeStamp, a.Remarks " +
        //            "FROM Activities a LEFT OUTER JOIN Equipments b ON a.EquipmentID = b.EquipmentID " +
        //            "LEFT OUTER JOIN PrismTypes c ON a.PrismTypeID = c.PrismTypeID " +
        //            "LEFT OUTER JOIN EquipmentModels d ON b.EquipmentModelID = d.EquipmentModelID {0} ORDER BY a.DateTimeStamp", strFilter);
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // get user info and add to users list
        //                ListViewItem lvItem = new ListViewItem();
        //                lvItem.Text = dbRdr["DateTimeStamp"] != DBNull.Value ? string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dbRdr["DateTimeStamp"])) : "";
        //                lvItem.Tag = Convert.ToInt32(dbRdr["ActivityID"]);
        //                lvItem.ImageIndex = 0;
        //                lvItem.SubItems.Add(dbRdr["SerialNo"] != DBNull.Value ? Convert.ToString(dbRdr["SerialNo"]) : "-----");
        //                lvItem.SubItems.Add(dbRdr["Model"] != DBNull.Value ? string.Format("{0}", Convert.ToString(dbRdr["Model"])) : "-----");
        //                lvItem.SubItems.Add(dbRdr["PrismType"] != DBNull.Value ? string.Format("{0}", Convert.ToString(dbRdr["PrismType"])) : "-----");
        //                lvItem.SubItems.Add(string.Format("{0}", Convert.ToInt32(dbRdr["Quantity"])));
        //                lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["LocationFrom"])));
        //                lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["LocationTo"])));
        //                lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["PersonInCharge"])));
        //                lvItem.SubItems.Add(string.Format("{0}", Convert.ToString(dbRdr["Remarks"])));

        //                // check if equipment/prism is deleted already
        //                if (lvItem.SubItems[1].Text == "-----" && lvItem.SubItems[2].Text == "-----" && lvItem.SubItems[3].Text == "-----")
        //                    continue;

        //                // add to list
        //                lstActivities.Items.Add(lvItem);
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh activities list
        //        lstActivities.EndUpdate();
        //        lstActivities.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void LoadActsSerialNos()
        //{
        //    try
        //    {
        //        // clear equipments list
        //        cboSerialNoActs.BeginUpdate();
        //        cboSerialNoActs.Items.Clear();

        //        // check if user exists
        //        string strSQL = string.Format("SELECT SerialNo FROM Equipments");
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // add serial no
        //                cboSerialNoActs.Items.Add(Convert.ToString(dbRdr["SerialNo"]));
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh equipments list
        //        cboSerialNoActs.EndUpdate();
        //        cboSerialNoActs.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void LoadActsPrismTypes()
        //{
        //    try
        //    {
        //        // clear prism type list
        //        cboPrismTypeActs.BeginUpdate();
        //        cboPrismTypeActs.Items.Clear();
                
        //        // check if user exists
        //        string strSQL = string.Format("SELECT PrismType FROM PrismTypes");
        //        SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
        //        if (dbRdr != null && dbRdr.HasRows)
        //        {
        //            while (dbRdr.Read())
        //            {
        //                // add prism type
        //                cboPrismTypeActs.Items.Add(Convert.ToString(dbRdr["PrismType"]));
        //            }
        //        }
        //        if (dbRdr != null) dbRdr.Close();

        //        // close connection
        //        m_dbMgr.Close();

        //        // refresh prism type list
        //        cboPrismTypeActs.EndUpdate();
        //        cboPrismTypeActs.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        #region Manage Users buttons

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // show add user form
            UserFrm frmUser = new UserFrm(true, -1, m_dbMgr);
            if (frmUser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            // get user id
            int iUserID = Convert.ToInt32(lstUsers.SelectedItems[0].Tag);

            // show edit user form
            UserFrm frmUser = new UserFrm(false, iUserID, m_dbMgr);
            if (frmUser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // get user id
            int iUserID = Convert.ToInt32(lstUsers.SelectedItems[0].Tag);
            string strUser = lstUsers.SelectedItems[0].Text;

            if (MessageBox.Show(string.Format("Are you sure you want to delete user '{0}'", strUser),
                Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                // delete user
                try
                {
                    string strSQL = string.Format("DELETE FROM Users WHERE UserID = {0}", iUserID);
                    int nRet = m_dbMgr.ExecuteNonQuery(strSQL);

                    // close connection
                    m_dbMgr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // reload users
                LoadUsers();
            }
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUsers.SelectedItems.Count > 0)
            {
                btnEditUser.Enabled = true;
                btnDeleteUser.Enabled = true;
            }
            else
            {
                btnEditUser.Enabled = false;
                btnDeleteUser.Enabled = false;
            }
        }

        private void mnuUsers_Opening(object sender, CancelEventArgs e)
        {
            mnuEditUser.Enabled = lstUsers.SelectedItems.Count == 0 ? false : true;
            mnuDeleteUser.Enabled = lstUsers.SelectedItems.Count == 0 ? false : true;
        }

        #endregion

        #region Equipments buttons

        private void btnEquipmentIn_Click(object sender, EventArgs e)
        {

        }

        //private void btnEquipmentOut_Click(object sender, EventArgs e)
        //{
        //    // check if one equipment is selected
        //    string strSerialNo = "";
        //    string strModel = "";
        //    if (lstEquipments.SelectedItems.Count == 1)
        //    {
        //        ListViewItem lvItem = lstEquipments.SelectedItems[0];
        //        string strCurrLoc = lvItem.SubItems[2].Text;
        //        strModel = lvItem.SubItems[1].Text;
        //        if (strCurrLoc == Program.m_strMSPOffice)
        //            strSerialNo = lvItem.Text;
        //    }

        //    //EquipOutFrm frmEquipOut = new EquipOutFrm(this, m_dbMgr, strSerialNo,strModel);
        //    //if (frmEquipOut.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    //{
        //    //    LoadEquipments("");
        //    //    LoadEquipmentModels();
        //    //    LoadActsSerialNos();
        //    //}
        //}

        //private void btnRefreshEquipment_Click(object sender, EventArgs e)
        //{
        //    string strFilter = "";

        //    // check if serial no. is not empty
        //    if (txtSerialNo.Text.Trim() != "")
        //    {
        //        strFilter = string.Format(" WHERE a.SerialNo LIKE '%{0}%' ", txtSerialNo.Text.Trim());
        //    }

        //    // check if model is not empty
        //    if (cboModel.Text.Trim() != "")
        //    {
        //        strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" b.Model LIKE '%{0}%' ", cboModel.Text.Trim());
        //    }

        //    // check if in/out/all
        //    if (cboInOut.Text.Trim() != "")
        //    {
        //        if (cboInOut.Text.Trim() == "IN")
        //            strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationTo = '{0}' ", Program.m_strMSPOffice);
        //        else if (cboInOut.Text.Trim() == "OUT")
        //            strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationTo <> '{0}' ", Program.m_strMSPOffice);
        //    }

        //    // check if location is selected
        //    if (cboLocations.Text.Trim() != "" && cboLocations.SelectedIndex != 0)
        //    {
        //        strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationTo = '{0}' ", cboLocations.Text.Trim());
        //    }

        //    // refresh equipments
        //    LoadEquipments(strFilter);
        //}



        //private void cboLocations_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // if a location is selected, the In/Out combobox will be set to All, to eliminate its conflict
        //    cboInOut.SelectedIndex = 0;
        //}

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            if (m_strAction == "item")
            {
                ExportToFile(lstItem, m_strAction);
            }
            if (m_strAction == "model")
            {
                ExportToFile(lstModel, m_strAction);
            }
            if (m_strAction == "location")
            {
                ExportToFile(lstItem, m_strAction);
            }
            if (m_strAction == "project")
            {
                ExportToFile(lstItem, m_strAction);
            }
            if (m_strAction == "ship")
            {
                ExportToFile(lstShipIn, m_strAction);
            }
            if (m_strAction == "activities")
            {
                ExportToFile(lstActivities, m_strAction);
            }

        }

        #endregion

        #region Prisms buttons

        //private void btnPrismIn_Click(object sender, EventArgs e)
        //{
        //    // check if one prism type is selected
        //    string strPrismType = "";
        //    string strQuantity = "";
        //    string strLocation = "";
        //    if (lstPrisms.SelectedItems.Count == 1)
        //    {
        //        ListViewItem lvItem = lstPrisms.SelectedItems[0];
        //        string strCurrLoc = lvItem.SubItems[2].Text;
        //        if (strCurrLoc != Program.m_strMSPOffice)
        //        {
        //            strPrismType = lvItem.Text;
        //            strQuantity = lvItem.SubItems[1].Text;
        //            strLocation = strCurrLoc;
        //        }
        //    }

        //    PrismInFrm frmPrismIn = new PrismInFrm(this, m_dbMgr, strPrismType, strQuantity, strLocation);
        //    if (frmPrismIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        LoadPrisms("");
        //        LoadPrismTypes();
        //        LoadActsPrismTypes();
        //    }
        //}

        //private void btnPrismOut_Click(object sender, EventArgs e)
        //{
        //    // check if one prism type is selected
        //    string strPrismType = "";
        //    string strQuantity = "";
        //    if (lstPrisms.SelectedItems.Count == 1)
        //    {
        //        ListViewItem lvItem = lstPrisms.SelectedItems[0];
        //        string strCurrLoc = lvItem.SubItems[2].Text;
        //        if (strCurrLoc == Program.m_strMSPOffice)
        //        {
        //            strPrismType = lvItem.Text;
        //            strQuantity = lvItem.SubItems[1].Text;
        //        }
        //    }

        //    PrismOutFrm frmPrismOut = new PrismOutFrm(this, m_dbMgr, strPrismType, strQuantity);
        //    if (frmPrismOut.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        LoadPrisms("");
        //        LoadPrismTypes();
        //        LoadActsPrismTypes();
        //    }
        //}

        //private void btnRefreshPrism_Click(object sender, EventArgs e)
        //{
        //    string strFilter = "";

        //    // check if prism type is not empty
        //    if (cboPrismType.Text.Trim() != "" && cboPrismType.Text.Trim() != "ALL")
        //    {
        //        strFilter = string.Format("WHERE b.PrismType LIKE '%{0}%'", cboPrismType.Text.Trim());
        //    }

        //    // check if in/out/all
        //    if (cboInOutPrism.Text.Trim() != "")
        //    {
        //        if (cboInOutPrism.Text.Trim() == "IN")
        //            strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationTo = '{0}'", Program.m_strMSPOffice);
        //        else if (cboInOutPrism.Text.Trim() == "OUT")
        //            strFilter = strFilter + (strFilter == "" ? "WHERE" : "AND") + string.Format(" a.LocationTo <> '{0}'", Program.m_strMSPOffice);
        //    }

        //    // refresh prisms
        //    LoadPrisms(strFilter);
        //}

        //private void mnuPrisms_Opening(object sender, CancelEventArgs e)
        //{
        //    if (lstPrisms.SelectedItems.Count == 0 || lstPrisms.SelectedItems.Count > 1 || m_bIsAdmin == false)
        //    {
        //        mnuPrismIn.Enabled = false;
        //        mnuPrismOut.Enabled = false;
        //    }
        //    else
        //    {
        //        ListViewItem lvItem = lstPrisms.SelectedItems[0];
        //        string strCurrLoc = lvItem.SubItems[2].Text;
        //        mnuPrismIn.Enabled = strCurrLoc == Program.m_strMSPOffice ? false : true;
        //        mnuPrismOut.Enabled = strCurrLoc == Program.m_strMSPOffice ? true : false;
        //    }
        //}

        //#endregion

        //#region Activities buttons

        //private void btnRefreshActs_Click(object sender, EventArgs e)
        //{
        //    // check if from-date and to-date are valid
        //    if (dtFrom.Value.Date > dtTo.Value.Date)
        //    {
        //        MessageBox.Show("From-Date cannot be later than To-Date.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // get from-date and to-date
        //    string strFilter = string.Format("WHERE a.DateTimeStamp >= '{0}' AND a.DateTimeStamp < '{1}'",
        //        dtFrom.Value.ToShortDateString(), dtTo.Value.AddDays(1).ToShortDateString());

        //    // prepare for sub-filter
        //    string strSubFilter = "";

        //    // check if serial no. is not empty
        //    if (cboSerialNoActs.Text.Trim() != "")
        //    {
        //        strSubFilter = strSubFilter + (strSubFilter == "" ? "" : " OR ") + string.Format(" b.SerialNo LIKE '%{0}%' ", cboSerialNoActs.Text.Trim());
        //    }

        //    // check if prism type is not empty
        //    if (cboPrismTypeActs.Text.Trim() != "")
        //    {
        //        strSubFilter = strSubFilter + (strSubFilter == "" ? "" : " OR ") + string.Format(" c.PrismType LIKE '%{0}%' ", cboPrismTypeActs.Text.Trim());
        //    }

        //    // check if has sub-filter
        //    if (strSubFilter.Trim() != "")
        //        strFilter = strFilter + " AND (" + strSubFilter + ")";

        //    // refresh activities
        //    LoadActivities(strFilter);
        //}

        #endregion

        public bool IsSerialNoExists(string strSerialNo, ref int iShipID, ref string strModel, ref string strCurrentLoc,
            ref DateTime datePurchase, ref DateTime dateLastCalibration, ref DateTime dateNextCalibration,ref string strDesc,ref int iInBal,ref int iOutBal, int iEquipmentModelID,int iItemID)
        {
            bool bRet = false;
            try
            {
                // check if instrument exists
                string strSQL = "";
                //if (iEquipmentModelID != -1 || iEquipmentModelID != null)
                if (iEquipmentModelID != -1 )
                {
                    //strSQL = string.Format("SELECT ShipID,S.ModelID, M.Model, LocationTo, PurchaseDate, LastCalibrationDate, NextCalibrationDate,Description,QtyIn,QtyOut " +
                    //"FROM Shipping  S left join Model M on S.ModelID=M.ModelID" +
                    //" WHERE SerialNo = '{0}' and S.ModelID={1} and S.ItemID={2}", strSerialNo,iEquipmentModelID,iItemID);
                    
                    strSQL = string.Format("Select Main.*,S.LocationFrom,S.LocationTo,S.Description from (select Max(S.ShipID)as ShipID,max(S.DateTimeStamp) as DateTimeStamp," +
                    "max(S.purchaseDate) as purchaseDate,max(S.LastCalibrationDate) as LastCalibrationDate,max(S.NextCalibrationDate) as NextCalibrationDate," +
                    "I.Name as Item,M.Model,SerialNo,sum(QtyIn) as QtyIn,sum(QtyOut) as QtyOut from Shipping S left join Item I on S.ItemID=I.ItemID left join Model M on S.modelID=M.ModelID  " +
                    "group by I.Name,M.Model,serialno) Main Left join Shipping S on Main.ShipID=S.ShipID " +
                    " WHERE S.SerialNo = '{0}' and S.ModelID={1} and S.ItemID={2}", strSerialNo, iEquipmentModelID, iItemID);
                }
                else
                {
                    //strSQL = string.Format("SELECT ShipID,S.ModelID, M.Model, LocationTo, PurchaseDate, LastCalibrationDate, NextCalibrationDate,Description,QtyIn,QtyOut " +
                    //"FROM Shipping S INNER JOIN Model M ON S.ModelID = M.ModelID " +
                    //"WHERE SerialNo = '{0}' and S.ItemID={1}", strSerialNo,iItemID);
                    strSQL = string.Format("Select Main.*,S.LocationFrom,S.LocationTo,S.Description from (select Max(S.ShipID)as ShipID,max(S.DateTimeStamp) as DateTimeStamp," +
                    "max(S.purchaseDate) as purchaseDate,max(S.LastCalibrationDate) as LastCalibrationDate,max(S.NextCalibrationDate) as NextCalibrationDate," +
                    "I.Name as Item,M.Model,SerialNo,sum(QtyIn) as QtyIn,sum(QtyOut) as QtyOut from Shipping S left join Item I on S.ItemID=I.ItemID left join Model M on S.modelID=M.ModelID  " +
                    "group by I.Name,M.Model,serialno) Main Left join Shipping S on Main.ShipID=S.ShipID " +
                    "WHERE S.SerialNo = '{0}' and S.ItemID={1}", strSerialNo, iItemID);
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
                        //datePurchase = dbRdr["PurchaseDate"] != DBNull.Value ? Convert.ToDateTime(dbRdr["PurchaseDate"]) : DateTime.MinValue ;
                        //dateLastCalibration = dbRdr["LastCalibrationDate"] != DBNull.Value ? Convert.ToDateTime(dbRdr["LastCalibrationDate"]): DateTime.MinValue;
                        //dateNextCalibration = dbRdr["NextCalibrationDate"] != DBNull.Value ? Convert.ToDateTime(dbRdr["NextCalibrationDate"]) : DateTime.MinValue;
                        datePurchase = Convert.ToDateTime(dbRdr["PurchaseDate"]) != m_dtMinDate ? Convert.ToDateTime(dbRdr["PurchaseDate"]) : m_dtMinDate;
                        dateLastCalibration = Convert.ToDateTime(dbRdr["LastCalibrationDate"]) != m_dtMinDate ? Convert.ToDateTime(dbRdr["LastCalibrationDate"]) : m_dtMinDate;
                        dateNextCalibration = Convert.ToDateTime(dbRdr["NextCalibrationDate"]) != m_dtMinDate ? Convert.ToDateTime(dbRdr["NextCalibrationDate"]) : m_dtMinDate;
                        strDesc = Convert.ToString(dbRdr["Description"]);
                        iInBal = Convert.ToInt32(dbRdr["QtyIn"]);
                        iOutBal = Convert.ToInt32(dbRdr["QtyOut"]);

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
        public bool IsModelExists(string strModel, ref int iEquipmentModelID)
        {
            bool bRet = false;
            try
            {
                // check if model exists
                string strSQL = string.Format("SELECT ModelID FROM Model WHERE Model = '{0}'", strModel);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iEquipmentModelID = Convert.ToInt32(dbRdr["ModelID"]);
                        bRet = true; // model exists
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

        public bool IsLocationExists(string strLoc, ref int iLocationID)
        {
            bool bRet = false;
            try
            {
                // check if location exists
                string strSQL = string.Format("SELECT LocationID FROM Location WHERE Name = '{0}'", strLoc);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get Location info
                        iLocationID = Convert.ToInt32(dbRdr["LocationID"]);
                        bRet = true; // Location exists
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
        public bool IsItemExists(string strItem, ref int iItemID)
        {
            bool bRet = false;
            try
            {
                // check if Item exists
                string strSQL = string.Format("SELECT * FROM Item WHERE Name = '{0}'", strItem);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        iItemID = Convert.ToInt32(dbRdr["ItemID"]);
                        bRet = true; // Item exists
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
        public bool IsItemNameExists(string strItem, ref int iItemID)
        {
            bool bRet = false;
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
                    bRet = true;
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
            return bRet;
        }

        public bool IsModelNameExists(string strModel, ref int iModelID)
        {
            bool bRet = false;
            try
            {
                // check if Item exists
                string strSQL = string.Format("SELECT * FROM Model WHERE Model = '{0}'", strModel);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        iModelID = Convert.ToInt32(dbRdr["ModelID"]);
                        bRet = true; // Item exists
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

        public bool IsProjectExists(string strProject, ref int iProjectID)
        {
            bool bRet = false;
            try
            {
                // check if project exists
                string strSQL = string.Format("SELECT ProjectID FROM Project WHERE Name = '{0}'", strProject);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get Project info
                        iProjectID = Convert.ToInt32(dbRdr["ProjectID"]);
                        bRet = true; // Project exists
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
        public bool AddItem(string strItem, ref int iItemID)
        {
            try
            {
                // insert equipment
                string strSQL = string.Format("INSERT INTO Item (Name,DateTimeStamp,[user]) VALUES ('{0}','{1}','{2}')", strItem, DateTime.Now, m_strDisplayName);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                strSQL = string.Format("SELECT ItemID FROM Item WHERE Name = '{0}'", strItem);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get location info
                        iItemID = Convert.ToInt32(dbRdr["ItemID"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

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

        public bool AddLocation(string strLoc, ref int iLocationID)
        {
            try
            {
                // insert Location
                string strSQL = string.Format("INSERT INTO Location (Name,DateTimeStamp,[user]) VALUES ('{0}','{1}','{2}')", strLoc, DateTime.Now, m_strDisplayName);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                // get location id
                strSQL = string.Format("SELECT LocationID FROM Location WHERE Name = '{0}'", strLoc);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get location info
                        iLocationID = Convert.ToInt32(dbRdr["LocationID"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

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
        public bool AddProject(string strProject, ref int iProjectID)
        {
            try
            {
                // insert Project
                string strSQL = string.Format("INSERT INTO Project (Name,DateTimeStamp,[user]) VALUES ('{0}','{1}','{2}')", strProject, DateTime.Now, m_strDisplayName);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                // get Project id
                strSQL = string.Format("SELECT ProjectID FROM Project WHERE Name = '{0}'", strProject);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get Project info
                        iProjectID = Convert.ToInt32(dbRdr["ProjectID"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

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

        public bool AddEquipmentModel(string strModel,int iItem, ref int iEquipmentModelID)
        {
            try
            {
                // insert model
                //string strSQL = string.Format("INSERT INTO Model (Model) VALUES ('{0}')", strModel);
                string strSQL = string.Format("INSERT INTO Model (ItemID,Model,DateTimeStamp,[User]) VALUES ({0},'{1}','{2}','{3}')", iItem, strModel, DateTime.Now, m_strDisplayName);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                // get model id
                strSQL = string.Format("SELECT ModelID FROM Model WHERE Model = '{0}'", strModel);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iEquipmentModelID = Convert.ToInt32(dbRdr["ModelID"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

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

        public bool AddEquipment(int iItemID, int iEquipmentModelID,string strSerialNo, string strLocationFrom, string strLocationTo, string strPersonInCharge,
            DateTime dtStamp, string strRemarks, DateTime dtPurchase, DateTime dtLastCalibration, DateTime dtNextCalibration, string strDesc,
             int iProjectID, string strStation, decimal QtyIn, decimal QtyOut, ref int iShipID)
        {
            try
            {
                // insert equipment
                //string strSQL = string.Format("INSERT INTO Equipments (SerialNo, EquipmentModelID, LocationFrom, LocationTo, PersonInCharge, " +
                //        "DateTimeStamp, Remarks, PurchaseDate, LastCalibrationDate, NextCalibrationDate,Description,LocationID,ProjectID,StationName,QtyIn,QtyOut,[User]) " +
                //        "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}','{10}','{11}','{12}','{13}',{14},{15},'{16}')",
                //        strSerialNo, iEquipmentModelID, strLocationFrom, strLocationTo, strPersonInCharge, dtStamp.ToString(), strRemarks,
                //        dtPurchase.ToString(), dtLastCalibration.ToString(), dtNextCalibration.ToString(), strDesc, iLocationID, iProjectID, strStation, QtyIn, QtyOut, m_strDisplayName);
                string strdtPurchase = "";
                string strdtLastCalibration = "";
                string strdtNextCalibration = "";
                if (dtPurchase == DateTime.MinValue)
                {
                    strdtPurchase = null;
                }
                else
                {
                    strdtPurchase = dtPurchase.ToString();
                }
                if (dtLastCalibration == DateTime.MinValue)
                {
                    strdtLastCalibration = null;
                }
                else
                {
                    strdtLastCalibration = dtLastCalibration.ToString();
                }
                if (dtNextCalibration == DateTime.MinValue)
                {
                    strdtNextCalibration = null;
                }
                else
                {
                    strdtNextCalibration = dtNextCalibration.ToString();
                }

                //string strSQL = string.Format("INSERT INTO Shipping (ItemID,ModelID,SerialNo, LocationFrom, LocationTo, PersonInCharge, " +
                //"DateTimeStamp, Remarks, PurchaseDate, LastCalibrationDate, NextCalibrationDate,Description,ProjectID,StationName,QtyIn,QtyOut,[User]) " +
                //"VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}','{10}','{11}','{12}','{13}',{14},{15},'{16}')",
                //iItemID, iEquipmentModelID, strSerialNo, strLocationFrom, strLocationTo, strPersonInCharge, dtStamp.ToString(), strRemarks,
                //dtPurchase.ToString(), dtLastCalibration.ToString(), dtNextCalibration.ToString(), strDesc, iProjectID, strStation, QtyIn, QtyOut, m_strDisplayName);
                
                string strSQL = string.Format("INSERT INTO Shipping (ItemID,ModelID,SerialNo, LocationFrom, LocationTo, PersonInCharge, " +
                "DateTimeStamp, Remarks, PurchaseDate, LastCalibrationDate, NextCalibrationDate,Description,ProjectID,StationName,QtyIn,QtyOut,[User]) " +
                "VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}','{10}','{11}','{12}','{13}',{14},{15},'{16}')",
                iItemID, iEquipmentModelID, strSerialNo, strLocationFrom, strLocationTo, strPersonInCharge, dtStamp.ToString(), strRemarks,
                strdtPurchase, strdtLastCalibration, strdtNextCalibration, strDesc, iProjectID, strStation, QtyIn, QtyOut, m_strDisplayName);

                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                // get model id
                strSQL = string.Format("SELECT ShipID FROM Shipping WHERE ItemID={0} and ModelID='{1}' and SerialNo = '{2}'", iItemID, iEquipmentModelID, strSerialNo);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iShipID = Convert.ToInt32(dbRdr["ShipID"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

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

        public bool AddActivity(int iShipID,int iItemID, int iModelID, int iQuantity, string strLocationFrom, string strLocationTo, string strPersonInCharge,
            DateTime dtStamp, string strRemarks)
        {
            try
            {
                string strSQL = "";
                // if instrument activity
                if (iItemID != -1 && iModelID == -1)
                {
                    strSQL = string.Format("INSERT INTO Activities (EquipmentID,ItemID, ModelID, Quantity, LocationFrom, LocationTo, PersonInCharge, " +
                        "DateTimeStamp, Remarks) VALUES ({0},{1}, 0, {2}, '{3}', '{4}', '{5}', '{6}', '{7}')",
                        iShipID,iItemID, iQuantity, strLocationFrom, strLocationTo, strPersonInCharge, dtStamp.ToString(), strRemarks);
                }
                // if prism activity
                else if (iItemID == -1 && iModelID != -1)
                {
                    strSQL = string.Format("INSERT INTO Activities (EquipmentID,ItemID, ModelID, Quantity, LocationFrom, LocationTo, PersonInCharge, " +
                        "DateTimeStamp, Remarks) VALUES ({0},0, {1}, {2}, '{3}', '{4}', '{5}', '{6}', '{7}')",
                        iShipID,iModelID, iQuantity, strLocationFrom, strLocationTo, strPersonInCharge, dtStamp.ToString(), strRemarks);
                }
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

        public bool IsPrismTypeExists(string strPrismType, ref int iPrismTypeID)
        {
            bool bRet = false;
            try
            {
                // check if prism type exists
                string strSQL = string.Format("SELECT PrismTypeID FROM PrismTypes WHERE PrismType = '{0}'", strPrismType);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iPrismTypeID = Convert.ToInt32(dbRdr["PrismTypeID"]);
                        bRet = true; // prism type exists
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

        public bool AddPrismType(string strPrismType, ref int iPrismTypeID)
        {
            try
            {
                // insert prism type
                string strSQL = string.Format("INSERT INTO PrismTypes (PrismType) VALUES ('{0}')", strPrismType);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                // get prism type
                strSQL = string.Format("SELECT PrismTypeID FROM PrismTypes WHERE PrismType = '{0}'", strPrismType);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get prism type info
                        iPrismTypeID = Convert.ToInt32(dbRdr["PrismTypeID"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();

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

        public bool AddPrismQuantity(int iPrismTypeID, int iQuantity, string strLocationFrom, string strLocationTo,
            string strPersonInCharge, DateTime dtStamp)
        {
            try
            {
                int iPrismID = -1;
                bool bHasRecord = false;

                // check if prism type/location-to exists in Prisms table; if it exists, get Quantity, and add to incoming quantity
                string strSQL = string.Format("SELECT PrismID, Quantity FROM Prisms WHERE PrismTypeID = {0} AND LocationTo = '{1}'",
                    iPrismTypeID, strLocationTo);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iPrismID = Convert.ToInt32(dbRdr["PrismID"]);
                        int iCurrQty = Convert.ToInt32(dbRdr["Quantity"]);
                        iQuantity += iCurrQty;
                        bHasRecord = true;
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                if (bHasRecord)
                {
                    // then update record
                    strSQL = string.Format("UPDATE Prisms SET Quantity = {0}, LocationFrom = '{1}', LocationTo = '{2}', " +
                        "PersonInCharge = '{3}', DateTimeStamp = '{4}' WHERE PrismID = {5}", iQuantity, strLocationFrom, strLocationTo,
                        strPersonInCharge, dtStamp.ToString(), iPrismID);
                }
                else
                {
                    // if prism type/location-to is not yet in Prisms table, insert new record
                    strSQL = string.Format("INSERT INTO Prisms (PrismTypeID, Quantity, LocationFrom, LocationTo, " +
                        "PersonInCharge, DateTimeStamp) VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}')",
                        iPrismTypeID, iQuantity, strLocationFrom, strLocationTo, strPersonInCharge, dtStamp.ToString());
                }
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

        public bool DeductPrismQuantity(int iPrismTypeID, int iQuantity, string strLocationFrom)
        {
            try
            {
                int iPrismID = -1;
                bool bHasRecord = false;

                // check if prism type/location-to exists in Prisms table; if it exists, get Quantity, and deduct incoming quantity
                string strSQL = string.Format("SELECT PrismID, Quantity FROM Prisms WHERE PrismTypeID = {0} AND LocationTo = '{1}'",
                    iPrismTypeID, strLocationFrom);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iPrismID = Convert.ToInt32(dbRdr["PrismID"]);
                        int iCurrQty = Convert.ToInt32(dbRdr["Quantity"]);
                        iQuantity = iCurrQty - iQuantity;
                        if (iQuantity < 0) iQuantity = 0; // this is to ensure no negative quantity
                        bHasRecord = true;
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                if (bHasRecord)
                {
                    // then update record
                    strSQL = string.Format("UPDATE Prisms SET Quantity = {0} WHERE PrismID = {1}", iQuantity, iPrismID);
                    int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                }

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

        //private void mnuEquipEdit_Click(object sender, EventArgs e)
        //{
        //    // check if one equipment is selected
        //    string strSerialNo = "";
        //    string strModel = "";
        //    string strItem = "";
        //    if (lstEquipments.SelectedItems.Count == 1)
        //    {
        //        ListViewItem lvItem = lstEquipments.SelectedItems[0];
        //        strSerialNo = lvItem.Text;
        //        strModel = lvItem.SubItems[1].Text;
        //    }
        //    int iItemID = -1;
        //    SelectItem(strItem, ref iItemID);           
        //    int iEquipmentModelID=-1;
        //    SelectModel(strModel,iItemID, ref iEquipmentModelID);
        //    //EquipEditFrm frmEquip = new EquipEditFrm(this, m_dbMgr, strSerialNo, iEquipmentModelID);
        //    //if (frmEquip.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    //{
        //    //    LoadEquipments("");
        //    //    //LoadEquipmentModels();
        //    //}
        //}
        public void SelectModel(string strModel,int iItemID, ref int iEquipmentModelID)
        {
            try
            {
                iEquipmentModelID = -1;
                string strSQL = "";
                // check if model exists
                if (iItemID != -1)
                {
                    strSQL = string.Format("SELECT ModelID FROM Model where model='{0}' and itemid={1}", strModel, iItemID);
                }
                else
                {
                    strSQL = string.Format("SELECT ModelID FROM Model where model='{0}'", strModel);
                }
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

        private void mnuEquipDelete_Click(object sender, EventArgs e)
        {

        }

        public bool GetLastRemarks(int iShipID, ref int iActivityID, ref string strRemarks)
        {
            bool bRet = false;
            try
            {
                // check if instrument exists
                string strSQL = string.Format("SELECT ActivityID, Remarks FROM Activities WHERE ActivityID = (SELECT MAX(ActivityID) FROM Activities WHERE EquipmentID = {0})", iShipID);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        iActivityID = Convert.ToInt32(dbRdr["ActivityID"]);
                        strRemarks = Convert.ToString(dbRdr["Remarks"]);
                        bRet = true; // has record
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

        public bool UpdateLastRemarks(int iShipID, int iActivityID, string strRemarks)
        {
            try
            {
                // update remarks on activity record
                string strSQL = string.Format("UPDATE Activities SET Remarks = '{0}' WHERE ActivityID = {1}",
                        strRemarks, iActivityID);
                int nRet = m_dbMgr.ExecuteNonQuery(strSQL);
                strSQL = string.Format("UPDATE Shipping SET Remarks = '{0}' WHERE ShipID = {1}",
                        strRemarks, iShipID);
                nRet = m_dbMgr.ExecuteNonQuery(strSQL);

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

        public bool UpdateRemarks(int iActivityID, string strRemarks)
        {
            try
            {
                // update remarks on activity record
                string strSQL = string.Format("UPDATE Activities SET Remarks = '{0}' WHERE ActivityID = {1}",
                        strRemarks, iActivityID);
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

        //private void mnuEditRemarks_Click(object sender, EventArgs e)
        //{
        //    // check if one equipment is selected
        //    string strDate = "";
        //    string strName = "";
        //    int iActivityID = 0;
        //    string strRemarks = "";
        //    if (lstActivities.SelectedItems.Count == 1)
        //    {
        //        ListViewItem lvItem = lstActivities.SelectedItems[0];
        //        iActivityID = (int)lvItem.Tag;
        //        strDate = lvItem.Text;
        //        if (lvItem.SubItems[1].Text == "-----" && lvItem.SubItems[2].Text == "-----")
        //            strName = lvItem.SubItems[3].Text;
        //        else
        //            strName = lvItem.SubItems[1].Text;
        //        strRemarks = lvItem.SubItems[8].Text;
        //    }

        //    EditActivityFrm frmEditAct = new EditActivityFrm(this, m_dbMgr, strDate, strName, iActivityID, strRemarks);
        //    if (frmEditAct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        btnRefreshActs_Click(sender, e);
        //    }
        //}

        //private void mnuActivities_Opening(object sender, CancelEventArgs e)
        //{
        //    if (lstActivities.SelectedItems.Count == 0 || lstActivities.SelectedItems.Count > 1 || m_bIsAdmin == false)
        //    {
        //        mnuEditRemarks.Enabled = false;
        //    }
        //    else
        //    {
        //        mnuEditRemarks.Enabled = true;
        //    }
        //}
        public bool DeleteEquipment(string strSerialNo)
        {
            try
            {
                // update remarks on activity record
                string strSQL = string.Format("DELETE FROM Equipments WHERE SerialNo = '{0}'", strSerialNo);
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
        public bool DeleteShipIn(string strShipID, string strItem,string strModel,string strSerialNo,string strLocFrom,string strLocTo,string strReqby,string strDate)
        {
            try
            {
                // update remarks on activity record
                int iItemID=-1;
                SelectItem(strItem,ref iItemID);
                int iModelID=-1;
                SelectModel(strModel,iItemID,ref iModelID);
                string strSQL = "";
                if (strSerialNo != "")
                {
                    strSQL = string.Format("DELETE FROM Shipping WHERE ShipID={0} and ItemID={1} and ModelID={2} and SerialNo = '{3}' and  LocationTo='{4}' " +
                    "and PersonInCharge='{5}' and convert(varchar(10),DateTimeStamp,111)='{6}'", strShipID,iItemID, iModelID, strSerialNo, strLocTo, strReqby, strDate);
                }
                else
                {
                    strSQL = string.Format("DELETE FROM Shipping WHERE ShipID={0} and ItemID={1} and ModelID={2} and LocationTo='{3}' " +
                   "and PersonInCharge='{4}' and convert(varchar(10),DateTimeStamp,111)='{5}'",strShipID, iItemID, iModelID, strLocTo, strReqby, strDate);
                }
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
        public int CheckRowtoDelete(string strShipID,string strItem, string strModel, string strSerialNo, string strLocFrom, string strLocTo, string strReqby, string strDate)
        {
            int iCount = 0;
            try
            {
                // update remarks on activity record
                int iItemID = -1;
                SelectItem(strItem, ref iItemID);
                int iModelID = -1;
                SelectModel(strModel, iItemID, ref iModelID);
                string strSQL = "";
                DateTime dtDate =Convert.ToDateTime(strDate);
                if (strSerialNo != "")
                {
                    strSQL = string.Format("Select Count(*) as [count] FROM Shipping WHERE ShipID={0} and ItemID={1} and ModelID={2} and SerialNo = '{3}'  and LocationTo='{4}' " +
                   "and PersonInCharge='{5}' and convert(varchar(10),DateTimeStamp,111)='{6}'",strShipID, iItemID, iModelID, strSerialNo, strLocTo, strReqby, strDate);
                }
                else
                {
                    strSQL = string.Format("Select Count(*) as [count] FROM Shipping WHERE ShipID={0} and ItemID={1} and ModelID={2}  and LocationTo='{3}' " +
                   "and PersonInCharge='{4}' and convert(varchar(10),DateTimeStamp,111)='{5}'",strShipID, iItemID, iModelID, strLocTo, strReqby, strDate);
                }
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr.Read())
                {
                    //if (dbRdr != null && dbRdr.HasRows)
                    //{
                    iCount = Convert.ToInt16(dbRdr["count"]);
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
            return iCount;
        }

        public bool DeleteItem(string strItem,string strTable)
        {
            try
            {
                // update remarks on activity record
                string strSQL = string.Format("DELETE FROM {0} WHERE Name = '{1}'",strTable, strItem);
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
        public bool DeleteModel(string strModel)
        {
            try
            {
                // update remarks on activity record
                string strSQL = string.Format("DELETE FROM Model WHERE Model = '{0}'", strModel);
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

        public bool DeleteActivitie(string strDate,string strSerialNo,string strModel)
        {
            try
            {
                string strEquipmentID = "";
                //for filter
                string strSQL = string.Format("select b.EquipmentID from Equipments b Left Join EquipmentModels d ON b.EquipmentModelID = d.EquipmentModelID " +
                "where b.SerialNo='{0}' and d.Model='{1}' ",strSerialNo, strModel);
                //int nRet1 = m_dbMgr.ExecuteNonQuery(strSQL1);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    if (dbRdr.Read())
                    {
                        // get equipment info
                        strEquipmentID = Convert.ToString(dbRdr["EquipmentID"]);
                    }
                }
                if (dbRdr != null) dbRdr.Close();
                
                // Delete activity record
                strSQL = string.Format("delete from Activities where EquipmentID='{0}' and convert(varchar(10),DateTimeStamp,111) = '{1}'", strEquipmentID, strDate);
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
        private void ExportToFile(ListView lstView,string strName)
        {
            // check if there's record in the list
            if (lstView.Items.Count == 0)
            {
                MessageBox.Show("There is no record in the list.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            // initialize data variable
            object[,] arrData = new object[lstView.Items.Count + 1, lstView.Columns.Count];

            // loop through header columns
            for (int i = 0; i < lstView.Columns.Count; i++)
            {
                arrData[0, i] = lstView.Columns[i].Text;
            }

            // loop through items
            for (int i = 0; i < lstView.Items.Count; i++)
            {
                ListViewItem lvItem = lstView.Items[i];

                // loop through columns
                for (int j = 0; j < lstView.Columns.Count; j++)
                {
                    arrData[i + 1, j] = lvItem.SubItems[j].Text;
                }
            }

            // show save file dialog
            dlgFileSave.FileName = string.Format("{0}_{1:yyyyMMdd_HHmmss}.xls",strName, DateTime.Now);
            dlgFileSave.Filter = "Excel File (*.xls)|*.xls| All files (*.*)|*.*";
            dlgFileSave.FilterIndex = 0;
            if (dlgFileSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // save data to file
                GenerateExcel(dlgFileSave.FileName, arrData, lstView.Items.Count + 1, lstView.Columns.Count);

                // show successfully saved
                MessageBox.Show("Data are successfully saved to a file.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        public void GenerateExcel(string strFilePath, object[,] arrData, int iRow, int iCol)
        {
            Excel.Application xlApp = null;
            Excel._Workbook xlBook = null;
            try
            {
                // open ms excel
                GC.Collect();
                xlApp = new Excel.Application();
                xlBook = (Excel._Workbook)(xlApp.Workbooks.Add(Missing.Value));

                string strSheet = "Data";
                ((Excel._Worksheet)xlBook.Worksheets[1]).Name = strSheet;

                // create excel report
                Excel._Worksheet xlSheet = null;
                Excel.Range xlRange = null;
                try
                {
                    // transfer data
                    xlSheet = (Excel._Worksheet)xlBook.Worksheets[strSheet];
                    for (int i = 1; i <= iCol; i++)
                        xlSheet.Cells[1, i].EntireColumn.NumberFormat = "@";

                    xlRange = xlSheet.get_Range("A1", Missing.Value).get_Resize(iRow, iCol);
                    xlRange.Value2 = arrData;
                    
                    xlRange.Borders[Excel.XlBordersIndex.xlInsideVertical].Weight = Excel.XlBorderWeight.xlThin;
                    xlRange.Borders[Excel.XlBordersIndex.xlInsideHorizontal].Weight = Excel.XlBorderWeight.xlThin;
                    xlRange.Borders.Color = ColorTranslator.ToOle(Color.Black);

                    xlRange = xlSheet.get_Range("A1", Missing.Value).get_Resize(1, iCol);
                    xlRange.Font.Bold = true;
                    xlRange.Font.Size = 12;


                }
                catch { }

                // check range
                if (xlRange != null)
                {
                    // release range
                    Marshal.ReleaseComObject(xlRange);
                    xlRange = null;
                }

                // check worksheet
                if (xlSheet != null)
                {
                    // release worksheet
                    Marshal.ReleaseComObject(xlSheet);
                    xlSheet = null;
                }

                // save excel file
                xlBook.SaveAs(strFilePath, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value);
                xlBook.Close(Missing.Value, Missing.Value, Missing.Value);

                // release resources
                if (xlBook != null)
                {
                    // release workbook
                    Marshal.ReleaseComObject(xlBook);
                    xlBook = null;
                }
            }
            catch { }

            // release workbook
            if (xlBook != null)
            {
                // close workbook
                xlBook.Close(Missing.Value, Missing.Value, Missing.Value);
                Marshal.ReleaseComObject(xlBook);
                xlBook = null;
            }

            // release application
            if (xlApp != null)
            {
                // close excel
                xlApp.Workbooks.Close();
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
                xlApp = null;
            }

            // cleanup
            GC.Collect();
        }

        //private void mnuDeleteActivities_Click(object sender, EventArgs e)
        //{
        //    // check if one Activitie is selected
        //    string strSerialNo = "";
        //    string strDate = "";
        //    string strModel = "";
        //    if (lstActivities.SelectedItems.Count == 1)
        //    {
        //        ListViewItem lvItem = lstActivities.SelectedItems[0];
        //        strDate = DateTime.ParseExact(lvItem.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
        //        strSerialNo = lvItem.SubItems[1].Text;
        //        strModel = lvItem.SubItems[2].Text;
        //    }

        //    if (MessageBox.Show(string.Format("Are you sure want to delete the Activities with serial no. '{0}'?", strSerialNo), this.Text,
        //        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
        //    {
        //        if (DeleteActivitie(strDate,strSerialNo,strModel))
        //        {
        //            //btnRefreshEquipment_Click(sender, e);
        //            //btnRefreshActs_Click(sender, e);
        //            MessageBox.Show("Activitie is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }

        //}

        //private void btnPrism_Click(object sender, EventArgs e)
        //{
        //    splitItems.Visible = true;
        //    lstPrisms.Visible = true;
        //    lstEquipments.Visible = false;
        //    lstActivities.Visible = false;
        //    lblRight.Text = "List of Prism";
        //    panel8.Visible = false;
        //    //panel3.Visible = false;
        //    panel6.Visible = true;
        //    panel6.Dock = DockStyle.Fill;
        //}

        //private void btnEquipment_Click(object sender, EventArgs e)
        //{
        //    splitItems.Visible = true;
        //    lstPrisms.Visible = false;
        //    lstEquipments.Visible = true;
        //    lstActivities.Visible = false;
        //    lblRight.Text = "List of Equipments";
        //    panel8.Visible = false;
        //    //panel3.Visible = true;
        //    panel6.Visible = false;
        //    //panel3.Dock = DockStyle.Fill;

        //}

        //private void btnActivity_Click(object sender, EventArgs e)
        //{
        //    splitItems.Visible = true;
        //    lstPrisms.Visible = false;
        //    lstEquipments.Visible = false;
        //    lstActivities.Visible = true;
        //    lblRight.Text = "List of Activities";
        //    panel8.Visible = true;
        //    //panel3.Visible = false;
        //    panel6.Visible = false;
        //    panel8.Dock = DockStyle.Fill;

        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (m_strAction == "item")
            {

                string strItemName = "";
                string strRemark = "";
                if (m_strAction == "item")
                {
                    if (lstItem.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (lstItem.SelectedItems.Count == 1)
                    {
                        ListViewItem lvItem = lstItem.SelectedItems[0];
                        strItemName = lvItem.Text;
                        strRemark = lvItem.SubItems[1].Text;
                    }
                    ItemFrm frmitem = new ItemFrm(this, m_dbMgr, strItemName, strRemark,m_strAction);
                    if (frmitem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadItem("");
                        //LoadEquipmentModels();
                    }
                }

            }
            if (m_strAction == "model")
            {

                string strModelName = "";
                string strItem = "";
                if (lstModel.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstModel.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstModel.SelectedItems[0];
                    strModelName = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    //strSerial = lvItem.SubItems[2].Text;
                }
                ModelFrm frmModel = new ModelFrm(this, m_dbMgr, strModelName,strItem, m_strAction);
                if (frmModel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadModel("");
                    //LoadEquipmentModels();
                }

            }
            if (m_strAction == "location")
            {

                string strItemName = "";
                string strRemark = "";
                if (m_strAction == "location")
                {
                    if (lstItem.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (lstItem.SelectedItems.Count == 1)
                    {
                        ListViewItem lvItem = lstItem.SelectedItems[0];
                        strItemName = lvItem.Text;
                        strRemark = lvItem.SubItems[1].Text;
                    }
                    ItemFrm frmitem = new ItemFrm(this, m_dbMgr, strItemName, strRemark, m_strAction);
                    if (frmitem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadLocProj("");
                        //LoadEquipmentModels();
                    }
                }

            }
            if (m_strAction == "project")
            {

                string strItemName = "";
                string strRemark = "";
                if (m_strAction == "project")
                {
                    if (lstItem.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (lstItem.SelectedItems.Count == 1)
                    {
                        ListViewItem lvItem = lstItem.SelectedItems[0];
                        strItemName = lvItem.Text;
                        strRemark = lvItem.SubItems[1].Text;
                    }
                    ItemFrm frmitem = new ItemFrm(this, m_dbMgr, strItemName, strRemark, m_strAction);
                    if (frmitem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadLocProj("");
                        //LoadEquipmentModels();
                    }
                }

            }

            if (m_strAction == "ship")
            {
                string strShipID = "";
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                if (lstShipIn.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lstShipIn.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstShipIn.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;

                }
                int iItemID = -1;
                SelectItem(strItem, ref iItemID);
                int iEquipmentModelID = -1;
                SelectModel(strModel, iItemID, ref iEquipmentModelID);
                ShipInEditFrm frmEditShipIn = new ShipInEditFrm(this, m_dbMgr,strShipID, strItem, strSerialNo, iEquipmentModelID, iItemID, strItem);
                if (frmEditShipIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadShipping("");
                    //LoadEquipmentModels();
                }
            }
            if (m_strAction == "activities")
            {
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                string strShipID = "";
                if (lstActivities.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lstActivities.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstActivities.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;

                }
                int iItemID = -1;
                SelectItem(strItem, ref iItemID);
                int iEquipmentModelID = -1;
                SelectModel(strModel, iItemID, ref iEquipmentModelID);
                ShipInEditFrm frmEditShipIn = new ShipInEditFrm(this, m_dbMgr,strShipID, strItem, strSerialNo, iEquipmentModelID, iItemID, strItem);
                if (frmEditShipIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadActivities("");
                    //LoadEquipmentModels();
                }
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_strAction == "item")
            {

                // check if one item is selected
                string strItem = "";
                if (lstItem.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstItem.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstItem.SelectedItems[0];
                    strItem = lvItem.Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this item ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteItem(strItem,m_strAction))
                    {
                        LoadItem("");
                        MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (m_strAction == "model")
            {

                // check if one item is selected
                string strModel = "";
                if (lstModel.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstModel.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstModel.SelectedItems[0];
                    strModel = lvItem.Text;
                    //strSerial = lvItem.SubItems[2].Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this Model ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteModel(strModel))
                    {
                        LoadModel("");
                        MessageBox.Show("Model is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (m_strAction == "location")
            {

                // check if one item is selected
                string strItem = "";
                if (lstItem.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstItem.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstItem.SelectedItems[0];
                    strItem = lvItem.Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this item ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteItem(strItem,m_strAction))
                    {
                        LoadLocProj("");
                        MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (m_strAction == "project")
            {

                // check if one item is selected
                string strItem = "";
                if (lstItem.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstItem.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstItem.SelectedItems[0];
                    strItem = lvItem.Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this item ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteItem(strItem, m_strAction))
                    {
                        LoadLocProj("");
                        MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            if (m_strAction == "ship")
            {
                string strShipID = "";
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                string strLocFrom = "";
                string strLocTo = "";
                string strReqby = "";
                string strDate = "";
                if (lstShipIn.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lstShipIn.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstShipIn.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;
                    //strLocFrom = lvItem.SubItems[4].Text;
                    strLocTo = lvItem.SubItems[4].Text;
                    strReqby = lvItem.SubItems[5].Text;
                    strDate = DateTime.ParseExact(lvItem.SubItems[6].Text, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                    //strDate = DateTime.ParseExact(lvItem.SubItems[5].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat).ToString("yyyy/MM/dd");
                    //strDate = lvItem.SubItems[5].Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete the {0} {1} {2}?", strItem,strSerialNo == "" ? "" : "with serial no.", strSerialNo), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                        if (DeleteShipIn(strShipID, strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate))
                        {
                            //btnRefreshEquipment_Click(sender, e);
                            //btnRefreshActs_Click(sender, e);
                            LoadShipping("");
                            MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                }
            }

            if (m_strAction == "activities")
            {
                string strShipID = "";
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                string strLocFrom = "";
                string strLocTo = "";
                string strReqby = "";
                string strDate = "";
                if (lstActivities.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lstActivities.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstActivities.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;
                    strLocFrom = lvItem.SubItems[4].Text;
                    strLocTo = lvItem.SubItems[5].Text;
                    strReqby = lvItem.SubItems[7].Text;
                    strDate = DateTime.ParseExact(lvItem.SubItems[8].Text, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                    //strDate = DateTime.ParseExact(lvItem.SubItems[5].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat).ToString("yyyy/MM/dd");
                    //strDate = lvItem.SubItems[5].Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete the {0} {1} {2}?", strItem, strSerialNo == "" ? "" : "with serial no.", strSerialNo), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (CheckRowtoDelete(strShipID,strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate) > 1)
                    {
                        if (MessageBox.Show("There are one more row to delete. Do you want to delete all row?", this.Text,
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DeleteShipIn(strShipID, strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate))
                            {
                                //btnRefreshEquipment_Click(sender, e);
                                //btnRefreshActs_Click(sender, e);
                                LoadActivities("");
                                MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                    else
                    {
                        if (DeleteShipIn(strShipID, strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate))
                        {
                            //btnRefreshEquipment_Click(sender, e);
                            //btnRefreshActs_Click(sender, e);
                            LoadActivities("");
                            MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }
            }

        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstShipIn.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = true;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            btnAdd.Enabled = true;
            lblRight.Text = "List of Items";
            m_strAction = "item";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadItem("");
        }

        private void btnShipIn_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = false;
            lstShipIn.Visible = true;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            lblRight.Text = "List of Ship Item";
            m_strAction = "ship";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadShipping("");

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (m_strAction == "item")
            {
                ItemFrm frmItem = new ItemFrm(this, m_dbMgr, "", "", m_strAction);
                if (frmItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadItem("");
                }

            }
            if (m_strAction == "model")
            {
                ModelFrm frmModel = new ModelFrm(this, m_dbMgr,"","", m_strAction);
                if (frmModel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadModel("");
                }

            }
            if (m_strAction == "location")
            {
                ItemFrm frmItem = new ItemFrm(this, m_dbMgr, "", "", m_strAction);
                if (frmItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLocProj("");
                }

            }
            if (m_strAction == "project")
            {
                ItemFrm frmItem = new ItemFrm(this, m_dbMgr, "", "", m_strAction);
                if (frmItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLocProj("");
                }

            }

            if (m_strAction == "ship")
            {
                ShipInFrm frmShipIn = new ShipInFrm(this, m_dbMgr, "", "");
                if (frmShipIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadShipping("");
                }
            }
            //if (m_strAction == "shipout")
            //{
            //    ShipOutFrm frmShipOut = new ShipOutFrm(this, m_dbMgr, "", "");
            //    if (frmShipOut.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        MessageBox.Show("Saving Successful.", this.Text,
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        LoadShipping(string.Format("Where a.LocationTo <> '{0}' ", Program.m_strMSPOffice));
            //    }
            //}

        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            if (m_strAction == "item")
            {
                try
                {
                    ItemFilterFrm frmItemfilter = new ItemFilterFrm(this, m_dbMgr);
                    if (frmItemfilter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadItem(m_strFilter);
                    }
                }
                catch { }
            }
            if (m_strAction == "model")
            {
                try
                {
                    ItemFilterFrm frmItemfilter = new ItemFilterFrm(this, m_dbMgr);
                    if (frmItemfilter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadModel(m_strFilter);
                    }
                }
                catch { }
            }
            if (m_strAction == "location")
            {
                try
                {
                    ItemFilterFrm frmItemfilter = new ItemFilterFrm(this, m_dbMgr);
                    if (frmItemfilter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadLocProj(m_strFilter);
                    }
                }
                catch { }
            }
            if (m_strAction == "project")
            {
                try
                {
                    ItemFilterFrm frmItemfilter = new ItemFilterFrm(this, m_dbMgr);
                    if (frmItemfilter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadLocProj(m_strFilter);
                    }
                }
                catch { }
            }

            if (m_strAction == "ship")
            {
                try
                {
                    FrmShipInFilter frmfilterShipIn = new FrmShipInFilter(this, m_dbMgr);
                    if (frmfilterShipIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadShipping(m_strFilter);
                    }
                }
                catch { }
            }
            if (m_strAction == "activities")
            {
                try
                {
                    FrmActivitiesFilter frmfilterAct = new FrmActivitiesFilter(this, m_dbMgr);
                    if (frmfilterAct.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadActivities(m_strFilter);
                    }
                }
                catch { }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (m_strAction == "item")
            {
                LoadItem("");
            }
            if (m_strAction == "model")
            {
                LoadModel("");
            }
            if (m_strAction == "location")
            {
                LoadLocProj("");
            }
            if (m_strAction == "project")
            {
                LoadLocProj("");
            }
            if (m_strAction == "ship")
            {
                LoadShipping("");
            }
            if (m_strAction == "activities")
            {
                LoadActivities("");
            }
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstItem.Visible = false;
            lstShipIn.Visible = false;
            lstModel.Visible = true;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            lstActivities.Visible = false;
            btnAdd.Enabled = true;
            lblRight.Text = "List of Models";
            m_strAction = "model";
            LoadModel("");
            if (m_bIsAdmin == 3)
                EnableButton(false);
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Add Data", btnAdd);
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Edit Data", btnEdit);
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Delete Data", btnDelete);
        }

        private void btnfilter_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Filter Data", btnfilter);
        }

        private void btnExport_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Export Data", btnExport);
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Refresh Data", btnRefresh);
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
        public void SelectProject(string strPrj, ref int iPrjID)
        {
            try
            {
                iPrjID = -1;
                // check if model exists
                string strSQL = string.Format("SELECT * FROM Project where Name='{0}'", strPrj);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr.Read())
                {
                    //if (dbRdr != null && dbRdr.HasRows)
                    //{
                    iPrjID = Convert.ToInt16(dbRdr["ProjectID"]);
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

        public void SelectLocation(string strLoc, ref int iLocID)
        {
            try
            {
                iLocID = -1;
                // check if model exists
                string strSQL = string.Format("SELECT * FROM Location where Name='{0}'", strLoc);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr.Read())
                {
                    //if (dbRdr != null && dbRdr.HasRows)
                    //{
                    iLocID = Convert.ToInt16(dbRdr["LocationID"]);
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

        private void mnuList_Opening(object sender, CancelEventArgs e)
        {
            ListView lstTemp = new ListView();
            if (lstItem.Visible)
            {
                lstTemp = lstItem;
            }
            if (lstShipIn.Visible)
            {
                lstTemp = lstShipIn;
            }
            if (lstModel.Visible)
            {
                lstTemp = lstModel;
            }
            //if (lstlocation.Visible)
            //{
            //    lstTemp = lstlocation;
            //}
            //if (lstproject.Visible)
            //{
            //    lstTemp = lstproject;
            //}

            if (lstTemp.SelectedItems.Count == 0 || lstTemp.SelectedItems.Count > 1 || m_bIsAdmin == 3)
            {
                mnuAdd.Enabled = false;
                mnuEdit.Enabled = false;
                mnuDelete.Enabled = false;
            }
            else
            {
                ListViewItem lvItem = lstTemp.SelectedItems[0];
                string strCurrLoc = lvItem.SubItems[2].Text;
                if (lstShipIn.Visible)
                {

                    mnuAdd.Enabled = strCurrLoc == Program.m_strMSPOffice ? false : true;
                }
                mnuEdit.Enabled = true;
                mnuDelete.Enabled = true;
            }
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            // check if one item is selected
            if (m_strAction == "item")
            {

                string strItemName = "";
                string strRemark = "";
                if (lstItem.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstItem.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstItem.SelectedItems[0];
                    strItemName = lvItem.Text;
                    strRemark = lvItem.SubItems[1].Text;
                }
                ItemFrm frmitem = new ItemFrm(this, m_dbMgr, strItemName, strRemark, m_strAction);
                if (frmitem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadItem("");
                    //LoadEquipmentModels();
                }

            }
            if (m_strAction == "model")
            {

                string strModelName = "";
                string strItem = "";
                if (lstModel.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstModel.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstModel.SelectedItems[0];
                    strModelName = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    //strSerial = lvItem.SubItems[2].Text;
                }
                ModelFrm frmModel = new ModelFrm(this, m_dbMgr, strModelName, strItem, m_strAction);
                if (frmModel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadModel("");
                    //LoadEquipmentModels();
                }

            }
            if (m_strAction == "location")
            {

                string strItemName = "";
                string strRemark = "";
                if (m_strAction == "location")
                {
                    if (lstItem.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (lstItem.SelectedItems.Count == 1)
                    {
                        ListViewItem lvItem = lstItem.SelectedItems[0];
                        strItemName = lvItem.Text;
                        strRemark = lvItem.SubItems[1].Text;
                    }
                    ItemFrm frmitem = new ItemFrm(this, m_dbMgr, strItemName, strRemark, m_strAction);
                    if (frmitem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadLocProj("");
                        //LoadEquipmentModels();
                    }
                }

            }
            if (m_strAction == "project")
            {

                string strItemName = "";
                string strRemark = "";
                if (m_strAction == "project")
                {
                    if (lstItem.SelectedItems.Count < 1)
                    {
                        MessageBox.Show("There are no selected value.Please select one row to edit.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (lstItem.SelectedItems.Count == 1)
                    {
                        ListViewItem lvItem = lstItem.SelectedItems[0];
                        strItemName = lvItem.Text;
                        strRemark = lvItem.SubItems[1].Text;
                    }
                    ItemFrm frmitem = new ItemFrm(this, m_dbMgr, strItemName, strRemark, m_strAction);
                    if (frmitem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadLocProj("");
                        //LoadEquipmentModels();
                    }
                }

            }
            if (m_strAction == "ship")
            {
                string strShipID = "";
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                if (lstShipIn.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstShipIn.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;

                }
                int iItemID = -1;
                SelectItem(strItem, ref iItemID);
                int iEquipmentModelID = -1;
                SelectModel(strModel, iItemID, ref iEquipmentModelID);
                ShipInEditFrm frmEditShipIn = new ShipInEditFrm(this, m_dbMgr, strShipID, strItem, strSerialNo, iEquipmentModelID, iItemID, strItem);
                if (frmEditShipIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadShipping("");
                    //LoadEquipmentModels();
                }
            }
            if (m_strAction == "shipout")
            {
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                string strShipID = "";
                if (lstShipIn.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstShipIn.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;

                }
                int iItemID = -1;
                SelectItem(strItem, ref iItemID);
                int iEquipmentModelID = -1;
                SelectModel(strModel, iItemID, ref iEquipmentModelID);
                ShipInEditFrm frmEditShipIn = new ShipInEditFrm(this, m_dbMgr, strShipID, strItem, strSerialNo, iEquipmentModelID, iItemID, strItem);
                if (frmEditShipIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadShipping(string.Format("Where a.LocationTo <> '{0}' ", Program.m_strMSPOffice));
                    //LoadEquipmentModels();
                }
            }


        }

        private void mnuAdd_Click(object sender, EventArgs e)
        {
            if (m_strAction == "item")
            {
                ItemFrm frmItem = new ItemFrm(this, m_dbMgr, "", "", m_strAction);
                if (frmItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadItem("");
                }

            }
            if (m_strAction == "model")
            {
                ModelFrm frmModel = new ModelFrm(this, m_dbMgr, "", "", m_strAction);
                if (frmModel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadModel("");
                }

            }
            if (m_strAction == "location")
            {
                ItemFrm frmItem = new ItemFrm(this, m_dbMgr, "", "", m_strAction);
                if (frmItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLocProj("");
                }

            }
            if (m_strAction == "project")
            {
                ItemFrm frmItem = new ItemFrm(this, m_dbMgr, "", "", m_strAction);
                if (frmItem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLocProj("");
                }

            }

            if (m_strAction == "ship")
            {
                ShipInFrm frmShipIn = new ShipInFrm(this, m_dbMgr, "", "");
                if (frmShipIn.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadShipping("");
                }
            }
            if (m_strAction == "shipout")
            {
                ShipOutFrm frmShipOut = new ShipOutFrm(this, m_dbMgr, "", "");
                if (frmShipOut.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Saving Successful.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadShipping(string.Format("Where a.LocationTo <> '{0}' ", Program.m_strMSPOffice));
                }
            }


        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (m_strAction == "item")
            {

                // check if one item is selected
                string strItem = "";
                if (lstItem.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstItem.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstItem.SelectedItems[0];
                    strItem = lvItem.Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this item ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteItem(strItem,m_strAction))
                    {
                        LoadItem("");
                        MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (m_strAction == "model")
            {

                // check if one item is selected
                string strModel = "";
                if (lstModel.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstModel.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstModel.SelectedItems[0];
                    strModel = lvItem.Text;
                    //strSerial = lvItem.SubItems[2].Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this Model ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteModel(strModel))
                    {
                        LoadModel("");
                        MessageBox.Show("Model is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (m_strAction == "location")
            {

                // check if one item is selected
                string strItem = "";
                if (lstItem.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstItem.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstItem.SelectedItems[0];
                    strItem = lvItem.Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this item ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteItem(strItem, m_strAction))
                    {
                        LoadLocProj("");
                        MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (m_strAction == "project")
            {

                // check if one item is selected
                string strItem = "";
                if (lstItem.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (lstItem.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstItem.SelectedItems[0];
                    strItem = lvItem.Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete this item ?"), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DeleteItem(strItem, m_strAction))
                    {
                        LoadLocProj("");
                        MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (m_strAction == "ship")
            {
                string strShipID = "";
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                string strLocFrom = "";
                string strLocTo = "";
                string strReqby = "";
                string strDate = "";
                if (lstShipIn.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lstShipIn.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstShipIn.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;
                    //strLocFrom = lvItem.SubItems[4].Text;
                    strLocTo = lvItem.SubItems[4].Text;
                    strReqby = lvItem.SubItems[5].Text;
                    strDate = DateTime.ParseExact(lvItem.SubItems[6].Text, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                    //strDate = DateTime.ParseExact(lvItem.SubItems[5].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat).ToString("yyyy/MM/dd");
                    //strDate = lvItem.SubItems[5].Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete the {0} {1} {2}?", strItem, strSerialNo == "" ? "" : "with serial no.", strSerialNo), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (CheckRowtoDelete(strShipID,strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate) > 1)
                    {
                        if (MessageBox.Show("There are one more row to delete. Do you want to delete all row?", this.Text,
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DeleteShipIn(strShipID, strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate))
                            {
                                //btnRefreshEquipment_Click(sender, e);
                                //btnRefreshActs_Click(sender, e);
                                LoadShipping("");
                                MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                    else
                    {
                        if (DeleteShipIn(strShipID,strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate))
                        {
                            //btnRefreshEquipment_Click(sender, e);
                            //btnRefreshActs_Click(sender, e);
                            LoadShipping("");
                            MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }
            }
            if (m_strAction == "shipout")
            {
                string strShipID = "";
                string strItem = "";
                string strSerialNo = "";
                string strModel = "";
                string strLocFrom = "";
                string strLocTo = "";
                string strReqby = "";
                string strDate = "";
                if (lstShipIn.SelectedItems.Count < 1)
                {
                    MessageBox.Show("There are no selected value.Please select one row to delete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (lstShipIn.SelectedItems.Count == 1)
                {
                    ListViewItem lvItem = lstShipIn.SelectedItems[0];
                    strShipID = lvItem.Text;
                    strItem = lvItem.SubItems[1].Text;
                    strModel = lvItem.SubItems[2].Text;
                    strSerialNo = lvItem.SubItems[3].Text;
                    strLocFrom = lvItem.SubItems[4].Text;
                    strLocTo = lvItem.SubItems[5].Text;
                    strReqby = lvItem.SubItems[7].Text;
                    strDate = DateTime.ParseExact(lvItem.SubItems[8].Text, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                    //strDate = DateTime.ParseExact(lvItem.SubItems[5].Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat).ToString("yyyy/MM/dd");
                    //strDate = lvItem.SubItems[5].Text;
                }

                if (MessageBox.Show(string.Format("Are you sure want to delete the {0} {1} {2}?", strItem, strSerialNo == "" ? "" : "with serial no.", strSerialNo), this.Text,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (CheckRowtoDelete(strShipID,strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate) > 1)
                    {
                        if (MessageBox.Show("There are one more row to delete. Do you want to delete all row?", this.Text,
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DeleteShipIn(strShipID, strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate))
                            {
                                //btnRefreshEquipment_Click(sender, e);
                                //btnRefreshActs_Click(sender, e);
                                LoadShipping(string.Format("Where a.LocationTo <> '{0}' ", Program.m_strMSPOffice));
                                MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                    else
                    {
                        if (DeleteShipIn(strShipID, strItem, strModel, strSerialNo, strLocFrom, strLocTo, strReqby, strDate))
                        {
                            //btnRefreshEquipment_Click(sender, e);
                            //btnRefreshActs_Click(sender, e);
                            LoadShipping(string.Format("Where a.LocationTo <> '{0}' ", Program.m_strMSPOffice));
                            MessageBox.Show("Item is deleted successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }
            }


        }

        private void btnShipOut_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = false;
            lstShipIn.Visible = true;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            lstActivities.Visible = false;
            lblRight.Text = "List of Ship Out";
            m_strAction = "shipout";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadShipping(string.Format("Where a.LocationTo <> '{0}' ", Program.m_strMSPOffice));

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = false;
            lstShipIn.Visible = false;
            gbButtonBar.Visible = false;
            gbReport.Visible = true;
            lstReport.Visible = true;
            lstActivities.Visible = false;
            btnAdd.Enabled = true;
            lblRight.Text = "Reports";
            m_strAction = "report";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadProductTransactionReport("");
            cboReportList.SelectedIndex = 0;
        }

        private void btnRptFilter_Click(object sender, EventArgs e)
        {
            if (cboReportList.SelectedIndex == 0)
            {
                try
                {
                    ProductTranRptFilter frmfilterProductTran = new ProductTranRptFilter(this, m_dbMgr);
                    if (frmfilterProductTran.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadProductTransactionReport(m_strFilter);
                    }
                }
                catch { }
            }

        }

        private void btnRptExport_Click(object sender, EventArgs e)
        {
            if (cboReportList.SelectedIndex == 0)
            {
                ExportToFile(lstReport, "Product_Transaction_Report");
            }

        }

        private void btnReportRefresh_Click(object sender, EventArgs e)
        {
            if (cboReportList.SelectedIndex == 0)
            {
                LoadProductTransactionReport("");
            }

        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstShipIn.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = true;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            lstActivities.Visible = false;
            btnAdd.Enabled = true;
            lblRight.Text = "List of Location";
            m_strAction = "location";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadLocProj("");

        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstShipIn.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = true;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            lstActivities.Visible = false;
            btnAdd.Enabled = true;
            lblRight.Text = "List of Project";
            m_strAction = "project";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadLocProj("");

        }

        private void btnShipItem_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = false;
            lstShipIn.Visible = true;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            lstActivities.Visible = false;
            btnAdd.Enabled = true;
            lblRight.Text = "List of Ship Item";
            m_strAction = "ship";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadShipping("");

        }

        private void btnActivities_Click(object sender, EventArgs e)
        {
            splitItems.Visible = true;
            //lstPrisms.Visible = false;
            //lstEquipments.Visible = false;
            //lstActivities.Visible = false;
            lstModel.Visible = false;
            lstItem.Visible = false;
            lstShipIn.Visible = false;
            gbButtonBar.Visible = true;
            gbReport.Visible = false;
            lstReport.Visible = false;
            lstActivities.Visible = true;
            btnAdd.Enabled = false;
            lblRight.Text = "List of Activities";
            m_strAction = "activities";
            if (m_bIsAdmin == 3)
                EnableButton(false);
            LoadActivities("");

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
