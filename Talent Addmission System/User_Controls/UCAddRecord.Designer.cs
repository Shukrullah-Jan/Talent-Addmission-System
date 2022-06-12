namespace Talent_Addmission_System.User_Controls
{
    partial class UCAddRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAddRecord));
            this.panelAddStudent = new System.Windows.Forms.Panel();
            this.tbTeacherName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pbStudentPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblFeesError = new System.Windows.Forms.Label();
            this.tbPaid = new Guna.UI2.WinForms.Guna2TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbCashier = new Guna.UI2.WinForms.Guna2TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpAddmissionDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.gbRadioButtons = new System.Windows.Forms.GroupBox();
            this.rbUnkownStudentID = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbOldStudent = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbNewStudent = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnCapture = new Guna.UI2.WinForms.Guna2Button();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.timePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.timePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.cbPrograms = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbFees = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbDuration = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbFatherName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbStudentName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbStudentID = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbRegistrationNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAddRecord = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.panelMoreDetails = new System.Windows.Forms.Panel();
            this.tbStudentAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbNotePrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chbMoreDetails = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epSID = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFees = new System.Windows.Forms.ErrorProvider(this.components);
            this.epName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epFatherName = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPaid = new System.Windows.Forms.ErrorProvider(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panelAddStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPicture)).BeginInit();
            this.gbRadioButtons.SuspendLayout();
            this.panelMoreDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFatherName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPaid)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAddStudent
            // 
            this.panelAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panelAddStudent.Controls.Add(this.tbTeacherName);
            this.panelAddStudent.Controls.Add(this.label16);
            this.panelAddStudent.Controls.Add(this.pbStudentPicture);
            this.panelAddStudent.Controls.Add(this.lblFeesError);
            this.panelAddStudent.Controls.Add(this.tbPaid);
            this.panelAddStudent.Controls.Add(this.label15);
            this.panelAddStudent.Controls.Add(this.tbCashier);
            this.panelAddStudent.Controls.Add(this.label14);
            this.panelAddStudent.Controls.Add(this.dtpAddmissionDate);
            this.panelAddStudent.Controls.Add(this.label13);
            this.panelAddStudent.Controls.Add(this.gbRadioButtons);
            this.panelAddStudent.Controls.Add(this.btnReset);
            this.panelAddStudent.Controls.Add(this.btnCapture);
            this.panelAddStudent.Controls.Add(this.btnBrowse);
            this.panelAddStudent.Controls.Add(this.timePickerTo);
            this.panelAddStudent.Controls.Add(this.label12);
            this.panelAddStudent.Controls.Add(this.timePickerFrom);
            this.panelAddStudent.Controls.Add(this.cbPrograms);
            this.panelAddStudent.Controls.Add(this.tbPhoneNumber);
            this.panelAddStudent.Controls.Add(this.tbFees);
            this.panelAddStudent.Controls.Add(this.tbDuration);
            this.panelAddStudent.Controls.Add(this.tbFatherName);
            this.panelAddStudent.Controls.Add(this.tbStudentName);
            this.panelAddStudent.Controls.Add(this.tbStudentID);
            this.panelAddStudent.Controls.Add(this.tbRegistrationNumber);
            this.panelAddStudent.Controls.Add(this.btnAddRecord);
            this.panelAddStudent.Controls.Add(this.btnClear);
            this.panelAddStudent.Controls.Add(this.btnPrint);
            this.panelAddStudent.Controls.Add(this.panelMoreDetails);
            this.panelAddStudent.Controls.Add(this.chbMoreDetails);
            this.panelAddStudent.Controls.Add(this.label9);
            this.panelAddStudent.Controls.Add(this.label8);
            this.panelAddStudent.Controls.Add(this.label7);
            this.panelAddStudent.Controls.Add(this.label6);
            this.panelAddStudent.Controls.Add(this.label5);
            this.panelAddStudent.Controls.Add(this.label4);
            this.panelAddStudent.Controls.Add(this.label3);
            this.panelAddStudent.Controls.Add(this.label2);
            this.panelAddStudent.Controls.Add(this.label1);
            this.panelAddStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAddStudent.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelAddStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelAddStudent.Location = new System.Drawing.Point(0, 0);
            this.panelAddStudent.Name = "panelAddStudent";
            this.panelAddStudent.Size = new System.Drawing.Size(970, 569);
            this.panelAddStudent.TabIndex = 31;
            // 
            // tbTeacherName
            // 
            this.tbTeacherName.Animated = true;
            this.tbTeacherName.BorderColor = System.Drawing.Color.Gray;
            this.tbTeacherName.BorderRadius = 5;
            this.tbTeacherName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTeacherName.DefaultText = "";
            this.tbTeacherName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTeacherName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTeacherName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTeacherName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTeacherName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbTeacherName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTeacherName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTeacherName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbTeacherName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTeacherName.Location = new System.Drawing.Point(100, 326);
            this.tbTeacherName.Name = "tbTeacherName";
            this.tbTeacherName.PasswordChar = '\0';
            this.tbTeacherName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbTeacherName.PlaceholderText = "Teacher";
            this.tbTeacherName.SelectedText = "";
            this.tbTeacherName.Size = new System.Drawing.Size(154, 26);
            this.tbTeacherName.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label16.Location = new System.Drawing.Point(9, 326);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 25);
            this.label16.TabIndex = 163;
            this.label16.Text = "Teacher:";
            // 
            // pbStudentPicture
            // 
            this.pbStudentPicture.BackColor = System.Drawing.Color.Transparent;
            this.pbStudentPicture.Image = global::Talent_Addmission_System.Properties.Resources.student;
            this.pbStudentPicture.ImageRotate = 0F;
            this.pbStudentPicture.Location = new System.Drawing.Point(826, 21);
            this.pbStudentPicture.Name = "pbStudentPicture";
            this.pbStudentPicture.Size = new System.Drawing.Size(102, 102);
            this.pbStudentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStudentPicture.TabIndex = 159;
            this.pbStudentPicture.TabStop = false;
            // 
            // lblFeesError
            // 
            this.lblFeesError.AutoSize = true;
            this.lblFeesError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeesError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblFeesError.Location = new System.Drawing.Point(428, 296);
            this.lblFeesError.Name = "lblFeesError";
            this.lblFeesError.Size = new System.Drawing.Size(0, 15);
            this.lblFeesError.TabIndex = 158;
            this.lblFeesError.Visible = false;
            // 
            // tbPaid
            // 
            this.tbPaid.Animated = true;
            this.tbPaid.BorderColor = System.Drawing.Color.Gray;
            this.tbPaid.BorderRadius = 5;
            this.tbPaid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPaid.DefaultText = "";
            this.tbPaid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPaid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPaid.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbPaid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPaid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbPaid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPaid.Location = new System.Drawing.Point(285, 290);
            this.tbPaid.Name = "tbPaid";
            this.tbPaid.PasswordChar = '\0';
            this.tbPaid.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbPaid.PlaceholderText = "Paid";
            this.tbPaid.SelectedText = "";
            this.tbPaid.Size = new System.Drawing.Size(102, 26);
            this.tbPaid.TabIndex = 10;
            this.tbPaid.TextChanged += new System.EventHandler(this.tbPaid_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label15.Location = new System.Drawing.Point(232, 290);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 25);
            this.label15.TabIndex = 156;
            this.label15.Text = "Paid:";
            // 
            // tbCashier
            // 
            this.tbCashier.Animated = true;
            this.tbCashier.BorderColor = System.Drawing.Color.Gray;
            this.tbCashier.BorderRadius = 5;
            this.tbCashier.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbCashier.DefaultText = "";
            this.tbCashier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbCashier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbCashier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCashier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbCashier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbCashier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCashier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCashier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbCashier.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbCashier.Location = new System.Drawing.Point(442, 361);
            this.tbCashier.Name = "tbCashier";
            this.tbCashier.PasswordChar = '\0';
            this.tbCashier.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbCashier.PlaceholderText = "Cashier";
            this.tbCashier.SelectedText = "";
            this.tbCashier.Size = new System.Drawing.Size(154, 26);
            this.tbCashier.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(363, 361);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 25);
            this.label14.TabIndex = 154;
            this.label14.Text = "Cashier:";
            // 
            // dtpAddmissionDate
            // 
            this.dtpAddmissionDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpAddmissionDate.BorderRadius = 5;
            this.dtpAddmissionDate.Checked = true;
            this.dtpAddmissionDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.dtpAddmissionDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAddmissionDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtpAddmissionDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpAddmissionDate.Location = new System.Drawing.Point(162, 150);
            this.dtpAddmissionDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpAddmissionDate.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpAddmissionDate.Name = "dtpAddmissionDate";
            this.dtpAddmissionDate.Size = new System.Drawing.Size(225, 27);
            this.dtpAddmissionDate.TabIndex = 4;
            this.dtpAddmissionDate.Value = new System.DateTime(2022, 2, 25, 17, 44, 39, 444);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label13.Location = new System.Drawing.Point(9, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 25);
            this.label13.TabIndex = 152;
            this.label13.Text = "Addmission Date:";
            // 
            // gbRadioButtons
            // 
            this.gbRadioButtons.Controls.Add(this.rbUnkownStudentID);
            this.gbRadioButtons.Controls.Add(this.rbOldStudent);
            this.gbRadioButtons.Controls.Add(this.rbNewStudent);
            this.gbRadioButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbRadioButtons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbRadioButtons.Location = new System.Drawing.Point(368, 3);
            this.gbRadioButtons.Name = "gbRadioButtons";
            this.gbRadioButtons.Size = new System.Drawing.Size(436, 38);
            this.gbRadioButtons.TabIndex = 151;
            this.gbRadioButtons.TabStop = false;
            // 
            // rbUnkownStudentID
            // 
            this.rbUnkownStudentID.AutoSize = true;
            this.rbUnkownStudentID.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbUnkownStudentID.CheckedState.BorderThickness = 0;
            this.rbUnkownStudentID.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbUnkownStudentID.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbUnkownStudentID.CheckedState.InnerOffset = -4;
            this.rbUnkownStudentID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbUnkownStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbUnkownStudentID.Location = new System.Drawing.Point(259, 1);
            this.rbUnkownStudentID.Name = "rbUnkownStudentID";
            this.rbUnkownStudentID.Size = new System.Drawing.Size(171, 25);
            this.rbUnkownStudentID.TabIndex = 20;
            this.rbUnkownStudentID.Text = "Unknown Student ID";
            this.rbUnkownStudentID.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbUnkownStudentID.UncheckedState.BorderThickness = 2;
            this.rbUnkownStudentID.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbUnkownStudentID.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbUnkownStudentID.CheckedChanged += new System.EventHandler(this.chbUnkownStudentID_CheckedChanged);
            // 
            // rbOldStudent
            // 
            this.rbOldStudent.AutoSize = true;
            this.rbOldStudent.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbOldStudent.CheckedState.BorderThickness = 0;
            this.rbOldStudent.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbOldStudent.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbOldStudent.CheckedState.InnerOffset = -4;
            this.rbOldStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOldStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbOldStudent.Location = new System.Drawing.Point(134, 1);
            this.rbOldStudent.Name = "rbOldStudent";
            this.rbOldStudent.Size = new System.Drawing.Size(110, 25);
            this.rbOldStudent.TabIndex = 19;
            this.rbOldStudent.Text = "Old Student";
            this.rbOldStudent.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbOldStudent.UncheckedState.BorderThickness = 2;
            this.rbOldStudent.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbOldStudent.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbOldStudent.CheckedChanged += new System.EventHandler(this.rbOldStudent_CheckedChanged);
            // 
            // rbNewStudent
            // 
            this.rbNewStudent.AutoSize = true;
            this.rbNewStudent.Checked = true;
            this.rbNewStudent.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbNewStudent.CheckedState.BorderThickness = 0;
            this.rbNewStudent.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbNewStudent.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbNewStudent.CheckedState.InnerOffset = -4;
            this.rbNewStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNewStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbNewStudent.Location = new System.Drawing.Point(6, 1);
            this.rbNewStudent.Name = "rbNewStudent";
            this.rbNewStudent.Size = new System.Drawing.Size(117, 25);
            this.rbNewStudent.TabIndex = 18;
            this.rbNewStudent.TabStop = true;
            this.rbNewStudent.Text = "New Student";
            this.rbNewStudent.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbNewStudent.UncheckedState.BorderThickness = 2;
            this.rbNewStudent.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbNewStudent.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbNewStudent.CheckedChanged += new System.EventHandler(this.rbNewStudent_CheckedChanged);
            // 
            // btnReset
            // 
            this.btnReset.Animated = true;
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReset.BorderRadius = 5;
            this.btnReset.BorderThickness = 1;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReset.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnReset.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnReset.Location = new System.Drawing.Point(826, 227);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 32);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Animated = true;
            this.btnCapture.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCapture.BorderRadius = 5;
            this.btnCapture.BorderThickness = 1;
            this.btnCapture.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCapture.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCapture.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCapture.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCapture.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCapture.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCapture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCapture.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnCapture.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCapture.Location = new System.Drawing.Point(826, 183);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(102, 32);
            this.btnCapture.TabIndex = 22;
            this.btnCapture.Text = "Capture";
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Animated = true;
            this.btnBrowse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowse.BorderRadius = 5;
            this.btnBrowse.BorderThickness = 1;
            this.btnBrowse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrowse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBrowse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrowse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBrowse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBrowse.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnBrowse.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBrowse.Location = new System.Drawing.Point(826, 139);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(102, 32);
            this.btnBrowse.TabIndex = 21;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // timePickerTo
            // 
            this.timePickerTo.CalendarFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePickerTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.timePickerTo.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.timePickerTo.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.timePickerTo.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.timePickerTo.CustomFormat = "hh:mm tt";
            this.timePickerTo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerTo.Location = new System.Drawing.Point(287, 253);
            this.timePickerTo.Name = "timePickerTo";
            this.timePickerTo.ShowUpDown = true;
            this.timePickerTo.Size = new System.Drawing.Size(99, 27);
            this.timePickerTo.TabIndex = 8;
