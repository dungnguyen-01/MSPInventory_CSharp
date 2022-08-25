namespace MSPInventory
{
    partial class ShipOutFrm
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
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cboSerialNo = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBy = new System.Windows.Forms.ComboBox();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtDateOut = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numQuantity);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cboItem);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cboLocation);
            this.groupBox1.Controls.Add(this.cboProject);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtStation);
            this.groupBox1.Controls.Add(this.lblDesc);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.cboSerialNo);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboBy);
            this.groupBox1.Controls.Add(this.cboTo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtDateOut);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboModel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(65, 162);
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
            this.label14.Location = new System.Drawing.Point(6, 166);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Quantity";
            // 
            // cboItem
            // 
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(65, 22);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(149, 21);
            this.cboItem.TabIndex = 0;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Item No.";
            // 
            // cboLocation
            // 
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(65, 194);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(149, 21);
            this.cboLocation.TabIndex = 5;
            this.cboLocation.Visible = false;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Location";
            this.label8.Visible = false;
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
            this.cboSerialNo.DropDownHeight = 130;
            this.cboSerialNo.FormattingEnabled = true;
            this.cboSerialNo.IntegralHeight = false;
            this.cboSerialNo.Location = new System.Drawing.Point(65, 50);
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
            this.cboBy.DropDownHeight = 150;
            this.cboBy.FormattingEnabled = true;
            this.cboBy.IntegralHeight = false;
            this.cboBy.Location = new System.Drawing.Point(65, 134);
            this.cboBy.Name = "cboBy";
            this.cboBy.Size = new System.Drawing.Size(149, 21);
            this.cboBy.TabIndex = 4;
            // 
            // cboTo
            // 
            this.cboTo.DropDownHeight = 200;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.IntegralHeight = false;
            this.cboTo.Location = new System.Drawing.Point(65, 106);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(149, 21);
            this.cboTo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "By";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // dtDateOut
            // 
            this.dtDateOut.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateOut.Location = new System.Drawing.Point(312, 19);
            this.dtDateOut.Name = "dtDateOut";
            this.dtDateOut.Size = new System.Drawing.Size(149, 20);
            this.dtDateOut.TabIndex = 6;
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
            this.cboModel.DropDownHeight = 150;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.IntegralHeight = false;
            this.cboModel.Location = new System.Drawing.Point(65, 78);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(149, 21);
            this.cboModel.TabIndex = 2;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial No.";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(289, 270);
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
            this.btnCancel.Location = new System.Drawing.Point(370, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ShipOutFrm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(482, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ShipOutFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ship Out";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtDateOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBy;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboSerialNo;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label14;
    }
}