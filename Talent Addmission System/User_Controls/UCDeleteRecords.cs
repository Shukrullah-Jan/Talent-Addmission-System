using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using Talent_Addmission_System.Properties;

namespace Talent_Addmission_System.User_Controls
{
    public partial class UCDeleteRecords : UserControl
    {
        DBAccess database = new DBAccess(Dashboard.dataSourcePath);
        DataTable dtWhiteSpaceIds;
        DataTable dtStudents;
        // record ID
        public static int studentID = -1;
        // variables
        public static string regNumber = "", program = "";

        public static Boolean UCDeleteRecordState = false;
        // icons
        Bitmap bitmapIcon;
        Icon icon;

        public UCDeleteRecords()
        {
            InitializeComponent();
        }

        private void UCDeleteRecords_Load(object sender, EventArgs e)
        {
            int displayRecordFormRegNumber = DisplayRecordForm.studentRegNumberToPass;

            if (DisplayRecordForm.btnDeleteClicked && displayRecordFormRegNumber != -1)
            {
                rbRegNumber.Checked = true;
                tbRegistrationNumber.Text = displayRecordFormRegNumber.ToString();
                dtStudents = new DataTable();

                try
                {
                    string query = "Select * from " + Dashboard.accessTableName + $" Where ID = {displayRecordFormRegNumber}";
                    database.readDatathroughAdapter(query, dtStudents);

                    if (dtStudents.Rows.Count > 0)
                    {

                        dgvSearchedRecords.DataSource = dtStudents;
                        modifyColumns();
                    }
                    else
                    {
                
                        dgvSearchedRecords.DataSource = "";
                        MessageBox.Show("Student with registration number " + tbRegistrationNumber.Text + " is not present in the database");

                    }
                }
                catch (OleDbException)
                {
                    try
                    {
                        int.Parse(tbRegistrationNumber.Text.Trim());
                    }
                    catch (FormatException)
                    {
                      
                        MessageBox.Show("Error: Student registration number should not contain white space or letters");
                    }
                    catch (Exception exe)
                    {
                 
                        MessageBox.Show(exe.Message);
                    }
       
                    dgvSearchedRecords.DataSource = "";

                }
                catch (Exception ex)
                {


                    dgvSearchedRecords.DataSource = "";
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                rbStudentID.Checked = true;
                rbRegNumber.Checked = false;
                rbStudentName.Checked = false;
            }

    
        }

    
        private void btnDisplayRecord_Click(object sender, EventArgs e)
        {
            if (dgvSearchedRecords.Rows.Count < 1) return;

            // change booelan values
            UCSearchRecords.UCSearchRecordState = false;
            UCHome.UCHomeState = false;
            UCDeleteRecordState = true;

            if (dgvSearchedRecords.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSearchedRecords.SelectedRows)
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
                            // zero if record's ID is whitespace
                            studentID = 0;
                            program = Convert.ToString(row.Cells["program"].Value);

                        }
                        else
                        {
                            // -1 if records's ID contains whitespace
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

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (dgvSearchedRecords.SelectedRows.Count > 0)
            {

                DialogResult result = MessageBox.Show("Do you want to delete the selected record?", "Delete record", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {

                        string regN = Convert.ToString(dgvSearchedRecords.SelectedRows[0].Cells["ID"].Value);
                        string query = "Delete From " + Dashboard.accessTableName + " where ID = " + regN;


                        OleDbCommand deleteCommand = new OleDbCommand(query);
                        int row = database.executeQuery(deleteCommand);

                        if (row == 1)
                        {
                            for (int i = dtStudents.Rows.Count - 1; i >= 0; i--)
                            {
                                DataRow dr = dtStudents.Rows[i];
                                if (dr["ID"].ToString() == regN.ToString())
                                {

                                    dtStudents.Rows.Remove(dr);
                                }


                            }
                            dtStudents.AcceptChanges();
                          
                            MessageBox.Show("Record with registration number " + regN + " deleted successfully", "Delete Record");
                            btnSearchRecord.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Error!!!\nRecord with " + regN + " can't be deleted");

                        }

                        epRegistrationNumber.SetError(tbRegistrationNumber, "");
                    }
                    catch (FormatException)
                    {
                        epRegistrationNumber.SetError(tbRegistrationNumber, "Registration number is not in correct format\n" +
                            "Should not contain letters or whitespace");
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }


            }

        }

        public void changeEPIconTick(ErrorProvider ep)
        {
            bitmapIcon = new Bitmap(Resources.epTickIcon);
            bitmapIcon.MakeTransparent(Color.White);
            System.IntPtr icH = bitmapIcon.GetHicon();
            icon = Icon.FromHandle(icH);
            ep.Icon = icon;
        }
        public void changeEPIconError(ErrorProvider ep)
        {
            bitmapIcon = new Bitmap(Resources.epIcon);
            bitmapIcon.MakeTransparent(Color.White);
            System.IntPtr icH = bitmapIcon.GetHicon();
            icon = Icon.FromHandle(icH);
            ep.Icon = icon;
        }

        private void rbStudentID_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbStudentID.Checked)
            {
                epRegistrationNumber.SetError(tbRegistrationNumber, "");
                epName.SetError(tbStudentName, "");

                tbStudentID.Enabled = true;
                tbStudentID.Focus();
                tbRegistrationNumber.Enabled = false;
                tbStudentName.Enabled = false;

            }
        }

