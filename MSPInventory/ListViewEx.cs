using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ControlEx
{
    public partial class ListViewEx : ListView
    {
        // definition of message constants
        public const int WM_HSCROLL = 0x114;
        public const int WM_VSCROLL = 0x115;

        /// <summary>
        /// class constructor
        /// </summary>
        public ListViewEx()
        {
            // initialize control
            this.DoubleBuffered = true;
            this.OwnerDraw = true;
           
            // handle custom drawing
            this.DrawItem += new DrawListViewItemEventHandler(this.ListViewEx_DrawItem);
            this.DrawSubItem += new DrawListViewSubItemEventHandler(this.ListViewEx_DrawSubItem);
            this.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(this.ListViewEx_DrawColumnHeader);
            this.Resize += new EventHandler(this.ListViewEx_Resize);
        }

        /// <summary>
        /// resizes the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ListViewEx_Resize(object sender, EventArgs e)
        {
            try
            {
                // get total column width
                int iWidth = 0;
                for (int i = 0; i < this.Columns.Count - 1; i++)
                    iWidth += this.Columns[i].Width;

                // resize last column
                if (this.Width - iWidth > 150)
                    this.Columns[this.Columns.Count - 1].Width = this.Width - iWidth;
            }
            catch {}
        }

        /// <summary>
        /// draws the list column headers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewEx_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // draw column headers
            e.Graphics.FillRectangle(new SolidBrush(Color.LightSteelBlue), e.Bounds);
            e.Graphics.DrawString(e.Header.Text, this.Font, Brushes.Black, 
                new PointF(e.Bounds.X + 3, e.Bounds.Top + 3));

            // draw column separator
            if (e.Header.Index > 0)
                e.Graphics.DrawLine(new Pen(this.BackColor), new Point(e.Bounds.Left, 
                    e.Bounds.Top), new Point(e.Bounds.Left, e.Bounds.Bottom));
        }

        /// <summary>
        /// draws the list item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewEx_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // draw list items
            if ((this.View == View.Details) && (!this.ShowGroups || this.Groups.Count == 0))
                e.Item.BackColor = (e.Item.Index % 2 != 0 ? Color.Lavender : this.BackColor);
            e.DrawDefault = true;
        }

        /// <summary>
        /// custom draws the list subitems
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewEx_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // draw list subitems
            e.Graphics.DrawString(e.SubItem.Text, this.Font, Brushes.SlateGray, e.Bounds);
        }

        /// <summary>
        /// redraws the control when scrolling
        /// </summary>
        /// <param name="msgEvent"></param>
        protected override void WndProc(ref Message msgEvent)
        {
            // check message type
            switch (msgEvent.Msg)
            {
            case WM_HSCROLL: // redraw on scroll
            case WM_VSCROLL: this.Refresh(); break;
            }

            // pass message to default handler
            base.WndProc(ref msgEvent);
        } 
    }
}
