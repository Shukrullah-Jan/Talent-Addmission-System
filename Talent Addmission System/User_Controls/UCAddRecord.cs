using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Talent_Addmission_System.Properties;


namespace Talent_Addmission_System.User_Controls
{

    public partial class UCAddRecord : UserControl
    {
        // database
        private DBAccess database;
        private Functions functions = new Functions();

        // variables
        private string regNumber, sID, sName, fName, admissionDate, program, duration,
            timing,teacher, phoneNumber, cashier, studentAddress, notePrice, courseAmount, paidAmount;

        // other variables
        private float amount, paid;
        private string printText = "";

        // variables related to student image
        private string path = "";
        private Image image;


        // icons
        Bitmap bitmapIcon;
        Icon icon;

     
        public UCAddRecord()
        {
            InitializeComponent();

            timePickerFrom.Format = DateTimePickerFormat.Custom;
            timePickerTo.Format = DateTimePickerFormat.Custom;
            timePickerFrom.CustomFormat = "hh:mm tt";
            timePickerTo.CustomFormat = "hh:mm tt";
            timePickerFrom.ShowUpDown = true;
            timePickerTo.ShowUpDown = true;

            chbMoreDetails.Checked = false;
            panelMoreDetails.Visible = false;
            rbNewStudent.Checked = true;
      
        }

