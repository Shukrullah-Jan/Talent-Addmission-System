namespace Talent_Addmission_System.User_Controls
{
    partial class UCSearchRecords
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearchRecord = new Guna.UI2.WinForms.Guna2Button();
            this.groupBoxSearch = new Guna.UI2.WinForms.Guna2GroupBox();
            this.tbRegistrationNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStudentName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbStudentID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxSearchBy = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rbRegNumber = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbStudentName = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbStudentID = new Guna.UI2.WinForms.Guna2RadioButton();
            this.epID = new System.Windows.Forms.ErrorProvider(this.components);
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epRegistrationNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelDisplayBtn = new System.Windows.Forms.Panel();
            this.dgvSearchedRecords = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnDisplayRecord = new Guna.UI2.WinForms.Guna2Button();
            this.panelSearch.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxSearchBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRegistrationNumber)).BeginInit();
            this.panelDisplayBtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchedRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panelSearch.Controls.Add(this.btnSearchRecord);
            this.panelSearch.Controls.Add(this.groupBoxSearch);
            this.panelSearch.Controls.Add(this.groupBoxSearchBy);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(332, 569);
            this.panelSearch.TabIndex = 0;
            // 
            // btnSearchRecord
            // 
            this.btnSearchRecord.Animated = true;
            this.btnSearchRecord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchRecord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchRecord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSearchRecord.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSearchRecord.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnSearchRecord.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSearchRecord.Location = new System.Drawing.Point(13, 328);
            this.btnSearchRecord.Name = "btnSearchRecord";
            this.btnSearchRecord.Size = new System.Drawing.Size(152, 40);
            this.btnSearchRecord.TabIndex = 0;
            this.btnSearchRecord.Text = "SEARCH RECORD";
            this.btnSearchRecord.Click += new System.EventHandler(this.btnSearchRecord_Click);
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.groupBoxSearch.Controls.Add(this.tbRegistrationNumber);
            this.groupBoxSearch.Controls.Add(this.label1);
            this.groupBoxSearch.Controls.Add(this.tbStudentName);
            this.groupBoxSearch.Controls.Add(this.tbStudentID);
            this.groupBoxSearch.Controls.Add(this.label3);
            this.groupBoxSearch.Controls.Add(this.label2);
            this.groupBoxSearch.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.groupBoxSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.groupBoxSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxSearch.Location = new System.Drawing.Point(3, 104);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(327, 207);
            this.groupBoxSearch.TabIndex = 40;
            this.groupBoxSearch.Text = "Search";
            // 
            // tbRegistrationNumber
            // 
            this.tbRegistrationNumber.Animated = true;
            this.tbRegistrationNumber.BorderColor = System.Drawing.Color.Silver;
            this.tbRegistrationNumber.BorderRadius = 5;
            this.tbRegistrationNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbRegistrationNumber.DefaultText = "";
            this.tbRegistrationNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbRegistrationNumber.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.tbRegistrationNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbRegistrationNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbRegistrationNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbRegistrationNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbRegistrationNumber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRegistrationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbRegistrationNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbRegistrationNumber.Location = new System.Drawing.Point(144, 139);
            this.tbRegistrationNumber.Name = "tbRegistrationNumber";
            this.tbRegistrationNumber.PasswordChar = '\0';
            this.tbRegistrationNumber.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbRegistrationNumber.PlaceholderText = "Registration Number";
            this.tbRegistrationNumber.SelectedText = "";
            this.tbRegistrationNumber.Size = new System.Drawing.Size(137, 26);
            this.tbRegistrationNumber.TabIndex = 2;
            this.tbRegistrationNumber.TextChanged += new System.EventHandler(this.tbRegistrationNumber_TextChanged);
            this.tbRegistrationNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRegistrationNumber_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(5, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 21);
            this.label1.TabIndex = 145;
            this.label1.Text = "Reg/Slip Number:";
            // 
            // tbStudentName
            // 
            this.tbStudentName.Animated = true;
            this.tbStudentName.BorderColor = System.Drawing.Color.Silver;
            this.tbStudentName.BorderRadius = 5;
            this.tbStudentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStudentName.DefaultText = "";
            this.tbStudentName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbStudentName.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.tbStudentName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbStudentName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbStudentName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbStudentName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentName.Location = new System.Drawing.Point(144, 97);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.PasswordChar = '\0';
            this.tbStudentName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentName.PlaceholderText = "Student Name";
            this.tbStudentName.SelectedText = "";
            this.tbStudentName.Size = new System.Drawing.Size(154, 26);
            this.tbStudentName.TabIndex = 1;
            this.tbStudentName.TextChanged += new System.EventHandler(this.tbStudentName_TextChanged);
            this.tbStudentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbStudentName_KeyDown);
            // 
            // tbStudentID
            // 
            this.tbStudentID.Animated = true;
            this.tbStudentID.BorderColor = System.Drawing.Color.Silver;
            this.tbStudentID.BorderRadius = 5;
            this.tbStudentID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStudentID.DefaultText = "";
            this.tbStudentID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbStudentID.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.tbStudentID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbStudentID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbStudentID.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbStudentID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentID.Location = new System.Drawing.Point(144, 56);
            this.tbStudentID.Name = "tbStudentID";
            this.tbStudentID.PasswordChar = '\0';
            this.tbStudentID.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentID.PlaceholderText = "Student ID";
            this.tbStudentID.SelectedText = "";
            this.tbStudentID.Size = new System.Drawing.Size(137, 26);
            this.tbStudentID.TabIndex = 0;
            this.tbStudentID.TextChanged += new System.EventHandler(this.tbStudentID_TextChanged);
            this.tbStudentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbStudentID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(5, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 141;
            this.label3.Text = "Student Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(5, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 140;
            this.label2.Text = "Student ID:";
            // 
            // groupBoxSearchBy
            // 
            this.groupBoxSearchBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.groupBoxSearchBy.Controls.Add(this.rbRegNumber);
            this.groupBoxSearchBy.Controls.Add(this.rbStudentName);
            this.groupBoxSearchBy.Controls.Add(this.rbStudentID);
            this.groupBoxSearchBy.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.groupBoxSearchBy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.groupBoxSearchBy.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxSearchBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBoxSearchBy.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSearchBy.Name = "groupBoxSearchBy";
            this.groupBoxSearchBy.Size = new System.Drawing.Size(327, 95);
            this.groupBoxSearchBy.TabIndex = 39;
            this.groupBoxSearchBy.Text = "Search By";
            // 
            // rbRegNumber
            // 
            this.rbRegNumber.AutoSize = true;
            this.rbRegNumber.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbRegNumber.CheckedState.BorderThickness = 0;
            this.rbRegNumber.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbRegNumber.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbRegNumber.CheckedState.InnerOffset = -4;
            this.rbRegNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.rbRegNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbRegNumber.Location = new System.Drawing.Point(149, 58);
            this.rbRegNumber.Name = "rbRegNumber";
            this.rbRegNumber.Size = new System.Drawing.Size(149, 19);
            this.rbRegNumber.TabIndex = 2;
            this.rbRegNumber.Text = "Registeration Number";
            this.rbRegNumber.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbRegNumber.UncheckedState.BorderThickness = 2;
            this.rbRegNumber.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbRegNumber.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbRegNumber.CheckedChanged += new System.EventHandler(this.rbRegNumber_CheckedChanged);
            // 
            // rbStudentName
            // 
            this.rbStudentName.AutoSize = true;
            this.rbStudentName.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbStudentName.CheckedState.BorderThickness = 0;
            this.rbStudentName.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbStudentName.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbStudentName.CheckedState.InnerOffset = -4;
            this.rbStudentName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.rbStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbStudentName.Location = new System.Drawing.Point(73, 58);
            this.rbStudentName.Name = "rbStudentName";
            this.rbStudentName.Size = new System.Drawing.Size(58, 19);
            this.rbStudentName.TabIndex = 1;
            this.rbStudentName.Text = "Name";
            this.rbStudentName.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbStudentName.UncheckedState.BorderThickness = 2;
            this.rbStudentName.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbStudentName.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbStudentName.CheckedChanged += new System.EventHandler(this.rbStudentName_CheckedChanged);
            // 
            // rbStudentID
            // 
            this.rbStudentID.AutoSize = true;
            this.rbStudentID.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbStudentID.CheckedState.BorderThickness = 0;
            this.rbStudentID.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbStudentID.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbStudentID.CheckedState.InnerOffset = -4;
            this.rbStudentID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.rbStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbStudentID.Location = new System.Drawing.Point(10, 58);
            this.rbStudentID.Name = "rbStudentID";
            this.rbStudentID.Size = new System.Drawing.Size(38, 19);
            this.rbStudentID.TabIndex = 0;
            this.rbStudentID.Text = "ID";
            this.rbStudentID.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbStudentID.UncheckedState.BorderThickness = 2;
            this.rbStudentID.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbStudentID.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbStudentID.CheckedChanged += new System.EventHandler(this.rbStudentID_CheckedChanged);
            // 
            // epID
            // 
            this.epID.ContainerControl = this;
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            // 
            // epRegistrationNumber
            // 
            this.epRegistrationNumber.ContainerControl = this;
            // 
            // panelDisplayBtn
            // 
            this.panelDisplayBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panelDisplayBtn.Controls.Add(this.dgvSearchedRecords);
            this.panelDisplayBtn.Controls.Add(this.btnDisplayRecord);
            this.panelDisplayBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplayBtn.Location = new System.Drawing.Point(332, 0);
            this.panelDisplayBtn.Name = "panelDisplayBtn";
            this.panelDisplayBtn.Size = new System.Drawing.Size(638, 569);
            this.panelDisplayBtn.TabIndex = 139;
            // 
            // dgvSearchedRecords
            // 
            this.dgvSearchedRecords.AllowUserToAddRows = false;
            this.dgvSearchedRecords.AllowUserToDeleteRows = false;
            this.dgvSearchedRecords.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSearchedRecords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSearchedRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSearchedRecords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSearchedRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSearchedRecords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSearchedRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearchedRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSearchedRecords.ColumnHeadersHeight = 32;
            this.dgvSearchedRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSearchedRecords.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSearchedRecords.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSearchedRecords.EnableHeadersVisualStyles = false;
            this.dgvSearchedRecords.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSearchedRecords.Location = new System.Drawing.Point(0, 0);
            this.dgvSearchedRecords.MultiSelect = false;
            this.dgvSearchedRecords.Name = "dgvSearchedRecords";
            this.dgvSearchedRecords.ReadOnly = true;
            this.dgvSearchedRecords.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvSearchedRecords.RowHeadersVisible = false;
            this.dgvSearchedRecords.RowHeadersWidth = 32;
            this.dgvSearchedRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchedRecords.Size = new System.Drawing.Size(638, 519);
            this.dgvSearchedRecords.TabIndex = 141;
            this.dgvSearchedRecords.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSearchedRecords.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvSearchedRecords.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvSearchedRecords.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvSearchedRecords.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvSearchedRecords.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvSearchedRecords.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSearchedRecords.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvSearchedRecords.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvSearchedRecords.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSearchedRecords.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSearchedRecords.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSearchedRecords.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvSearchedRecords.ThemeStyle.ReadOnly = true;
            this.dgvSearchedRecords.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSearchedRecords.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSearchedRecords.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvSearchedRecords.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Maroon;
            this.dgvSearchedRecords.ThemeStyle.RowsStyle.Height = 22;
            this.dgvSearchedRecords.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvSearchedRecords.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Navy;
            // 
            // btnDisplayRecord
            // 
            this.btnDisplayRecord.Animated = true;
            this.btnDisplayRecord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDisplayRecord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDisplayRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDisplayRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDisplayRecord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisplayRecord.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplayRecord.ForeColor = System.Drawing.Color.White;
            this.btnDisplayRecord.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnDisplayRecord.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDisplayRecord.Location = new System.Drawing.Point(477, 524);
            this.btnDisplayRecord.Name = "btnDisplayRecord";
            this.btnDisplayRecord.Size = new System.Drawing.Size(151, 40);
            this.btnDisplayRecord.TabIndex = 0;
            this.btnDisplayRecord.Text = "DISPLAY RECORD";
            this.btnDisplayRecord.Click += new System.EventHandler(this.btnDisplayRecord_Click_1);
            // 
            // UCSearchRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDisplayBtn);
            this.Controls.Add(this.panelSearch);
            this.Name = "UCSearchRecords";
            this.Size = new System.Drawing.Size(970, 569);
            this.Load += new System.EventHandler(this.UCSearchRecords_Load);
            this.SizeChanged += new System.EventHandler(this.UCSearchRecords_SizeChanged);
            this.panelSearch.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxSearchBy.ResumeLayout(false);
            this.groupBoxSearchBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRegistrationNumber)).EndInit();
            this.panelDisplayBtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchedRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private Guna.UI2.WinForms.Guna2GroupBox groupBoxSearch;
        private Guna.UI2.WinForms.Guna2GroupBox groupBoxSearchBy;
        private Guna.UI2.WinForms.Guna2RadioButton rbRegNumber;
        private Guna.UI2.WinForms.Guna2RadioButton rbStudentName;
        private Guna.UI2.WinForms.Guna2RadioButton rbStudentID;
        private Guna.UI2.WinForms.Guna2TextBox tbRegistrationNumber;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbStudentName;
        private Guna.UI2.WinForms.Guna2TextBox tbStudentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnSearchRecord;
        private System.Windows.Forms.ErrorProvider epID;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epRegistrationNumber;
        private System.Windows.Forms.Panel panelDisplayBtn;
        private Guna.UI2.WinForms.Guna2Button btnDisplayRecord;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSearchedRecords;
    }
}
