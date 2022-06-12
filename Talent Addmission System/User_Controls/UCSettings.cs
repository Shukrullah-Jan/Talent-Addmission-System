using System;
using System.IO;
using System.Windows.Forms;
using Talent_Addmission_System.Properties;
using System.Drawing;
using System.Globalization;
using System.Data.OleDb;

namespace Talent_Addmission_System.User_Controls
{
    public partial class UCSettings : UserControl
    {
        private DBAccess database = new DBAccess(Dashboard.dataSourcePath);
        System.Collections.Specialized.StringCollection programs;
        private string backupPath = "C:\\";
        public UCSettings()
        {
            InitializeComponent();

        }

        private void UCSettings_Load(object sender, EventArgs e)
        {

            tbTableName.Enabled = false;
            tbPaymentTable.Enabled = false;
            tbDataSourcePath.Enabled = false;
            tbImagesLocation.Enabled = false;
            btnSubmit.Enabled = false;
            btnChangeDataSource.Enabled = false;
            btnChangeImagesLocation.Enabled = false;


            // passwords
            tbCurrentPassword.Enabled = false;
            tbNewPassword.Enabled = false;
            tbConfirmPassword.Enabled = false;
            btnChangePassword.Enabled = false;
         

            // user passwords
            tbCurrentPasswordUser.Enabled = false;
            tbNewPasswordUser.Enabled = false;
            tbConfirmPasswordUser.Enabled = false;
            btnChangePasswordUser.Enabled = false;
            btnResetUserPasssword.Enabled = false;

            // add button
            btnAdd.Enabled = false;

            // contact info
            tbContactNumber.Enabled = false;
            tbCourseAddress.Enabled = false;
            btnChangeContactInfo.Enabled = false;

            // get data source info
            tbDataSourcePath.Text = Settings.Default["dataSourcePath"].ToString();
            tbTableName.Text = Settings.Default["accessTableName"].ToString();
            tbPaymentTable.Text = Settings.Default["paymentTable"].ToString();
            tbImagesLocation.Text = Settings.Default["imagesLocation"].ToString();

            // get contact info
            tbContactNumber.Text = Settings.Default["contactNumber"].ToString();
            tbCourseAddress.Text = Settings.Default["courseAddress"].ToString();


            // get list of programs
            programs = (System.Collections.Specialized.StringCollection)Settings.Default["programsList"];

            setPrograms(programs);

            if (SplashScreenForm.adminLogin == false)
            {
                chbEnableEditing.Enabled = false;
                chbAdminChangePassword.Enabled = false;
                chbEnableContactControls.Enabled = false;

                tbAddNewProgram.Enabled = false;
                btnRemove.Enabled = false;

            }
        }

