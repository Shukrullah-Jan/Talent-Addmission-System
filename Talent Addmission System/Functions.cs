using System;
using System.Data;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;

namespace Talent_Addmission_System
{
    internal class Functions
    {
        private DBAccess database = new DBAccess(Dashboard.dataSourcePath);


        // functions for returning unique registration number 
        public int getNewRegistrationNumber()
        {
            DataTable dtRegNumbers = new DataTable();
            string query = "Select ID from " + Dashboard.accessTableName;
            int oldRegNumber = 0;
            try
            {
                database.readDatathroughAdapter(query, dtRegNumbers);

                if (dtRegNumbers.Rows.Count > 0)
                {
                    try
                    {
                        foreach (DataRow row in dtRegNumbers.Rows)
                        {
                        
                            oldRegNumber = int.Parse(row["ID"].ToString());
                        }
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                  
                }
                return ++oldRegNumber;
              
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Can't read ID column\n" + ex.Message);
          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return ++oldRegNumber;

        }

        // function to get a valid student ID for new students
        public int getNewStudentID()
        {
            DataTable dtStudentIDs = new DataTable();
            string query = "Select studentID from " + Dashboard.accessTableName;

            List<int> ids = new List<int>();
            int id = 1;
            int i;

            try
            {
                database.readDatathroughAdapter(query, dtStudentIDs);

                if (dtStudentIDs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtStudentIDs.Rows)
                    {
                        string studentID = row["studentID"].ToString();

                        try
                        {
                            i = int.Parse(studentID.Trim());
                            ids.Add(i);
                        }
                        catch (FormatException)
                        {
                            continue;
                        }

                    }

                    for (id = 1; id <= ids.Count; id++)
                    {
                        if (!(ids.Contains(id)))
                        {
                            return id;
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Can't read studentID column\n" + ex.Message);

            }

            return id++;

        }

        public int getNewInstructorID()
        {
            DataTable dtInstructorIDs = new DataTable();
            string query = "Select instructorID from "+ Dashboard.paymentTableName;

            List<int> ids = new List<int>();
            int id = 1;
            int i;

            try
            {
                database.createConn();
                database.readDatathroughAdapter(query, dtInstructorIDs);

                if (dtInstructorIDs.Rows.Count > 0)
                {
                    foreach (DataRow row in dtInstructorIDs.Rows)
                    {
                        string instructorID = row["instructorID"].ToString();

                        try
                        {
                            i = int.Parse(instructorID.Trim());
                            ids.Add(i);
                        }
                        catch (FormatException)
                        {
                            continue;
                        }

                    }

                    for (id = 1; id <= ids.Count; id++)
                    {
                        if (!(ids.Contains(id)))
                        {
                            return id;
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Can't read instructorID column\n" + ex.Message);

            }
            database.closeConn();
            return id++;
        }
        
        // if ID exists return ID
        // else -1
        public int checkStudentIDInDatabase(int oldID)
        {
            DataTable dtStudentIDs = new DataTable();
            string query = "Select studentID from " + Dashboard.accessTableName;

            List<int> ids = new List<int>();
            int i;

            try
            {
                database.readDatathroughAdapter(query, dtStudentIDs);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Can't read ID column\n" + ex.Message);
                return -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }


            if (dtStudentIDs.Rows.Count > 0)
            {
                foreach (DataRow row in dtStudentIDs.Rows)
                {
                    string studentID = row["studentID"].ToString();

                    try
                    {
                        i = int.Parse(studentID.Trim());
                        ids.Add(i);
                    }
                    catch (FormatException)
                    {
                        continue;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
       

            if (ids.Contains(oldID)) return oldID;

            return -1;
        }

     
        public static Boolean areColumnNamesValid(Guna.UI2.WinForms.Guna2DataGridView dgv)
        {
            try
            {
                if (dgv.Columns["ID"] != null && dgv.Columns["studentName"] != null &&
                  dgv.Columns["fatherName"] != null && dgv.Columns["studentID"] != null &&
                 dgv.Columns["program"] != null && dgv.Columns["duration"] != null &&
                 dgv.Columns["timing"] != null && dgv.Columns["amount"] != null &&
                 dgv.Columns["paid"] != null && dgv.Columns["admissionDate"] != null &&
                 dgv.Columns["teacher"] != null &&
                 dgv.Columns["phoneNumber"] != null &&
                 dgv.Columns["cashier"] != null && dgv.Columns["notePrice"] != null &&
                 dgv.Columns["studentAddress"] != null && dgv.Columns["picture"] != null)
                { 
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public string getAvailableDriveName()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Boolean isCDriveReady = false;

            foreach (DriveInfo d in allDrives)
            {

                //Console.WriteLine("Drive {0}", d.Name);
                //Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {

                    if (d.Name != "C:\\" && d.TotalFreeSpace >= 1000000000 && d.DriveType == DriveType.Fixed)
                    {
                        return d.Name;
                    }

                    if (d.Name == "C:\\" && d.TotalFreeSpace >= 5000000000 && d.DriveType == DriveType.Fixed)
                    {
                        isCDriveReady = true;
                    }

                    //Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    //Console.WriteLine("  File system: {0}", d.DriveFormat);
                    //Console.WriteLine(
                    //    "  Available space to current user:{0, 15} bytes",
                    //    d.AvailableFreeSpace);

                    //Console.WriteLine(
                    //    "  Total available space:          {0, 15} bytes",
                    //    d.TotalFreeSpace);

                    //Console.WriteLine(
                    //    "  Total size of drive:            {0, 15} bytes ",
                    //    d.TotalSize);
                }
                else
                {
                    MessageBox.Show("No drive in your computer is ready or drives are out of minimum space for this operation\nStop any file operation and try again", "Drives are not ready");
                }

            }

            if (isCDriveReady == true) return "C:\\";

            return "";
        }

        //private void createLocation()
        //{


        //    //if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "data_source_path.txt")))
        //    //{
        //    //    using (StreamReader reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "data_source_path.txt"))) // this line may cause an error
        //    //    {
        //    //        string dataSourcePath = reader.ReadLine();
        //    //        if (!(string.IsNullOrEmpty(dataSourcePath)))
        //    //        {
        //    //            string availableDrive = getAvailableDriveName();
        //    //            if (availableDrive != "")
        //    //            {

        //    //                string p = Path.Combine(availableDrive, "STUDENT RECORDS");
        //    //                using (StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "data_source_path.txt"))) //// true to append data to the file
        //    //                {
        //    //                    writer.WriteLine(p);
        //    //                    writer.Close();
        //    //                }
        //    //                Directory.CreateDirectory(Path.Combine(getAvailableDriveName(), "STUDENT RECORDS"));
        //    //            }
        //    //        }

        //    //        reader.Close();
        //    //    }


        //    //}
        //    //else
        //    //{

        //    //}

        //}
    


        //private string getAvailableDriveName()
        //{
        //    DriveInfo[] allDrives = DriveInfo.GetDrives();
        //    Boolean isCDriveReady = false;

        //    foreach (DriveInfo d in allDrives)
        //    {

        //        //Console.WriteLine("Drive {0}", d.Name);
        //        //Console.WriteLine("  Drive type: {0}", d.DriveType);
        //        if (d.IsReady == true)
        //        {

        //            if (d.Name != "C:\\" && d.TotalFreeSpace >= 1000000000 && d.DriveType == DriveType.Fixed)
        //            {
        //                return d.Name;
        //            }

        //            if (d.Name == "C:\\" && d.TotalFreeSpace >= 5000000000 && d.DriveType == DriveType.Fixed)
        //            {
        //                isCDriveReady = true;
        //            }


        //            //Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
        //            //Console.WriteLine("  File system: {0}", d.DriveFormat);
        //            //Console.WriteLine(
        //            //    "  Available space to current user:{0, 15} bytes",
        //            //    d.AvailableFreeSpace);

        //            //Console.WriteLine(
        //            //    "  Total available space:          {0, 15} bytes",
        //            //    d.TotalFreeSpace);

        //            //Console.WriteLine(
        //            //    "  Total size of drive:            {0, 15} bytes ",
        //            //    d.TotalSize);
        //        }
        //        else
        //        {
        //            MessageBox.Show("No drive in your computer is ready or drives are out of minimum space for this operation\nStop any file operation and try again", "Drives are not ready");
        //        }

        //    }

        //    if (isCDriveReady == true) return "C:\\";

        //    return "";
        //}


    }
}
