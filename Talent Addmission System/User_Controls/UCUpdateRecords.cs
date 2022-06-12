using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Talent_Addmission_System.Properties;

namespace Talent_Addmission_System.User_Controls

{
    public partial class UCUpdateRecords : UserControl
    {

        DBAccess database = new DBAccess(Dashboard.dataSourcePath);
        Functions functions = new Functions();
        DataTable dtWhiteSpaceIds;
        
        // variables
        private string regNumber, sID, sName, fName, admissionDate, program, duration,
            timing, teacher, phoneNumber, cashier, studentAddress, notePrice;

        // keep track previous student ID when dgv selection changed
        private string previousStudentID = "",
        // keep track of searched student ID
            studentIDWhenSearchButtonClicked = "";
        // record ID
        public static int studentID = -1;
        // variables
        public static Boolean UCSearchRecordState = false;
        private float amount=0.0f, paid = 0.0f;
        // variables related to student image
        private string path = "";
        private Image image;

        // icons
        Bitmap bitmapIcon;
        Icon icon;

        public UCUpdateRecords()
        {
            InitializeComponent();

        }

        private void UCUpdateRecords_Load(object sender, EventArgs e)
        {
            // set dimensions of controls
            panelMatchedRecords.Width = this.Width - panelSearch.Width;
            panelMatchedRecords.Height = this.Height - panelControls.Height;
            panelMatchedRecords.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            panelControls.Width = this.Width - panelSearch.Width;
            panelControls.Height = this.Height - dgvSearchedRecords.Height;
            panelControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // align buttons
            pbStudentPicture.Location = new Point(panelControls.Width - 130, pbStudentPicture.Location.Y);
            btnBrowse.Location = new Point(panelControls.Width - 125, btnBrowse.Location.Y);
            btnCapture.Location = new Point(panelControls.Width - 125, btnCapture.Location.Y);
            btnReset.Location = new Point(panelControls.Width - 125, btnReset.Location.Y);
            btnUpdateRecord.Location = new Point(panelControls.Width - 165, panelControls.Height - 53);

            rbStudentID.Checked = true;
            rbStudentName.Checked = false;
            rbRegNumber.Checked = false;
            enableControls();
            // set current date for dtp
            dtpAddmissionDate.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSearchRecord_Click(object sender, EventArgs e)
        {
            DataTable dtStudents;
            string query = "";
            studentIDWhenSearchButtonClicked = "";

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
                            dtWhiteSpaceIds.Columns.Add("duration");
                            dtWhiteSpaceIds.Columns.Add("timing");
                            dtWhiteSpaceIds.Columns.Add("amount");
                            dtWhiteSpaceIds.Columns.Add("paid");
                            dtWhiteSpaceIds.Columns.Add("phoneNumber");
                            dtWhiteSpaceIds.Columns.Add("cashier");
                            dtWhiteSpaceIds.Columns.Add("notePrice");
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
                            if (dtWhiteSpaceIds.Rows.Count > 0) dgvSearchedRecords.DataSource = dtWhiteSpaceIds;
                            else
                            {
                                MessageBox.Show("Student with ID " + tbStudentID.Text + " is not present in the database");
                            }

                        }
                        else
                        {
                            clearControlsData();
                            dgvSearchedRecords.DataSource = "";
                            epIDUpdate.SetError(tbStudentIDUpdate, "");
                            lblFeesError.Visible = false;
                            MessageBox.Show("Student with ID " + tbStudentID.Text + " is not present in the database");
                            
                            
                        }
                    }
                    catch (OleDbException ex)
                    {
                    
                        clearControlsData();
                        dgvSearchedRecords.DataSource = "";
                        lblFeesError.Visible = false;
                        MessageBox.Show(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        lblFeesError.Visible = false;
                        dgvSearchedRecords.DataSource = "";
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    try
                    {
                        studentIDWhenSearchButtonClicked = tbStudentID.Text.Trim();

                        query = "Select * from " + Dashboard.accessTableName + " Where studentID = '" + tbStudentID.Text.Trim() + "'";
                        database.readDatathroughAdapter(query, dtStudents);

                        if (dtStudents.Rows.Count > 0)
                        {

                            dgvSearchedRecords.DataSource = dtStudents;

                        }
                        else
                        {
                            dgvSearchedRecords.DataSource = "";
                            clearControlsData();
                            epIDUpdate.SetError(tbStudentIDUpdate, "");
                            MessageBox.Show("Student with ID " + tbStudentID.Text + " is not present in the database");
                         
                        }
                    }
                    catch (OleDbException ex)
                    {
                     
                        clearControlsData();
                        dgvSearchedRecords.DataSource = "";
                        lblFeesError.Visible = false;
                        MessageBox.Show(ex.Message);

                    }
                    catch (Exception ex)
                    {
                        
                        dgvSearchedRecords.DataSource = "";
                        lblFeesError.Visible = false;
                        MessageBox.Show(ex.Message);
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
                        clearControlsData();
                        dgvSearchedRecords.DataSource = "";
                        epIDUpdate.SetError(tbStudentIDUpdate, "");
                        lblFeesError.Visible = false;
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
                        lblFeesError.Visible = false;
                        MessageBox.Show("Error: Student registration number should not contain white space or letters");
                    }
                    catch (Exception exe)
                    {
                        lblFeesError.Visible = false;
                        MessageBox.Show(exe.Message);
                    }
                    clearControlsData();
                    dgvSearchedRecords.DataSource = "";
                    lblFeesError.Visible = false;
                }
                catch (Exception ex)
                {

                
                    clearControlsData();
                    dgvSearchedRecords.DataSource = "";
                    lblFeesError.Visible = false;
                    MessageBox.Show(ex.Message);
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
                        clearControlsData();
                        dgvSearchedRecords.DataSource = "";
                        epIDUpdate.SetError(tbStudentIDUpdate, "");
                        lblFeesError.Visible = false;
                        MessageBox.Show(tbStudentName.Text + " Is not present inside the database");
               
                    }
                }
                catch (OleDbException ex)
                {
           
                    clearControlsData();
                    dgvSearchedRecords.DataSource = "";
                    lblFeesError.Visible = false;
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {

                    clearControlsData();
                    dgvSearchedRecords.DataSource = "";
                    lblFeesError.Visible = false;

                    MessageBox.Show(ex.Message);
                }

            }
            epNameUpdate.SetError(tbStudentNameUpdate, "");
            epFatherName.SetError(tbFatherName, "");
            epFees.SetError(tbFees, "");
            epPaid.SetError(tbPaid, "");
            enableControls();
            lblFeesError.Visible = false;
        }

