namespace MSPInventory
{
    partial class ProductTranRptFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSerialNo = new System.Windows.Forms.ComboBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboSerialNo);
            this.groupBox1.Controls.Add(this.cboItem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 148);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Serial No";
            // 
            // cboSerialNo
            // 
            this.cboSerialNo.DropDownHeight = 250;
            this.cboSerialNo.DropDownWidth = 149;
            this.cboSerialNo.FormattingEnabled = true;
            this.cboSerialNo.IntegralHeight = false;
            this.cboSerialNo.Location = new System.Drawing.Point(94, 106);
            this.cboSerialNo.Name = "cboSerialNo";
            this.cboSerialNo.Size = new System.Drawing.Size(164, 21);
            this.cboSerialNo.TabIndex = 3;
            // 
            // cboItem
            // 
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(94, 73);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(164, 21);
            this.cboItem.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Item";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(94, 44);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(164, 20);
            this.dtTo.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "To Date";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(94, 15);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(164, 20);
            this.dtFrom.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "From Date";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(186, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(105, 163);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ProductTranRptFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 194);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Name = "ProductTranRptFilter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Transaction Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSerialNo;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;

    }
}