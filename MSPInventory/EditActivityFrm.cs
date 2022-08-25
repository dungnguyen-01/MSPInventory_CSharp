using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSPInventory
{
    public partial class EditActivityFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;
        int m_iActivityID = -1;

        public EditActivityFrm(MainFrm frmMain, DatabaseMgr dbMgr, string strDate, string strName, int iActivityID, string strRemarks)
        {
            InitializeComponent();
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;
            txtDate.Text = strDate;
            txtName.Text = strName;
            m_iActivityID = iActivityID;
            txtRemarks.Text = strRemarks;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // save update
            try
            {
                m_frmMain.UpdateRemarks(m_iActivityID, txtRemarks.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
