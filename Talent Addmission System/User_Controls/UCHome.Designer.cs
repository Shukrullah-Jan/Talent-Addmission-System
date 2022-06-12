namespace Talent_Addmission_System.User_Controls
{
    partial class UCHome
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAllRecords = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnDisplayRecord = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllRecords
            // 
            this.dgvAllRecords.AllowUserToAddRows = false;
            this.dgvAllRecords.AllowUserToDeleteRows = false;
            this.dgvAllRecords.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvAllRecords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllRecords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvAllRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAllRecords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllRecords.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllRecords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllRecords.ColumnHeadersHeight = 32;
            this.dgvAllRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllRecords.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllRecords.EnableHeadersVisualStyles = false;
            this.dgvAllRecords.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllRecords.Location = new System.Drawing.Point(0, 18);
            this.dgvAllRecords.MultiSelect = false;
            this.dgvAllRecords.Name = "dgvAllRecords";
            this.dgvAllRecords.ReadOnly = true;
            this.dgvAllRecords.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvAllRecords.RowHeadersVisible = false;
            this.dgvAllRecords.RowHeadersWidth = 32;
            this.dgvAllRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllRecords.Size = new System.Drawing.Size(970, 502);
            this.dgvAllRecords.TabIndex = 1;
            this.dgvAllRecords.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllRecords.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvAllRecords.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvAllRecords.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvAllRecords.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvAllRecords.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvAllRecords.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvAllRecords.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvAllRecords.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvAllRecords.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvAllRecords.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAllRecords.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAllRecords.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvAllRecords.ThemeStyle.ReadOnly = true;
            this.dgvAllRecords.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvAllRecords.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAllRecords.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvAllRecords.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Maroon;
            this.dgvAllRecords.ThemeStyle.RowsStyle.Height = 22;
            this.dgvAllRecords.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvAllRecords.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Navy;
            // 
            // btnDisplayRecord
            // 
            this.btnDisplayRecord.Animated = true;
            this.btnDisplayRecord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDisplayRecord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDisplayRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDisplayRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDisplayRecord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDisplayRecord.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisplayRecord.ForeColor = System.Drawing.Color.White;
            this.btnDisplayRecord.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnDisplayRecord.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDisplayRecord.Location = new System.Drawing.Point(808, 524);
            this.btnDisplayRecord.Name = "btnDisplayRecord";
            this.btnDisplayRecord.Size = new System.Drawing.Size(155, 40);
            this.btnDisplayRecord.TabIndex = 2;
            this.btnDisplayRecord.Text = "DISPLAY RECORD";
            this.btnDisplayRecord.Click += new System.EventHandler(this.btnDisplayRecord_Click);
            // 
            // UCHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.btnDisplayRecord);
            this.Controls.Add(this.dgvAllRecords);
            this.Name = "UCHome";
            this.Size = new System.Drawing.Size(970, 569);
            this.Load += new System.EventHandler(this.UCHome_Load);
            this.SizeChanged += new System.EventHandler(this.UCHome_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvAllRecords;
        private Guna.UI2.WinForms.Guna2Button btnDisplayRecord;
    }
}
