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
    public partial class ItemFilterFrm : Form
    {
        MainFrm m_frmMain = null;
        DatabaseMgr m_dbMgr = null;
        public ItemFilterFrm(MainFrm frmMain, DatabaseMgr dbMgr)
        {
            m_frmMain = frmMain;
            m_dbMgr = dbMgr;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strFilter = "";

            if (cboCriteria.Text != "" && txtFilter.Text !="")
            {
                if (cboCriteria.Text == "=")
                {
                    if (m_frmMain.m_strAction == "model")
                    {
                        strFilter = string.Format("where Model='{0}'", txtFilter.Text);
                    }
                    else
                    {
                        strFilter = string.Format("where Name='{0}'", txtFilter.Text);
                    }
                }
                else
                {
                    if (m_frmMain.m_strAction == "model")
                    {

                        strFilter = string.Format("where Model like '%{0}%'", txtFilter.Text);
                    }
                    else
                    {
                        strFilter = string.Format("where Name like '%{0}%'", txtFilter.Text);
                    }
                }
            }
            m_frmMain.m_strFilter = strFilter;

            // close window with OK result
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
