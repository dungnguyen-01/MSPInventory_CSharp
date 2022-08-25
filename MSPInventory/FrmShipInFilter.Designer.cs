namespace MSPInventory
{
    partial class FrmShipInFilter
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboInOut = new System.Windows.Forms.ComboBox();
            this.cboLocTo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Lavender;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnOK);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(279, 352);
            this.panel3.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(185, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(104, 320);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboInOut);
            this.groupBox1.Controls.Add(this.cboLocTo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboProject);
            this.groupBox1.Controls.Add(this.cboItem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtStation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cboModel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSerialNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 299);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "In/Out";
            // 
            // cboInOut
            // 
            this.cboInOut.FormattingEnabled = true;
            this.cboInOut.Items.AddRange(new object[] {
            "In",
            "Out"});
            this.cboInOut.Location = new System.Drawing.Point(98, 75);
            this.cboInOut.Name = "cboInOut";
            this.cboInOut.Size = new System.Drawing.Size(164, 21);
            this.cboInOut.TabIndex = 2;
            // 
            // cboLocTo
            // 
            this.cboLocTo.FormattingEnabled = true;
            this.cboLocTo.Location = new System.Drawing.Point(98, 200);
            this.cboLocTo.Name = "cboLocTo";
            this.cboLocTo.Size = new System.Drawing.Size(164, 21);
            this.cboLocTo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Current Location";
            // 
            // cboProject
            // 
            this.cboProject.FormattingEnabled = true;
            this.cboProject.Location = new System.Drawing.Point(98, 232);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(164, 21);
            this.cboProject.TabIndex = 8;
            // 
            // cboItem
            // 
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(98, 106);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(164, 21);
            this.cboItem.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Item";
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(98, 263);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(164, 20);
            this.txtStation.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Station";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Project";
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(98, 45);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(164, 20);
            this.dtTo.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "To Date";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(98, 15);
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
            // cboModel
            // 
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Location = new System.Drawing.Point(98, 167);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(164, 21);
            this.cboModel.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Model";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(98, 137);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(164, 20);
            this.txtSerialNo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Serial No.";
            // 
            // FrmShipInFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 356);
            this.Controls.Add(this.panel3);
            this.Name = "FrmShipInFilter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shipping Filter";
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.ComboBox cboLocTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboInOut;
    }
}