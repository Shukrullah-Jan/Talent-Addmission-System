using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Talent_Addmission_System
{
    public partial class AnalyzeForm : Form
    {


        private DBAccess database = new DBAccess(Dashboard.dataSourcePath);
        private HashSet<string> uniqueStudentIDs = new HashSet<string>();
        private List<string> currentMonthStudents = new List<string>();
        private DataTable dtAllStudents = new DataTable();

        // fields for chart
        private List<int> studentsEachMonth = new List<int>() { 0,0,0,0,0,0,0,0,0,0,0,0};
        private List<double> totalAmountEachMonth = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private List<double> paidAmountEachMonth = new List<double>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        string currentDate = DateTime.Now.ToLongDateString();

        private int isFilled = -1;
        public AnalyzeForm()
        {
            InitializeComponent();
        }



        private void AnalyzeForm_Load(object sender, EventArgs e)
        {
            
            lbCurrentMonthStudents.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            lbCurrentMonthStudents.MeasureItem += lbCurrentMonthStudents_MeasureItem;
            lbCurrentMonthStudents.DrawItem += lbCurrentMonthStudents_DrawItem;

            lblSelectMonth.Text = "Select Month, " + DateTime.Now.Year.ToString();
            fillMonths();
    

            string shortDate = currentDate.Substring(currentDate.IndexOf(" ")).Trim();
            string currentMonth = shortDate.Substring(0, shortDate.IndexOf(" ")).Trim();
            // temporary variables
            string tempShortDate, tempCurrentMonth;
            string query = "Select * From " + Dashboard.accessTableName;
            
            try
            {
                database.readDatathroughAdapter(query, dtAllStudents);

                if (dtAllStudents.Rows.Count > 0)
                {
                    int index = 0;
                    foreach (var row in dtAllStudents.Rows )
                    {
                       
                        uniqueStudentIDs.Add(dtAllStudents.Rows[index]["studentID"].ToString());

                        // current month total number of students
                        string date = dtAllStudents.Rows[index]["admissionDate"].ToString();
                        tempShortDate = date.Substring(date.IndexOf(" ")).Trim();
                        tempCurrentMonth = tempShortDate.Substring(0, tempShortDate.IndexOf(" ")).Trim();
                        // compare months
                        if (currentMonth == tempCurrentMonth)
                        {
                            currentMonthStudents.Add(dtAllStudents.Rows[index]["studentID"].ToString());

                            lbCurrentMonthStudents.Items.Add(dtAllStudents.Rows[index]["studentID"].ToString() + ": "
                                + dtAllStudents.Rows[index]["studentName"].ToString() + ", "
                                + dtAllStudents.Rows[index]["program"].ToString());
                         
                        }

                        index++;
                    }
    
                }
   
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (uniqueStudentIDs.Count > 0)
            {
                btnAllStudents.Text = uniqueStudentIDs.Count.ToString();
          
            }
            else {
                btnAllStudents.Text = "0";
            }

            if (currentMonthStudents.Count > 0)
            {
                btnStudentsCurrentMonth.Text = currentMonthStudents.Count.ToString();
                
         
            }
            else btnStudentsCurrentMonth.Text = "0";


     
     
        }

      
        private void cbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable adStudents = new DataTable();
            double totalAmount = 0.0;
            double paidAmount = 0.0;

            int currentYear = DateTime.Now.Year;
     
            // temporary variables
            string tempShortDate, tempCurrentMonth, tempYear;
            string query = "Select * From " + Dashboard.accessTableName;

            try
            {
                database.readDatathroughAdapter(query, adStudents);

                if (adStudents.Rows.Count > 0)
                {
                    int index = 0;
                    foreach (var row in adStudents.Rows)
                    {
  
                        // current month total number of students
                        string date = adStudents.Rows[index]["admissionDate"].ToString();
                        tempShortDate = date.Substring(date.IndexOf(" ")).Trim();
                        tempCurrentMonth = tempShortDate.Substring(0, tempShortDate.IndexOf(" ")).Trim();

                        // get year
                        tempYear = date.Substring(date.LastIndexOf(" ")).Trim();
                 
                        // compare months
                        if (cbMonths.Text == tempCurrentMonth && tempYear == currentYear.ToString())
                        {

                            // current month total amount
                            try
                            {
                                totalAmount += double.Parse(adStudents.Rows[index]["amount"].ToString());
                                paidAmount += double.Parse(adStudents.Rows[index]["paid"].ToString());
                            }
                            catch (FormatException)
                            {

                            }
                        }

                        index++;
                    }

                }

            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            // Calculate Total Amount
            if (totalAmount > 999)
            {
                tbTotalAmount.Text = String.Format("{0:0.00 k}", totalAmount);
            }
            else
            {
                tbTotalAmount.Text = String.Format("{0:0.00}", totalAmount);
            }
            if (paidAmount > 999)
            {
                tbPaidAmount.Text = String.Format("{0:0.00 k}", paidAmount); 
            }
            else
            {
                tbPaidAmount.Text = String.Format("{0:0.00}", paidAmount); 
            }
          
        
        }
        private void lbCurrentMonthStudents_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(lbCurrentMonthStudents.Items[e.Index].ToString(),
                lbCurrentMonthStudents.Font, lbCurrentMonthStudents.Width).Height;
        }

        private void lbCurrentMonthStudents_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(lbCurrentMonthStudents.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

       

        private void chbEnableChart_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnableChart.Checked)
            {
                studentsChart.Visible = true;
                paymentChart.Visible = true;
                if (isFilled == -1)
                {
               
                    fillChart();
                    isFilled++;
                }

             
            }
            else
            {
                studentsChart.Visible = false;
                paymentChart.Visible = false;
            }
           
           
        }
        private void fillMonths()
        {

            cbMonths.Items.Add("January");
            cbMonths.Items.Add("February");
            cbMonths.Items.Add("March");
            cbMonths.Items.Add("April");
            cbMonths.Items.Add("May");
            cbMonths.Items.Add("June");
            cbMonths.Items.Add("July");
            cbMonths.Items.Add("August");
            cbMonths.Items.Add("September");
            cbMonths.Items.Add("October");
            cbMonths.Items.Add("November");
            cbMonths.Items.Add("December");

            cbMonths.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void fillChart()
        {

            DataTable dtStudents = new DataTable();

            int currentYear = DateTime.Now.Year;


            // temporary variables
            string tempShortDate, tempCurrentMonth, tempYear;
            string query = "Select * From " + Dashboard.accessTableName;



            try
            {
                database.readDatathroughAdapter(query, dtStudents);

                if (dtStudents.Rows.Count > 0)
                {
                    int index = 0;
                    foreach (var row in dtStudents.Rows)
                    {

                        // current month total number of students
                        string date = dtStudents.Rows[index]["admissionDate"].ToString();
                        tempShortDate = date.Substring(date.IndexOf(" ")).Trim();
                        tempCurrentMonth = tempShortDate.Substring(0, tempShortDate.IndexOf(" ")).Trim();

                        // get year
                        tempYear = date.Substring(date.LastIndexOf(" ")).Trim();

                        // compare years
                        if (currentYear.ToString() == tempYear)
                        {

                            // current month total amount
                            try
                            {
                                if (tempCurrentMonth == "January")
                                {
                                    studentsEachMonth[0] += 1;
                                    totalAmountEachMonth[0] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[0] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "February")
                                {
                                    studentsEachMonth[1] += 1;
                                    totalAmountEachMonth[1] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[1] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "March")
                                {
                                    studentsEachMonth[2] += 1;
                                    totalAmountEachMonth[2] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[2] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "April")
                                {
                                    studentsEachMonth[3] += 1;
                                    totalAmountEachMonth[3] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[3] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "May")
                                {
                                    studentsEachMonth[4] += 1;
                                    totalAmountEachMonth[4] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[4] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "June")
                                {
                                    studentsEachMonth[5] += 1;
                      
                                    totalAmountEachMonth[5] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[5] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "July")
                                {
                                    studentsEachMonth[6] += 1;
                       
                                    totalAmountEachMonth[6] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[6] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "August")
                                {
                                    studentsEachMonth[7] += 1;

                                    totalAmountEachMonth[7] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[7] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "September")
                                {
                                    studentsEachMonth[8] += 1;
                    
                                    totalAmountEachMonth[8] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[8] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "October")
                                {
                                    studentsEachMonth[9] += 1;
                                   
                                    totalAmountEachMonth[9] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[9] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "November")
                                {
                                    studentsEachMonth[10] += 1;

                                    totalAmountEachMonth[10] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[10] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }
                                else if (tempCurrentMonth == "December")
                                {
                                    studentsEachMonth[11] += 1;
  
                                    totalAmountEachMonth[11] += double.Parse(dtStudents.Rows[index]["amount"].ToString());
                                    paidAmountEachMonth[11] += double.Parse(dtStudents.Rows[index]["paid"].ToString());
                                }

                            }
                            catch (FormatException)
                            {

                            }
                        }

                        index++;
                    }

                }

            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (DateTime.Now.Month < 7)
            {
                studentsChart.Series["Students"].Points.AddXY("Jan", studentsEachMonth[0]);
                studentsChart.Series["Students"].Points.AddXY("Feb", studentsEachMonth[1]);
                studentsChart.Series["Students"].Points.AddXY("March", studentsEachMonth[2]);
                studentsChart.Series["Students"].Points.AddXY("April", studentsEachMonth[3]);
                studentsChart.Series["Students"].Points.AddXY("May", studentsEachMonth[4]);
                studentsChart.Series["Students"].Points.AddXY("June", studentsEachMonth[5]);

                // set total amount line
                paymentChart.Series["Total Amount"].Points.AddXY("Jan", totalAmountEachMonth[0]);
                paymentChart.Series["Total Amount"].Points.AddXY("Feb", totalAmountEachMonth[1]);
                paymentChart.Series["Total Amount"].Points.AddXY("March", totalAmountEachMonth[2]);
                paymentChart.Series["Total Amount"].Points.AddXY("April", totalAmountEachMonth[3]);
                paymentChart.Series["Total Amount"].Points.AddXY("May", totalAmountEachMonth[4]);
                paymentChart.Series["Total Amount"].Points.AddXY("June", totalAmountEachMonth[5]);

                // set paid amount line

                paymentChart.Series["Paid Amount"].Points.AddXY("Jan", paidAmountEachMonth[0]);
                paymentChart.Series["Paid Amount"].Points.AddXY("Feb", paidAmountEachMonth[1]);
                paymentChart.Series["Paid Amount"].Points.AddXY("March", paidAmountEachMonth[2]);
                paymentChart.Series["Paid Amount"].Points.AddXY("April", paidAmountEachMonth[3]);
                paymentChart.Series["Paid Amount"].Points.AddXY("May", paidAmountEachMonth[4]);
                paymentChart.Series["Paid Amount"].Points.AddXY("June", paidAmountEachMonth[5]);
            }
            else
            {
                // set students line
                studentsChart.Series["Students"].Points.AddXY("Jan", studentsEachMonth[0]);
                studentsChart.Series["Students"].Points.AddXY("Feb", studentsEachMonth[1]);
                studentsChart.Series["Students"].Points.AddXY("March", studentsEachMonth[2]);
                studentsChart.Series["Students"].Points.AddXY("April", studentsEachMonth[3]);
                studentsChart.Series["Students"].Points.AddXY("May", studentsEachMonth[4]);
                studentsChart.Series["Students"].Points.AddXY("June", studentsEachMonth[5]);
                studentsChart.Series["Students"].Points.AddXY("July", studentsEachMonth[6]);
                studentsChart.Series["Students"].Points.AddXY("August", studentsEachMonth[7]);
                studentsChart.Series["Students"].Points.AddXY("Sept", studentsEachMonth[8]);
                studentsChart.Series["Students"].Points.AddXY("Oct", studentsEachMonth[9]);
                studentsChart.Series["Students"].Points.AddXY("Nov", studentsEachMonth[10]);
                studentsChart.Series["Students"].Points.AddXY("Dec", studentsEachMonth[11]);

                // set total amount line
                paymentChart.Series["Total Amount"].Points.AddXY("Jan", totalAmountEachMonth[0]);
                paymentChart.Series["Total Amount"].Points.AddXY("Feb", totalAmountEachMonth[1]);
                paymentChart.Series["Total Amount"].Points.AddXY("March", totalAmountEachMonth[2]);
                paymentChart.Series["Total Amount"].Points.AddXY("April", totalAmountEachMonth[3]);
                paymentChart.Series["Total Amount"].Points.AddXY("May", totalAmountEachMonth[4]);
                paymentChart.Series["Total Amount"].Points.AddXY("June", totalAmountEachMonth[5]);
                paymentChart.Series["Total Amount"].Points.AddXY("July", totalAmountEachMonth[6]);
                paymentChart.Series["Total Amount"].Points.AddXY("August", totalAmountEachMonth[7]);
                paymentChart.Series["Total Amount"].Points.AddXY("Sept", totalAmountEachMonth[8]);
                paymentChart.Series["Total Amount"].Points.AddXY("Oct", totalAmountEachMonth[9]);
                paymentChart.Series["Total Amount"].Points.AddXY("Nov", totalAmountEachMonth[10]);
                paymentChart.Series["Total Amount"].Points.AddXY("Dec", totalAmountEachMonth[11]);

                // set paint amount line

                paymentChart.Series["Paid Amount"].Points.AddXY("Jan", paidAmountEachMonth[0]);
                paymentChart.Series["Paid Amount"].Points.AddXY("Feb", paidAmountEachMonth[1]);
                paymentChart.Series["Paid Amount"].Points.AddXY("March", paidAmountEachMonth[2]);
                paymentChart.Series["Paid Amount"].Points.AddXY("April", paidAmountEachMonth[3]);
                paymentChart.Series["Paid Amount"].Points.AddXY("May", paidAmountEachMonth[4]);
                paymentChart.Series["Paid Amount"].Points.AddXY("June", paidAmountEachMonth[5]);
                paymentChart.Series["Paid Amount"].Points.AddXY("July", paidAmountEachMonth[6]);
                paymentChart.Series["Paid Amount"].Points.AddXY("August", paidAmountEachMonth[7]);
                paymentChart.Series["Paid Amount"].Points.AddXY("Sep", paidAmountEachMonth[8]);
                paymentChart.Series["Paid Amount"].Points.AddXY("Oct", paidAmountEachMonth[9]);
                paymentChart.Series["Paid Amount"].Points.AddXY("Nov", paidAmountEachMonth[10]);
                paymentChart.Series["Paid Amount"].Points.AddXY("Dec", paidAmountEachMonth[11]);

            }




        }

   
    }
}