        private void chbEnableEditing_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnableEditing.Checked)
            {
                tbTableName.Enabled = true;
                tbPaymentTable.Enabled = true;
                tbDataSourcePath.Enabled = true;
                tbImagesLocation.Enabled = true;
                btnSubmit.Enabled = true;
                btnChangeDataSource.Enabled = true;
                btnChangeImagesLocation.Enabled = true;
            }
            else
            {
                tbTableName.Enabled = false;
                tbPaymentTable.Enabled = false;
                tbDataSourcePath.Enabled = false;
                tbImagesLocation.Enabled = false;
                btnSubmit.Enabled = false;
                btnChangeDataSource.Enabled = false;
                btnChangeImagesLocation.Enabled = false;

            }
        }

        private void btnChangeDataSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Access files (*.accdb) | *.accdb";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                tbDataSourcePath.Text = fd.FileName;

            }
        }

        private void btnChangeImagesLocation_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbImagesLocation.Text = dialog.SelectedPath;

            }
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to change data source, access table names and images location?\n" +
            "Changing data source will cause records to be inserted, upadated, deleted to a different database", "Change Datasource", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Dashboard.dataSourcePath = tbDataSourcePath.Text;
                Dashboard.accessTableName = tbTableName.Text;
                Dashboard.paymentTableName = tbPaymentTable.Text;

                //images
                Dashboard.imagesLocation = tbImagesLocation.Text;
                Settings.Default["imagesLocation"] = tbImagesLocation.Text;

                Settings.Default["dataSourcePath"] = tbDataSourcePath.Text;
                Settings.Default["accessTableName"] = tbTableName.Text;
                Settings.Default["paymentTable"] = tbPaymentTable.Text;
                Settings.Default["settingsState"] = true;
                Settings.Default.Save();

                chbEnableEditing.Checked = false;

                MessageBox.Show("Data source, access table names and images location has been changed successfully\nCurrent" +
                    "data source: " + tbDataSourcePath.Text + "\nStudents tabel name: " + tbTableName.Text +
                    "\nPayment tabel name: " + tbPaymentTable.Text +
                    "\nCurrecnt Images Location: " + tbImagesLocation.Text);
            }


        }

        // admin password settings
        private void chbChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAdminChangePassword.Checked)
            {
                tbCurrentPassword.Enabled = true;
                tbNewPassword.Enabled = true;
                tbConfirmPassword.Enabled = true;
                btnChangePassword.Enabled = true;
            }
            else
            {
                tbCurrentPassword.Enabled = false;
                tbNewPassword.Enabled = false;
                tbConfirmPassword.Enabled = false;
                btnChangePassword.Enabled = false;
            }
        }



        private void tbCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            tbCurrentPassword.BorderColor = Color.LightBlue;
            tbCurrentPassword.BorderThickness = 1;
            tbCurrentPassword.ForeColor = Color.White;
        }

        private void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            tbConfirmPassword.BorderColor = Color.LightBlue;
            tbConfirmPassword.BorderThickness = 1;
            tbConfirmPassword.ForeColor = Color.White;
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (Settings.Default["password"].ToString() == tbCurrentPassword.Text)
            {
                if (tbNewPassword.Text == tbConfirmPassword.Text)
                {

                    DialogResult result = MessageBox.Show("Do you really want to change the password?\n"
                         , "Change Password", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Settings.Default["password"] = tbNewPassword.Text;
                        Settings.Default["settingsState"] = true;
                        Settings.Default.Save();

                        // reset controls texts
                        chbAdminChangePassword.Checked = false;
                        tbCurrentPassword.Text = "";
                        tbNewPassword.Text = "";
                        tbConfirmPassword.Text = "";

                        MessageBox.Show("Password has been changed successfully\nNew Password: " + Settings.Default["password"].ToString());

                    }
                    else
                    {
                        tbCurrentPassword.Enabled = false;
                        tbNewPassword.Enabled = false;
                        tbConfirmPassword.Enabled = false;
                        btnChangePassword.Enabled = false;
                        chbAdminChangePassword.Checked = false;
                        tbCurrentPassword.Text = "";
                        tbNewPassword.Text = "";
                        tbConfirmPassword.Text = "";
                    }


                }
                else
                {
                    tbConfirmPassword.Focus();
                    tbConfirmPassword.BorderColor = Color.Red;
                    tbConfirmPassword.BorderThickness = 1;
                    tbConfirmPassword.ForeColor = Color.Red;
                }
            }
            else
            {
                tbCurrentPassword.Focus();
                tbCurrentPassword.BorderColor = Color.Red;
                tbCurrentPassword.BorderThickness = 1;
                tbCurrentPassword.ForeColor = Color.Red;

            }


        }

        // user password settings
        private void chbUserChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chbUserChangePassword.Checked)
            {
                tbCurrentPasswordUser.Enabled = true;
                tbNewPasswordUser.Enabled = true;
                tbConfirmPasswordUser.Enabled = true;
                btnChangePasswordUser.Enabled = true;
                if (SplashScreenForm.adminLogin)
                {
                    btnResetUserPasssword.Enabled = true;
                }
            
            }
            else
            {
                tbCurrentPasswordUser.Enabled = false;
                tbNewPasswordUser.Enabled = false;
                tbConfirmPasswordUser.Enabled = false;
                btnChangePasswordUser.Enabled = false;
                btnResetUserPasssword.Enabled = false;
                if (SplashScreenForm.adminLogin)
                {
                    btnResetUserPasssword.Enabled = false;
                }
            }
        }

        private void tbCurrentPasswordUser_TextChanged(object sender, EventArgs e)
        {
            tbCurrentPasswordUser.BorderColor = Color.LightBlue;
            tbCurrentPasswordUser.BorderThickness = 1;
            tbCurrentPasswordUser.ForeColor = Color.White;
        }

        private void tbConfirmPasswordUser_TextChanged(object sender, EventArgs e)
        {
            tbConfirmPasswordUser.BorderColor = Color.LightBlue;
            tbConfirmPasswordUser.BorderThickness = 1;
            tbConfirmPasswordUser.ForeColor = Color.White;
        }

        private void btnChangePasswordUser_Click(object sender, EventArgs e)
        {

            if (Settings.Default["userPassword"].ToString() == tbCurrentPasswordUser.Text)
            {
                if (tbNewPasswordUser.Text == tbConfirmPasswordUser.Text)
                {

                    DialogResult result = MessageBox.Show("Do you really want to change the password?\n"
                         , "Change User Password", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Settings.Default["userPassword"] = tbNewPasswordUser.Text;
                        Settings.Default["settingsState"] = true;
                        Settings.Default.Save();

                        // reset controls texts
                        chbUserChangePassword.Checked = false;
                        tbCurrentPasswordUser.Text = "";
                        tbNewPasswordUser.Text = "";
                        tbConfirmPasswordUser.Text = "";

                        MessageBox.Show("Password has been changed successfully\nNew Password: " + Settings.Default["userPassword"].ToString());

                    }
                    else
                    {
                        tbCurrentPasswordUser.Enabled = false;
                        tbNewPasswordUser.Enabled = false;
                        tbConfirmPasswordUser.Enabled = false;
                        btnChangePasswordUser.Enabled = false;
                        chbUserChangePassword.Checked = false;
                        tbCurrentPasswordUser.Text = "";
                        tbNewPasswordUser.Text = "";
                        tbConfirmPasswordUser.Text = "";
                    }


                }
                else
                {
                    tbConfirmPasswordUser.Focus();
                    tbConfirmPasswordUser.BorderColor = Color.Red;
                    tbConfirmPasswordUser.BorderThickness = 1;
                    tbConfirmPasswordUser.ForeColor = Color.Red;
                }
            }
            else
            {
                tbCurrentPasswordUser.Focus();
                tbCurrentPasswordUser.BorderColor = Color.Red;
                tbCurrentPasswordUser.BorderThickness = 1;
                tbCurrentPasswordUser.ForeColor = Color.Red;

            }
        }


        private void chbEnableContactControls_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnableContactControls.Checked)
            {
                tbContactNumber.Enabled = true;
                tbCourseAddress.Enabled = true;
                btnChangeContactInfo.Enabled = true;
            }
            else
            {
                tbContactNumber.Enabled = false;
                tbCourseAddress.Enabled = false;
                btnChangeContactInfo.Enabled = false;
            }
        }

        private void btnChangeContactInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbContactNumber.Text.Trim()))
            {
                tbContactNumber.Text = "";
                tbContactNumber.Focus();
                tbContactNumber.BorderColor = Color.Red;

                tbContactNumber.BorderThickness = 1;
                tbContactNumber.ForeColor = Color.Red;

                tbContactNumber.PlaceholderText = "Contact Number";
                tbContactNumber.PlaceholderForeColor = Color.Red;
                return;
            }
            else
            {
                tbContactNumber.BorderColor = Color.LightBlue;
                tbContactNumber.BorderThickness = 1;
                tbContactNumber.ForeColor = Color.White;

                tbContactNumber.PlaceholderForeColor = Color.LightBlue;
            }

            if (string.IsNullOrEmpty(tbCourseAddress.Text.Trim()))
            {
                tbCourseAddress.Text = "";
                tbCourseAddress.Focus();
                tbCourseAddress.BorderColor = Color.Red;

                tbCourseAddress.BorderThickness = 1;
                tbCourseAddress.ForeColor = Color.Red;

                tbCourseAddress.PlaceholderText = "Course Address";
                tbCourseAddress.PlaceholderForeColor = Color.Red;

                return;
            }
            else
            {
                tbCourseAddress.BorderColor = Color.LightBlue;
                tbCourseAddress.BorderThickness = 1;
                tbCourseAddress.ForeColor = Color.White;
                tbCourseAddress.PlaceholderForeColor = Color.LightBlue;
            }


            DialogResult result = MessageBox.Show("Do you really want to change contact information?\n"
                 , "Change Contact Info", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                Settings.Default["contactNumber"] = tbContactNumber.Text.Trim();
                Settings.Default["courseAddress"] = tbCourseAddress.Text.Trim();

                Settings.Default.Save();

                tbContactNumber.Text = Settings.Default["contactNumber"].ToString();
                tbCourseAddress.Text = Settings.Default["courseAddress"].ToString();

                tbContactNumber.Enabled = false;
                tbCourseAddress.Enabled = false;
                btnChangeContactInfo.Enabled = false;
                chbEnableContactControls.Checked = false;

                MessageBox.Show("Contact information has been changed successfully\nContact Number: " + tbContactNumber.Text
                    + "\nCourse Address: " + tbCourseAddress.Text);
            }



        }

        private void tbContactNumber_TextChanged(object sender, EventArgs e)
        {
            tbContactNumber.BorderColor = Color.LightBlue;
            tbContactNumber.BorderThickness = 1;
            tbContactNumber.ForeColor = Color.White;
        }

        private void tbCourseAddress_TextChanged(object sender, EventArgs e)
        {
            tbCourseAddress.BorderColor = Color.LightBlue;
            tbCourseAddress.BorderThickness = 1;
            tbCourseAddress.ForeColor = Color.White;
        }

        private void tbAddNewProgram_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAddNewProgram.Text.Trim()))
            {
                btnAdd.Enabled = false;
            }
            else btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(tbAddNewProgram.Text.Trim())))
            {
                DialogResult result = MessageBox.Show("Do you want to add " + tbAddNewProgram.Text + " to list of programs?", "Add New Program", MessageBoxButtons.YesNo);


                if (result == DialogResult.Yes)
                {
                    programs.Add(tbAddNewProgram.Text);
                    lbPrograms.Items.Add(tbAddNewProgram.Text);
                    Settings.Default["programsList"] = programs;
                    Settings.Default.Save();
                    MessageBox.Show(tbAddNewProgram.Text + " added successfully to list of programs");
                }

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to remove " + lbPrograms.SelectedItem + " from the list of programs?", "Remove Program", MessageBoxButtons.YesNo);


            if (result == DialogResult.Yes)
            {

                programs.Remove(lbPrograms.SelectedItem.ToString());
                lbPrograms.Items.Remove(lbPrograms.SelectedItem);
                Settings.Default["programsList"] = programs;
                Settings.Default.Save();

            }

        }
        private void UCSettings_SizeChanged(object sender, EventArgs e)
        {
            gbDataSource.Width = this.Width;

        }
        private void setPrograms(System.Collections.Specialized.StringCollection programs)
        {
            foreach (string program in programs)
            {
                lbPrograms.Items.Add(program);
            }
            lbPrograms.SelectedIndex = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbBackup.Text = dialog.SelectedPath;
                backupPath = dialog.SelectedPath;

            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

            if (Directory.Exists(tbBackup.Text.Trim()))
            {
                backupDatabase();
            }
            else
            {
                MessageBox.Show("Path is not valid!!!\nTry another path", "Path not exists");
            }


        }

        private void backupDatabase()
        {
            try
            {

                if (File.Exists(Dashboard.dataSourcePath))
                {

                    string dbName = "Students_Database.accdb";
                    string currentDatabasePath = Dashboard.dataSourcePath;
                    string backTimeStamp = Path.GetFileNameWithoutExtension(dbName);
                    string destFileName = DateTime.Now.ToString("dd-mm-yyyy", CultureInfo.InvariantCulture) + dbName;
                    string pathToBackup = backupPath;
                    DialogResult result = MessageBox.Show("Do you want to backup database in the following location?\n" +
                        tbBackup.Text, "Back up Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        destFileName = Path.Combine(pathToBackup, destFileName);
                        File.Copy(currentDatabasePath, destFileName, true);

                        MessageBox.Show("Database successfully backed up", "Backup Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Data source path is not valid!!!\nConnect or choose a different " +
                        "data source and try again", "Data source does not exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (IOException ex)
            {
                MessageBox.Show("Error!!!\nCan't backup database due to the following error\n" + ex.Message, "Back up failed!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!!!\nCan't backup database due to the following error\n" + ex.Message, "Back up failed!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnResetUserPasssword_Click(object sender, EventArgs e)
        {
            if (SplashScreenForm.adminLogin)
            {
               DialogResult result =  MessageBox.Show("Do you want to reset user password to 12345?",
                    "Reset User Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Settings.Default["userPassword"] = "12345";
                    Settings.Default.Save();
                    MessageBox.Show("Current user password is: 12345",
                     "User Password Changed", MessageBoxButtons.OK);
                }
            }
        }
        

        //private void btnRestore_Click(object sender, EventArgs e)
        //{
        //    //string PathToRestoreDB = Environment.CurrentDirectory + @"\Students_Database.accdb";
        //    //OpenFileDialog ofd = new OpenFileDialog();
        //    //if (ofd.ShowDialog() == DialogResult.OK)
        //    //{
        //    //    string Filetorestore = ofd.FileName;    // Rename Current Database to .Bak
        //    //    File.Move(PathToRestoreDB, PathToRestoreDB + ".bak");     //Restore the Database From Backup Folder
        //    //    File.Copy(Filetorestore, PathToRestoreDB, true);
        //    //}


        //    //    OpenFileDialog ofd = new OpenFileDialog();

        //    //    ofd.InitialDirectory = "C:\\";
        //    //    ofd.Title = "Browse Database File";
        //    //    ofd.CheckFileExists = true;
        //    //    ofd.CheckPathExists = true;

        //    //    ofd.DefaultExt = "accdb";
        //    //    ofd.Filter = "Access Database (*.accdb) | *.accdb";
        //    //    ofd.FilterIndex = 2;
        //    //    ofd.RestoreDirectory = true;

        //    //    ofd.ReadOnlyChecked = true;
        //    //    ofd.ShowReadOnly = true;

        //    //    if (ofd.ShowDialog() == DialogResult.OK)
        //    //    {
        //    //        tbBackup.Text = ofd.FileName;
        //    //    }

        //    //    string databaseName = Dashboard.databaseName;


        //    //    try
        //    //    {
        //    //        database.createConn();
        //    //        string str = "USE master;";
        //    //        string str2 = "ALTER DATABASE " + databaseName + " SET SINGLE_SINGLE USER WITH ROLLBACK IMMEDIATE;";

        //    //        string str3 = "RESTORE DATABASE " + databaseName + " FROM DISK = '" + tbBackup.Text + "' WITH REPLACE ";
        //    //        OleDbCommand cmd1 = new OleDbCommand(str);
        //    //        OleDbCommand cmd2 = new OleDbCommand(str2);
        //    //        OleDbCommand cmd3 = new OleDbCommand(str3);

        //    //        cmd1.ExecuteNonQuery();
        //    //        cmd2.ExecuteNonQuery();
        //    //        cmd3.ExecuteNonQuery();

        //    //        MessageBox.Show("Database recovered successfully");
        //    //        database.closeConn();


        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        MessageBox.Show(ex.Message);
        //    //    }
        //    //}

        //}

    }
}