        private void UCAddRecord_Load(object sender, EventArgs e)
        {
            panelAddStudent.Width = this.Width;
            panelMoreDetails.Width = this.Width;
            pbStudentPicture.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnBrowse.Anchor = AnchorStyles.Right | AnchorStyles.Top; ;
            btnCapture.Anchor = AnchorStyles.Right | AnchorStyles.Top; ;
            btnClear.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnAddRecord.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnPrint.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnReset.Anchor = AnchorStyles.Right | AnchorStyles.Top;

            // set current date for dtp
            dtpAddmissionDate.Text = DateTime.Now.ToLongDateString();

            // set programs list
            System.Collections.Specialized.StringCollection programs = (System.Collections.Specialized.StringCollection)Settings.Default["programsList"];
            setPrograms(programs);

            // set error providers icons
            setIcons();

            // validate timing
            validateTiming();

            // database related code
            database = new DBAccess(Dashboard.dataSourcePath);

            // check new and old student
            tbRegistrationNumber.Enabled = false;
            tbRegistrationNumber.Text = functions.getNewRegistrationNumber().ToString();

            if (rbNewStudent.Checked)
            {
                tbStudentID.Enabled = false;
                tbStudentID.Text = functions.getNewStudentID().ToString();
                tbStudentName.Focus();

            }
            if (rbOldStudent.Checked)
            {
                tbStudentID.Text = functions.getNewStudentID().ToString();
                tbStudentID.Enabled = true;

            }

            epSID.SetError(tbStudentID, "");

        }

      
        private void tbStudentID_TextChanged(object sender, EventArgs e)
        {
            // Note: check whether rb unknown student id is checked or not
            try
            {

                int oldID = int.Parse(tbStudentID.Text.Trim());
                int result = functions.checkStudentIDInDatabase(oldID);

                if (oldID < 1)
                {
                    changeEPIconError(epSID);
                    epSID.SetError(tbStudentID, "Invalid student ID\nID should not be below 0 or negative numbers");

                    tbStudentID.Focus();
                    return;
                }

                if (rbUnkownStudentID.Checked)
                {
                    if (result == -1)
                    {
                        changeEPIconTick(epSID);

                        epSID.SetError(tbStudentID, "Valid Student ID");
                        tbStudentName.Text = "";
                        tbFatherName.Text = "";
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                        
                    }
                    else if (string.IsNullOrWhiteSpace(tbStudentID.Text)){
                        changeEPIconTick(epSID);


                        epSID.SetError(tbStudentID, "unassigned student ID\nThis record will be added without an ID");
                        tbStudentName.Text = "";
                        tbFatherName.Text = "";
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                    }
                    else
                    {
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid Student ID\nThis ID already exists in the database");
                        DataTable dtStudentData = new DataTable();
                        string query = "Select * from " + Dashboard.accessTableName + " Where studentID = '" + oldID.ToString() + "'";

                        database.readDatathroughAdapter(query, dtStudentData);

                        if (dtStudentData.Rows.Count > 0)
                        {
                            if (dtStudentData.Rows[0]["studentName"].ToString().Equals(""))
                            {
                                tbStudentName.Text = "Unknown";
                            }
                            else
                            {
                                tbStudentName.Text = dtStudentData.Rows[0]["studentName"].ToString();
                            }
                            if (dtStudentData.Rows[0]["fatherName"].ToString().Equals(""))
                            {
                                tbFatherName.Text = "Unknown";
                            }
                            else
                            {
                                tbFatherName.Text = dtStudentData.Rows[0]["fatherName"].ToString();
                            }


                        }
                    }

                }

                else if (rbOldStudent.Checked)
                {
                    if (result == -1)
                    {
                        changeEPIconError(epSID);

                        epSID.SetError(tbStudentID, "Invalid Student ID\n" +
                            "Old student IDs should be inside database\ntry a different student ID");
                        tbStudentName.Text = "";
                        tbFatherName.Text = "";
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                        return;
                    }
                    else
                    {
                        // epSID icon
                        changeEPIconTick(epSID);
                        epSID.SetError(tbStudentID, "Valid ID");
                        DataTable dtStudentData = new DataTable();
                        string query = "Select * from " + Dashboard.accessTableName + " Where studentID = '" + oldID.ToString() + "'";

                        database.readDatathroughAdapter(query, dtStudentData);

                        if (dtStudentData.Rows.Count > 0)
                        {
                            if (dtStudentData.Rows[0]["studentName"].ToString().Equals(""))
                            {
                                tbStudentName.Text = "Unknown";
                            }
                            else
                            {
                                tbStudentName.Text = dtStudentData.Rows[0]["studentName"].ToString();
                            }
                            if (dtStudentData.Rows[0]["fatherName"].ToString().Equals(""))
                            {
                                tbFatherName.Text = "Unknown";
                            }
                            else
                            {
                                tbFatherName.Text = dtStudentData.Rows[0]["fatherName"].ToString();
                            }

                        }

                    }

                }  
            }
            catch (FormatException)
            {
                if (rbUnkownStudentID.Checked)
                {
                    if ((string.IsNullOrEmpty(tbStudentID.Text.Trim())))
                    {
                        changeEPIconTick(epSID);
                        epSID.SetError(tbStudentID, "unassigned student ID\n" +
                                   "This record will be added without an ID");

                        tbStudentName.Text = "";
                        tbFatherName.Text = "";
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                      
                    }
                    else
                    {
                        // epSID icon
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid Student ID\n" +
                                   "Unknown student ID should not contain letters");

                        tbStudentName.Text = "";
                        tbFatherName.Text = "";
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                        return;
                    }
                }
                else
                {

                    // epSID icon
                    changeEPIconError(epSID);
                    epSID.SetError(tbStudentID, "Invalid Student ID\n" +
                               "Student ID should not contain letters or whitespace");

                    tbStudentName.Text = "";
                    tbFatherName.Text = "";
                    epName.SetError(tbStudentName, "");
                    epFatherName.SetError(tbFatherName, "");

                    return;
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
                epName.SetError(tbStudentName, "Invalid Student name\nShould contain letters");
                return;
            }
            else epName.SetError(tbStudentName, "");

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

        private void tbFees_TextChanged_1(object sender, EventArgs e)
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

        private void timePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = timePickerFrom.Value;
            timePickerTo.Value = dt.AddHours(1);
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
            else
            {
                // reset previous pictures
                if (image != Resources.student && image != null)
                {
                    pbStudentPicture.Image = image;
                   
                }
                else
                {
                    pbStudentPicture.Image = Resources.student;
                    image = Resources.student;
                    path = "";
                }
               
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            path = "";
            image = Resources.student;
            pbStudentPicture.Image = Resources.student;
            TakePictureForm.capturedImage = null;
            TakePictureForm.isDoneClicked = false;
       
        }

        private void rbNewStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNewStudent.Checked)
            {
                tbRegistrationNumber.Enabled = false;
                tbRegistrationNumber.Text = functions.getNewRegistrationNumber().ToString();
                tbStudentID.Enabled = false;
                tbStudentID.Text = functions.getNewStudentID().ToString();
                epSID.SetError(tbStudentID, "");
          
            }
        }

