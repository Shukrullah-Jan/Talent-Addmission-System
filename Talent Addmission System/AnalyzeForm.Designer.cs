namespace Talent_Addmission_System
{
    partial class AnalyzeForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyzeForm));
            this.btnAllStudents = new Guna.UI2.WinForms.Guna2Button();
            this.btnStudentsCurrentMonth = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbCurrentMonthStudents = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelectMonth = new System.Windows.Forms.Label();
            this.cbMonths = new Guna.UI2.WinForms.Guna2ComboBox();
            this.studentsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.paymentChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chbEnableChart = new Guna.UI2.WinForms.Guna2CheckBox();
            this.tbTotalAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbPaidAmount = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAllStudents
            // 
            this.btnAllStudents.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAllStudents.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAllStudents.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAllStudents.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAllStudents.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(194)))));
            this.btnAllStudents.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnAllStudents.ForeColor = System.Drawing.Color.White;
            this.btnAllStudents.Location = new System.Drawing.Point(9, 28);
            this.btnAllStudents.Name = "btnAllStudents";
            this.btnAllStudents.Size = new System.Drawing.Size(146, 54);
            this.btnAllStudents.TabIndex = 0;
            this.btnAllStudents.Text = "All Students";
            // 
            // btnStudentsCurrentMonth
            // 
            this.btnStudentsCurrentMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStudentsCurrentMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStudentsCurrentMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStudentsCurrentMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStudentsCurrentMonth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(194)))));
            this.btnStudentsCurrentMonth.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnStudentsCurrentMonth.ForeColor = System.Drawing.Color.White;
            this.btnStudentsCurrentMonth.Location = new System.Drawing.Point(161, 28);
            this.btnStudentsCurrentMonth.Name = "btnStudentsCurrentMonth";
            this.btnStudentsCurrentMonth.Size = new System.Drawing.Size(146, 54);
            this.btnStudentsCurrentMonth.TabIndex = 1;
            this.btnStudentsCurrentMonth.Text = "Current Month";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "All Students";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(657, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grand Total ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(830, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Paid";
            // 
            // lbCurrentMonthStudents
            // 
            this.lbCurrentMonthStudents.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentMonthStudents.FormattingEnabled = true;
            this.lbCurrentMonthStudents.Location = new System.Drawing.Point(9, 141);
            this.lbCurrentMonthStudents.Name = "lbCurrentMonthStudents";
            this.lbCurrentMonthStudents.Size = new System.Drawing.Size(146, 355);
            this.lbCurrentMonthStudents.TabIndex = 7;
            this.lbCurrentMonthStudents.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbCurrentMonthStudents_DrawItem);
            this.lbCurrentMonthStudents.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.lbCurrentMonthStudents_MeasureItem);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "Students got admission\r\nthis month:";
            // 
            // lblSelectMonth
            // 
            this.lblSelectMonth.AutoSize = true;
            this.lblSelectMonth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectMonth.Location = new System.Drawing.Point(482, 4);
            this.lblSelectMonth.Name = "lblSelectMonth";
            this.lblSelectMonth.Size = new System.Drawing.Size(96, 20);
            this.lblSelectMonth.TabIndex = 9;
            this.lblSelectMonth.Text = "Select Month";
            // 
            // cbMonths
            // 
            this.cbMonths.BackColor = System.Drawing.Color.Transparent;
            this.cbMonths.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonths.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(141)))), ((int)(((byte)(69)))));
            this.cbMonths.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonths.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbMonths.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMonths.ForeColor = System.Drawing.Color.Black;
            this.cbMonths.ItemHeight = 22;
            this.cbMonths.Location = new System.Drawing.Point(486, 27);
            this.cbMonths.Name = "cbMonths";
            this.cbMonths.Size = new System.Drawing.Size(140, 28);
            this.cbMonths.TabIndex = 10;
            this.cbMonths.SelectedIndexChanged += new System.EventHandler(this.cbMonths_SelectedIndexChanged);
            // 
            // studentsChart
            // 
            this.studentsChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.studentsChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            this.studentsChart.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 86.36968F;
            chartArea1.InnerPlotPosition.Width = 90.2994F;
            chartArea1.InnerPlotPosition.X = 5F;
            chartArea1.InnerPlotPosition.Y = 3.35106F;
            chartArea1.Name = "ChartArea1";
            this.studentsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.studentsChart.Legends.Add(legend1);
            this.studentsChart.Location = new System.Drawing.Point(174, 109);
            this.studentsChart.Name = "studentsChart";
            this.studentsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(194)))));
            series1.CustomProperties = "IsXAxisQuantitative=False";
            series1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.LegendText = "Students";
            series1.MarkerSize = 6;
            series1.Name = "Students";
            series1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(118)))), ((int)(((byte)(200)))));
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.studentsChart.Series.Add(series1);
            this.studentsChart.Size = new System.Drawing.Size(746, 191);
            this.studentsChart.TabIndex = 13;
            this.studentsChart.Text = "Students Chart";
            this.studentsChart.Visible = false;
            // 
            // paymentChart
            // 
            this.paymentChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.paymentChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            this.paymentChart.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 86.36968F;
            chartArea2.InnerPlotPosition.Width = 90.2994F;
            chartArea2.InnerPlotPosition.X = 5F;
            chartArea2.InnerPlotPosition.Y = 3.35106F;
            chartArea2.Name = "ChartArea1";
            this.paymentChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.paymentChart.Legends.Add(legend2);
            this.paymentChart.Location = new System.Drawing.Point(174, 305);
            this.paymentChart.Name = "paymentChart";
            this.paymentChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalRight;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series2.Legend = "Legend1";
            series2.Name = "Total Amount";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "Paid Amount";
            this.paymentChart.Series.Add(series2);
            this.paymentChart.Series.Add(series3);
            this.paymentChart.Size = new System.Drawing.Size(746, 191);
            this.paymentChart.TabIndex = 14;
            this.paymentChart.Text = "Students Chart";
            this.paymentChart.Visible = false;
            // 
            // chbEnableChart
            // 
            this.chbEnableChart.AutoSize = true;
            this.chbEnableChart.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbEnableChart.CheckedState.BorderRadius = 0;
            this.chbEnableChart.CheckedState.BorderThickness = 0;
            this.chbEnableChart.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(33)))), ((int)(((byte)(255)))));
            this.chbEnableChart.Location = new System.Drawing.Point(174, 88);
            this.chbEnableChart.Name = "chbEnableChart";
            this.chbEnableChart.Size = new System.Drawing.Size(88, 17);
            this.chbEnableChart.TabIndex = 15;
            this.chbEnableChart.Text = "Display Chart";
            this.chbEnableChart.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbEnableChart.UncheckedState.BorderRadius = 0;
            this.chbEnableChart.UncheckedState.BorderThickness = 0;
            this.chbEnableChart.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(33)))), ((int)(((byte)(255)))));
            this.chbEnableChart.CheckedChanged += new System.EventHandler(this.chbEnableChart_CheckedChanged);
            // 
            // tbTotalAmount
            // 
            this.tbTotalAmount.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.tbTotalAmount.BorderThickness = 0;
            this.tbTotalAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTotalAmount.DefaultText = "Total Amount";
            this.tbTotalAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTotalAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTotalAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTotalAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTotalAmount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.tbTotalAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTotalAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalAmount.ForeColor = System.Drawing.Color.White;
            this.tbTotalAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTotalAmount.Location = new System.Drawing.Point(632, 28);
            this.tbTotalAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTotalAmount.Name = "tbTotalAmount";
            this.tbTotalAmount.PasswordChar = '\0';
            this.tbTotalAmount.PlaceholderText = "";
            this.tbTotalAmount.SelectedText = "";
            this.tbTotalAmount.Size = new System.Drawing.Size(141, 54);
            this.tbTotalAmount.TabIndex = 16;
            this.tbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPaidAmount
            // 
            this.tbPaidAmount.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.tbPaidAmount.BorderThickness = 0;
            this.tbPaidAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPaidAmount.DefaultText = "Paid Amount";
            this.tbPaidAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbPaidAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbPaidAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPaidAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbPaidAmount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.tbPaidAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPaidAmount.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPaidAmount.ForeColor = System.Drawing.Color.White;
            this.tbPaidAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbPaidAmount.Location = new System.Drawing.Point(779, 28);
            this.tbPaidAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPaidAmount.Name = "tbPaidAmount";
            this.tbPaidAmount.PasswordChar = '\0';
            this.tbPaidAmount.PlaceholderText = "";
            this.tbPaidAmount.SelectedText = "";
            this.tbPaidAmount.Size = new System.Drawing.Size(141, 54);
            this.tbPaidAmount.TabIndex = 17;
            this.tbPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AnalyzeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 530);
            this.Controls.Add(this.tbPaidAmount);
            this.Controls.Add(this.tbTotalAmount);
            this.Controls.Add(this.chbEnableChart);
            this.Controls.Add(this.paymentChart);
            this.Controls.Add(this.studentsChart);
            this.Controls.Add(this.cbMonths);
            this.Controls.Add(this.lblSelectMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCurrentMonthStudents);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStudentsCurrentMonth);
            this.Controls.Add(this.btnAllStudents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(950, 540);
            this.Name = "AnalyzeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnalyzeForm";
            this.Load += new System.EventHandler(this.AnalyzeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAllStudents;
        private Guna.UI2.WinForms.Guna2Button btnStudentsCurrentMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbCurrentMonthStudents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelectMonth;
        private Guna.UI2.WinForms.Guna2ComboBox cbMonths;
        private System.Windows.Forms.DataVisualization.Charting.Chart studentsChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart paymentChart;
        private Guna.UI2.WinForms.Guna2CheckBox chbEnableChart;
        private Guna.UI2.WinForms.Guna2TextBox tbTotalAmount;
        private Guna.UI2.WinForms.Guna2TextBox tbPaidAmount;
    }
}