        private void dgvSearchedRecords_SelectionChanged(object sender, EventArgs e)
        {
  
            if (dgvSearchedRecords.SelectedRows.Count > 0)
            {

                foreach (DataGridViewRow row in dgvSearchedRecords.SelectedRows)
                {
                    try
                    {
                        previousStudentID = Convert.ToString(row.Cells["studentID"].Value);

                        tbRegNumberUpdate.Text = Convert.ToString(row.Cells["ID"].Value);
                        tbStudentIDUpdate.Text = Convert.ToString(row.Cells["studentID"].Value);
                        tbStudentNameUpdate.Text = Convert.ToString(row.Cells["studentName"].Value);
                        tbFatherName.Text = Convert.ToString(row.Cells["fatherName"].Value);
                        dtpAddmissionDate.Text = Convert.ToString(row.Cells["admissionDate"].Value);

                        // set programs list
                        System.Collections.Specialized.StringCollection programs = (System.Collections.Specialized.StringCollection)Settings.Default["programsList"];
                        setPrograms(programs);
                        cbPrograms.Items.Add(row.Cells["program"].Value);
                        cbPrograms.Text = Convert.ToString(row.Cells["program"].Value);

                        tbDuration.Text = Convert.ToString(row.Cells["duration"].Value);
                        tbTiming.Text = Convert.ToString(row.Cells["timing"].Value);
                        tbFees.Text = Convert.ToString(row.Cells["amount"].Value);
                        tbPaid.Text = Convert.ToString(row.Cells["paid"].Value);
                        tbTeacherName.Text = Convert.ToString(row.Cells["teacher"].Value);
                        tbPhoneNumber.Text = Convert.ToString(row.Cells["phoneNumber"].Value);
                        tbCashier.Text = Convert.ToString(row.Cells["cashier"].Value);
                        tbNotePrice.Text = Convert.ToString(row.Cells["notePrice"].Value);
                        tbStudentAddress.Text = Convert.ToString(row.Cells["studentAddress"].Value);

                        // show or hide lblFeesError
                        if (string.IsNullOrEmpty(tbFees.Text.Trim()) && string.IsNullOrEmpty(tbPaid.Text.Trim()))
                        {
                            lblFeesError.Visible = false;
                        }

            
                        try
                        {
                            Image studentPicture = Image.FromFile(Convert.ToString(row.Cells["picture"].Value));
                            pbStudentPicture.Image = studentPicture;
                        }
                        catch (FileNotFoundException)
                        {
                            pbStudentPicture.Image = Resources.student;
                        }
                        catch (Exception)
                        {
                            pbStudentPicture.Image = Resources.student;
                        }
                    }
                    catch (FormatException)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(row.Cells["ID"].Value)))
                        {
                            program = Convert.ToString(row.Cells["program"].Value);
                            MessageBox.Show("This record has not a valid reg. no\nreg.no contains letters or whitespace");
                            return;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                // hide some columns
                modifyColumns();
            }
            else
            {
                previousStudentID = "";
                epIDUpdate.SetError(tbStudentIDUpdate, "");
            }
            epFees.SetError(tbFees, "");
            epPaid.SetError(tbPaid, "");

        }
        private void tbStudentIDUpdate_TextChanged(object sender, EventArgs e)
        {

            if (previousStudentID == tbStudentIDUpdate.Text.Trim())
            {
                changeEPIconTick(epIDUpdate);
                epIDUpdate.SetError(tbStudentIDUpdate, "Valid student ID");

                return;
            }

            try
            {

                int mStudentID = int.Parse(tbStudentIDUpdate.Text.Trim());
                int isPresentInDatabase = functions.checkStudentIDInDatabase(mStudentID);
                if (mStudentID < 1)
                {
                    changeEPIconError(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "Invalid student ID\nID should not be below 0 or negative numbers");

                    tbStudentIDUpdate.Focus();
                    return;
                }
                else if (isPresentInDatabase > 0)
                {
                    changeEPIconInformation(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "Valid student ID\nBut This ID belongs" +
                        " to another student too\n" +
                        "Make sure both students are the same person");
                    return;
                }
                else
                {
                    changeEPIconTick(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "Valid student ID\nNot Taken");
                }
            

            }
            catch (FormatException)
            {

                if ((string.IsNullOrWhiteSpace(tbStudentIDUpdate.Text)))
                {
                    changeEPIconTick(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "unassigned student ID\n" +
                                "This record will be added without student ID");

                    return;
                }
                else
                {

                    changeEPIconError(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "Invalid student ID\nID contains letters or whitespace");

                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }

        }

        private void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update record?", "Update record", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    database.createConn();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Can't establish connection\nTry Again\nTip: check access database path in settings" + ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't establish connection\nTry Again\n" + ex.Message);
                    return;
                }