        private void rbStudentName_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbStudentName.Checked)
            {
                epID.SetError(tbStudentID, "");
                epRegistrationNumber.SetError(tbRegistrationNumber, "");

                tbStudentID.Enabled = false;
                tbRegistrationNumber.Enabled = false;
                tbStudentName.Enabled = true;
            tbStudentName.Focus();

        }
        }

        private void rbRegNumber_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbRegNumber.Checked)
            {
                epID.SetError(tbStudentID, "");
                epName.SetError(tbStudentName, "");

                tbStudentID.Enabled = false;
                tbRegistrationNumber.Enabled = true;
                tbRegistrationNumber.Focus();
                tbStudentName.Enabled = false;

            }
        }

        private void tbStudentID_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                int ID = int.Parse(tbStudentID.Text.Trim());

                // epSID icon
                changeEPIconTick(epID);
                epID.SetError(tbStudentID, "Valid Student ID");

            }
            catch (FormatException)
            {
                if (!(string.IsNullOrWhiteSpace(tbStudentID.Text)))
                {
                    // epSID icon
                    changeEPIconError(epID);
                    epID.SetError(tbStudentID, "Invalid Student ID\n" +
                                "Student ID should not contain letters or whitespace");
                    return;

                }
                else
                {
                    changeEPIconTick(epID);
                    epID.SetError(tbStudentID, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
        }

        private void tbStudentName_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbStudentName.Text))
            {
                changeEPIconError(epName);
                epName.SetError(tbStudentName, "Student name should not contain white space");
            }
            else
            {
                changeEPIconTick(epName);
                epName.SetError(tbStudentName, "Valid student name");
            }
        }

        private void tbRegistrationNumber_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                int regNumber = int.Parse(tbRegistrationNumber.Text.Trim());
                // epSID icon
                changeEPIconTick(epRegistrationNumber);
                epRegistrationNumber.SetError(tbRegistrationNumber, "Valid Registration Number");

            }
            catch (FormatException)
            {

                // epSID icon
                changeEPIconError(epRegistrationNumber);
                epRegistrationNumber.SetError(tbRegistrationNumber, "Invalid Registration Number\n" +
                            "Registration number should not contain letters or whitespace");
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }
        }

        private void btnSearchRecord_Click_1(object sender, EventArgs e)
        {

            string query = "";

            if (rbStudentID.Checked)
            {
                dtStudents = new DataTable();

                if (string.IsNullOrWhiteSpace(tbStudentID.Text))
                {
                    try
                    {
                        query = "Select * from " + Dashboard.accessTableName;
                        database.readDatathroughAdapter(query, dtStudents);

                        if (dtStudents.Rows.Count > 0)
                        {
                            dtWhiteSpaceIds = new DataTable();
                            dtWhiteSpaceIds.Columns.Add("ID");
                            dtWhiteSpaceIds.Columns.Add("studentName");
                            dtWhiteSpaceIds.Columns.Add("fatherName");
                            dtWhiteSpaceIds.Columns.Add("studentID");
                            dtWhiteSpaceIds.Columns.Add("admissionDate");
                            dtWhiteSpaceIds.Columns.Add("program");
                            dtWhiteSpaceIds.Columns.Add("timing");
                            dtWhiteSpaceIds.Columns.Add("amount");
                            dtWhiteSpaceIds.Columns.Add("paid");
                            dtWhiteSpaceIds.Columns.Add("duration");
                            dtWhiteSpaceIds.Columns.Add("phoneNumber");
                            dtWhiteSpaceIds.Columns.Add("cashier");
                            dtWhiteSpaceIds.Columns.Add("studentAddress");
                            dtWhiteSpaceIds.Columns.Add("picture");

                            for (int i = 0; i < dtStudents.Rows.Count; i++)
                            {
                                if (string.IsNullOrWhiteSpace(dtStudents.Rows[i][3].ToString()))
                                {

                                    DataRow row = dtStudents.Rows[i];
                                    dtWhiteSpaceIds.ImportRow(row);
                                }


                            }
                            if (dtWhiteSpaceIds.Rows.Count > 0)
                            {
                                dgvSearchedRecords.DataSource = dtWhiteSpaceIds;

                                // set column width
                                dgvSearchedRecords.Columns["ID"].Width = 40;
                                dgvSearchedRecords.Columns["studentName"].Width = 80;
                                dgvSearchedRecords.Columns["fatherName"].Width = 80;
                                dgvSearchedRecords.Columns["studentID"].Width = 60;
                                dgvSearchedRecords.Columns["program"].Width = 80;
                                dgvSearchedRecords.Columns["timing"].Width = 130;

                                // changing header names
                                dgvSearchedRecords.Columns["ID"].HeaderText = "Reg.no";
                                dgvSearchedRecords.Columns["studentName"].HeaderText = "Student name";
                                dgvSearchedRecords.Columns["fatherName"].HeaderText = "Father name";
                                dgvSearchedRecords.Columns["studentID"].HeaderText = "Student ID";
                                dgvSearchedRecords.Columns["admissionDate"].HeaderText = "Admission Date";
                                dgvSearchedRecords.Columns["program"].HeaderText = "Program";
                                dgvSearchedRecords.Columns["timing"].HeaderText = "Timing";
                                dgvSearchedRecords.Columns["amount"].HeaderText = "Amount";
                                dgvSearchedRecords.Columns["paid"].HeaderText = "Paid";


                                dgvSearchedRecords.Columns["duration"].HeaderText = "Duration";
                                dgvSearchedRecords.Columns["phoneNumber"].HeaderText = "Phone Number";
                                dgvSearchedRecords.Columns["cashier"].HeaderText = "Cashier";
                                dgvSearchedRecords.Columns["studentAddress"].HeaderText = "Student Address";
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Student with ID " + tbStudentID.Text + " is not present in the database");
                            }
                         

                        }
                        else
                        {
                            MessageBox.Show("Student with ID " + tbStudentID.Text + " is not present in the database");
                            dgvSearchedRecords.DataSource = "";
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message);
                        dgvSearchedRecords.DataSource = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        dgvSearchedRecords.DataSource = "";
                    }

                }
                else
                {
                    try
                    {
                        query = "Select * from " + Dashboard.accessTableName + " Where studentID = '" + tbStudentID.Text.Trim() + "'";
                        database.readDatathroughAdapter(query, dtStudents);

                        if (dtStudents.Rows.Count > 0)
                        {

                            dgvSearchedRecords.DataSource = dtStudents;

                        }
                        else
                        {
                            MessageBox.Show("Student with ID " + tbStudentID.Text + " is not present in the database");
                            dgvSearchedRecords.DataSource = "";
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message);
                        dgvSearchedRecords.DataSource = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        dgvSearchedRecords.DataSource = "";
                    }

                }

            }
            else if (rbRegNumber.Checked)
            {
                dtStudents = new DataTable();
                try
                {
                    query = "Select * from " + Dashboard.accessTableName + $" Where ID = {tbRegistrationNumber.Text.Trim()}";
                    database.readDatathroughAdapter(query, dtStudents);

                    if (dtStudents.Rows.Count > 0)
                    {

                        dgvSearchedRecords.DataSource = dtStudents;
                    }
                    else
                    {
                        MessageBox.Show("Student with registration number " + tbRegistrationNumber.Text + " is not present in the database");
                        dgvSearchedRecords.DataSource = "";
                    }
                }
                catch (OleDbException)
                {
                    try
                    {
                        int.Parse(tbRegistrationNumber.Text.Trim());
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error: Student registration number should not contain white space or letters");
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(exe.Message);
                    }
                    dgvSearchedRecords.DataSource = "";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    dgvSearchedRecords.DataSource = "";
                }

            }
            else if (rbStudentName.Checked)
            {
           
                dtStudents = new DataTable();
                try
                {
                    query = $"Select * from " + Dashboard.accessTableName + " Where studentName = '" + tbStudentName.Text.Trim() + "'";
                    database.readDatathroughAdapter(query, dtStudents);

                    if (dtStudents.Rows.Count > 0)
                    {

                        dgvSearchedRecords.DataSource = dtStudents;
                    }
                    else
                    {
                        MessageBox.Show(tbStudentName.Text + " Is not present inside the database");
                        dgvSearchedRecords.DataSource = "";
                    }
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Message);
                    dgvSearchedRecords.DataSource = "";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    dgvSearchedRecords.DataSource = "";
                }

            }

            if (dgvSearchedRecords.Rows.Count > 0)
            {
                modifyColumns();
            }
        }

 

        private void tbStudentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchRecord.PerformClick();
            }
        }

        private void tbStudentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchRecord.PerformClick();
            }
        }

        private void tbRegistrationNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchRecord.PerformClick();
            }
        }
        private void UCDeleteRecords_SizeChanged(object sender, EventArgs e)
        {
            dgvSearchedRecords.Width = this.Width - panelSearch.Width;
            dgvSearchedRecords.Height = this.Height - 68;
            dgvSearchedRecords.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dgvSearchedRecords.ScrollBars = ScrollBars.Both;

            panelDisplayBtn.Width = this.Width - panelSearch.Width;


            btnDisplayRecord.Location = new Point(panelDisplayBtn.Width - 350, panelDisplayBtn.Height - 64);
            btnDeleteRecord.Location = new Point(panelDisplayBtn.Width - 184, panelDisplayBtn.Height - 64);


        }
        private void modifyColumns() {

            if (Functions.areColumnNamesValid(dgvSearchedRecords))
            {
                // set column width
                dgvSearchedRecords.Columns["ID"].Width = 40;
                dgvSearchedRecords.Columns["studentName"].Width = 80;
                dgvSearchedRecords.Columns["fatherName"].Width = 80;
                dgvSearchedRecords.Columns["studentID"].Width = 60;
                dgvSearchedRecords.Columns["program"].Width = 80;
                dgvSearchedRecords.Columns["timing"].Width = 130;

                // changing header names
                dgvSearchedRecords.Columns["ID"].HeaderText = "Reg.no";
                dgvSearchedRecords.Columns["studentName"].HeaderText = "Student name";
                dgvSearchedRecords.Columns["fatherName"].HeaderText = "Father name";
                dgvSearchedRecords.Columns["studentID"].HeaderText = "Student ID";
                dgvSearchedRecords.Columns["admissionDate"].HeaderText = "Admission Date";
                dgvSearchedRecords.Columns["program"].HeaderText = "Program";
                dgvSearchedRecords.Columns["timing"].HeaderText = "Timing";
                dgvSearchedRecords.Columns["amount"].HeaderText = "Amount";
                dgvSearchedRecords.Columns["paid"].HeaderText = "Paid";
                dgvSearchedRecords.Columns["duration"].HeaderText = "Duration";
                dgvSearchedRecords.Columns["phoneNumber"].HeaderText = "Phone Number";
                dgvSearchedRecords.Columns["cashier"].HeaderText = "Cashier";
                dgvSearchedRecords.Columns["studentAddress"].HeaderText = "Student Address";
            }
            else
            {
                MessageBox.Show("A column name inside access table has not a valid name\nRead the instruction" +
                         " for how to name columns in settings", "Column name error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
 
    } 
}
