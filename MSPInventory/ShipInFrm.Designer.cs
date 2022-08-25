namespace MSPInventory
{
    partial class ShipInFrm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoShipOut = new System.Windows.Forms.RadioButton();
            this.rdoShipIn = new System.Windows.Forms.RadioButton();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cboSerialNo = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBy = new System.Windows.Forms.ComboBox();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.dtDateIn = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.dtNextCalibrationDate = new System.Windows.Forms.DateTimePicker();
            this.dtLastCalibrationDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkPurchase = new System.Windows.Forms.CheckBox();
            this.chkLastCali = new System.Windows.Forms.CheckBox();
            this.chkNextCali = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cboItem);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboProject);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtStation);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.cboSerialNo);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboBy);
            this.groupBox1.Controls.Add(this.cboFrom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.dtDateIn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboModel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoShipOut);
            this.groupBox3.Controls.Add(this.rdoShipIn);
            this.groupBox3.Location = new System.Drawing.Point(6, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 44);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            // 
            // rdoShipOut
            // 
            this.rdoShipOut.AutoSize = true;
            this.rdoShipOut.Location = new System.Drawing.Point(99, 18);
            this.rdoShipOut.Name = "rdoShipOut";
            this.rdoShipOut.Size = new System.Drawing.Size(66, 17);
            this.rdoShipOut.TabIndex = 1;
            this.rdoShipOut.Text = "Ship Out";
            this.rdoShipOut.UseVisualStyleBackColor = true;
            this.rdoShipOut.CheckedChanged += new System.EventHandler(this.rdoShipOut_CheckedChanged);
            // 
            // rdoShipIn
            // 
            this.rdoShipIn.AutoSize = true;
            this.rdoShipIn.Checked = true;
            this.rdoShipIn.Location = new System.Drawing.Point(12, 17);
            this.rdoShipIn.Name = "rdoShipIn";
            this.rdoShipIn.Size = new System.Drawing.Size(58, 17);
            this.rdoShipIn.TabIndex = 0;
            this.rdoShipIn.TabStop = true;
            this.rdoShipIn.Text = "Ship In";
            this.rdoShipIn.UseVisualStyleBackColor = true;
            this.rdoShipIn.CheckedChanged += new System.EventHandler(this.rdoShipIn_CheckedChanged);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(65, 203);
            this.numQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(148, 20);
            this.numQuantity.TabIndex = 5;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Quantity";
            // 
            // cboItem
            // 
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(65, 63);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(149, 21);
            this.cboItem.TabIndex = 0;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Item No.";
            // 
            // cboProject
            // 
            this.cboProject.DropDownHeight = 130;
            this.cboProject.FormattingEnabled = true;
            this.cboProject.IntegralHeight = false;
            this.cboProject.Location = new System.Drawing.Point(312, 134);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(149, 21);
            this.cboProject.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(237, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Station Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(237, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Project Name";
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(312, 164);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(149, 20);
            this.txtStation.TabIndex = 9;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(237, 197);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 13;
            this.lblDesc.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(312, 193);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(149, 20);
            this.txtDesc.TabIndex = 10;
            // 
            // cboSerialNo
            // 
            this.cboSerialNo.DropDownHeight = 150;
            this.cboSerialNo.FormattingEnabled = true;
            this.cboSerialNo.IntegralHeight = false;
            this.cboSerialNo.Location = new System.Drawing.Point(65, 92);
            this.cboSerialNo.Name = "cboSerialNo";
            this.cboSerialNo.Size = new System.Drawing.Size(149, 21);
            this.cboSerialNo.TabIndex = 1;
            this.cboSerialNo.SelectedIndexChanged += new System.EventHandler(this.cboSerialNo_SelectedIndexChanged);
            this.cboSerialNo.Leave += new System.EventHandler(this.cboSerialNo_Leave);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(240, 65);
            this.txtRemarks.MaxLength = 100;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(190, 56);
            this.txtRemarks.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Remarks";
            // 
            // cboBy
            // 
            this.cboBy.DropDownHeight = 130;
            this.cboBy.FormattingEnabled = true;
            this.cboBy.IntegralHeight = false;
            this.cboBy.Location = new System.Drawing.Point(65, 175);
            this.cboBy.Name = "cboBy";
            this.cboBy.Size = new System.Drawing.Size(149, 21);
            this.cboBy.TabIndex = 4;
            // 
            // cboFrom
            // 
            this.cboFrom.DropDownHeight = 150;
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.IntegralHeight = false;
            this.cboFrom.Location = new System.Drawing.Point(65, 147);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(149, 21);
            this.cboFrom.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "By";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(6, 151);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(30, 13);
            this.lblLocation.TabIndex = 4;
            this.lblLocation.Text = "From";
            // 
            // dtDateIn
            // 
            this.dtDateIn.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateIn.Location = new System.Drawing.Point(312, 19);
            this.dtDateIn.Name = "dtDateIn";
            this.dtDateIn.Size = new System.Drawing.Size(149, 20);
            this.dtDateIn.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date";
            // 
            // cboModel
            // 
            this.cboModel.DropDownHeight = 120;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.IntegralHeight = false;
            this.cboModel.Location = new System.Drawing.Point(65, 119);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(149, 21);
            this.cboModel.TabIndex = 2;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            this.cboModel.Enter += new System.EventHandler(this.cboModel_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial No.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkNextCali);
            this.groupBox2.Controls.Add(this.chkLastCali);
            this.groupBox2.Controls.Add(this.chkPurchase);
            this.groupBox2.Controls.Add(this.chkAdd);
            this.groupBox2.Controls.Add(this.dtNextCalibrationDate);
            this.groupBox2.Controls.Add(this.dtLastCalibrationDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dtPurchaseDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(12, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Other Facts";
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Location = new System.Drawing.Point(278, 21);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(209, 17);
            this.chkAdd.TabIndex = 4;
            this.chkAdd.Text = "Adding same serial with different Model";
            this.chkAdd.UseVisualStyleBackColor = true;
            this.chkAdd.Visible = false;
            // 
            // dtNextCalibrationDate
            // 
            this.dtNextCalibrationDate.CustomFormat = "\" \"";
            this.dtNextCalibrationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNextCalibrationDate.Location = new System.Drawing.Point(120, 71);
            this.dtNextCalibrationDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtNextCalibrationDate.Name = "dtNextCalibrationDate";
            this.dtNextCalibrationDate.Size = new System.Drawing.Size(151, 20);
            this.dtNextCalibrationDate.TabIndex = 3;
            this.dtNextCalibrationDate.ValueChanged += new System.EventHandler(this.dtNextCalibrationDate_ValueChanged);
            // 
            // dtLastCalibrationDate
            // 
            this.dtLastCalibrationDate.CustomFormat = "\" \"";
            this.dtLastCalibrationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLastCalibrationDate.Location = new System.Drawing.Point(120, 45);
            this.dtLastCalibrationDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtLastCalibrationDate.Name = "dtLastCalibrationDate";
            this.dtLastCalibrationDate.Size = new System.Drawing.Size(151, 20);
            this.dtLastCalibrationDate.TabIndex = 2;
            this.dtLastCalibrationDate.ValueChanged += new System.EventHandler(this.dtLastCalibrationDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Next Calibration";
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.CustomFormat = "\" \"";
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPurchaseDate.Location = new System.Drawing.Point(120, 19);
            this.dtPurchaseDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.Size = new System.Drawing.Size(151, 20);
            this.dtPurchaseDate.TabIndex = 1;
            this.dtPurchaseDate.ValueChanged += new System.EventHandler(this.dtPurchaseDate_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Last Calibration";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Purchase Date";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(289, 364);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkPurchase
            // 
            this.chkPurchase.AutoSize = true;
            this.chkPurchase.Location = new System.Drawing.Point(105, 22);
            this.chkPurchase.Name = "chkPurchase";
            this.chkPurchase.Size = new System.Drawing.Size(15, 14);
            this.chkPurchase.TabIndex = 5;
            this.chkPurchase.UseVisualStyleBackColor = true;
            this.chkPurchase.CheckedChanged += new System.EventHandler(this.chkPurchase_CheckedChanged);
            // 
            // chkLastCali
            // 
            this.chkLastCali.AutoSize = true;
            this.chkLastCali.Location = new System.Drawing.Point(105, 48);
            this.chkLastCali.Name = "chkLastCali";
            this.chkLastCali.Size = new System.Drawing.Size(15, 14);
            this.chkLastCali.TabIndex = 6;
            this.chkLastCali.UseVisualStyleBackColor = true;
            this.chkLastCali.CheckedChanged += new System.EventHandler(this.chkLastCali_CheckedChanged);
            // 
            // chkNextCali
            // 
            this.chkNextCali.AutoSize = true;
            this.chkNextCali.Location = new System.Drawing.Point(105, 74);
            this.chkNextCali.Name = "chkNextCali";
            this.chkNextCali.Size = new System.Drawing.Size(15, 14);
            this.chkNextCali.TabIndex = 7;
            this.chkNextCali.UseVisualStyleBackColor = true;
            this.chkNextCali.CheckedChanged += new System.EventHandler(this.chkNextCali_CheckedChanged);
            // 
            // ShipInFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 403);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ShipInFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ship IN";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtDateIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBy;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtNextCalibrationDate;
        private System.Windows.Forms.DateTimePicker dtLastCalibrationDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboSerialNo;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoShipOut;
        private System.Windows.Forms.RadioButton rdoShipIn;
        private System.Windows.Forms.CheckBox chkNextCali;
        private System.Windows.Forms.CheckBox chkLastCali;
        private System.Windows.Forms.CheckBox chkPurchase;
    }
}