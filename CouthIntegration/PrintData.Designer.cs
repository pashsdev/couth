namespace CouthIntegration
{
    partial class PrintData
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbTemplate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.CmbUnits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkMarkAll = new System.Windows.Forms.CheckBox();
            this.ChkMarkEven = new System.Windows.Forms.CheckBox();
            this.ChkMarkOdd = new System.Windows.Forms.CheckBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.txtSerialNoTo = new System.Windows.Forms.TextBox();
            this.lblSerialNoTo = new System.Windows.Forms.Label();
            this.txtSerialNoFrom = new System.Windows.Forms.TextBox();
            this.lblSerialNoFrom = new System.Windows.Forms.Label();
            this.CmbJobNo = new System.Windows.Forms.ComboBox();
            this.lblJobno = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadSerialNo = new System.Windows.Forms.RadioButton();
            this.RadJobno = new System.Windows.Forms.RadioButton();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnPrintPreview = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.DgvColSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColhead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColPerfomance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColR01_PUMP_MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvcolR01_VOLTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvcolCATEGORY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColkwhp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColAMPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColPHASE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColRPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColMIN_BORE_SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColDISCHARGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColHEAD_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColC_SIZE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColR01_AMPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColJobno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvColMark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CmbTemplate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtJobNo);
            this.panel1.Controls.Add(this.CmbUnits);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.BtnReset);
            this.panel1.Controls.Add(this.BtnClear);
            this.panel1.Controls.Add(this.txtSerialNoTo);
            this.panel1.Controls.Add(this.lblSerialNoTo);
            this.panel1.Controls.Add(this.txtSerialNoFrom);
            this.panel1.Controls.Add(this.lblSerialNoFrom);
            this.panel1.Controls.Add(this.CmbJobNo);
            this.panel1.Controls.Add(this.lblJobno);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.BtnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 75);
            this.panel1.TabIndex = 3;
            // 
            // CmbTemplate
            // 
            this.CmbTemplate.DisplayMember = "TemplateName";
            this.CmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTemplate.FormattingEnabled = true;
            this.CmbTemplate.Location = new System.Drawing.Point(469, 45);
            this.CmbTemplate.Name = "CmbTemplate";
            this.CmbTemplate.Size = new System.Drawing.Size(205, 21);
            this.CmbTemplate.TabIndex = 20;
            this.CmbTemplate.ValueMember = "TemplateID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Template";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(69, 45);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(337, 20);
            this.txtJobNo.TabIndex = 18;
            // 
            // CmbUnits
            // 
            this.CmbUnits.DisplayMember = "UnitName";
            this.CmbUnits.FormattingEnabled = true;
            this.CmbUnits.Location = new System.Drawing.Point(268, 16);
            this.CmbUnits.Name = "CmbUnits";
            this.CmbUnits.Size = new System.Drawing.Size(148, 21);
            this.CmbUnits.TabIndex = 17;
            this.CmbUnits.ValueMember = "UnitID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Unit";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkMarkAll);
            this.groupBox2.Controls.Add(this.ChkMarkEven);
            this.groupBox2.Controls.Add(this.ChkMarkOdd);
            this.groupBox2.Location = new System.Drawing.Point(818, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 31);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // ChkMarkAll
            // 
            this.ChkMarkAll.AutoSize = true;
            this.ChkMarkAll.Location = new System.Drawing.Point(168, 10);
            this.ChkMarkAll.Name = "ChkMarkAll";
            this.ChkMarkAll.Size = new System.Drawing.Size(64, 17);
            this.ChkMarkAll.TabIndex = 2;
            this.ChkMarkAll.Text = "Mark All";
            this.ChkMarkAll.UseVisualStyleBackColor = true;
            this.ChkMarkAll.CheckedChanged += new System.EventHandler(this.ChkMarkAll_CheckedChanged);
            // 
            // ChkMarkEven
            // 
            this.ChkMarkEven.AutoSize = true;
            this.ChkMarkEven.Location = new System.Drawing.Point(84, 10);
            this.ChkMarkEven.Name = "ChkMarkEven";
            this.ChkMarkEven.Size = new System.Drawing.Size(78, 17);
            this.ChkMarkEven.TabIndex = 1;
            this.ChkMarkEven.Text = "Mark Even";
            this.ChkMarkEven.UseVisualStyleBackColor = true;
            this.ChkMarkEven.CheckedChanged += new System.EventHandler(this.ChkMarkEven_CheckedChanged);
            // 
            // ChkMarkOdd
            // 
            this.ChkMarkOdd.AutoSize = true;
            this.ChkMarkOdd.Location = new System.Drawing.Point(6, 10);
            this.ChkMarkOdd.Name = "ChkMarkOdd";
            this.ChkMarkOdd.Size = new System.Drawing.Size(73, 17);
            this.ChkMarkOdd.TabIndex = 0;
            this.ChkMarkOdd.Text = "Mark Odd";
            this.ChkMarkOdd.UseVisualStyleBackColor = true;
            this.ChkMarkOdd.CheckedChanged += new System.EventHandler(this.ChkMarkOdd_CheckedChanged);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(680, 45);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(61, 23);
            this.BtnReset.TabIndex = 15;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(747, 45);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(65, 23);
            this.BtnClear.TabIndex = 13;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // txtSerialNoTo
            // 
            this.txtSerialNoTo.Location = new System.Drawing.Point(789, 16);
            this.txtSerialNoTo.Name = "txtSerialNoTo";
            this.txtSerialNoTo.Size = new System.Drawing.Size(182, 20);
            this.txtSerialNoTo.TabIndex = 12;
            // 
            // lblSerialNoTo
            // 
            this.lblSerialNoTo.AutoSize = true;
            this.lblSerialNoTo.Location = new System.Drawing.Point(707, 19);
            this.lblSerialNoTo.Name = "lblSerialNoTo";
            this.lblSerialNoTo.Size = new System.Drawing.Size(66, 13);
            this.lblSerialNoTo.TabIndex = 11;
            this.lblSerialNoTo.Text = "Serial No To";
            // 
            // txtSerialNoFrom
            // 
            this.txtSerialNoFrom.Location = new System.Drawing.Point(509, 16);
            this.txtSerialNoFrom.Name = "txtSerialNoFrom";
            this.txtSerialNoFrom.Size = new System.Drawing.Size(187, 20);
            this.txtSerialNoFrom.TabIndex = 10;
            // 
            // lblSerialNoFrom
            // 
            this.lblSerialNoFrom.AutoSize = true;
            this.lblSerialNoFrom.Location = new System.Drawing.Point(426, 19);
            this.lblSerialNoFrom.Name = "lblSerialNoFrom";
            this.lblSerialNoFrom.Size = new System.Drawing.Size(76, 13);
            this.lblSerialNoFrom.TabIndex = 9;
            this.lblSerialNoFrom.Text = "Serial No From";
            // 
            // CmbJobNo
            // 
            this.CmbJobNo.DisplayMember = "Jobno";
            this.CmbJobNo.FormattingEnabled = true;
            this.CmbJobNo.Location = new System.Drawing.Point(69, 45);
            this.CmbJobNo.Name = "CmbJobNo";
            this.CmbJobNo.Size = new System.Drawing.Size(148, 21);
            this.CmbJobNo.TabIndex = 8;
            this.CmbJobNo.ValueMember = "Jobno";
            this.CmbJobNo.Visible = false;
            // 
            // lblJobno
            // 
            this.lblJobno.AutoSize = true;
            this.lblJobno.Location = new System.Drawing.Point(7, 49);
            this.lblJobno.Name = "lblJobno";
            this.lblJobno.Size = new System.Drawing.Size(41, 13);
            this.lblJobno.TabIndex = 7;
            this.lblJobno.Text = "Job No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadSerialNo);
            this.groupBox1.Controls.Add(this.RadJobno);
            this.groupBox1.Location = new System.Drawing.Point(69, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 34);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // RadSerialNo
            // 
            this.RadSerialNo.AutoSize = true;
            this.RadSerialNo.Location = new System.Drawing.Point(72, 12);
            this.RadSerialNo.Name = "RadSerialNo";
            this.RadSerialNo.Size = new System.Drawing.Size(68, 17);
            this.RadSerialNo.TabIndex = 7;
            this.RadSerialNo.TabStop = true;
            this.RadSerialNo.Text = "Serial No";
            this.RadSerialNo.UseVisualStyleBackColor = true;
            this.RadSerialNo.CheckedChanged += new System.EventHandler(this.RadSerialNo_CheckedChanged);
            // 
            // RadJobno
            // 
            this.RadJobno.AutoSize = true;
            this.RadJobno.Location = new System.Drawing.Point(6, 12);
            this.RadJobno.Name = "RadJobno";
            this.RadJobno.Size = new System.Drawing.Size(59, 17);
            this.RadJobno.TabIndex = 6;
            this.RadJobno.Text = "Job No";
            this.RadJobno.UseVisualStyleBackColor = true;
            this.RadJobno.CheckedChanged += new System.EventHandler(this.RadJobno_CheckedChanged);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(973, 14);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search By *";
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvColSno,
            this.DgvColhead,
            this.DgvColPerfomance,
            this.DgvColR01_PUMP_MODEL,
            this.DgvcolR01_VOLTS,
            this.DgvcolCATEGORY,
            this.DgvColkwhp,
            this.DgvColAMPS,
            this.DgvColPHASE,
            this.DgvColRPM,
            this.DgvColMIN_BORE_SIZE,
            this.DgvColDISCHARGE,
            this.DgvColHEAD_MAX,
            this.DgvColC_SIZE,
            this.DgvColR01_AMPS,
            this.DgvColItemID,
            this.DgvColProduct,
            this.DgvColJobno,
            this.DgvColDesc,
            this.DgvColSerialNo,
            this.DgvColTemplate,
            this.DgvColMark});
            this.Grid.Location = new System.Drawing.Point(5, 89);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(1053, 305);
            this.Grid.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnPrintPreview);
            this.panel2.Controls.Add(this.BtnPrint);
            this.panel2.Location = new System.Drawing.Point(5, 400);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 34);
            this.panel2.TabIndex = 15;
            // 
            // BtnPrintPreview
            // 
            this.BtnPrintPreview.Location = new System.Drawing.Point(825, 6);
            this.BtnPrintPreview.Name = "BtnPrintPreview";
            this.BtnPrintPreview.Size = new System.Drawing.Size(96, 23);
            this.BtnPrintPreview.TabIndex = 16;
            this.BtnPrintPreview.Text = "Print Preview";
            this.BtnPrintPreview.UseVisualStyleBackColor = true;
            this.BtnPrintPreview.Visible = false;
            this.BtnPrintPreview.Click += new System.EventHandler(this.BtnPrintPreview_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(927, 6);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(120, 23);
            this.BtnPrint.TabIndex = 14;
            this.BtnPrint.Text = "Send To Print";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // DgvColSno
            // 
            this.DgvColSno.DataPropertyName = "Sno";
            this.DgvColSno.Frozen = true;
            this.DgvColSno.HeaderText = "Sno";
            this.DgvColSno.Name = "DgvColSno";
            this.DgvColSno.ReadOnly = true;
            this.DgvColSno.Width = 60;
            // 
            // DgvColhead
            // 
            this.DgvColhead.DataPropertyName = "Head";
            this.DgvColhead.HeaderText = "Head";
            this.DgvColhead.Name = "DgvColhead";
            this.DgvColhead.ReadOnly = true;
            this.DgvColhead.Visible = false;
            // 
            // DgvColPerfomance
            // 
            this.DgvColPerfomance.DataPropertyName = "Perfomance";
            this.DgvColPerfomance.HeaderText = "Perfomance";
            this.DgvColPerfomance.Name = "DgvColPerfomance";
            this.DgvColPerfomance.ReadOnly = true;
            this.DgvColPerfomance.Visible = false;
            // 
            // DgvColR01_PUMP_MODEL
            // 
            this.DgvColR01_PUMP_MODEL.DataPropertyName = "R01_PUMP_MODEL";
            this.DgvColR01_PUMP_MODEL.HeaderText = "R01_PUMP_MODEL";
            this.DgvColR01_PUMP_MODEL.Name = "DgvColR01_PUMP_MODEL";
            this.DgvColR01_PUMP_MODEL.ReadOnly = true;
            this.DgvColR01_PUMP_MODEL.Visible = false;
            // 
            // DgvcolR01_VOLTS
            // 
            this.DgvcolR01_VOLTS.DataPropertyName = "R01_VOLTS";
            this.DgvcolR01_VOLTS.HeaderText = "R01_VOLTS";
            this.DgvcolR01_VOLTS.Name = "DgvcolR01_VOLTS";
            this.DgvcolR01_VOLTS.ReadOnly = true;
            this.DgvcolR01_VOLTS.Visible = false;
            // 
            // DgvcolCATEGORY
            // 
            this.DgvcolCATEGORY.DataPropertyName = "CATEGORY";
            this.DgvcolCATEGORY.HeaderText = "CATEGORY";
            this.DgvcolCATEGORY.Name = "DgvcolCATEGORY";
            this.DgvcolCATEGORY.ReadOnly = true;
            this.DgvcolCATEGORY.Visible = false;
            // 
            // DgvColkwhp
            // 
            this.DgvColkwhp.DataPropertyName = "kwhp";
            this.DgvColkwhp.HeaderText = "kwhp";
            this.DgvColkwhp.Name = "DgvColkwhp";
            this.DgvColkwhp.ReadOnly = true;
            this.DgvColkwhp.Visible = false;
            // 
            // DgvColAMPS
            // 
            this.DgvColAMPS.DataPropertyName = "AMPS";
            this.DgvColAMPS.HeaderText = "AMPS";
            this.DgvColAMPS.Name = "DgvColAMPS";
            this.DgvColAMPS.ReadOnly = true;
            this.DgvColAMPS.Visible = false;
            // 
            // DgvColPHASE
            // 
            this.DgvColPHASE.DataPropertyName = "PHASE";
            this.DgvColPHASE.HeaderText = "PHASE";
            this.DgvColPHASE.Name = "DgvColPHASE";
            this.DgvColPHASE.ReadOnly = true;
            this.DgvColPHASE.Visible = false;
            // 
            // DgvColRPM
            // 
            this.DgvColRPM.DataPropertyName = "RPM";
            this.DgvColRPM.HeaderText = "RPM";
            this.DgvColRPM.Name = "DgvColRPM";
            this.DgvColRPM.ReadOnly = true;
            this.DgvColRPM.Visible = false;
            // 
            // DgvColMIN_BORE_SIZE
            // 
            this.DgvColMIN_BORE_SIZE.DataPropertyName = "MIN_BORE_SIZE";
            this.DgvColMIN_BORE_SIZE.HeaderText = "MIN_BORE_SIZE";
            this.DgvColMIN_BORE_SIZE.Name = "DgvColMIN_BORE_SIZE";
            this.DgvColMIN_BORE_SIZE.ReadOnly = true;
            this.DgvColMIN_BORE_SIZE.Visible = false;
            // 
            // DgvColDISCHARGE
            // 
            this.DgvColDISCHARGE.DataPropertyName = "DISCHARGE";
            this.DgvColDISCHARGE.HeaderText = "DISCHARGE";
            this.DgvColDISCHARGE.Name = "DgvColDISCHARGE";
            this.DgvColDISCHARGE.ReadOnly = true;
            this.DgvColDISCHARGE.Visible = false;
            // 
            // DgvColHEAD_MAX
            // 
            this.DgvColHEAD_MAX.DataPropertyName = "HEAD_MAX";
            this.DgvColHEAD_MAX.HeaderText = "HEAD_MAX";
            this.DgvColHEAD_MAX.Name = "DgvColHEAD_MAX";
            this.DgvColHEAD_MAX.ReadOnly = true;
            this.DgvColHEAD_MAX.Visible = false;
            // 
            // DgvColC_SIZE
            // 
            this.DgvColC_SIZE.DataPropertyName = "C_SIZE";
            this.DgvColC_SIZE.HeaderText = "C_SIZE";
            this.DgvColC_SIZE.Name = "DgvColC_SIZE";
            this.DgvColC_SIZE.ReadOnly = true;
            this.DgvColC_SIZE.Visible = false;
            // 
            // DgvColR01_AMPS
            // 
            this.DgvColR01_AMPS.DataPropertyName = "R01_AMPS";
            this.DgvColR01_AMPS.HeaderText = "R01_AMPS";
            this.DgvColR01_AMPS.Name = "DgvColR01_AMPS";
            this.DgvColR01_AMPS.ReadOnly = true;
            this.DgvColR01_AMPS.Visible = false;
            // 
            // DgvColItemID
            // 
            this.DgvColItemID.DataPropertyName = "Inventory_Item_Id";
            this.DgvColItemID.HeaderText = "ItemID";
            this.DgvColItemID.Name = "DgvColItemID";
            this.DgvColItemID.ReadOnly = true;
            this.DgvColItemID.Visible = false;
            // 
            // DgvColProduct
            // 
            this.DgvColProduct.DataPropertyName = "Product";
            this.DgvColProduct.HeaderText = "Product";
            this.DgvColProduct.Name = "DgvColProduct";
            this.DgvColProduct.ReadOnly = true;
            this.DgvColProduct.Visible = false;
            // 
            // DgvColJobno
            // 
            this.DgvColJobno.DataPropertyName = "JobNo";
            this.DgvColJobno.HeaderText = "Job No";
            this.DgvColJobno.Name = "DgvColJobno";
            this.DgvColJobno.ReadOnly = true;
            this.DgvColJobno.Width = 200;
            // 
            // DgvColDesc
            // 
            this.DgvColDesc.DataPropertyName = "ProductDesc";
            this.DgvColDesc.HeaderText = "Prod. Desc";
            this.DgvColDesc.Name = "DgvColDesc";
            this.DgvColDesc.ReadOnly = true;
            this.DgvColDesc.Width = 300;
            // 
            // DgvColSerialNo
            // 
            this.DgvColSerialNo.DataPropertyName = "SerialNo";
            this.DgvColSerialNo.HeaderText = "Serial No";
            this.DgvColSerialNo.Name = "DgvColSerialNo";
            this.DgvColSerialNo.ReadOnly = true;
            this.DgvColSerialNo.Width = 200;
            // 
            // DgvColTemplate
            // 
            this.DgvColTemplate.DataPropertyName = "Template";
            this.DgvColTemplate.HeaderText = "Template";
            this.DgvColTemplate.Name = "DgvColTemplate";
            this.DgvColTemplate.ReadOnly = true;
            this.DgvColTemplate.Visible = false;
            this.DgvColTemplate.Width = 200;
            // 
            // DgvColMark
            // 
            this.DgvColMark.HeaderText = "Mark";
            this.DgvColMark.Name = "DgvColMark";
            // 
            // PrintData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 438);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Job no / Serial no search";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadSerialNo;
        private System.Windows.Forms.RadioButton RadJobno;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerialNoTo;
        private System.Windows.Forms.Label lblSerialNoTo;
        private System.Windows.Forms.TextBox txtSerialNoFrom;
        private System.Windows.Forms.Label lblSerialNoFrom;
        private System.Windows.Forms.ComboBox CmbJobNo;
        private System.Windows.Forms.Label lblJobno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkMarkAll;
        private System.Windows.Forms.CheckBox ChkMarkEven;
        private System.Windows.Forms.CheckBox ChkMarkOdd;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnPrintPreview;
        private System.Windows.Forms.ComboBox CmbUnits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.ComboBox CmbTemplate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColhead;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColPerfomance;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColR01_PUMP_MODEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvcolR01_VOLTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvcolCATEGORY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColkwhp;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColAMPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColPHASE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColRPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColMIN_BORE_SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColDISCHARGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColHEAD_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColC_SIZE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColR01_AMPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColJobno;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvColTemplate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DgvColMark;
    }
}