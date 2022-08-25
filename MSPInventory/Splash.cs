using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MSPInventory
{
    public partial class Splash : Form
    {
        private bool m_bFade = false;
        private int m_iDur = 0;

        public Splash()
        {
            InitializeComponent();

            // show product version
            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            // fade away
            tmrFade.Start();
        }

        private void tmrFade_Tick(object sender, EventArgs e)
        {
            // check if fading in
            if (!m_bFade)
            {
                // increase opacity
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                {
                    // fade out on full opacity
                    if (++m_iDur > 30)
                        m_bFade = true;
                }
            }
            else
            {
                // decrease opacity
                this.Opacity -= 0.05;

                // close on full transparency
                if (this.Opacity <= 0)
                    this.Close();
            }
        }
    }
}
