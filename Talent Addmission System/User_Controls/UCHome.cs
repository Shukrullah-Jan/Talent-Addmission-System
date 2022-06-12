using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Talent_Addmission_System.User_Controls
{
    public partial class UCHome : UserControl
    {

        DBAccess database = new DBAccess(Dashboard.dataSourcePath);

        // record ID
        public static int studentID = -1;
        // variables
        public static string regNumber = "", program = "";
        // variable for showing UCHome state
        public static Boolean UCHomeState = false;
        public UCHome()
        {
            InitializeComponent();
        }


        private void UCHome_Load(object sender, EventArgs e)
        {
            dgvAllRecords.Width = this.Width;
            dgvAllRecords.ScrollBars = ScrollBars.Both;
            dgvAllRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvAllRecords.AllowUserToResizeRows = false;

            try
            {

                DataTable dtRecords = new DataTable();
                string query = "Select * from " + Dashboard.accessTableName;
                database.readDatathroughAdapter(query, dtRecords);

                dgvAllRecords.DataSource = dtRecords;
                if (Functions.areColumnNamesValid(dgvAllRecords))
                {

                    // hide some columns 
                    dgvAllRecords.Columns["teacher"].Visible = false;
                    dgvAllRecords.Columns["admissionDate"].Visible = false;
                    dgvAllRecords.Columns["phoneNumber"].Visible = false;
                    dgvAllRecords.Columns["cashier"].Visible = false;
                    dgvAllRecords.Columns["notePrice"].Visible = false;
                    dgvAllRecords.Columns["studentAddress"].Visible = false;
                    dgvAllRecords.Columns["picture"].Visible = false;
                    dgvAllRecords.Columns["teacher"].Visible = false;

                    // set column width
                    dgvAllRecords.Columns["ID"].Width = 60;
                    dgvAllRecords.Columns["studentName"].Width = 100;
                    dgvAllRecords.Columns["fatherName"].Width = 100;
                    dgvAllRecords.Columns["studentID"].Width = 70;
                    dgvAllRecords.Columns["program"].Width = 80;
                    dgvAllRecords.Columns["duration"].Width = 50;
                    dgvAllRecords.Columns["timing"].Width = 130;
                    dgvAllRecords.Columns["amount"].Width = 60;
                    dgvAllRecords.Columns["paid"].Width = 60;

                    // changing header names
                    dgvAllRecords.Columns["ID"].HeaderText = "Reg.no";
                    dgvAllRecords.Columns["studentName"].HeaderText = "Student name";
                    dgvAllRecords.Columns["fatherName"].HeaderText = "Father name";
                    dgvAllRecords.Columns["studentID"].HeaderText = "Student ID";
                    dgvAllRecords.Columns["program"].HeaderText = "Program";
                    dgvAllRecords.Columns["duration"].HeaderText = "Duration";
                    dgvAllRecords.Columns["timing"].HeaderText = "Timing";
                    dgvAllRecords.Columns["amount"].HeaderText = "Amount";
                    dgvAllRecords.Columns["paid"].HeaderText = "Paid";
                }
                else
                {
                    MessageBox.Show("A column name inside access table has not a valid name\nRead the instruction" +
                " for how to name columns in settings", "Column name error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            database.closeConn();
        }


        private void btnDisplayRecord_Click(object sender, EventArgs e)
        {
            if (dgvAllRecords.Rows.Count < 1) return;
            

            // change boolean values
            UCSearchRecords.UCSearchRecordState = false;
            UCDeleteRecords.UCDeleteRecordState = false;
            UCHomeState = true;

            if (dgvAllRecords.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvAllRecords.SelectedRows)
                {
                    try
                    {
                        regNumber = Convert.ToString(row.Cells["ID"].Value);
                        program = Convert.ToString(row.Cells["program"].Value);
                        studentID = int.Parse((Convert.ToString(row.Cells["studentID"].Value)));

                    }
                    catch (FormatException)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(row.Cells["studentID"].Value)))
                        {
                            // zero if student ID is whitespace
                            studentID = 0;
                            program = Convert.ToString(row.Cells["program"].Value);

                        }
                        else
                        {
                            // -1 if student ID contains letters
                            studentID = -1;
                            program = Convert.ToString(row.Cells["program"].Value);
                            MessageBox.Show("This record has not a valid ID\nID contains letters");

                     
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
            }

            FormCollection fc = Application.OpenForms;
            Boolean isFormOpen = false;
            DisplayRecordForm displayForm = new DisplayRecordForm();

            foreach (Form f in fc)
            {
                if ((f.Name == "DisplayRecordForm"))
                {
                    isFormOpen = true;
                    displayForm = (DisplayRecordForm)f;
                }
            }


            if (isFormOpen == false)
            {
                displayForm.Show();
            }
            else
            {
                displayForm.BringToFront();
                displayForm.Focus();

            }

        }
        private void UCHome_SizeChanged(object sender, EventArgs e)
        {

            dgvAllRecords.Width = this.Width;
            dgvAllRecords.Height = this.Height - 85;
            dgvAllRecords.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dgvAllRecords.ScrollBars = ScrollBars.Both;


            btnDisplayRecord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDisplayRecord.Location = new Point(this.Width - 180, this.Height - 63);

        }


    }
}
