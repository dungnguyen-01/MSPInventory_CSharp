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
    public partial class PrismOutFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;

        public PrismOutFrm(MainFrm frmMain, DatabaseMgr dbMgr, string strPrismType, string strQuantity)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;

            // load prism types
            LoadPrismTypes();

            // load locations from outside
            LoadLocationsFromOutside();

            // load persons in charge
            LoadPersonsInCharge();

            // auto-select
            if (strPrismType != "")
            {
                cboPrismType.SelectedIndex = cboPrismType.FindString(strPrismType);
                numQuantity.Value = Convert.ToDecimal(strQuantity);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // check if prism type is not empty
            if (cboPrismType.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the Prism Type.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if quantity is not empty
            if (numQuantity.Value.ToString() == "")
            {
                MessageBox.Show("Please enter the Quantity of the prism.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // check if to-location is not empty
            if (cboTo.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the To field.", this.Text,
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

            // save activity/prism/prism type
            try
            {
                int iPrismTypeID = -1;

                // check if prism type exists
                if (m_frmMain.IsPrismTypeExists(cboPrismType.Text.Trim(), ref iPrismTypeID))
                {
                    // check if to-location have some quantity of the prism type; if have, add this to the quantity
                    m_frmMain.AddPrismQuantity(iPrismTypeID, Convert.ToInt32(numQuantity.Value), Program.m_strMSPOffice,
                        cboTo.Text.Trim(), cboBy.Text.Trim(), dtDateOut.Value);

                    // check if office have some quantity of the prism type; if have, deduct this from the quantity;
                    m_frmMain.DeductPrismQuantity(iPrismTypeID, Convert.ToInt32(numQuantity.Value), Program.m_strMSPOffice);
                }
                else
                {
                    // if prism type is not yet in PrismTypes table, insert record
                    m_frmMain.AddPrismType(cboPrismType.Text.Trim(), ref iPrismTypeID);

                    // insert record to Prisms table (reuse AddPrismQuantity method)
                    m_frmMain.AddPrismQuantity(iPrismTypeID, Convert.ToInt32(numQuantity.Value), Program.m_strMSPOffice,
                        cboTo.Text.Trim(), cboBy.Text.Trim(), dtDateOut.Value);
                }

                // insert event in Activities record
                m_frmMain.AddActivity(-1,-1, iPrismTypeID, Convert.ToInt32(numQuantity.Value), Program.m_strMSPOffice,
                cboTo.Text.Trim(), cboBy.Text.Trim(), dtDateOut.Value, txtRemarks.Text);

                //m_frmMain.AddActivity(-1, iPrismTypeID, Convert.ToInt32(numQuantity.Value), Program.m_strMSPOffice,
                //    cboTo.Text.Trim(), cboBy.Text.Trim(), dtDateOut.Value, txtRemarks.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void LoadPrismTypes()
        {
            try
            {
                // clear prism type list
                cboPrismType.BeginUpdate();
                cboPrismType.Items.Clear();

                // check if user exists
                string strSQL = string.Format("SELECT PrismType FROM PrismTypes ORDER BY PrismType");
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add prism type
                        cboPrismType.Items.Add(Convert.ToString(dbRdr["PrismType"]));
                    }
                }
                if (dbRdr != null) dbRdr.Close();

                // close connection
                m_dbMgr.Close();

                // refresh prism type list
                cboPrismType.EndUpdate();
                cboPrismType.Refresh();
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
                string strSQL = string.Format("SELECT DISTINCT LocationFrom as Location FROM Activities WHERE LocationFrom <> '{0}' UNION " +
                    "SELECT DISTINCT LocationTo as Location FROM Activities WHERE LocationTo <> '{0}'", Program.m_strMSPOffice);
                SqlDataReader dbRdr = m_dbMgr.ExecuteReader(strSQL);
                if (dbRdr != null && dbRdr.HasRows)
                {
                    while (dbRdr.Read())
                    {
                        // add location
                        cboTo.Items.Add(Convert.ToString(dbRdr["Location"]));
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
    }
}
