using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Talent_Addmission_System.User_Controls;

namespace Talent_Addmission_System
{
    public partial class DisplayRecordForm : Form
    {
        private DBAccess database = new DBAccess(Dashboard.dataSourcePath);

        public static int studentRegNumberToPass = -1;
        public static Boolean btnDeleteClicked = false;
        public static int formWidth = -1;
        public static int formHeight = -1;

        // get open forms
        private FormCollection fc = Application.OpenForms;
        private Dashboard dashboard = new Dashboard();

        private Boolean isDashboardOpen = false;
        private Boolean pbStudentClicked = false;

        public DisplayRecordForm()
        {
            InitializeComponent();

            pbStudentPicture.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Normal;

        }

        private void DisplayRecordForm_Load(object sender, EventArgs e)
        {

            DataTable dtStudentIDs = new DataTable();
            Image studentPicture = Properties.Resources.student;
            string query = "";

            if (UCHome.UCHomeState)
            {
                if (UCHome.studentID >= 0)
                {
                    // checks if student ID is not empty
                    if (UCHome.studentID == 0)
                    {
                        int regNum = -1;
                        try
                        {
                            regNum = int.Parse(UCHome.regNumber);
                            studentRegNumberToPass = regNum;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error!!!\nStudent has not a valid student ID and Registration number\nStudent Registration number is not in correct format");
                            return;
                        }

                        // query using student registration number
                        query = "Select * from " + Dashboard.accessTableName + " Where ID = " + regNum;

                        try
                        {
                            database.readDatathroughAdapter(query, dtStudentIDs);
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read " + Dashboard.accessTableName + " data \n" + ex.Message);
                            return;

                        }

                        try
                        {
                            if (dtStudentIDs.Rows.Count > 0)
                            {
                               
                                lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["ID"].ToString();
                                lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentID"].ToString();
                                lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentName"].ToString();
                                lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["fatherName"].ToString();
                                lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["admissionDate"].ToString();
                                // programs 
                                cbPrograms.Items.Add(dtStudentIDs.Rows[0]["program"].ToString());
                                cbPrograms.SelectedIndex = 0;

                                lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["duration"].ToString();
                                lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["timing"].ToString();
                                lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["amount"].ToString();
                                lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["paid"].ToString();
                                lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["phoneNumber"].ToString();
                                lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["cashier"].ToString();
                                lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["notePrice"].ToString();
                                lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentAddress"].ToString();

                                try
                                {
                                    studentPicture = Image.FromFile(dtStudentIDs.Rows[0]["picture"].ToString());
                                    pbStudentPicture.Image = studentPicture;
                                 
                                }
                                catch (FileNotFoundException)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                    
                                }
                                catch (Exception)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                }
                            }
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read data through database\n" + ex.Message);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }

                    else
                    {

                        try
                        {
                            query = "Select * From " + Dashboard.accessTableName + " Where studentID = " + "'" + UCHome.studentID.ToString() + "'";
                            database.readDatathroughAdapter(query, dtStudentIDs);
                      
                            if (dtStudentIDs.Rows.Count > 0)
                            {
                                for (int index = 0; index < dtStudentIDs.Rows.Count; index++)
                                {
                                    if (dtStudentIDs.Rows[index]["ID"].ToString() == UCHome.regNumber)
                                    {
    
                                        studentRegNumberToPass = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? -1 : int.Parse(dtStudentIDs.Rows[index]["ID"].ToString());

                                        lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["ID"].ToString();
                                        lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentID"].ToString();
                                        lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentName"].ToString();
                                        lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["fatherName"].ToString();
                                        lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["admissionDate"].ToString();

                                        lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["duration"].ToString();
                                        lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["timing"].ToString();
                                        lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["amount"].ToString();
                                        lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["paid"].ToString();
                                        lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                        lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["phoneNumber"].ToString();
                                        lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["cashier"].ToString();
                                        lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["notePrice"].ToString();
                                        lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentAddress"].ToString();

                                    }
                                    // programs 
                                    cbPrograms.Items.Add(dtStudentIDs.Rows[index]["program"].ToString());


                                    try
                                    {
                                        if (File.Exists(dtStudentIDs.Rows[index]["picture"].ToString()))
                                        {
                                            studentPicture = Image.FromFile(dtStudentIDs.Rows[index]["picture"].ToString());
                                            pbStudentPicture.Image = studentPicture;
                                           
                                        }

                                    }
                                    catch (FileNotFoundException)
                                    {
                                        pbStudentPicture.Image = Properties.Resources.student;
                                       
                                    }
                                    catch (Exception)
                                    {

                                        pbStudentPicture.Image = Properties.Resources.student;
                                    }

                                }
                                cbPrograms.Text = UCHome.program;

                            }

                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read data through database\n" + ex.Message);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }

                }
                else if (UCHome.studentID == -1)
                {
                    int regNum = -1;
                    try
                    {

                        regNum = int.Parse(UCHome.regNumber);
                        studentRegNumberToPass = regNum;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error!!!\nStudent has not a valid student ID and Registration number\nStudent Registration number is not in correct format");
                        return;
                    }

                    // query using student registration number
                    query = "Select * from " + Dashboard.accessTableName + " Where ID = " + regNum;

                    try
                    {
                        database.readDatathroughAdapter(query, dtStudentIDs);
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read " + Dashboard.accessTableName + " data \n" + ex.Message);
                        return;

                    }

                    try
                    {
                        if (dtStudentIDs.Rows.Count > 0)
                        {
                            // power of ternary operator
                            lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["ID"].ToString();
                            lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentID"].ToString();
                            lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentName"].ToString();
                            lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["fatherName"].ToString();
                            lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["admissionDate"].ToString();
                            // programs 
                            cbPrograms.Items.Add(dtStudentIDs.Rows[0]["program"].ToString());
                            cbPrograms.SelectedIndex = 0;

                            lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["duration"].ToString();
                            lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["timing"].ToString();
                            lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["amount"].ToString();
                            lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["paid"].ToString();
                            lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                            lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["phoneNumber"].ToString();
                            lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["cashier"].ToString();
                            lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["notePrice"].ToString();
                            lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentAddress"].ToString();


                            try
                            {
                                studentPicture = Image.FromFile(dtStudentIDs.Rows[0]["picture"].ToString());
                                pbStudentPicture.Image = studentPicture;
                              
                            }
                            catch (FileNotFoundException)
                            {
                                pbStudentPicture.Image = Properties.Resources.student;
                      
                            }
                            catch (Exception)
                            {
                                pbStudentPicture.Image = Properties.Resources.student;
                            }
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read data through database\n" + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (UCSearchRecords.UCSearchRecordState)
            {
                if (UCSearchRecords.studentID >= 0)
                {
                    // checks if student ID is not empty
                    if (UCSearchRecords.studentID == 0)
                    {
                        int regNum = -1;
                        try
                        {
                            regNum = int.Parse(UCSearchRecords.regNumber);
                            studentRegNumberToPass = regNum;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error!!!\nStudent has not a valid student ID and Registration number\nStudent Registration number is not in correct format");
                            return;
                        }

                        // query using student registration number
                        query = "Select * from " + Dashboard.accessTableName + " Where ID = " + regNum;

                        try
                        {
                            database.readDatathroughAdapter(query, dtStudentIDs);
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read " + Dashboard.accessTableName + " data \n" + ex.Message);
                            return;

                        }

                        try
                        {
                            if (dtStudentIDs.Rows.Count > 0)
                            {
                                // power of ternary operator
                                lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["ID"].ToString();
                                lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentID"].ToString();
                                lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentName"].ToString();
                                lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["fatherName"].ToString();
                                lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["admissionDate"].ToString();
                                // programs 
                                cbPrograms.Items.Add(dtStudentIDs.Rows[0]["program"].ToString());
                                cbPrograms.SelectedIndex = 0;

                                lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["duration"].ToString();
                                lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["timing"].ToString();
                                lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["amount"].ToString();
                                lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["paid"].ToString();
                                lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["phoneNumber"].ToString();
                                lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["cashier"].ToString();
                                lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["notePrice"].ToString();
                                lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentAddress"].ToString();

                                try
                                {
                                    studentPicture = Image.FromFile(dtStudentIDs.Rows[0]["picture"].ToString());
                                    pbStudentPicture.Image = studentPicture;
                                   
                                }
                                catch (FileNotFoundException)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                  
                                }
                                catch (Exception)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                }
                            }
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read data through database\n" + ex.Message);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }

                    else
                    {

                        try
                        {
                            query = "Select * From " + Dashboard.accessTableName + " Where studentID = " + "'" + UCSearchRecords.studentID.ToString() + "'";
                            database.readDatathroughAdapter(query, dtStudentIDs);

                            if (dtStudentIDs.Rows.Count > 0)
                            {
                                for (int index = 0; index < dtStudentIDs.Rows.Count; index++)
                                {
                                    studentRegNumberToPass = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? -1 : int.Parse(dtStudentIDs.Rows[index]["ID"].ToString());
                                    lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["ID"].ToString();
                                    lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentID"].ToString();
                                    lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentName"].ToString();
                                    lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["fatherName"].ToString();
                                    lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["admissionDate"].ToString();
                                    // programs 
                                    cbPrograms.Items.Add(dtStudentIDs.Rows[index]["program"].ToString());


                                    lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["duration"].ToString();
                                    lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["timing"].ToString();
                                    lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["amount"].ToString();
                                    lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["paid"].ToString();
                                    lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                    lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["phoneNumber"].ToString();
                                    lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["cashier"].ToString();
                                    lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["notePrice"].ToString();
                                    lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentAddress"].ToString();


                                    try
                                    {
                                        if (File.Exists(dtStudentIDs.Rows[index]["picture"].ToString()))
                                        {
                                            studentPicture = Image.FromFile(dtStudentIDs.Rows[index]["picture"].ToString());
                                            pbStudentPicture.Image = studentPicture;

                                        }

                                    }
                                    catch (FileNotFoundException)
                                    {
                                        pbStudentPicture.Image = Properties.Resources.student;
                                    }
                                    catch (Exception)
                                    {

                                        pbStudentPicture.Image = Properties.Resources.student;
                                    }

                                }
                                cbPrograms.Text = UCSearchRecords.program;

                            }

                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read data through database\n" + ex.Message);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }

                }
                else if (UCSearchRecords.studentID == -1)
                {
                    int regNum = -1;
                    try
                    {
                        regNum = int.Parse(UCSearchRecords.regNumber);
                        studentRegNumberToPass = regNum;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error!!!\nStudent has not a valid student ID and Registration number\nStudent Registration number is not in correct format");
                        return;
                    }

                    // query using student registration number
                    query = "Select * from " + Dashboard.accessTableName + " Where ID = " + regNum;

                    try
                    {
                        database.readDatathroughAdapter(query, dtStudentIDs);
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read " + Dashboard.accessTableName + " data \n" + ex.Message);
                        return;

                    }

                    try
                    {
                        if (dtStudentIDs.Rows.Count > 0)
                        {
                            
                            lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["ID"].ToString();
                            lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentID"].ToString();
                            lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentName"].ToString();
                            lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["fatherName"].ToString();
                            lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["admissionDate"].ToString();
                            // programs 
                            cbPrograms.Items.Add(dtStudentIDs.Rows[0]["program"].ToString());
                            cbPrograms.SelectedIndex = 0;

                            lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["duration"].ToString();
                            lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["timing"].ToString();
                            lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["amount"].ToString();
                            lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["paid"].ToString();
                            lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                            lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["phoneNumber"].ToString();
                            lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["cashier"].ToString();
                            lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["notePrice"].ToString();
                            lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentAddress"].ToString();


                            try
                            {
                                studentPicture = Image.FromFile(dtStudentIDs.Rows[0]["picture"].ToString());
                                pbStudentPicture.Image = studentPicture;
                     
                            }
                            catch (FileNotFoundException)
                            {
                                pbStudentPicture.Image = Properties.Resources.student;
                              
                            }
                            catch (Exception)
                            {
                                pbStudentPicture.Image = Properties.Resources.student;
                            }
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read data through database\n" + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (UCDeleteRecords.UCDeleteRecordState)
            {
                if (UCDeleteRecords.studentID >= 0)
                {
                    // checks if student ID is not empty
                    if (UCDeleteRecords.studentID == 0)
                    {
                        int regNum = -1;
                        try
                        {
                            regNum = int.Parse(UCDeleteRecords.regNumber);
                            studentRegNumberToPass = regNum;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error!!!\nStudent has not a valid student ID and Registration number\nStudent Registration number is not in correct format");
                            return;
                        }

                        // query using student registration number
                        query = "Select * from " + Dashboard.accessTableName + " Where ID = " + regNum;

                        try
                        {
                            database.readDatathroughAdapter(query, dtStudentIDs);
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read " + Dashboard.accessTableName + " data \n" + ex.Message);
                            return;

                        }

                        try
                        {
                            if (dtStudentIDs.Rows.Count > 0)
                            {

                                lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["ID"].ToString();
                                lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentID"].ToString();
                                lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentName"].ToString();
                                lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["fatherName"].ToString();
                                lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["admissionDate"].ToString();
                                // programs 
                                cbPrograms.Items.Add(dtStudentIDs.Rows[0]["program"].ToString());
                                cbPrograms.SelectedIndex = 0;

                                lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["duration"].ToString();
                                lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["timing"].ToString();
                                lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["amount"].ToString();
                                lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["paid"].ToString();
                                lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["phoneNumber"].ToString();
                                lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["cashier"].ToString();
                                lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["notePrice"].ToString();
                                lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentAddress"].ToString();

                                try
                                {
                                    studentPicture = Image.FromFile(dtStudentIDs.Rows[0]["picture"].ToString());
                                    pbStudentPicture.Image = studentPicture;
                                  
                                }
                                catch (FileNotFoundException)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                   
                                }
                                catch (Exception)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                }
                            }
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read data through database\n" + ex.Message);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }

                    else
                    {

                        try
                        {
                            query = "Select * From " + Dashboard.accessTableName + " Where studentID = " + "'" + UCDeleteRecords.studentID.ToString() + "'";
                            database.readDatathroughAdapter(query, dtStudentIDs);

                            if (dtStudentIDs.Rows.Count > 0)
                            {
                                for (int index = 0; index < dtStudentIDs.Rows.Count; index++)
                                {
                                    studentRegNumberToPass = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? -1 : int.Parse(dtStudentIDs.Rows[index]["ID"].ToString());
                                    lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["ID"].ToString();
                                    lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentID"].ToString();
                                    lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentName"].ToString();
                                    lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["fatherName"].ToString();
                                    lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["admissionDate"].ToString();
                                    // programs 
                                    cbPrograms.Items.Add(dtStudentIDs.Rows[index]["program"].ToString());


                                    lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["duration"].ToString();
                                    lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["timing"].ToString();
                                    lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["amount"].ToString();
                                    lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["paid"].ToString();
                                    lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                    lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["phoneNumber"].ToString();
                                    lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["cashier"].ToString();
                                    lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["notePrice"].ToString();
                                    lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentAddress"].ToString();


                                    try
                                    {
                                        if (File.Exists(dtStudentIDs.Rows[index]["picture"].ToString()))
                                        {
                                            studentPicture = Image.FromFile(dtStudentIDs.Rows[index]["picture"].ToString());
                                            pbStudentPicture.Image = studentPicture;
                                          
                                        }

                                    }
                                    catch (FileNotFoundException)
                                    {
                                        pbStudentPicture.Image = Properties.Resources.student;
                                      
                                    }
                                    catch (Exception)
                                    {

                                        pbStudentPicture.Image = Properties.Resources.student;
                                    }

                                }
                                cbPrograms.Text = UCDeleteRecords.program;

                            }

                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Can't read data through database\n" + ex.Message);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


                    }

                }
                else if (UCDeleteRecords.studentID == -1)
                {
                    int regNum = -1;
                    try
                    {
                        regNum = int.Parse(UCDeleteRecords.regNumber);
                        studentRegNumberToPass = regNum;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Error!!!\nStudent has not a valid student ID and Registration number\nStudent Registration number is not in correct format");
                        return;
                    }

                    // query using student registration number
                    query = "Select * from " + Dashboard.accessTableName + " Where ID = " + regNum;

                    try
                    {
                        database.readDatathroughAdapter(query, dtStudentIDs);
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read " + Dashboard.accessTableName + " data \n" + ex.Message);
                        return;

                    }

                    try
                    {
                        if (dtStudentIDs.Rows.Count > 0)
                        {

                            lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["ID"].ToString();
                            lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentID"].ToString();
                            lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentName"].ToString();
                            lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["fatherName"].ToString();
                            lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["admissionDate"].ToString();
                            // programs 
                            cbPrograms.Items.Add(dtStudentIDs.Rows[0]["program"].ToString());
                            cbPrograms.SelectedIndex = 0;

                            lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["duration"].ToString();
                            lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["timing"].ToString();
                            lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["amount"].ToString();
                            lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["paid"].ToString();
                            lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                            lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["phoneNumber"].ToString();
                            lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["cashier"].ToString();
                            lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["notePrice"].ToString();
                            lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["studentAddress"].ToString();


                            try
                            {
                                studentPicture = Image.FromFile(dtStudentIDs.Rows[0]["picture"].ToString());
                                pbStudentPicture.Image = studentPicture;
                               
                            }
                            catch (FileNotFoundException)
                            {
                                pbStudentPicture.Image = Properties.Resources.student;
                              
                            }
                            catch (Exception)
                            {
                                pbStudentPicture.Image = Properties.Resources.student;
                            }
                        }
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read data through database\n" + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }

        }

        private void pbGoBack_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        private void cbPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtStudentIDs = new DataTable();
            Image studentPicture;
            string query = "";

            if (UCHome.UCHomeState)
            {
                if (UCHome.studentID > 0)
                {
                    try
                    {
                        query = "Select * From " + Dashboard.accessTableName + " Where studentID = " + "'" + UCHome.studentID.ToString() + "'";
                        database.readDatathroughAdapter(query, dtStudentIDs);

                        if (dtStudentIDs.Rows.Count > 0)
                        {

                            for (int index = 0; index <= cbPrograms.SelectedIndex; index++)
                            {
                                lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["ID"].ToString();
                                lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentID"].ToString();
                                lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentName"].ToString();
                                lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["fatherName"].ToString();
                                lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["admissionDate"].ToString();

                                lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["duration"].ToString();
                                lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["timing"].ToString();
                                lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["amount"].ToString();
                                lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["paid"].ToString();
                                lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["phoneNumber"].ToString();
                                lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["cashier"].ToString();
                                lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["notePrice"].ToString();
                                lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentAddress"].ToString();


                                try
                                {
                                    if (File.Exists(dtStudentIDs.Rows[index]["picture"].ToString()))
                                    {
                                        studentPicture = Image.FromFile(dtStudentIDs.Rows[index]["picture"].ToString());
                                        pbStudentPicture.Image = studentPicture;
                                       
                                    }

                                }
                                catch (FileNotFoundException)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                   
                                }
                                catch (Exception)
                                {

                                    pbStudentPicture.Image = Properties.Resources.student;
                                }

                            }


                        }

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read data through database\n" + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else if (UCSearchRecords.UCSearchRecordState)
            {
                if (UCSearchRecords.studentID > 0)
                {
                    try
                    {
                        query = "Select * From " + Dashboard.accessTableName + " Where studentID = " + "'" + UCSearchRecords.studentID.ToString() + "'";
                        database.readDatathroughAdapter(query, dtStudentIDs);

                        if (dtStudentIDs.Rows.Count > 0)
                        {

                            for (int index = 0; index <= cbPrograms.SelectedIndex; index++)
                            {
                                lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["ID"].ToString();
                                lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentID"].ToString();
                                lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentName"].ToString();
                                lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["fatherName"].ToString();
                                lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["admissionDate"].ToString();

                                lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["duration"].ToString();
                                lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["timing"].ToString();
                                lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["amount"].ToString();
                                lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["paid"].ToString();
                                lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["phoneNumber"].ToString();
                                lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["cashier"].ToString();
                                lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["notePrice"].ToString();
                                lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentAddress"].ToString();


                                try
                                {
                                    if (File.Exists(dtStudentIDs.Rows[index]["picture"].ToString()))
                                    {
                                        studentPicture = Image.FromFile(dtStudentIDs.Rows[index]["picture"].ToString());
                                        pbStudentPicture.Image = studentPicture;
                                       
                                    }

                                }
                                catch (FileNotFoundException)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                   
                                }
                                catch (Exception)
                                {

                                    pbStudentPicture.Image = Properties.Resources.student;
                                }

                            }


                        }

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read data through database\n" + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else if (UCDeleteRecords.UCDeleteRecordState)
            {
                if (UCDeleteRecords.studentID > 0)
                {
                    try
                    {
                        query = "Select * From " + Dashboard.accessTableName + " Where studentID = " + "'" + UCDeleteRecords.studentID.ToString() + "'";
                        database.readDatathroughAdapter(query, dtStudentIDs);

                        if (dtStudentIDs.Rows.Count > 0)
                        {

                            for (int index = 0; index <= cbPrograms.SelectedIndex; index++)
                            {
                                lblRegNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["ID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["ID"].ToString();
                                lblStudentID.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentID"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentID"].ToString();
                                lblStudentName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentName"].ToString();
                                lblFatherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["fatherName"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["fatherName"].ToString();
                                lblAddmissionDate.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["admissionDate"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["admissionDate"].ToString();

                                lblDuration.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["duration"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["duration"].ToString();
                                lblTiming.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["timing"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["timing"].ToString();
                                lblAmount.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["amount"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["amount"].ToString();
                                lblPaid.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["paid"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["paid"].ToString();
                                lblTeacherName.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[0]["teacher"].ToString())) ? "-----" : dtStudentIDs.Rows[0]["teacher"].ToString();
                                lblPhoneNumber.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["phoneNumber"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["phoneNumber"].ToString();
                                lblCashier.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["cashier"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["cashier"].ToString();
                                lblNotePrice.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["notePrice"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["notePrice"].ToString();
                                lblStudentAddress.Text = (string.IsNullOrEmpty(dtStudentIDs.Rows[index]["studentAddress"].ToString())) ? "-----" : dtStudentIDs.Rows[index]["studentAddress"].ToString();


                                try
                                {
                                    if (File.Exists(dtStudentIDs.Rows[index]["picture"].ToString()))
                                    {
                                        studentPicture = Image.FromFile(dtStudentIDs.Rows[index]["picture"].ToString());
                                        pbStudentPicture.Image = studentPicture;
                                       
                                    }

                                }
                                catch (FileNotFoundException)
                                {
                                    pbStudentPicture.Image = Properties.Resources.student;
                                    
                                }
                                catch (Exception)
                                {

                                    pbStudentPicture.Image = Properties.Resources.student;
                                }

                            }


                        }

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Can't read data through database\n" + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }

        }

    
        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (SplashScreenForm.adminLogin == false)
            {
                MessageBox.Show("Login as administrator to delete this record!", "Unable to delete");
                return;
            }
            btnDeleteClicked = true;

            foreach (Form f in fc)
            {

                if (f.Name == "Dashboard")
                {
                    isDashboardOpen = true;
                    dashboard = (Dashboard)f;
                }
            }

            if (isDashboardOpen)
            {

                formWidth = dashboard.Width;
                formHeight = dashboard.Height;
                Dashboard d = new Dashboard();
                d.Show();
                dashboard.Hide();
            }
            this.Close();

        }

        private void pbStudentPicture_Click(object sender, EventArgs e)
        {
            if (pbStudentClicked == false)
            {
           
                pbStudentPicture.Width = 230;
                pbStudentPicture.Height = 240;
                pbStudentClicked = true;
            }
            else
            {
      
                pbStudentPicture.Width = 112;
                pbStudentPicture.Height = 125;
                pbStudentClicked = false;
            }
        }
    }
}