//            this.timePickerTo.ValueChanged += new System.EventHandler(this.timePickerTo_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.Location = new System.Drawing.Point(232, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 25);
            this.label12.TabIndex = 146;
            this.label12.Text = "To:";
            // 
            // timePickerFrom
            // 
            this.timePickerFrom.CalendarFont = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePickerFrom.CalendarForeColor = System.Drawing.Color.Red;
            this.timePickerFrom.CalendarMonthBackground = System.Drawing.Color.Red;
            this.timePickerFrom.CalendarTitleBackColor = System.Drawing.Color.Red;
            this.timePickerFrom.CalendarTitleForeColor = System.Drawing.Color.Red;
            this.timePickerFrom.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.timePickerFrom.CustomFormat = "hh:mm tt";
            this.timePickerFrom.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerFrom.Location = new System.Drawing.Point(100, 255);
            this.timePickerFrom.Name = "timePickerFrom";
            this.timePickerFrom.ShowUpDown = true;
            this.timePickerFrom.Size = new System.Drawing.Size(102, 27);
            this.timePickerFrom.TabIndex = 7;
            this.timePickerFrom.ValueChanged += new System.EventHandler(this.timePickerFrom_ValueChanged);
            // 
            // cbPrograms
            // 
            this.cbPrograms.BackColor = System.Drawing.Color.Transparent;
            this.cbPrograms.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbPrograms.BorderRadius = 5;
            this.cbPrograms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPrograms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrograms.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.cbPrograms.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPrograms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbPrograms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrograms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbPrograms.ItemHeight = 22;
            this.cbPrograms.Location = new System.Drawing.Point(162, 183);
            this.cbPrograms.Name = "cbPrograms";
            this.cbPrograms.Size = new System.Drawing.Size(179, 28);
            this.cbPrograms.TabIndex = 5;
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Animated = true;
            this.tbPhoneNumber.BorderColor = System.Drawing.Color.Gray;
            this.tbPhoneNumber.BorderRadius = 5;
            this.tbPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPhoneNumber.DefaultText = "";
            this.tbPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPhoneNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPhoneNumber.Location = new System.Drawing.Point(153, 361);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.PasswordChar = '\0';
            this.tbPhoneNumber.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbPhoneNumber.PlaceholderText = "Phone Number";
            this.tbPhoneNumber.SelectedText = "";
            this.tbPhoneNumber.Size = new System.Drawing.Size(179, 26);
            this.tbPhoneNumber.TabIndex = 12;
            // 
            // tbFees
            // 
            this.tbFees.Animated = true;
            this.tbFees.BorderColor = System.Drawing.Color.Gray;
            this.tbFees.BorderRadius = 5;
            this.tbFees.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFees.DefaultText = "";
            this.tbFees.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFees.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFees.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFees.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFees.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbFees.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbFees.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFees.Location = new System.Drawing.Point(100, 291);
            this.tbFees.Name = "tbFees";
            this.tbFees.PasswordChar = '\0';
            this.tbFees.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbFees.PlaceholderText = "Fees";
            this.tbFees.SelectedText = "";
            this.tbFees.Size = new System.Drawing.Size(102, 26);
            this.tbFees.TabIndex = 9;
            this.tbFees.TextChanged += new System.EventHandler(this.tbFees_TextChanged_1);
            // 
            // tbDuration
            // 
            this.tbDuration.Animated = true;
            this.tbDuration.BorderColor = System.Drawing.Color.Gray;
            this.tbDuration.BorderRadius = 5;
            this.tbDuration.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDuration.DefaultText = "";
            this.tbDuration.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbDuration.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbDuration.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDuration.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbDuration.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbDuration.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbDuration.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbDuration.Location = new System.Drawing.Point(100, 220);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.PasswordChar = '\0';
            this.tbDuration.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbDuration.PlaceholderText = "Duration";
            this.tbDuration.SelectedText = "";
            this.tbDuration.Size = new System.Drawing.Size(154, 26);
            this.tbDuration.TabIndex = 6;
            // 
            // tbFatherName
            // 
            this.tbFatherName.Animated = true;
            this.tbFatherName.BorderColor = System.Drawing.Color.Gray;
            this.tbFatherName.BorderRadius = 5;
            this.tbFatherName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFatherName.DefaultText = "";
            this.tbFatherName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFatherName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFatherName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFatherName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFatherName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbFatherName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFatherName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFatherName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbFatherName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFatherName.Location = new System.Drawing.Point(162, 112);
            this.tbFatherName.Name = "tbFatherName";
            this.tbFatherName.PasswordChar = '\0';
            this.tbFatherName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbFatherName.PlaceholderText = "Father Name";
            this.tbFatherName.SelectedText = "";
            this.tbFatherName.Size = new System.Drawing.Size(179, 26);
            this.tbFatherName.TabIndex = 3;
            this.tbFatherName.TextChanged += new System.EventHandler(this.tbFatherName_TextChanged);
            // 
            // tbStudentName
            // 
            this.tbStudentName.Animated = true;
            this.tbStudentName.BorderColor = System.Drawing.Color.Gray;
            this.tbStudentName.BorderRadius = 5;
            this.tbStudentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStudentName.DefaultText = "";
            this.tbStudentName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbStudentName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbStudentName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStudentName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStudentName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbStudentName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStudentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentName.Location = new System.Drawing.Point(162, 77);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.PasswordChar = '\0';
            this.tbStudentName.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentName.PlaceholderText = "Student Name";
            this.tbStudentName.SelectedText = "";
            this.tbStudentName.Size = new System.Drawing.Size(179, 26);
            this.tbStudentName.TabIndex = 2;
            this.tbStudentName.TextChanged += new System.EventHandler(this.tbStudentName_TextChanged);
            // 
            // tbStudentID
            // 
            this.tbStudentID.Animated = true;
            this.tbStudentID.BorderColor = System.Drawing.Color.Gray;
            this.tbStudentID.BorderRadius = 5;
            this.tbStudentID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStudentID.DefaultText = "";
            this.tbStudentID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbStudentID.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.tbStudentID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbStudentID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStudentID.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbStudentID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentID.Location = new System.Drawing.Point(162, 42);
            this.tbStudentID.Name = "tbStudentID";
            this.tbStudentID.PasswordChar = '\0';
            this.tbStudentID.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentID.PlaceholderText = "Student ID";
            this.tbStudentID.SelectedText = "";
            this.tbStudentID.Size = new System.Drawing.Size(154, 26);
            this.tbStudentID.TabIndex = 1;
            this.tbStudentID.TextChanged += new System.EventHandler(this.tbStudentID_TextChanged);
            // 
            // tbRegistrationNumber
            // 
            this.tbRegistrationNumber.Animated = true;
            this.tbRegistrationNumber.BorderColor = System.Drawing.Color.Gray;
            this.tbRegistrationNumber.BorderRadius = 5;
            this.tbRegistrationNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbRegistrationNumber.DefaultText = "";
            this.tbRegistrationNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbRegistrationNumber.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.tbRegistrationNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbRegistrationNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbRegistrationNumber.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbRegistrationNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbRegistrationNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRegistrationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbRegistrationNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbRegistrationNumber.Location = new System.Drawing.Point(162, 8);
            this.tbRegistrationNumber.Name = "tbRegistrationNumber";
            this.tbRegistrationNumber.PasswordChar = '\0';
            this.tbRegistrationNumber.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbRegistrationNumber.PlaceholderText = "Registration Number";
            this.tbRegistrationNumber.SelectedText = "";
            this.tbRegistrationNumber.Size = new System.Drawing.Size(154, 26);
            this.tbRegistrationNumber.TabIndex = 0;
            // 
            // btnAddRecord
            // 
            this.btnAddRecord.Animated = true;
            this.btnAddRecord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRecord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddRecord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnAddRecord.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRecord.ForeColor = System.Drawing.Color.White;
            this.btnAddRecord.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnAddRecord.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAddRecord.Location = new System.Drawing.Point(393, 516);
            this.btnAddRecord.Name = "btnAddRecord";
            this.btnAddRecord.Size = new System.Drawing.Size(153, 40);
            this.btnAddRecord.TabIndex = 17;
            this.btnAddRecord.Text = "ADD RECORD";
            this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecord_Click);
            // 
            // btnClear
            // 
            this.btnClear.Animated = true;
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnClear.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClear.Location = new System.Drawing.Point(775, 516);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(153, 40);
            this.btnClear.TabIndex = 19;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Animated = true;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnPrint.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPrint.Location = new System.Drawing.Point(584, 516);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(153, 40);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panelMoreDetails
            // 
            this.panelMoreDetails.Controls.Add(this.tbStudentAddress);
            this.panelMoreDetails.Controls.Add(this.tbNotePrice);
            this.panelMoreDetails.Controls.Add(this.label11);
            this.panelMoreDetails.Controls.Add(this.label10);
            this.panelMoreDetails.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelMoreDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panelMoreDetails.Location = new System.Drawing.Point(3, 426);
            this.panelMoreDetails.Name = "panelMoreDetails";
            this.panelMoreDetails.Size = new System.Drawing.Size(967, 81);
            this.panelMoreDetails.TabIndex = 30;
            // 
            // tbStudentAddress
            // 
            this.tbStudentAddress.Animated = true;
            this.tbStudentAddress.BorderColor = System.Drawing.Color.Gray;
            this.tbStudentAddress.BorderRadius = 5;
            this.tbStudentAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStudentAddress.DefaultText = "";
            this.tbStudentAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbStudentAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbStudentAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStudentAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStudentAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbStudentAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStudentAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStudentAddress.Location = new System.Drawing.Point(205, 46);
            this.tbStudentAddress.Name = "tbStudentAddress";
            this.tbStudentAddress.PasswordChar = '\0';
            this.tbStudentAddress.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbStudentAddress.PlaceholderText = "Student\'s Address";
            this.tbStudentAddress.SelectedText = "";
            this.tbStudentAddress.Size = new System.Drawing.Size(222, 26);
            this.tbStudentAddress.TabIndex = 16;
            // 
            // tbNotePrice
            // 
            this.tbNotePrice.Animated = true;
            this.tbNotePrice.BorderColor = System.Drawing.Color.Gray;
            this.tbNotePrice.BorderRadius = 5;
            this.tbNotePrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNotePrice.DefaultText = "";
            this.tbNotePrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNotePrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNotePrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNotePrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNotePrice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.tbNotePrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNotePrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbNotePrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNotePrice.Location = new System.Drawing.Point(205, 7);
            this.tbNotePrice.Name = "tbNotePrice";
            this.tbNotePrice.PasswordChar = '\0';
            this.tbNotePrice.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbNotePrice.PlaceholderText = "Note Price";
            this.tbNotePrice.SelectedText = "";
            this.tbNotePrice.Size = new System.Drawing.Size(173, 26);
            this.tbNotePrice.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Location = new System.Drawing.Point(6, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(159, 25);
            this.label11.TabIndex = 131;
            this.label11.Text = "Student\'s Address:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label10.Location = new System.Drawing.Point(6, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 25);
            this.label10.TabIndex = 130;
            this.label10.Text = "Result Card/Note Price:";
            // 
            // chbMoreDetails
            // 
            this.chbMoreDetails.AutoSize = true;
            this.chbMoreDetails.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbMoreDetails.CheckedState.BorderRadius = 0;
            this.chbMoreDetails.CheckedState.BorderThickness = 0;
            this.chbMoreDetails.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbMoreDetails.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbMoreDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chbMoreDetails.Location = new System.Drawing.Point(14, 400);
            this.chbMoreDetails.Name = "chbMoreDetails";
            this.chbMoreDetails.Size = new System.Drawing.Size(131, 29);
            this.chbMoreDetails.TabIndex = 14;
            this.chbMoreDetails.Text = "More Details";
            this.chbMoreDetails.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chbMoreDetails.UncheckedState.BorderRadius = 0;
            this.chbMoreDetails.UncheckedState.BorderThickness = 0;
            this.chbMoreDetails.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chbMoreDetails.CheckedChanged += new System.EventHandler(this.chbMoreDetails_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(9, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 25);
            this.label9.TabIndex = 129;
            this.label9.Text = "Phone Number:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(9, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 25);
            this.label8.TabIndex = 128;
            this.label8.Text = "Fees:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(9, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 25);
            this.label7.TabIndex = 127;
            this.label7.Text = "Timing:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(9, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 126;
            this.label6.Text = "Duration:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(9, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 25);
            this.label5.TabIndex = 125;
            this.label5.Text = "Program/Package:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(9, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 124;
            this.label4.Text = "Father Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 123;
            this.label3.Text = "Student Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 122;
            this.label2.Text = "Student ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 25);
            this.label1.TabIndex = 121;
            this.label1.Text = "Reg/Slip Number:";
            // 
            // epSID
            // 
            this.epSID.ContainerControl = this;
            this.epSID.Icon = ((System.Drawing.Icon)(resources.GetObject("epSID.Icon")));
            // 
            // epFees
            // 
            this.epFees.ContainerControl = this;
            this.epFees.Icon = ((System.Drawing.Icon)(resources.GetObject("epFees.Icon")));
            // 
            // epName
            // 
            this.epName.ContainerControl = this;
            this.epName.Icon = ((System.Drawing.Icon)(resources.GetObject("epName.Icon")));
            // 
            // epFatherName
            // 
            this.epFatherName.ContainerControl = this;
            this.epFatherName.Icon = ((System.Drawing.Icon)(resources.GetObject("epFatherName.Icon")));
            // 
            // epPaid
            // 
            this.epPaid.ContainerControl = this;
            this.epPaid.Icon = ((System.Drawing.Icon)(resources.GetObject("epPaid.Icon")));
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
    //        this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // UCAddRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.panelAddStudent);
            this.Name = "UCAddRecord";
            this.Size = new System.Drawing.Size(970, 569);
            this.Load += new System.EventHandler(this.UCAddRecord_Load);
            this.SizeChanged += new System.EventHandler(this.UCAddRecord_SizeChanged);
            this.panelAddStudent.ResumeLayout(false);
            this.panelAddStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPicture)).EndInit();
            this.gbRadioButtons.ResumeLayout(false);
            this.gbRadioButtons.PerformLayout();
            this.panelMoreDetails.ResumeLayout(false);
            this.panelMoreDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epFatherName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPaid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelAddStudent;
        private Guna.UI2.WinForms.Guna2Button btnAddRecord;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private System.Windows.Forms.Panel panelMoreDetails;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2CheckBox chbMoreDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbRegistrationNumber;
        private Guna.UI2.WinForms.Guna2ComboBox cbPrograms;
        private Guna.UI2.WinForms.Guna2TextBox tbPhoneNumber;
        private Guna.UI2.WinForms.Guna2TextBox tbFees;
        private Guna.UI2.WinForms.Guna2TextBox tbDuration;
        private Guna.UI2.WinForms.Guna2TextBox tbFatherName;
        private Guna.UI2.WinForms.Guna2TextBox tbStudentName;
        private Guna.UI2.WinForms.Guna2TextBox tbStudentID;
        private System.Windows.Forms.DateTimePicker timePickerTo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker timePickerFrom;
        private Guna.UI2.WinForms.Guna2TextBox tbStudentAddress;
        private Guna.UI2.WinForms.Guna2TextBox tbNotePrice;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btnCapture;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private System.Windows.Forms.GroupBox gbRadioButtons;
        private Guna.UI2.WinForms.Guna2RadioButton rbOldStudent;
        private Guna.UI2.WinForms.Guna2RadioButton rbNewStudent;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpAddmissionDate;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox tbCashier;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider epSID;
        private Guna.UI2.WinForms.Guna2TextBox tbPaid;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider epFees;
        private System.Windows.Forms.ErrorProvider epName;
        private System.Windows.Forms.ErrorProvider epFatherName;
        private System.Windows.Forms.Label lblFeesError;
        private System.Windows.Forms.ErrorProvider epPaid;
        private Guna.UI2.WinForms.Guna2RadioButton rbUnkownStudentID;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private Guna.UI2.WinForms.Guna2PictureBox pbStudentPicture;
        private Guna.UI2.WinForms.Guna2TextBox tbTeacherName;
        private System.Windows.Forms.Label label16;
    }
}