                regNumber = tbRegNumberUpdate.Text.Trim();
                sID = tbStudentIDUpdate.Text.Trim();
                sName = tbStudentNameUpdate.Text.Trim();
                fName = tbFatherName.Text.Trim();
                admissionDate = dtpAddmissionDate.Text.Trim();
                program = cbPrograms.Text.Trim();
                duration = tbDuration.Text.Trim();
                timing = tbTiming.Text.Trim();
                teacher = tbTeacherName.Text.Trim();
                duration = tbDuration.Text.Trim();
                phoneNumber = tbPhoneNumber.Text.Trim();
                cashier = tbCashier.Text.Trim();
                studentAddress = tbStudentAddress.Text.Trim();
                notePrice = tbNotePrice.Text.Trim();

                // validation
                if (validateStudentID())
                {

                    if (validateStudentNameAndFatherName())
                    {

                        // validate fees, paid and noteprice controls
                        try
                        {
                            amount = float.Parse(tbFees.Text.Trim());
                        }
                        catch (FormatException)
                        {
                            amount = 0.0F;

                        }
                        try
                        {
                            paid = float.Parse(tbPaid.Text.Trim());
                        }
                        catch (FormatException)
                        {
                            paid = 0.0F;
                          
                        }
                        try
                        {
                            float.Parse(tbNotePrice.Text.Trim());
                        }
                        catch (FormatException)
                        {
                            notePrice = "";
                        }

                        // all about image
                        string imagePath = "";
                        string imgLocation = Settings.Default["imagesLocation"].ToString();
                        //random int number for student picture
                        Random rand = new Random();
                        rand.Next(200);

                        try
                        {

                            if (Directory.Exists(imgLocation))
                            {
                                if (!(string.IsNullOrEmpty(path)))
                                {
                                    if (!(pbStudentPicture.Image.Equals(Resources.student)))
                                    {

                                        string imageName = Path.GetFileName(path);
                                        imagePath = Path.Combine(imgLocation, tbStudentNameUpdate.Text.Trim() + rand.Next(2000) + imageName + ".jpg");

                                        // save image to particular folder
                                        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }

                                }
                                else if (TakePictureForm.isDoneClicked && TakePictureForm.capturedImage != null)
                                {
                                    if (!(pbStudentPicture.Image.Equals(Resources.student)))
                                    {
                                        imagePath = Path.Combine(imgLocation, tbStudentNameUpdate.Text.Trim() + rand.Next(2000) + ".jpg");
                                        image = TakePictureForm.capturedImage;
                                        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }
                                }

                            }
                            else
                            {
                                Directory.CreateDirectory(imgLocation);
                                if (!(string.IsNullOrEmpty(path)))
                                {
                                    if (!(pbStudentPicture.Image.Equals(Resources.student)))
                                    {
                                        string imageName = Path.GetFileName(path);
                                        imagePath = Path.Combine(imgLocation, tbStudentNameUpdate.Text.Trim() + rand.Next(2000) + imageName + ".jpg");

                                        // save image to particular folder
                                        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }
                                    else
                                    {
                                        imagePath = "";
                                    }

                                }
                                else if (TakePictureForm.isDoneClicked && TakePictureForm.capturedImage != null)
                                {
                                    if (!(pbStudentPicture.Image.Equals(Resources.student)))
                                    {
                                        imagePath = Path.Combine(imgLocation, tbStudentNameUpdate.Text.Trim() + rand.Next(2000) + ".jpg");
                                        image = TakePictureForm.capturedImage;
                                        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }
                                    else
                                    {
                                        imagePath = "";
                                    }
                                }
                                else
                                {
                                    imagePath = "";
                                }

                            }

                            // check if there are more ocurrences of record via valid ID
                  
                            string updateQuery = "";
                            OleDbCommand updateCommand;
                            int rowsUpdated = -1;

                            if (!(string.IsNullOrEmpty(studentIDWhenSearchButtonClicked)))
                            {

                                try
                                {
                            
                                    int isInDatabase = functions.checkStudentIDInDatabase(int.Parse(studentIDWhenSearchButtonClicked));

                                    if (isInDatabase > 0)
                                    {
                                        string newQuery = "Select * From " + Dashboard.accessTableName + " Where studentID = '"+ studentIDWhenSearchButtonClicked + "'";
                                        DataTable newDtStudent = new DataTable();

                                        database.readDatathroughAdapter(newQuery, newDtStudent);

                                        database.closeConn();

                                        if (newDtStudent.Rows.Count > 0)
                                        {
                                           
                                            // update record's data
                                             updateQuery = "Update " + Dashboard.accessTableName + " Set studentName = '" + @sName + "',fatherName = '" +
                                              @fName + "',studentID = '" + @sID + "' Where studentID = '" + studentIDWhenSearchButtonClicked + "'";

                                             updateCommand = new OleDbCommand(updateQuery);

                                             rowsUpdated = database.executeQuery(updateCommand);
                                             database.closeConn();

                                        }

                                    }
                                }
                                catch (FormatException)
                                {
                                   
                                }
                                catch (Exception)
                                {
                                   
                                }
                               
                            }
                      

                            int regNum = -1;
                            try
                            {
                                regNum = int.Parse(tbRegNumberUpdate.Text.Trim());
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Error!!!\nStudent has not a valid Registration number\nStudent Registration number is not in correct format");
                                return;
                            }

                            // update record's data
                            updateQuery = "Update " + Dashboard.accessTableName + " Set studentName = '" + @sName + "',fatherName = '" +
                              @fName + "',studentID = '" + @sID + "',admissionDate = '" + @admissionDate
                              + "',program = '" + @program + "',duration = '" + @duration
                              + "',timing = '" + @timing + "',amount = '" + @amount.ToString()
                              +"',paid = '" +paid.ToString() + "',teacher = '" + @teacher
                              + "',phoneNumber = '" + @phoneNumber
                              + "',cashier = '" + @cashier 
                              +"',notePrice = '" + @notePrice 
                              + "',studentAddress = '" + @studentAddress +
                              "',picture = '" + @imagePath +
                              "' Where ID = " + regNum;


                            updateCommand = new OleDbCommand(updateQuery);
                            int rows = database.executeQuery(updateCommand);

                            if (rows > 0)
                            {
                                if (rowsUpdated > 0)
                                {
                                    MessageBox.Show("Record updated successfully\n" + rowsUpdated + " rows updated\n\n" + "Registration Number: " + regNumber + "\n"
                                    + "Student ID: " + sID + "\n"
                                    + "Student Name: " + sName + "\n" +
                                      "Father Name: " + fName + "\n" + "Admission Date: " + admissionDate + "\n"
                                     + "Program: " + program + "\n" + "Fees: " + amount.ToString() + "\n"
                                     + "Timing: " + timing + "\n" + "Teacher name: " + teacher + "\n"
                                     + "Duration: " + duration + "\n" + "Phone Number: " + phoneNumber);

                                }
                                else
                                {
                                    MessageBox.Show("Record updated successfully\n" + rows + " rows updated\n\n" + "Registration Number: " + regNumber + "\n"
                                    + "Student ID: " + sID + "\n"
                                    + "Student Name: " + sName + "\n" +
                                      "Father Name: " + fName + "\n" + "Admission Date: " + admissionDate + "\n"
                                     + "Program: " + program + "\n" + "Fees: " + amount.ToString() + "\n"
                                     + "Timing: " + timing + "Teacher name: " + teacher + "\n"
                                     + "\n" + "Duration: " + duration + "\n" + "Phone Number: " + phoneNumber);

                                }


                            }
                            else
                            {
                                MessageBox.Show("Error occured!!! Can't update student data","Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }

                            epFees.SetError(tbFees, "");
                            epPaid.SetError(tbPaid, "");
                            database.closeConn();

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
                    else
                    {
                        MessageBox.Show("Can't add record\nStudent name and father name is not in correct format", "Update record", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else
                {
                    try
                    {
                        if (int.Parse( tbStudentIDUpdate.Text.Trim()) < 1)
                        {
                            MessageBox.Show("Error!!!\nInvalid student ID\nID should not be below 0 or negative numbers", "Negative ID Error", MessageBoxButtons.OK, MessageBoxIcon.Information) ;
                            changeEPIconError(epIDUpdate);
                            epIDUpdate.SetError(tbStudentIDUpdate, "Invalid student ID\nID should not be below 0 or negative numbers");

                            tbStudentIDUpdate.Focus();
                            return;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error!!!\nInvalid student ID\nID contains letters or whitespaces", "Invalid ID Error", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                        changeEPIconError(epIDUpdate);
                        epIDUpdate.SetError(tbStudentIDUpdate, "Invalid student ID\nID contains letters or whitespaces");
                        return;
                    }
                  

                  
                }

                epIDUpdate.SetError(tbStudentIDUpdate, "");
                epFees.SetError(tbFees, "");
                epPaid.SetError(tbPaid, "");

                btnSearchRecord.PerformClick();
            }

        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
    
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                file.Multiselect = false;

                if (file.ShowDialog() == DialogResult.OK)
                {
                    pbStudentPicture.Image = Image.FromFile(file.FileName);
                    path = file.FileName;
                    image = Image.FromFile(path);
                    pbStudentPicture.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;
                }
                else
                {
                    path = "";
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {

            TakePictureForm f = new TakePictureForm();
            f.ShowDialog();

            if (TakePictureForm.isDoneClicked && (TakePictureForm.capturedImage != null || TakePictureForm.capturedImage != Resources.student))
            {
                pbStudentPicture.Image = TakePictureForm.capturedImage;
                image = Resources.student;
                path = "";
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            path = "";
            image = Resources.student;
            pbStudentPicture.Image = Resources.student;
            TakePictureForm.capturedImage = null;
            TakePictureForm.isDoneClicked = false;

        }

        private void rbStudentID_CheckedChanged(object sender, EventArgs e)
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

       
        private void tbStudentNameUpdate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbStudentNameUpdate.Text))
            {
                epNameUpdate.SetError(tbStudentNameUpdate, "Invalid Student name\nShould contain letters");
                return;
            }
            else epNameUpdate.SetError(tbStudentNameUpdate, "");
        }

        private void tbFees_TextChanged(object sender, EventArgs e)
        {
            try
            {
                amount = float.Parse(tbFees.Text.Trim());

            }
            catch (FormatException)
            {
                epFees.SetError(tbFees, "Enter program fees in correct format\nShould not contain letters");
                amount = 0.0f;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            epFees.SetError(tbFees, "");


            if (paid > amount)
            {
                float remainder = paid - amount;
                lblFeesError.Visible = true;
                lblFeesError.ForeColor = Color.LightBlue;
                lblFeesError.Text = "Give " + remainder.ToString() + " rupees to student";
            }
            else if (paid < amount)
            {
                float unpaid = amount - paid;
                lblFeesError.Visible = true;
                lblFeesError.ForeColor = Color.Red;
                lblFeesError.Text = "Student should pay " + unpaid.ToString() + " more";
            }
            else
            {
                lblFeesError.Visible = false;
                lblFeesError.ForeColor = Color.LightBlue;
            }
    
        }

        private void tbFatherName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFatherName.Text))
            {
                epFatherName.SetError(tbFatherName, "Invalid Student Father name\nShould contain letters");
                return;
            }
            else epFatherName.SetError(tbFatherName, "");
        }

        private void tbPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                paid = float.Parse(tbPaid.Text.Trim());
            }
            catch (FormatException)
            {
                epPaid.SetError(tbPaid, "Enter paid amount fees in correct format\nShould not contain letters");
                paid = 0.0f;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            epPaid.SetError(tbPaid, "");

            if (paid > amount)
            {
                float remainder = paid - amount;
                lblFeesError.Visible = true;
                lblFeesError.ForeColor = Color.LightBlue;
                lblFeesError.Text = "Give " + remainder.ToString() + " rupees to student";
            }
            else if (paid < amount)
            {
                float unpaid = amount - paid;
                lblFeesError.Visible = true;
                lblFeesError.ForeColor = Color.Red;
                lblFeesError.Text = "Student should pay " + unpaid.ToString() + " more";
            }
            else
            {
                lblFeesError.Visible = false;
                lblFeesError.ForeColor = Color.LightBlue;
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

        private void rbStudentName_CheckedChanged(object sender, EventArgs e)
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

 

        private void rbRegNumber_CheckedChanged(object sender, EventArgs e)
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

        private void tbStudentID_TextChanged(object sender, EventArgs e)
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

        private void tbStudentName_TextChanged(object sender, EventArgs e)
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

        private void tbRegistrationNumber_TextChanged(object sender, EventArgs e)
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

        private void UCUpdateRecords_SizeChanged(object sender, EventArgs e)
        {

            panelMatchedRecords.Width = this.Width - panelSearch.Width;
            panelMatchedRecords.Height = this.Height - panelControls.Height-15;
            dgvSearchedRecords.Width = panelMatchedRecords.Width;
            dgvSearchedRecords.Height = panelMatchedRecords.Height;
            panelControls.Width = this.Width - panelSearch.Width;
            panelControls.Location = new Point(panelSearch.Width, panelMatchedRecords.Height);
    
            // align buttons
            pbStudentPicture.Location = new Point(panelControls.Width - 130, pbStudentPicture.Location.Y);
            btnBrowse.Location = new Point(panelControls.Width - 125, btnBrowse.Location.Y);
            btnCapture.Location = new Point(panelControls.Width - 125, btnCapture.Location.Y);
            btnReset.Location = new Point(panelControls.Width - 125, btnReset.Location.Y);
            btnUpdateRecord.Location = new Point(panelControls.Width - 178, btnUpdateRecord.Location.Y);

        }

        private void clearControlsData()
        {
            tbRegNumberUpdate.Text = "";
            tbStudentIDUpdate.Text = "";
            tbStudentNameUpdate.Text = "";
            tbFatherName.Text = "";
            tbFees.Text = "";
            tbPaid.Text = "";
            tbDuration.Text = "";
            tbPhoneNumber.Text = "";
            tbCashier.Text = "";
            tbNotePrice.Text = "";
            tbStudentAddress.Text = "";
            tbNotePrice.Text = "";
            dtpAddmissionDate.Text = DateTime.UtcNow.ToLongDateString();
            cbPrograms.Items.Add("Windows 10");
            cbPrograms.SelectedIndex = 0;

            path = "";
            pbStudentPicture.Image = Resources.student;

            epFees.SetError(tbFees, "");
            epPaid.SetError(tbPaid, "");


        }


        private Boolean validateStudentID()
        {

            if (previousStudentID == tbStudentIDUpdate.Text.Trim())
            {
                changeEPIconTick(epIDUpdate);
                epIDUpdate.SetError(tbStudentIDUpdate, "Valid student ID");

                return true;
            }

            try
            {

                int mStudentID = int.Parse(tbStudentIDUpdate.Text.Trim());
                if (mStudentID < 1)
                {

                    changeEPIconError(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "Invalid student ID\nID should not be below 0 or negative numbers");

                    tbStudentIDUpdate.Focus();
                    return false;
                }
                return true;
               
            }
            catch (FormatException)
            {

                if ((string.IsNullOrWhiteSpace(tbStudentIDUpdate.Text)))
                {
                    changeEPIconTick(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "unassigned student ID\n" +
                                "This record will be added without student ID");

                    return true;
                }
                else
                {

                    changeEPIconError(epIDUpdate);
                    epIDUpdate.SetError(tbStudentIDUpdate, "Invalid student ID\nID contains letters or whitespace");

                    tbStudentIDUpdate.Focus();
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }
        }

        private Boolean validateStudentNameAndFatherName()
        {

            if (string.IsNullOrWhiteSpace(tbStudentNameUpdate.Text.Trim()))
            {
                epNameUpdate.SetError(tbStudentNameUpdate, "Invalid Student name\nShould contain whitespace");
                tbStudentNameUpdate.Focus();
                return false;
            }
            epNameUpdate.SetError(tbStudentNameUpdate, "");

            if (string.IsNullOrWhiteSpace(tbFatherName.Text.Trim()))
            {
                epFatherName.SetError(tbFatherName, "Invalid Student Father name\nShould contain letters");
                tbFatherName.Focus();
                return false;
            }

            epFatherName.SetError(tbFatherName, "");

            return true;
        }

        private void enableControls()
        {

            if (dgvSearchedRecords.Rows.Count > 0)
            {
                tbStudentIDUpdate.Enabled = true;
                tbStudentNameUpdate.Enabled = true;
                tbFatherName.Enabled = true;
                dtpAddmissionDate.Enabled = true;
                cbPrograms.Enabled = true;
                tbDuration.Enabled = true;
                tbTiming.Enabled = true;
                tbFees.Enabled = true;
                tbPaid.Enabled = true;
                tbTeacherName.Enabled = true;
                tbNotePrice.Enabled = true;
                tbCashier.Enabled = true;
                tbPhoneNumber.Enabled = true;
                tbStudentAddress.Enabled = true;
               
                btnBrowse.Enabled = true;
                btnCapture.Enabled = true;
                btnReset.Enabled = true;
                btnUpdateRecord.Enabled = true;
                lblFeesError.Visible = true;
            }
            else
            {
                tbStudentIDUpdate.Enabled = false;
                tbStudentNameUpdate.Enabled = false;
                tbFatherName.Enabled = false;
                dtpAddmissionDate.Enabled = false;
                cbPrograms.Enabled = false;
                tbDuration.Enabled = false;
                tbTiming.Enabled = false;
                tbFees.Enabled = false;
                tbPaid.Enabled = false;
                tbTeacherName.Enabled = false;
                tbNotePrice.Enabled = false;
                tbCashier.Enabled = false;
                tbPhoneNumber.Enabled = false;
                tbStudentAddress.Enabled = false;

                btnBrowse.Enabled = false;
                btnCapture.Enabled = false;
                btnReset.Enabled = false;
                btnUpdateRecord.Enabled = false;
                lblFeesError.Visible = false;
            }
        }

        public void changeEPIconError(ErrorProvider ep)
        {
            bitmapIcon = new Bitmap(Resources.epIcon);
            bitmapIcon.MakeTransparent(Color.White);
            System.IntPtr icH = bitmapIcon.GetHicon();
            icon = Icon.FromHandle(icH);
            ep.Icon = icon;
        }
        public void changeEPIconTick(ErrorProvider ep)
        {
            bitmapIcon = new Bitmap(Resources.epTickIcon);
            bitmapIcon.MakeTransparent(Color.White);
            System.IntPtr icH = bitmapIcon.GetHicon();
            icon = Icon.FromHandle(icH);
            ep.Icon = icon;
        }
        public void changeEPIconInformation(ErrorProvider ep)
        {
            bitmapIcon = new Bitmap(Resources.epIconInfo);
            bitmapIcon.MakeTransparent(Color.White);
            System.IntPtr icH = bitmapIcon.GetHicon();
            icon = Icon.FromHandle(icH);
            ep.Icon = icon;
        }

      
        private void setPrograms(System.Collections.Specialized.StringCollection programs)
        {
            foreach (string program in programs)
            {
                cbPrograms.Items.Add(program);
            }
           
        }

        private void modifyColumns()
        {

            if (Functions.areColumnNamesValid(dgvSearchedRecords))
            {
                // hide some columns 
 
                dgvSearchedRecords.Columns["duration"].Visible = false;
                dgvSearchedRecords.Columns["amount"].Visible = false;
                dgvSearchedRecords.Columns["paid"].Visible = false;
                dgvSearchedRecords.Columns["teacher"].Visible = false;
                dgvSearchedRecords.Columns["phoneNumber"].Visible = false;
                dgvSearchedRecords.Columns["cashier"].Visible = false;
                dgvSearchedRecords.Columns["notePrice"].Visible = false;
                dgvSearchedRecords.Columns["studentAddress"].Visible = false;
                dgvSearchedRecords.Columns["picture"].Visible = false;

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
            }
            else
            {
                MessageBox.Show("A column name inside access table has not a valid name\nRead the instruction" +
                         " for how to name columns in settings", "Column name error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
