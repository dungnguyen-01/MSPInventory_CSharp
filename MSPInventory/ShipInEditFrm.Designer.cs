namespace MSPInventory
{
    partial class ShipInEditFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtLastCalibrationDate = new System.Windows.Forms.DateTimePicker();
            this.dtNextCalibrationDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkPurchase = new System.Windows.Forms.CheckBox();
            this.chkLastCali = new System.Windows.Forms.CheckBox();
            this.chkNextCali = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial No.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Last Calibration";
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.CustomFormat = "\" \"";
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPurchaseDate.Location = new System.Drawing.Point(117, 20);
            this.dtPurchaseDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(145, 20);
            this.dtPurchaseDate.TabIndex = 1;
            this.dtPurchaseDate.Value = new System.DateTime(2014, 11, 11, 14, 18, 5, 0);
            this.dtPurchaseDate.ValueChanged += new System.EventHandler(this.dtPurchaseDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Purchase Date";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(126, 387);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Next Calibration";
            // 
            // dtLastCalibrationDate
            // 
            this.dtLastCalibrationDate.CustomFormat = "\" \"";
            this.dtLastCalibrationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLastCalibrationDate.Location = new System.Drawing.Point(117, 46);
            this.dtLastCalibrationDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtLastCalibrationDate.Name = "dtLastCalibrationDate";
            this.dtLastCalibrationDate.Size = new System.Drawing.Size(145, 20);
            this.dtLastCalibrationDate.TabIndex = 2;
            this.dtLastCalibrationDate.ValueChanged += new System.EventHandler(this.dtLastCalibrationDate_ValueChanged);
            // 
            // dtNextCalibrationDate
            // 
            this.dtNextCalibrationDate.CustomFormat = "\" \"";
            this.dtNextCalibrationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNextCalibrationDate.Location = new System.Drawing.Point(117, 72);
            this.dtNextCalibrationDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtNextCalibrationDate.Name = "dtNextCalibrationDate";
            this.dtNextCalibrationDate.Size = new System.Drawing.Size(145, 20);
            this.dtNextCalibrationDate.TabIndex = 3;
            this.dtNextCalibrationDate.ValueChanged += new System.EventHandler(this.dtNextCalibrationDate_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(207, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkNextCali);
            this.groupBox2.Controls.Add(this.chkLastCali);
            this.groupBox2.Controls.Add(this.chkPurchase);
            this.groupBox2.Controls.Add(this.dtNextCalibrationDate);
            this.groupBox2.Controls.Add(this.dtLastCalibrationDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dtPurchaseDate);
            this.groupBox2.Location = new System.Drawing.Point(12, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other Facts";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboProject);
            this.groupBox4.Controls.Add(this.txtStation);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtItem);
            this.groupBox4.Controls.Add(this.txtDesc);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtRemarks);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtSerialNo);
            this.groupBox4.Controls.Add(this.cboModel);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(270, 260);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // cboProject
            // 
            this.cboProject.DropDownHeight = 120;
            this.cboProject.FormattingEnabled = true;
            this.cboProject.IntegralHeight = false;
            this.cboProject.Location = new System.Drawing.Point(109, 207);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(152, 21);
            this.cboProject.TabIndex = 5;
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(109, 233);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(152, 20);
            this.txtStation.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Station";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Project";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(109, 18);
            this.txtItem.Margin = new System.Windows.Forms.Padding(2);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(152, 20);
            this.txtItem.TabIndex = 9;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(109, 181);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(152, 20);
            this.txtDesc.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Item Name";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(8, 116);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(252, 55);
            this.txtRemarks.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Remarks";
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Location = new System.Drawing.Point(109, 45);
            this.txtSerialNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Size = new System.Drawing.Size(152, 20);
            this.txtSerialNo.TabIndex = 1;
            // 
            // cboModel
            // 
            this.cboModel.DropDownHeight = 150;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.IntegralHeight = false;
            this.cboModel.Location = new System.Drawing.Point(109, 72);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(152, 21);
            this.cboModel.TabIndex = 2;
            this.cboModel.Enter += new System.EventHandler(this.cboModel_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Serial No.";
            // 
            // chkPurchase
            // 
            this.chkPurchase.AutoSize = true;
            this.chkPurchase.Location = new System.Drawing.Point(100, 23);
            this.chkPurchase.Name = "chkPurchase";
            this.chkPurchase.Size = new System.Drawing.Size(15, 14);
            this.chkPurchase.TabIndex = 8;
            this.chkPurchase.UseVisualStyleBackColor = true;
            this.chkPurchase.CheckedChanged += new System.EventHandler(this.chkPurchase_CheckedChanged);
            // 
            // chkLastCali
            // 
            this.chkLastCali.AutoSize = true;
            this.chkLastCali.Location = new System.Drawing.Point(100, 49);
            this.chkLastCali.Name = "chkLastCali";
            this.chkLastCali.Size = new System.Drawing.Size(15, 14);
            this.chkLastCali.TabIndex = 9;
            this.chkLastCali.UseVisualStyleBackColor = true;
            this.chkLastCali.CheckedChanged += new System.EventHandler(this.chkLastCali_CheckedChanged);
            // 
            // chkNextCali
            // 
            this.chkNextCali.AutoSize = true;
            this.chkNextCali.Location = new System.Drawing.Point(100, 75);
            this.chkNextCali.Name = "chkNextCali";
            this.chkNextCali.Size = new System.Drawing.Size(15, 14);
            this.chkNextCali.TabIndex = 10;
            this.chkNextCali.UseVisualStyleBackColor = true;
            this.chkNextCali.CheckedChanged += new System.EventHandler(this.chkNextCali_CheckedChanged);
            // 
            // ShipInEditFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(295, 419);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ShipInEditFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Shipping";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtLastCalibrationDate;
        private System.Windows.Forms.DateTimePicker dtNextCalibrationDate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.CheckBox chkPurchase;
        private System.Windows.Forms.CheckBox chkNextCali;
        private System.Windows.Forms.CheckBox chkLastCali;
    }
}