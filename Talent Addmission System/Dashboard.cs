using System;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Talent_Addmission_System.Properties;

namespace Talent_Addmission_System
{

    public partial class Dashboard : Form
    {
        DBAccess database;
        Functions functions = new Functions();

        // settings variables
        public static string dataSourcePath;
        public static string accessTableName;
        public static string paymentTableName;
        public static string databaseName;
        public static string imagesLocation;
        public static Boolean settingsState;


        public Dashboard()
        {
            InitializeComponent();

            this.MinimumSize = new System.Drawing.Size(1200, 650);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            

            // check datasource related information
            settingsState = (Boolean)Settings.Default["settingsState"];

            if (settingsState == false)
            {

                string imagesPath = Path.Combine(functions.getAvailableDriveName(), "Talent Addmission System\\RECORDS\\Students images");
                if (!(Directory.Exists(imagesPath)))
                {
                    Directory.CreateDirectory(imagesPath);
                }

                imagesLocation = imagesPath;
                dataSourcePath = Path.Combine(functions.getAvailableDriveName(), "Talent Addmission System\\RECORDS\\Students_Database.accdb");
                accessTableName = "students";
                paymentTableName = "payments";

                databaseName = Path.GetFileName(dataSourcePath);

                // save settings
                Settings.Default["imagesLocation"] = imagesLocation;
                Settings.Default["dataSourcePath"] = dataSourcePath ;
                Settings.Default["accessTableName"] = accessTableName;
                Settings.Default["paymentTable"] = paymentTableName;

                Settings.Default["settingsState"] = true;
                Settings.Default.Save();

            }
            else
            {
                dataSourcePath = Settings.Default["dataSourcePath"].ToString();
                accessTableName = Settings.Default["accessTableName"].ToString();
                paymentTableName = Settings.Default["paymentTable"].ToString();
                databaseName = Path.GetFileName(dataSourcePath);
                imagesLocation = Settings.Default["imagesLocation"].ToString();

                // save settings
                Settings.Default["settingsState"] = true;
                Settings.Default.Save();

            }

            database = new DBAccess(dataSourcePath);

            try
            {
                database.createConn();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show( "Can't establish connection \nError in the Data source!!!\n\n" +
                    "Tip: go to settings and make sure the access database path and table name is correct\n" +
                    ex.Message, "Data source connection failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            // disable key buttons if user login is true
            if (SplashScreenForm.adminLogin == false)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnPayments.Enabled = false;
            }

            if (SplashScreenForm.adminLogin)
            {
                if (DisplayRecordForm.studentRegNumberToPass != -1 && DisplayRecordForm.btnDeleteClicked)
                {

                    btnDelete.Focus();
                    btnDelete.PerformClick();
                    User_Controls.UCDeleteRecords ucUpdate = new User_Controls.UCDeleteRecords();
                    addUserControl(ucUpdate);


                    if ((DisplayRecordForm.formWidth > 1200 && DisplayRecordForm.formWidth <= 1250))
                    {
                        this.Width = DisplayRecordForm.formWidth;
                        this.Height = DisplayRecordForm.formHeight;

                    }
                    else if ((DisplayRecordForm.formHeight > 650 && DisplayRecordForm.formHeight <= 700))
                    {
                        this.Width = DisplayRecordForm.formWidth;
                        this.Height = DisplayRecordForm.formHeight;
                    }
                    else if (DisplayRecordForm.formWidth > 1250 || DisplayRecordForm.formHeight > 700)
                    {
                        this.Width = DisplayRecordForm.formWidth;
                        this.Height = DisplayRecordForm.formHeight;
                        this.Location = new System.Drawing.Point(-6, -4);
                    }
                    else
                    {
                        this.Width = DisplayRecordForm.formWidth;
                        this.Height = DisplayRecordForm.formHeight;
                    }
                    pbClose.Visible = true;
                }
                else
                {
                    User_Controls.UCHome home = new User_Controls.UCHome();
                    addUserControl(home);
                    pbClose.Visible = false;

                }
            }
            else
            {
                User_Controls.UCHome home = new User_Controls.UCHome();
                addUserControl(home);
                pbClose.Visible = false;
            }

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
         
            User_Controls.UCHome home = new User_Controls.UCHome();
            addUserControl(home);
            disableBooleanValuesOfDisplayForm();
     
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            User_Controls.UCAddRecord addRecord = new User_Controls.UCAddRecord();
            addUserControl(addRecord);
            disableBooleanValuesOfDisplayForm();
        }

       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            User_Controls.UCSearchRecords searchRecord = new User_Controls.UCSearchRecords();
            addUserControl(searchRecord);
            disableBooleanValuesOfDisplayForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User_Controls.UCUpdateRecords update = new User_Controls.UCUpdateRecords();
            addUserControl(update);
            if (DisplayRecordForm.btnDeleteClicked)
            {
                DisplayRecordForm.btnDeleteClicked = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            User_Controls.UCDeleteRecords delete = new User_Controls.UCDeleteRecords();
            addUserControl(delete);
      
        }
        private void btnPayments_Click(object sender, EventArgs e)
        {
            TeachersPaymentForm teachersPayment = new TeachersPaymentForm();
            teachersPayment.ShowDialog();
        }
        private void btnSettings_Click(object sender, EventArgs e)
        {
            User_Controls.UCSettings settings = new User_Controls.UCSettings();
            addUserControl(settings);
            disableBooleanValuesOfDisplayForm();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {

            User_Controls.UCHelp help = new User_Controls.UCHelp();
            addUserControl(help);
            disableBooleanValuesOfDisplayForm();
        }

      

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            database.closeConn();
            Application.Exit();
        }

        private void addUserControl(UserControl userControl)
        {
            // check user control type
            if (userControl is User_Controls.UCHome)
            {
                pbClose.Visible = false;
                lblUserControlName.Text = "HOME";
            }
            else if (userControl is User_Controls.UCAddRecord)
            {
                lblUserControlName.Text = "ADD RECORD";
                pbClose.Visible = true;
            }
            else if (userControl is User_Controls.UCSearchRecords)
            {
                lblUserControlName.Text = "SEARCH RECORDS";
                pbClose.Visible = true;
            }
            else if (userControl is User_Controls.UCUpdateRecords)
            {
                lblUserControlName.Text = "UPDATE RECORD";
                pbClose.Visible = true;
            }
            else if (userControl is User_Controls.UCDeleteRecords)
            {
                lblUserControlName.Text = "DELETE RECORD";
                pbClose.Visible = true;
            }
            else if (userControl is User_Controls.UCSettings)
            {
                lblUserControlName.Text = "SETTINGS";
                pbClose.Visible = true;
            }
            else if (userControl is User_Controls.UCHelp)
            {
                lblUserControlName.Text = "HELP";
                pbClose.Visible = true;
            }
            else
            {
                pbClose.Visible = true;
            }

            userControl.Dock = DockStyle.Fill;
            panelUserControls.Controls.Clear();
            userControl.BringToFront();
            panelUserControls.Controls.Add(userControl);

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            btnHome.PerformClick();

        }

        private void pbBackToSplashScreen_Click(object sender, EventArgs e)
        {
            SplashScreenForm splashScreen = new SplashScreenForm();
            splashScreen.Show();
            this.Hide();

        }

        private void pbAnalyze_Click(object sender, EventArgs e)
        {
            AnalyzeForm analyze = new AnalyzeForm();
            analyze.ShowDialog();
            
        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
            if (panelUserControls.Controls.Count > 0)
            {
                panelUserControls.Width = this.Width - 215;
                panelUserControls.Controls[0].Dock = DockStyle.Fill;
                panelUserControls.Height = this.Height - 60;

            }

            // panel title bar
            lblUserControlName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserControlName.Location = new System.Drawing.Point((panelTitleBar.Width / 2) - 90, lblUserControlName.Location.Y);

            pbClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbClose.Location = new System.Drawing.Point(panelTitleBar.Width - 50, pbClose.Location.Y);
            pbAnalyze.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbAnalyze.Location = new System.Drawing.Point(panelTitleBar.Width - 92, pbAnalyze.Location.Y);

        }

        private void disableBooleanValuesOfDisplayForm()
        {
            // reset boolean values of display form
            DisplayRecordForm.btnDeleteClicked = false;
        }

    }
}