        private void rbOldStudent_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbOldStudent.Checked)
            {
                
                tbStudentID.Enabled = true;

                try
                {
                    int oldID = int.Parse(tbStudentID.Text.Trim());
                    int result = functions.checkStudentIDInDatabase(oldID);


                    if (oldID < 1)
                    {
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid student ID\nID should not be below 0 or negative numbers");

                        tbStudentID.Focus();
                        return;
                    }

                    if (!(result == -1))
                    {
                        changeEPIconTick(epSID);

                        epSID.SetError(tbStudentID, "Valid Student ID");
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
             
                    }
                    else
                    {
                        // epSID icon
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid Student ID\nID does not exists in database");
                    
                    }

                }
                catch (FormatException)
                {
                    // epSID icon

                    changeEPIconError(epSID);
                    epSID.SetError(tbStudentID, "Invalid Student ID\n" +
                                "Student ID should not contain letters");

                    tbStudentName.Text = "";
                    tbFatherName.Text = "";
                    epName.SetError(tbStudentName, "");
                    epFatherName.SetError(tbFatherName, "");

           
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                  
                    return;

                }
          
                
           
            }
        }

        private void chbUnkownStudentID_CheckedChanged(object sender, EventArgs e)
        {

            if (rbUnkownStudentID.Checked)
            {
                tbStudentID.Enabled = true;

                try
                {
                    int oldID = int.Parse(tbStudentID.Text.Trim());
                    int result = functions.checkStudentIDInDatabase(oldID);


                    if (oldID < 1)
                    {
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid student ID\nID should not be below 0 or negative numbers");

                        tbStudentID.Focus();
                        return;
                    }

                    if (result == -1)
                    {
                        changeEPIconTick(epSID);

                        epSID.SetError(tbStudentID, "Valid Student ID");
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
       
                    }
                    else if (result > 0)
                    {
                        // epSID icon
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid Student ID\nID exists in Database");
                        DataTable dtStudentData = new DataTable();
                        string query = "Select * from " + Dashboard.accessTableName + " Where studentID = '" + oldID.ToString() + "'";

                        database.readDatathroughAdapter(query, dtStudentData);

                        if (dtStudentData.Rows.Count > 0)
                        {
                            if (dtStudentData.Rows[0]["studentName"].ToString().Equals(""))
                            {
                                tbStudentName.Text = "Unknown";
                            }
                            else
                            {
                                tbStudentName.Text = dtStudentData.Rows[0]["studentName"].ToString();
                            }
                            if (dtStudentData.Rows[0]["fatherName"].ToString().Equals(""))
                            {
                                tbFatherName.Text = "Unknown";
                            }
                            else
                            {
                                tbFatherName.Text = dtStudentData.Rows[0]["fatherName"].ToString();
                            }


                        }
                    }
                    else
                    {
                        changeEPIconError(epSID);

                        epSID.SetError(tbStudentID, "Invalid Student ID\nID contains letters");
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                    }

                }
                catch (FormatException)
                {
                    // epSID icon

                    if ((string.IsNullOrEmpty(tbStudentID.Text.Trim())))
                    {
                        changeEPIconTick(epSID);
                        epSID.SetError(tbStudentID, "Valid Student ID\n" +
                                   "This record will be inserted without an ID");

                        tbStudentName.Text = "";
                        tbFatherName.Text = "";
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                    
                    }
                    else
                    {
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid Student ID\n" +
                                   "Unknown student ID should not contain letters");

                        tbStudentName.Text = "";
                        tbFatherName.Text = "";
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;

                }

            }
            else
            {
                tbStudentID.Enabled = false;
            }
        }


        private void chbMoreDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMoreDetails.Checked)  panelMoreDetails.Visible = true;
            else panelMoreDetails.Visible = false ;
        }



        private void btnAddRecord_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to add record to database?", "Add new record", MessageBoxButtons.YesNo);
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

                

                regNumber = tbRegistrationNumber.Text.Trim();
                sID = tbStudentID.Text.Trim();
                sName = tbStudentName.Text.Trim();
                fName = tbFatherName.Text.Trim();
                admissionDate = dtpAddmissionDate.Text.Trim();
                program = cbPrograms.Text.Trim();
                duration = tbDuration.Text.Trim();
                timing = timePickerFrom.Text.Trim() + " To " + timePickerTo.Text.Trim();
                duration = tbDuration.Text.Trim();
                teacher = tbTeacherName.Text.Trim();
                phoneNumber = tbPhoneNumber.Text.Trim();
                cashier = tbCashier.Text.Trim();
                studentAddress = tbStudentAddress.Text.Trim();
                notePrice = tbNotePrice.Text.Trim();
                courseAmount = tbFees.Text.Trim();
                paidAmount = tbPaid.Text.Trim();


                // validation
                if (validateStudentID())
                {
                   
                    if (validateStudentNameAndFatherName())
                    {

                        // validate fees, paid and noteprice controls
                        try
                        {
                            float.Parse(tbFees.Text.Trim());
                        }
                        catch (FormatException)
                        {
                            courseAmount = "0";
                        }
                        try
                        {
                            float.Parse(tbPaid.Text.Trim());
                        }
                        catch (FormatException)
                        {
                            paidAmount = "0";
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
                                        imagePath = Path.Combine(imgLocation, tbStudentName.Text.Trim() + rand.Next(2000) + imageName + ".jpg");

                                        // save image to particular folder
                                        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }

                                }
                                else if (TakePictureForm.isDoneClicked && TakePictureForm.capturedImage != null)
                                {
                                    if (!(pbStudentPicture.Image.Equals(Resources.student)))
                                    {
                                        imagePath = Path.Combine(imgLocation, tbStudentName.Text.Trim() + rand.Next(2000) + ".jpg");
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
                                        imagePath = Path.Combine(imgLocation, tbStudentName.Text.Trim() + rand.Next(2000) + imageName + ".jpg") ;

                                        // save image to particular folder
                                        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }

                                }
                                else if (TakePictureForm.isDoneClicked && TakePictureForm.capturedImage != null)
                                {
                                    if (!(pbStudentPicture.Image.Equals(Resources.student)))
                                    {
                                        imagePath = Path.Combine(imgLocation, tbStudentName.Text.Trim() + rand.Next(2000) + ".jpg");
                                        image = TakePictureForm.capturedImage;
                                        image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }
                                }

                            }

                            string query = "Insert into "+ Dashboard.accessTableName + " (studentName, fatherName, studentID, admissionDate," +
                                "program, duration, timing, amount, paid, teacher, phoneNumber, cashier, notePrice, studentAddress, picture) " +
                                "values (@sName, @fName, @sID, @admissionDate, @program, @duration, @timing, @courseAmount, @paidAmount, @teacher, @phoneNumber, @cashier, @notePrice, @studentAddress, @imagePath)";
                            OleDbCommand command = new OleDbCommand(query);

                            command.Parameters.AddWithValue("@studentName", sName);
                            command.Parameters.AddWithValue("@fatherName", fName);
                            command.Parameters.AddWithValue("@studentID", sID);
                            command.Parameters.AddWithValue("@addmissionDate", admissionDate);
                            command.Parameters.AddWithValue("@program", program);
                            command.Parameters.AddWithValue("@duration", duration);
                            command.Parameters.AddWithValue("@timing", timing);
                            command.Parameters.AddWithValue("@amount", courseAmount);
                            command.Parameters.AddWithValue("@paid", paidAmount);
                            command.Parameters.AddWithValue("@teacher", teacher);
                            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                            command.Parameters.AddWithValue("@cashier", cashier);
                            command.Parameters.AddWithValue("@notePrice", notePrice);
                            command.Parameters.AddWithValue("@studentAddress", studentAddress);
                            command.Parameters.AddWithValue("@picture", imagePath);

                            try
                            {
                                database.executeQuery(command);
                                MessageBox.Show("Record added successfully\n" + "Registration Number: " + regNumber + "\n"
                                 + "Student ID: " + sID + "\n"
                                  + "Student Name: " + sName + "\n" +
                                 "Father Name: " + fName + "\n" + "Addmission Date: " + admissionDate + "\n"
                                  + "Program: " + program + "\n" + "Fees: " + courseAmount + "\n"
                                 + "Timing: " + timing + "\nTeacher: " + teacher + "\n"
                                 + "Duration: " + duration + "\n" + "Phone Number: " + phoneNumber);

                                // reset some controls
                                tbStudentID.Text = functions.getNewStudentID().ToString();
                                tbRegistrationNumber.Text = functions.getNewRegistrationNumber().ToString();
                                tbStudentName.Text = "";
                                tbFatherName.Text = "";
                                cbPrograms.SelectedIndex = 0;
                                tbFees.Text = "";
                                tbPaid.Text = "";
                                epSID.SetError(tbStudentID, "");
                                epName.SetError(tbStudentName, "");
                                epFatherName.SetError(tbFatherName, "");
                                epFees.SetError(tbFees, "");
                                epPaid.SetError(tbPaid, "");
                                // clear picture box picture and path of the image
                                path = "";
                                image = Resources.student;
                                pbStudentPicture.Image = Resources.student;
                                TakePictureForm.isDoneClicked = false;
                            }
                            catch (OleDbException ex)
                            {
                                MessageBox.Show("Error!!! Can't insert record to database\n" + ex.Message);

                                return;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                return;
                            }

                       
                            lblFeesError.Visible = false;
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
                        MessageBox.Show("Can't add record\nStudent name and father name is not in correct format", "Unsaved record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
                else
                {

                    try
                    {
                        if (int.Parse(tbStudentID.Text.Trim()) < 1)
                        {
                           
                            changeEPIconError(epSID);
                            epSID.SetError(tbStudentID, "Invalid student ID\nID should not be below 0 or negative numbers");
                            tbStudentID.Focus();
                            return;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error!!!\nInvalid student ID\nID should not contain letters","Invalid Student ID Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        epSID.SetError(tbStudentID, "Invalid student ID\nID should not contain letters");
                        return;
                    }
                  
                }
               
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            regNumber = tbRegistrationNumber.Text.Trim();
            sID = tbStudentID.Text.Trim();
            sName = tbStudentName.Text.Trim();
            fName = tbFatherName.Text.Trim();
            admissionDate = dtpAddmissionDate.Text.Trim();
            program = cbPrograms.Text.Trim();
            duration = tbDuration.Text.Trim();
            timing = timePickerFrom.Text.Trim() + " To " + timePickerTo.Text.Trim();
            duration = tbDuration.Text.Trim();
            phoneNumber = tbPhoneNumber.Text.Trim();
            cashier = tbCashier.Text.Trim();
            studentAddress = tbStudentAddress.Text.Trim();
            notePrice = tbNotePrice.Text.Trim();
            courseAmount = tbFees.Text.Trim();
            paidAmount = tbPaid.Text.Trim();

            // validation
            if (validateStudentID())
            {
              
                if (validateStudentNameAndFatherName())
                {
                    regNumber = tbRegistrationNumber.Text.Trim();
                    sID = tbStudentID.Text.Trim();
                    sName = tbStudentName.Text.Trim();
                    fName = tbFatherName.Text.Trim();
                    admissionDate = dtpAddmissionDate.Text.Trim();
                    program = cbPrograms.Text.Trim();
                    duration = tbDuration.Text.Trim();
                    timing = timePickerFrom.Text.Trim() + " To " + timePickerTo.Text.Trim();
                    duration = tbDuration.Text.Trim();
                    phoneNumber = tbPhoneNumber.Text.Trim();
                    cashier = tbCashier.Text.Trim();
                    studentAddress = tbStudentAddress.Text.Trim();
                    notePrice = tbNotePrice.Text.Trim();
                    courseAmount = tbFees.Text.Trim();
                    paidAmount = tbPaid.Text.Trim();

                    setPrintText();

                    printPreviewDialog1.Document = printDocument1;
                    // this line of code works perfectly for thermal printer
                    // to convert hundreths of an inch to mm multiply it by 0.254
                    printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Reciept", 300, 600);
                    printPreviewDialog1.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Can not add record\nMake sure you entered the details correctly", "Unsaved record", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else
            {
                return;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image i = Resources.B___W_Monogram;

            e.Graphics.DrawImage(i, 10, 14,70,70);
            e.Graphics.DrawString("\tTalent\nInstitute Of Computer Science", new Font("Cambria", 11, FontStyle.Bold), Brushes.Black, new Point(70, 30));
            e.Graphics.DrawString("---------------------------------------------------------------------------", new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black ,new Point(10, 72));
            e.Graphics.DrawString("---------------------------------------------------------------------------", new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black ,new Point(10, 77));
            e.Graphics.DrawString("\tADMISSION RECEIPT", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(10, 88));
          
            e.Graphics.DrawString(printText, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), Brushes.Black, new Point(10,102));
            e.Graphics.DrawString("  Software Designed By Shukrullah Askari 03362073245", new Font("Microsoft Sans Serif", 7, FontStyle.Regular), Brushes.Black, new Point(10,472));

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clearControlsData();
        }

        private void UCAddRecord_SizeChanged(object sender, EventArgs e)
        {
            panelAddStudent.Width = this.Width;
            panelMoreDetails.Width = this.Width;
            pbStudentPicture.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnBrowse.Anchor = AnchorStyles.Right | AnchorStyles.Top; ;
            btnCapture.Anchor = AnchorStyles.Right | AnchorStyles.Top; ;
            btnClear.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnAddRecord.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnPrint.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnReset.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }


        private void validateTiming()
        {
            DateTime dt = timePickerFrom.Value;

            timePickerTo.Value = dt.AddHours(1);

        }
        private void clearControlsData()
        {
            tbStudentName.Text = "";
            tbFatherName.Text = "";
            tbFees.Text = "";
            tbPaid.Text = "";
            tbDuration.Text = "";
            tbPhoneNumber.Text = "";
            tbTeacherName.Text = "";
            tbCashier.Text = "";
            tbNotePrice.Text = "";
            tbStudentAddress.Text = "";
            tbNotePrice.Text = "";
            dtpAddmissionDate.Text = DateTime.UtcNow.ToLongDateString();
            cbPrograms.SelectedIndex = 0;
            lblFeesError.Text = "";
            path = "";
            pbStudentPicture.Image = Properties.Resources.student;

            epName.SetError(tbStudentName, "");
            epFatherName.SetError(tbFatherName, "");
            epFees.SetError(tbFees, "");
            epPaid.SetError(tbPaid, "");

            tbStudentID.Text = functions.getNewStudentID().ToString();
            tbRegistrationNumber.Text = functions.getNewRegistrationNumber().ToString();
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
        private void setIcons()
        {
            bitmapIcon = new Bitmap(Resources.epIcon);
            bitmapIcon.MakeTransparent(Color.White);
            System.IntPtr icH = bitmapIcon.GetHicon();
            icon = Icon.FromHandle(icH);


            epFees.Icon = icon;
            epFatherName.Icon = icon;
            epSID.Icon = icon;
            epName.Icon = icon;
            epPaid.Icon = icon;


        }
        private Boolean validateStudentID()
        {
     
            try
            {
                if (rbUnkownStudentID.Checked)
                {
                    int oldStudentId = int.Parse(sID.Trim());
                    int result = functions.checkStudentIDInDatabase(oldStudentId);

                    if (oldStudentId < 1)
                    {
                        MessageBox.Show("Error!!!\nInvalid student ID\nID should not be below 0 or negative numbers", "Unsaved Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid student ID\nID should not be below 0 or negative numbers");

                        tbStudentID.Focus();
                        return false;
                    }
                    if (result == -1) return true;
                    else
                    { 
                       
                        MessageBox.Show("Error!!!\nCan't add record\nID you have entered" +
                            " exists inside the database", "ID exists");
                        return false;
                    }
                    
                }
                else if (rbOldStudent.Checked)
                {
                    int oldStudentId = int.Parse(sID.Trim());
                    int result = functions.checkStudentIDInDatabase(oldStudentId);

                    if (oldStudentId < 1)
                    {
                        MessageBox.Show("Error!!!\nInvalid student ID\nID should not be below 0 or negative numbers", "Unsaved Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid student ID\nID should not be below 0 or negative numbers");

                        tbStudentID.Focus();
                        return false;
                    }

                    if (result == -1) {
                        MessageBox.Show("Error: Can't insert record\nStudent ID you have entered is not in database\ntry a" +
                            " student ID that should be in the database", "Unsaved Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Error!!!\nStudent ID you have entered is not in database\ntry a student ID that should be in the database");
                        return false;
                    } 
                    else
                    {
                      
                        return true;
                    }
                }
            }
            catch (FormatException)
            {
                if (rbUnkownStudentID.Checked)
                {
                    if ((string.IsNullOrEmpty(tbStudentID.Text.Trim())))
                    {
                        changeEPIconTick(epSID);
                        epSID.SetError(tbStudentID, "unassigned student ID\n" +
                                   "This record will be added without an ID");

                        
                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                        return true;

                    }
                    else
                    {
                        // epSID icon
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Invalid Student ID\n" +
                                   "Unknown student ID should not contain letters");

                        epName.SetError(tbStudentName, "");
                        epFatherName.SetError(tbFatherName, "");
                     
                        changeEPIconError(epSID);
                        epSID.SetError(tbStudentID, "Unknown student ID you have entered contains letters");

                        return false;
                    }
                }
                else
                {
                    epSID.SetError(tbStudentID, "Invalid Student ID\nshould not contain letters or whitespace");

                    return false;
                }
           
           
            }
            catch (Exception)
            {
                return false;

            }
            epSID.SetError(tbStudentID, "");
            return true;
        }

        private Boolean validateStudentNameAndFatherName()
        {

            if (string.IsNullOrWhiteSpace(sName))
            {
                epName.SetError(tbStudentName, "Invalid Student name\nShould contain letters");
                tbStudentName.Focus();
                return false;
            }
            epName.SetError(tbStudentName, "");
     

            if (string.IsNullOrWhiteSpace(fName))
            {
                epFatherName.SetError(tbFatherName, "Invalid Student Father name\nShould contain letters");
                tbFatherName.Focus();
                return false;
            }

            epFatherName.SetError(tbFatherName, "");

          
            return true;
        }


        private void setPrograms(System.Collections.Specialized.StringCollection programs)
        {
            foreach (string program in programs)
            {
                cbPrograms.Items.Add(program);
            }
            cbPrograms.SelectedIndex = 0;
        }

        private void setPrintText()
        {
            float unpaid = 0.0F, remainder = 0.0F;

            if (amount > paid) unpaid = amount - paid;
            if (paid > amount) remainder = paid - amount;

            printText = "";
            printText = "---------------------------------------------------------------------------\n";
            printText += "Reg.No:\t\t    " + regNumber + "\n\n";
            printText += "Student ID:\t    " + sID + "\n\n";
            printText += "Student Name:\t    " + sName + "\n\n";
            printText += "Father Name:\t    " + fName + "\n\n";
            printText += "Program/Package:   " + program + "\n\n";
            printText += "Admission Date:\t    " + admissionDate + "\n\n";
            printText += "Timing:\t\t    " + timing + "\n\n";
            printText += "Fees:\t\t    " + amount.ToString() + "\n\n";
            printText += "Paid:\t\t    " + paid.ToString() + "\n\n";
            printText += "Unpaid:\t\t    " + unpaid.ToString() + "\n\n";
            printText += "Remainder:\t    " + remainder.ToString() + "\n";
            printText += "---------------------------------------------------------------------------\n";
            printText += "---------------------------------------------------------------------------\n";
            printText += "Contact Details:" + "\n";
            printText += "Phone#:   " + Settings.Default["contactNumber"].ToString() + "\n\n";
            printText += "Address: " + Settings.Default["courseAddress"].ToString();
            printText += "\n---------------------------------------------------------------------------\n";
          
        }
    }
}
