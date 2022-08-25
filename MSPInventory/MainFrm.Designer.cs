namespace MSPInventory
{
    partial class MainFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            System.Windows.Forms.ToolStripProfessionalRenderer toolStripProfessionalRenderer1 = new System.Windows.Forms.ToolStripProfessionalRenderer();
            OutlookBarLibrary.Renderers.Office2003Renderer office2003Renderer1 = new OutlookBarLibrary.Renderers.Office2003Renderer();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Super Admin", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Administrator", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Viewer", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Dzung", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Jolin", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Erwin", 2);
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.toolOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAbout = new System.Windows.Forms.ToolStripButton();
            this.statMain = new System.Windows.Forms.StatusStrip();
            this.mnuActivities = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditRemarks = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteActivities = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.imgStnLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgStnSmall = new System.Windows.Forms.ImageList(this.components);
            this.mnuPrisms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPrismIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrismOut = new System.Windows.Forms.ToolStripMenuItem();
            this.imgPrismLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgPrismSmall = new System.Windows.Forms.ImageList(this.components);
            this.mnuUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.imgUserLarge = new System.Windows.Forms.ImageList(this.components);
            this.imgUserSmall = new System.Windows.Forms.ImageList(this.components);
            this.tmrSplash = new System.Windows.Forms.Timer(this.components);
            this.hSplash = new System.ComponentModel.BackgroundWorker();
            this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.outlookBarMain = new OutlookBarLibrary.Controls.OutlookBar();
            this.outlookBarItemUsers = new OutlookBarLibrary.Controls.OutlookBarItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pnlOutlookUsers = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.outlookBarItem = new OutlookBarLibrary.Controls.OutlookBarItem();
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.btnModel = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnProject = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnActivities = new System.Windows.Forms.Button();
            this.btnShipItem = new System.Windows.Forms.Button();
            this.btnItem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitItems = new System.Windows.Forms.SplitContainer();
            this.gbReport = new System.Windows.Forms.GroupBox();
            this.btnReportRefresh = new System.Windows.Forms.Button();
            this.btnRptExport = new System.Windows.Forms.Button();
            this.btnRptFilter = new System.Windows.Forms.Button();
            this.cboReportList = new System.Windows.Forms.ComboBox();
            this.gbButtonBar = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnfilter = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblRight = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lstActivities = new ControlEx.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstReport = new ControlEx.ListViewEx();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstShipIn = new ControlEx.ListViewEx();
            this.colShipID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTLoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPInCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUpdateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCaliDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNextCaliDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Project = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_STN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstModel = new ControlEx.ListViewEx();
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstItem = new ControlEx.ListViewEx();
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstUsers = new ControlEx.ListViewEx();
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuMain.SuspendLayout();
            this.toolMain.SuspendLayout();
            this.mnuActivities.SuspendLayout();
            this.mnuList.SuspendLayout();
            this.mnuPrisms.SuspendLayout();
            this.mnuUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.outlookBarMain.ContentPanel.SuspendLayout();
            this.outlookBarItemUsers.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlOutlookUsers.SuspendLayout();
            this.outlookBarItem.SuspendLayout();
            this.gbItems.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitItems)).BeginInit();
            this.splitItems.Panel1.SuspendLayout();
            this.splitItems.Panel2.SuspendLayout();
            this.splitItems.SuspendLayout();
            this.gbReport.SuspendLayout();
            this.gbButtonBar.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1173, 30);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions,
            this.toolStripSeparator1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(46, 26);
            this.mnuFile.Text = "&File";
            // 
            // mnuOptions
            // 
            this.mnuOptions.Image = ((System.Drawing.Image)(resources.GetObject("mnuOptions.Image")));
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(153, 26);
            this.mnuOptions.Text = "Options...";
            this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(153, 26);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(55, 26);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = ((System.Drawing.Image)(resources.GetObject("mnuAbout.Image")));
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(240, 26);
            this.mnuAbout.Text = "&About MSP Inventory...";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // toolMain
            // 
            this.toolMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOptions,
            this.toolStripSeparator2,
            this.toolAbout});
            this.toolMain.Location = new System.Drawing.Point(0, 30);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(1173, 31);
            this.toolMain.TabIndex = 1;
            this.toolMain.Text = "toolStrip1";
            // 
            // toolOptions
            // 
            this.toolOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolOptions.Image")));
            this.toolOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOptions.Name = "toolOptions";
            this.toolOptions.Size = new System.Drawing.Size(29, 28);
            this.toolOptions.Text = "Options...";
            this.toolOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolAbout
            // 
            this.toolAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolAbout.Image")));
            this.toolAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAbout.Name = "toolAbout";
            this.toolAbout.Size = new System.Drawing.Size(29, 28);
            this.toolAbout.Text = "About MSP Inventory...";
            this.toolAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // statMain
            // 
            this.statMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statMain.Location = new System.Drawing.Point(0, 659);
            this.statMain.Name = "statMain";
            this.statMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statMain.Size = new System.Drawing.Size(1173, 22);
            this.statMain.TabIndex = 3;
            this.statMain.Text = "statusStrip1";
            // 
            // mnuActivities
            // 
            this.mnuActivities.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuActivities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditRemarks,
            this.mnuDeleteActivities});
            this.mnuActivities.Name = "mnuActivities";
            this.mnuActivities.Size = new System.Drawing.Size(191, 56);
            // 
            // mnuEditRemarks
            // 
            this.mnuEditRemarks.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditRemarks.Image")));
            this.mnuEditRemarks.Name = "mnuEditRemarks";
            this.mnuEditRemarks.Size = new System.Drawing.Size(190, 26);
            this.mnuEditRemarks.Text = "Edit Remarks...";
            // 
            // mnuDeleteActivities
            // 
            this.mnuDeleteActivities.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteActivities.Image")));
            this.mnuDeleteActivities.Name = "mnuDeleteActivities";
            this.mnuDeleteActivities.Size = new System.Drawing.Size(190, 26);
            this.mnuDeleteActivities.Text = "Delete Activities";
            // 
            // mnuList
            // 
            this.mnuList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete,
            this.toolStripSeparator3,
            this.mnuAdd});
            this.mnuList.Name = "mnuEquipments";
            this.mnuList.Size = new System.Drawing.Size(127, 88);
            this.mnuList.Opening += new System.ComponentModel.CancelEventHandler(this.mnuList_Opening);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = ((System.Drawing.Image)(resources.GetObject("mnuEdit.Image")));
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(126, 26);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuDelete.Image")));
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(126, 26);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(123, 6);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = ((System.Drawing.Image)(resources.GetObject("mnuAdd.Image")));
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(126, 26);
            this.mnuAdd.Text = "Add";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // imgStnLarge
            // 
            this.imgStnLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgStnLarge.ImageStream")));
            this.imgStnLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgStnLarge.Images.SetKeyName(0, "sokkia.png");
            this.imgStnLarge.Images.SetKeyName(1, "prism.png");
            this.imgStnLarge.Images.SetKeyName(2, "battery.png");
            this.imgStnLarge.Images.SetKeyName(3, "item.png");
            // 
            // imgStnSmall
            // 
            this.imgStnSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgStnSmall.ImageStream")));
            this.imgStnSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgStnSmall.Images.SetKeyName(0, "sokkia_small.png");
            this.imgStnSmall.Images.SetKeyName(1, "prism_small.png");
            this.imgStnSmall.Images.SetKeyName(2, "battery_small.png");
            this.imgStnSmall.Images.SetKeyName(3, "item_small.png");
            // 
            // mnuPrisms
            // 
            this.mnuPrisms.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuPrisms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrismIn,
            this.mnuPrismOut});
            this.mnuPrisms.Name = "mnuPrisms";
            this.mnuPrisms.Size = new System.Drawing.Size(152, 56);
            // 
            // mnuPrismIn
            // 
            this.mnuPrismIn.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrismIn.Image")));
            this.mnuPrismIn.Name = "mnuPrismIn";
            this.mnuPrismIn.Size = new System.Drawing.Size(151, 26);
            this.mnuPrismIn.Text = "Prism IN";
            // 
            // mnuPrismOut
            // 
            this.mnuPrismOut.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrismOut.Image")));
            this.mnuPrismOut.Name = "mnuPrismOut";
            this.mnuPrismOut.Size = new System.Drawing.Size(151, 26);
            this.mnuPrismOut.Text = "Prism OUT";
            // 
            // imgPrismLarge
            // 
            this.imgPrismLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPrismLarge.ImageStream")));
            this.imgPrismLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPrismLarge.Images.SetKeyName(0, "prism.png");
            // 
            // imgPrismSmall
            // 
            this.imgPrismSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPrismSmall.ImageStream")));
            this.imgPrismSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPrismSmall.Images.SetKeyName(0, "prism_small.png");
            // 
            // mnuUsers
            // 
            this.mnuUsers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddUser,
            this.mnuEditUser,
            this.mnuDeleteUser});
            this.mnuUsers.Name = "mnuUsers";
            this.mnuUsers.Size = new System.Drawing.Size(160, 82);
            this.mnuUsers.Opening += new System.ComponentModel.CancelEventHandler(this.mnuUsers_Opening);
            // 
            // mnuAddUser
            // 
            this.mnuAddUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddUser.Image")));
            this.mnuAddUser.Name = "mnuAddUser";
            this.mnuAddUser.Size = new System.Drawing.Size(159, 26);
            this.mnuAddUser.Text = "Add User";
            this.mnuAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // mnuEditUser
            // 
            this.mnuEditUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mnuEditUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditUser.Image")));
            this.mnuEditUser.Name = "mnuEditUser";
            this.mnuEditUser.Size = new System.Drawing.Size(159, 26);
            this.mnuEditUser.Text = "Edit User";
            this.mnuEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // mnuDeleteUser
            // 
            this.mnuDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteUser.Image")));
            this.mnuDeleteUser.Name = "mnuDeleteUser";
            this.mnuDeleteUser.Size = new System.Drawing.Size(159, 26);
            this.mnuDeleteUser.Text = "Delete User";
            this.mnuDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // imgUserLarge
            // 
            this.imgUserLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUserLarge.ImageStream")));
            this.imgUserLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUserLarge.Images.SetKeyName(0, "AdminLTELogo.png");
            this.imgUserLarge.Images.SetKeyName(1, "admin_user.png");
            this.imgUserLarge.Images.SetKeyName(2, "viewer_user.png");
            // 
            // imgUserSmall
            // 
            this.imgUserSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgUserSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imgUserSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tmrSplash
            // 
            this.tmrSplash.Tick += new System.EventHandler(this.tmrSplash_Tick);
            // 
            // hSplash
            // 
            this.hSplash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.hSplash_DoWork);
            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.Color.CornflowerBlue;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 61);
            this.splitMain.Margin = new System.Windows.Forms.Padding(4);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.outlookBarMain);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitItems);
            this.splitMain.Panel2.Controls.Add(this.lstUsers);
            this.splitMain.Panel2.Controls.Add(this.pnlBottom);
            this.splitMain.Panel2.Controls.Add(this.pnlRight);
            this.splitMain.Size = new System.Drawing.Size(1173, 598);
            this.splitMain.SplitterDistance = 220;
            this.splitMain.SplitterWidth = 5;
            this.splitMain.TabIndex = 4;
            // 
            // outlookBarMain
            // 
            // 
            // 
            // 
            this.outlookBarMain.ButtonsPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outlookBarMain.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outlookBarMain.ButtonsPanel.Location = new System.Drawing.Point(0, 496);
            this.outlookBarMain.ButtonsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outlookBarMain.ButtonsPanel.Name = "pnlButtons";
            this.outlookBarMain.ButtonsPanel.Size = new System.Drawing.Size(220, 102);
            this.outlookBarMain.ButtonsPanel.TabIndex = 0;
            // 
            // 
            // 
            this.outlookBarMain.ContentPanel.Controls.Add(this.outlookBarItemUsers);
            this.outlookBarMain.ContentPanel.Controls.Add(this.outlookBarItem);
            this.outlookBarMain.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookBarMain.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.outlookBarMain.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outlookBarMain.ContentPanel.Name = "pnlContent";
            this.outlookBarMain.ContentPanel.Size = new System.Drawing.Size(220, 496);
            this.outlookBarMain.ContentPanel.TabIndex = 0;
            toolStripProfessionalRenderer1.RoundedEdges = true;
            this.outlookBarMain.ContextMenuStripRenderer = toolStripProfessionalRenderer1;
            this.outlookBarMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.outlookBarMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookBarMain.Items.Add(this.outlookBarItemUsers);
            this.outlookBarMain.Items.Add(this.outlookBarItem);
            this.outlookBarMain.Location = new System.Drawing.Point(0, 0);
            this.outlookBarMain.Margin = new System.Windows.Forms.Padding(5);
            this.outlookBarMain.MinimumSize = new System.Drawing.Size(50, 38);
            this.outlookBarMain.Name = "outlookBarMain";
            this.outlookBarMain.Renderer = office2003Renderer1;
            this.outlookBarMain.RendererPreset = OutlookBarLibrary.Controls.OutlookBar.RendererPresets.Office2003Blue;
            this.outlookBarMain.SelectedItem = this.outlookBarItem;
            this.outlookBarMain.Size = new System.Drawing.Size(220, 598);
            this.outlookBarMain.TabIndex = 0;
            this.outlookBarMain.SelectedItemChanged += new System.EventHandler(this.outlookBarMain_SelectedItemChanged);
            // 
            // outlookBarItemUsers
            // 
            this.outlookBarItemUsers.Allowed = true;
            this.outlookBarItemUsers.ButtonBounds = new System.Drawing.Rectangle(0, 6, 220, 32);
            this.outlookBarItemUsers.ButtonText = "Manage Users";
            this.outlookBarItemUsers.ButtonVisible = true;
            this.outlookBarItemUsers.Controls.Add(this.panel1);
            this.outlookBarItemUsers.Controls.Add(this.pnlOutlookUsers);
            this.outlookBarItemUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookBarItemUsers.Image = ((System.Drawing.Image)(resources.GetObject("outlookBarItemUsers.Image")));
            this.outlookBarItemUsers.IsLarge = true;
            this.outlookBarItemUsers.Location = new System.Drawing.Point(0, 0);
            this.outlookBarItemUsers.Name = "outlookBarItemUsers";
            this.outlookBarItemUsers.Selected = false;
            this.outlookBarItemUsers.Size = new System.Drawing.Size(220, 496);
            this.outlookBarItemUsers.TabIndex = 1;
            this.outlookBarItemUsers.Text = "Manage Users";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.btnDeleteUser);
            this.panel1.Controls.Add(this.btnEditUser);
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 459);
            this.panel1.TabIndex = 4;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.BackgroundImage")));
            this.btnDeleteUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.Location = new System.Drawing.Point(13, 132);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(193, 47);
            this.btnDeleteUser.TabIndex = 6;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditUser.BackgroundImage")));
            this.btnEditUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Location = new System.Drawing.Point(13, 78);
            this.btnEditUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(193, 47);
            this.btnEditUser.TabIndex = 5;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddUser.BackgroundImage")));
            this.btnAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddUser.Location = new System.Drawing.Point(13, 23);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(193, 47);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // pnlOutlookUsers
            // 
            this.pnlOutlookUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlOutlookUsers.BackgroundImage")));
            this.pnlOutlookUsers.Controls.Add(this.label1);
            this.pnlOutlookUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOutlookUsers.Location = new System.Drawing.Point(0, 0);
            this.pnlOutlookUsers.Margin = new System.Windows.Forms.Padding(4);
            this.pnlOutlookUsers.Name = "pnlOutlookUsers";
            this.pnlOutlookUsers.Size = new System.Drawing.Size(220, 37);
            this.pnlOutlookUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(16, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Users";
            // 
            // outlookBarItem
            // 
            this.outlookBarItem.Allowed = true;
            this.outlookBarItem.ButtonBounds = new System.Drawing.Rectangle(0, 38, 220, 32);
            this.outlookBarItem.ButtonText = "Action";
            this.outlookBarItem.ButtonVisible = true;
            this.outlookBarItem.Controls.Add(this.gbItems);
            this.outlookBarItem.Controls.Add(this.panel2);
            this.outlookBarItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookBarItem.Image = ((System.Drawing.Image)(resources.GetObject("outlookBarItem.Image")));
            this.outlookBarItem.IsLarge = true;
            this.outlookBarItem.Location = new System.Drawing.Point(0, 0);
            this.outlookBarItem.Name = "outlookBarItem";
            this.outlookBarItem.Selected = false;
            this.outlookBarItem.Size = new System.Drawing.Size(220, 496);
            this.outlookBarItem.TabIndex = 0;
            this.outlookBarItem.Text = "Action";
            // 
            // gbItems
            // 
            this.gbItems.BackColor = System.Drawing.Color.Lavender;
            this.gbItems.Controls.Add(this.btnModel);
            this.gbItems.Controls.Add(this.btnReport);
            this.gbItems.Controls.Add(this.btnProject);
            this.gbItems.Controls.Add(this.btnLocation);
            this.gbItems.Controls.Add(this.btnActivities);
            this.gbItems.Controls.Add(this.btnShipItem);
            this.gbItems.Controls.Add(this.btnItem);
            this.gbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbItems.Location = new System.Drawing.Point(0, 37);
            this.gbItems.Margin = new System.Windows.Forms.Padding(4);
            this.gbItems.Name = "gbItems";
            this.gbItems.Padding = new System.Windows.Forms.Padding(4);
            this.gbItems.Size = new System.Drawing.Size(220, 459);
            this.gbItems.TabIndex = 6;
            this.gbItems.TabStop = false;
            // 
            // btnModel
            // 
            this.btnModel.Image = ((System.Drawing.Image)(resources.GetObject("btnModel.Image")));
            this.btnModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModel.Location = new System.Drawing.Point(21, 157);
            this.btnModel.Margin = new System.Windows.Forms.Padding(4);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(179, 41);
            this.btnModel.TabIndex = 14;
            this.btnModel.Text = "Model";
            this.btnModel.UseVisualStyleBackColor = true;
            this.btnModel.Click += new System.EventHandler(this.btnModel_Click);
            // 
            // btnReport
            // 
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReport.Location = new System.Drawing.Point(21, 298);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(179, 41);
            this.btnReport.TabIndex = 13;
            this.btnReport.Text = "Reports";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnProject
            // 
            this.btnProject.Image = ((System.Drawing.Image)(resources.GetObject("btnProject.Image")));
            this.btnProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProject.Location = new System.Drawing.Point(21, 251);
            this.btnProject.Margin = new System.Windows.Forms.Padding(4);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(179, 41);
            this.btnProject.TabIndex = 12;
            this.btnProject.Text = "Project";
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnLocation.Image")));
            this.btnLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocation.Location = new System.Drawing.Point(21, 204);
            this.btnLocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(179, 41);
            this.btnLocation.TabIndex = 10;
            this.btnLocation.Text = "Location";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnActivities
            // 
            this.btnActivities.Image = ((System.Drawing.Image)(resources.GetObject("btnActivities.Image")));
            this.btnActivities.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivities.Location = new System.Drawing.Point(21, 111);
            this.btnActivities.Margin = new System.Windows.Forms.Padding(4);
            this.btnActivities.Name = "btnActivities";
            this.btnActivities.Size = new System.Drawing.Size(179, 41);
            this.btnActivities.TabIndex = 9;
            this.btnActivities.Text = "Activities";
            this.btnActivities.UseVisualStyleBackColor = true;
            this.btnActivities.Click += new System.EventHandler(this.btnActivities_Click);
            // 
            // btnShipItem
            // 
            this.btnShipItem.Image = ((System.Drawing.Image)(resources.GetObject("btnShipItem.Image")));
            this.btnShipItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShipItem.Location = new System.Drawing.Point(21, 64);
            this.btnShipItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnShipItem.Name = "btnShipItem";
            this.btnShipItem.Size = new System.Drawing.Size(179, 41);
            this.btnShipItem.TabIndex = 8;
            this.btnShipItem.Text = "Ship Item";
            this.btnShipItem.UseVisualStyleBackColor = true;
            this.btnShipItem.Click += new System.EventHandler(this.btnShipItem_Click);
            // 
            // btnItem
            // 
            this.btnItem.Image = ((System.Drawing.Image)(resources.GetObject("btnItem.Image")));
            this.btnItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnItem.Location = new System.Drawing.Point(21, 17);
            this.btnItem.Margin = new System.Windows.Forms.Padding(4);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(179, 41);
            this.btnItem.TabIndex = 7;
            this.btnItem.Text = "Items";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 37);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(16, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Equipments";
            // 
            // splitItems
            // 
            this.splitItems.BackColor = System.Drawing.Color.CornflowerBlue;
            this.splitItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitItems.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitItems.Location = new System.Drawing.Point(0, 37);
            this.splitItems.Margin = new System.Windows.Forms.Padding(4);
            this.splitItems.Name = "splitItems";
            this.splitItems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitItems.Panel1
            // 
            this.splitItems.Panel1.Controls.Add(this.gbReport);
            this.splitItems.Panel1.Controls.Add(this.gbButtonBar);
            // 
            // splitItems.Panel2
            // 
            this.splitItems.Panel2.Controls.Add(this.lstActivities);
            this.splitItems.Panel2.Controls.Add(this.lstReport);
            this.splitItems.Panel2.Controls.Add(this.lstShipIn);
            this.splitItems.Panel2.Controls.Add(this.lstModel);
            this.splitItems.Panel2.Controls.Add(this.lstItem);
            this.splitItems.Size = new System.Drawing.Size(948, 531);
            this.splitItems.SplitterDistance = 68;
            this.splitItems.SplitterWidth = 5;
            this.splitItems.TabIndex = 7;
            // 
            // gbReport
            // 
            this.gbReport.BackColor = System.Drawing.Color.Lavender;
            this.gbReport.Controls.Add(this.btnReportRefresh);
            this.gbReport.Controls.Add(this.btnRptExport);
            this.gbReport.Controls.Add(this.btnRptFilter);
            this.gbReport.Controls.Add(this.cboReportList);
            this.gbReport.Location = new System.Drawing.Point(413, 4);
            this.gbReport.Margin = new System.Windows.Forms.Padding(4);
            this.gbReport.Name = "gbReport";
            this.gbReport.Padding = new System.Windows.Forms.Padding(4);
            this.gbReport.Size = new System.Drawing.Size(452, 69);
            this.gbReport.TabIndex = 1;
            this.gbReport.TabStop = false;
            // 
            // btnReportRefresh
            // 
            this.btnReportRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReportRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnReportRefresh.Image")));
            this.btnReportRefresh.Location = new System.Drawing.Point(387, 15);
            this.btnReportRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnReportRefresh.Name = "btnReportRefresh";
            this.btnReportRefresh.Size = new System.Drawing.Size(57, 41);
            this.btnReportRefresh.TabIndex = 12;
            this.btnReportRefresh.UseVisualStyleBackColor = true;
            this.btnReportRefresh.Click += new System.EventHandler(this.btnReportRefresh_Click);
            // 
            // btnRptExport
            // 
            this.btnRptExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRptExport.Image = ((System.Drawing.Image)(resources.GetObject("btnRptExport.Image")));
            this.btnRptExport.Location = new System.Drawing.Point(328, 15);
            this.btnRptExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnRptExport.Name = "btnRptExport";
            this.btnRptExport.Size = new System.Drawing.Size(57, 41);
            this.btnRptExport.TabIndex = 11;
            this.btnRptExport.UseVisualStyleBackColor = true;
            this.btnRptExport.Click += new System.EventHandler(this.btnRptExport_Click);
            // 
            // btnRptFilter
            // 
            this.btnRptFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRptFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnRptFilter.Image")));
            this.btnRptFilter.Location = new System.Drawing.Point(269, 15);
            this.btnRptFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnRptFilter.Name = "btnRptFilter";
            this.btnRptFilter.Size = new System.Drawing.Size(57, 41);
            this.btnRptFilter.TabIndex = 10;
            this.btnRptFilter.UseVisualStyleBackColor = true;
            this.btnRptFilter.Click += new System.EventHandler(this.btnRptFilter_Click);
            // 
            // cboReportList
            // 
            this.cboReportList.FormattingEnabled = true;
            this.cboReportList.Items.AddRange(new object[] {
            "Product Transaction Report"});
            this.cboReportList.Location = new System.Drawing.Point(12, 22);
            this.cboReportList.Margin = new System.Windows.Forms.Padding(4);
            this.cboReportList.Name = "cboReportList";
            this.cboReportList.Size = new System.Drawing.Size(257, 24);
            this.cboReportList.TabIndex = 6;
            // 
            // gbButtonBar
            // 
            this.gbButtonBar.BackColor = System.Drawing.Color.Lavender;
            this.gbButtonBar.Controls.Add(this.btnRefresh);
            this.gbButtonBar.Controls.Add(this.btnExport);
            this.gbButtonBar.Controls.Add(this.btnfilter);
            this.gbButtonBar.Controls.Add(this.btnDelete);
            this.gbButtonBar.Controls.Add(this.btnAdd);
            this.gbButtonBar.Controls.Add(this.btnEdit);
            this.gbButtonBar.Location = new System.Drawing.Point(7, 5);
            this.gbButtonBar.Margin = new System.Windows.Forms.Padding(4);
            this.gbButtonBar.Name = "gbButtonBar";
            this.gbButtonBar.Padding = new System.Windows.Forms.Padding(4);
            this.gbButtonBar.Size = new System.Drawing.Size(400, 69);
            this.gbButtonBar.TabIndex = 0;
            this.gbButtonBar.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(329, 18);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(57, 41);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseHover += new System.EventHandler(this.btnRefresh_MouseHover);
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(265, 18);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(57, 41);
            this.btnExport.TabIndex = 9;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnExport.MouseHover += new System.EventHandler(this.btnExport_MouseHover);
            // 
            // btnfilter
            // 
            this.btnfilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnfilter.Image = ((System.Drawing.Image)(resources.GetObject("btnfilter.Image")));
            this.btnfilter.Location = new System.Drawing.Point(201, 18);
            this.btnfilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(57, 41);
            this.btnfilter.TabIndex = 9;
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            this.btnfilter.MouseHover += new System.EventHandler(this.btnfilter_MouseHover);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(137, 18);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(57, 41);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseHover += new System.EventHandler(this.btnDelete_MouseHover);
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(9, 18);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(57, 41);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            this.btnAdd.MouseHover += new System.EventHandler(this.btnAdd_MouseHover);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(73, 18);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(57, 41);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnEdit.MouseHover += new System.EventHandler(this.btnEdit_MouseHover);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlBottom.BackgroundImage")));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 568);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(948, 30);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlRight
            // 
            this.pnlRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRight.BackgroundImage")));
            this.pnlRight.Controls.Add(this.lblRight);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(948, 37);
            this.pnlRight.TabIndex = 1;
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.BackColor = System.Drawing.Color.Transparent;
            this.lblRight.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblRight.Location = new System.Drawing.Point(4, 10);
            this.lblRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(111, 24);
            this.lblRight.TabIndex = 1;
            this.lblRight.Text = "List of Users";
            // 
            // lstActivities
            // 
            this.lstActivities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader12,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader33,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38});
            this.lstActivities.ContextMenuStrip = this.mnuList;
            this.lstActivities.FullRowSelect = true;
            this.lstActivities.HideSelection = false;
            this.lstActivities.LargeImageList = this.imgStnLarge;
            this.lstActivities.Location = new System.Drawing.Point(45, 186);
            this.lstActivities.Margin = new System.Windows.Forms.Padding(4);
            this.lstActivities.Name = "lstActivities";
            this.lstActivities.OwnerDraw = true;
            this.lstActivities.Size = new System.Drawing.Size(260, 244);
            this.lstActivities.SmallImageList = this.imgStnSmall;
            this.lstActivities.TabIndex = 18;
            this.lstActivities.UseCompatibleStateImageBehavior = false;
            this.lstActivities.View = System.Windows.Forms.View.Details;
            this.lstActivities.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "      ShipID";
            this.columnHeader1.Width = 23;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Item Name";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Model";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Serial No.";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "From Location";
            this.columnHeader16.Width = 190;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Current Location";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Quantity";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Person In-Charge";
            this.columnHeader19.Width = 100;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Last Updated Date";
            this.columnHeader20.Width = 150;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Purchase Date";
            this.columnHeader21.Width = 100;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Last Calibration";
            this.columnHeader22.Width = 100;
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Next Calibration";
            this.columnHeader26.Width = 100;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Description";
            this.columnHeader27.Width = 150;
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Project Name";
            this.columnHeader33.Width = 100;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Station Name";
            this.columnHeader36.Width = 100;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Remarks";
            this.columnHeader37.Width = 200;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "User";
            this.columnHeader38.Width = 80;
            // 
            // lstReport
            // 
            this.lstReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25});
            this.lstReport.FullRowSelect = true;
            this.lstReport.HideSelection = false;
            this.lstReport.LargeImageList = this.imgStnLarge;
            this.lstReport.Location = new System.Drawing.Point(315, 27);
            this.lstReport.Margin = new System.Windows.Forms.Padding(4);
            this.lstReport.Name = "lstReport";
            this.lstReport.OwnerDraw = true;
            this.lstReport.Size = new System.Drawing.Size(260, 244);
            this.lstReport.SmallImageList = this.imgStnSmall;
            this.lstReport.TabIndex = 17;
            this.lstReport.UseCompatibleStateImageBehavior = false;
            this.lstReport.View = System.Windows.Forms.View.Details;
            this.lstReport.Visible = false;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item Name";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Model";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Serial No.";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Location To/From";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "In";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Out";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Balance";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Date";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Description";
            this.columnHeader13.Width = 150;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Project";
            this.columnHeader14.Width = 90;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Station";
            this.columnHeader15.Width = 70;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "User";
            this.columnHeader23.Width = 80;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Requested By";
            this.columnHeader24.Width = 130;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Remarks";
            this.columnHeader25.Width = 200;
            // 
            // lstShipIn
            // 
            this.lstShipIn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShipID,
            this.colItemName,
            this.colModel,
            this.colSerial,
            this.colTLoc,
            this.colPInCharge,
            this.colUpdateDate,
            this.colPDate,
            this.colCaliDate,
            this.colNextCaliDate,
            this.colRemark,
            this.col_User,
            this.col_Project,
            this.col_STN,
            this.col_Desc});
            this.lstShipIn.ContextMenuStrip = this.mnuList;
            this.lstShipIn.FullRowSelect = true;
            this.lstShipIn.HideSelection = false;
            this.lstShipIn.LargeImageList = this.imgStnLarge;
            this.lstShipIn.Location = new System.Drawing.Point(584, 27);
            this.lstShipIn.Margin = new System.Windows.Forms.Padding(4);
            this.lstShipIn.Name = "lstShipIn";
            this.lstShipIn.OwnerDraw = true;
            this.lstShipIn.Size = new System.Drawing.Size(260, 244);
            this.lstShipIn.SmallImageList = this.imgStnSmall;
            this.lstShipIn.TabIndex = 16;
            this.lstShipIn.UseCompatibleStateImageBehavior = false;
            this.lstShipIn.View = System.Windows.Forms.View.Details;
            this.lstShipIn.Visible = false;
            // 
            // colShipID
            // 
            this.colShipID.Text = "      ShipID";
            this.colShipID.Width = 23;
            // 
            // colItemName
            // 
            this.colItemName.Text = "Item Name";
            this.colItemName.Width = 80;
            // 
            // colModel
            // 
            this.colModel.Text = "Model";
            this.colModel.Width = 150;
            // 
            // colSerial
            // 
            this.colSerial.Text = "Serial No.";
            this.colSerial.Width = 100;
            // 
            // colTLoc
            // 
            this.colTLoc.Text = "Current Location";
            this.colTLoc.Width = 100;
            // 
            // colPInCharge
            // 
            this.colPInCharge.Text = "Person In-Charge";
            this.colPInCharge.Width = 100;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.Text = "Last Updated Date";
            this.colUpdateDate.Width = 150;
            // 
            // colPDate
            // 
            this.colPDate.Text = "Purchase Date";
            this.colPDate.Width = 100;
            // 
            // colCaliDate
            // 
            this.colCaliDate.Text = "Last Calibration";
            this.colCaliDate.Width = 100;
            // 
            // colNextCaliDate
            // 
            this.colNextCaliDate.Text = "Next Calibration";
            this.colNextCaliDate.Width = 100;
            // 
            // colRemark
            // 
            this.colRemark.Text = "Remarks";
            this.colRemark.Width = 200;
            // 
            // col_User
            // 
            this.col_User.Text = "User";
            this.col_User.Width = 80;
            // 
            // col_Project
            // 
            this.col_Project.Text = "Project";
            // 
            // col_STN
            // 
            this.col_STN.Text = "Station";
            // 
            // col_Desc
            // 
            this.col_Desc.Text = "Description";
            this.col_Desc.Width = 200;
            // 
            // lstModel
            // 
            this.lstModel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader34,
            this.columnHeader35,
            this.columnHeader50});
            this.lstModel.ContextMenuStrip = this.mnuList;
            this.lstModel.FullRowSelect = true;
            this.lstModel.HideSelection = false;
            this.lstModel.Location = new System.Drawing.Point(9, 26);
            this.lstModel.Margin = new System.Windows.Forms.Padding(4);
            this.lstModel.Name = "lstModel";
            this.lstModel.OwnerDraw = true;
            this.lstModel.Size = new System.Drawing.Size(371, 181);
            this.lstModel.TabIndex = 15;
            this.lstModel.UseCompatibleStateImageBehavior = false;
            this.lstModel.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Name";
            this.columnHeader31.Width = 150;
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Item";
            this.columnHeader32.Width = 100;
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Remarks";
            this.columnHeader34.Width = 250;
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "Last Updated Date";
            this.columnHeader35.Width = 150;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "Last updated User";
            this.columnHeader50.Width = 120;
            // 
            // lstItem
            // 
            this.lstItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader51});
            this.lstItem.ContextMenuStrip = this.mnuList;
            this.lstItem.FullRowSelect = true;
            this.lstItem.HideSelection = false;
            this.lstItem.Location = new System.Drawing.Point(363, 279);
            this.lstItem.Margin = new System.Windows.Forms.Padding(4);
            this.lstItem.Name = "lstItem";
            this.lstItem.OwnerDraw = true;
            this.lstItem.Size = new System.Drawing.Size(347, 154);
            this.lstItem.TabIndex = 14;
            this.lstItem.UseCompatibleStateImageBehavior = false;
            this.lstItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Name";
            this.columnHeader28.Width = 200;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "Remarks";
            this.columnHeader29.Width = 250;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Last Updated Date";
            this.columnHeader30.Width = 150;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "Last updated User";
            this.columnHeader51.Width = 120;
            // 
            // lstUsers
            // 
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUser,
            this.colRole});
            this.lstUsers.ContextMenuStrip = this.mnuUsers;
            listViewGroup1.Header = "Super Admin";
            listViewGroup1.Name = "lstGroupSuperAmin";
            listViewGroup2.Header = "Administrator";
            listViewGroup2.Name = "lstGroupAdmin";
            listViewGroup3.Header = "Viewer";
            listViewGroup3.Name = "lstGroupViewer";
            this.lstUsers.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lstUsers.HideSelection = false;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup2;
            listViewItem3.Group = listViewGroup3;
            this.lstUsers.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.lstUsers.LargeImageList = this.imgUserLarge;
            this.lstUsers.Location = new System.Drawing.Point(4, 37);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.OwnerDraw = true;
            this.lstUsers.Size = new System.Drawing.Size(315, 244);
            this.lstUsers.SmallImageList = this.imgUserSmall;
            this.lstUsers.TabIndex = 3;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Tile;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            this.lstUsers.DoubleClick += new System.EventHandler(this.btnEditUser_Click);
            // 
            // colUser
            // 
            this.colUser.Text = "User";
            // 
            // colRole
            // 
            this.colRole.Text = "Role";
            this.colRole.Width = 255;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 681);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.statMain);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSP Inventory";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            this.mnuActivities.ResumeLayout(false);
            this.mnuList.ResumeLayout(false);
            this.mnuPrisms.ResumeLayout(false);
            this.mnuUsers.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.outlookBarMain.ContentPanel.ResumeLayout(false);
            this.outlookBarItemUsers.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlOutlookUsers.ResumeLayout(false);
            this.pnlOutlookUsers.PerformLayout();
            this.outlookBarItem.ResumeLayout(false);
            this.gbItems.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitItems.Panel1.ResumeLayout(false);
            this.splitItems.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitItems)).EndInit();
            this.splitItems.ResumeLayout(false);
            this.gbReport.ResumeLayout(false);
            this.gbButtonBar.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.StatusStrip statMain;
        private System.Windows.Forms.SplitContainer splitMain;
        private OutlookBarLibrary.Controls.OutlookBar outlookBarMain;
        private OutlookBarLibrary.Controls.OutlookBarItem outlookBarItemUsers;
        private OutlookBarLibrary.Controls.OutlookBarItem outlookBarItem;
        private System.Windows.Forms.Panel pnlOutlookUsers;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlRight;
        private ControlEx.ListViewEx lstUsers;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colRole;
        private System.Windows.Forms.ImageList imgUserLarge;
        private System.Windows.Forms.ImageList imgUserSmall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolOptions;
        private System.Windows.Forms.ImageList imgStnLarge;
        private System.Windows.Forms.ImageList imgStnSmall;
        private System.Windows.Forms.ImageList imgPrismLarge;
        private System.Windows.Forms.ImageList imgPrismSmall;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolAbout;
        private System.Windows.Forms.Timer tmrSplash;
        private System.ComponentModel.BackgroundWorker hSplash;
        private System.Windows.Forms.ContextMenuStrip mnuUsers;
        private System.Windows.Forms.ToolStripMenuItem mnuAddUser;
        private System.Windows.Forms.ToolStripMenuItem mnuEditUser;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteUser;
        private System.Windows.Forms.ContextMenuStrip mnuList;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ContextMenuStrip mnuPrisms;
        private System.Windows.Forms.ToolStripMenuItem mnuPrismIn;
        private System.Windows.Forms.ToolStripMenuItem mnuPrismOut;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip mnuActivities;
        private System.Windows.Forms.ToolStripMenuItem mnuEditRemarks;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.SaveFileDialog dlgFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteActivities;
        private System.Windows.Forms.SplitContainer splitItems;
        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Button btnActivities;
        private System.Windows.Forms.Button btnShipItem;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.GroupBox gbButtonBar;
        private System.Windows.Forms.Button btnfilter;
        private System.Windows.Forms.GroupBox gbReport;
        private System.Windows.Forms.Button btnRptExport;
        private System.Windows.Forms.Button btnRptFilter;
        private System.Windows.Forms.ComboBox cboReportList;
        private System.Windows.Forms.Button btnRefresh;
        private ControlEx.ListViewEx lstItem;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.Button btnModel;
        private ControlEx.ListViewEx lstModel;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader34;
        private System.Windows.Forms.ColumnHeader columnHeader35;
        private System.Windows.Forms.ColumnHeader columnHeader32;
        private ControlEx.ListViewEx lstShipIn;
        private System.Windows.Forms.ColumnHeader colItemName;
        private System.Windows.Forms.ColumnHeader colModel;
        private System.Windows.Forms.ColumnHeader colSerial;
        private System.Windows.Forms.ColumnHeader colTLoc;
        private System.Windows.Forms.ColumnHeader colPInCharge;
        private System.Windows.Forms.ColumnHeader colUpdateDate;
        private System.Windows.Forms.ColumnHeader colPDate;
        private System.Windows.Forms.ColumnHeader colCaliDate;
        private System.Windows.Forms.ColumnHeader colNextCaliDate;
        private System.Windows.Forms.ColumnHeader colRemark;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader columnHeader50;
        private System.Windows.Forms.ColumnHeader columnHeader51;
        private System.Windows.Forms.ColumnHeader col_User;
        private System.Windows.Forms.ColumnHeader colShipID;
        private ControlEx.ListViewEx lstReport;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.Button btnReportRefresh;
        private ControlEx.ListViewEx lstActivities;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader33;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader col_Project;
        private System.Windows.Forms.ColumnHeader col_STN;
        private System.Windows.Forms.ColumnHeader col_Desc;
    }
}

