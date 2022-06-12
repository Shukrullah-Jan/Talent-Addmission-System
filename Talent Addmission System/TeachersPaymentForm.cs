using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Talent_Addmission_System
{
    public partial class TeachersPaymentForm : Form
    {

        private DBAccess database = new DBAccess(Dashboard.dataSourcePath);
        private Functions functions = new Functions();
        private string iName, iID, iLastName, iDesignation;

        private double totalAmount = 0.0;
        private float percentage = 0.0f;
        private float allowance = 0.0f;
        private float deductions = 0.0f;
        private double netSalary = 0.0f;

        public TeachersPaymentForm()
        {
            InitializeComponent();
        }

        private void TeachersPaymentForm_Load(object sender, EventArgs e)
        {
            // set date and time of today
            dtpCurrentDate.Text = DateTime.Now.ToLongDateString();

            // disable controls
            tbInstructorID.Enabled = false;
            tbInstructorName.Enabled = false;
            tbLastName.Enabled = false;
            tbDesignation.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;
            tbUnpaidAmount.Enabled = false;

            // enable some controls

            tbTotalAmountToReduct.Enabled = true;
            numericUpDownPercentage.Enabled = true;

            tbInstructorID.Text = functions.getNewInstructorID().ToString();

            fillListBox();
            fillHistoryRTB();
        }


        private void chbEnableEditing_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnableEditing.Checked)
            {
                tbInstructorName.Enabled = true;
                tbLastName.Enabled = true;
                tbDesignation.Enabled = true;
                btnAdd.Enabled = true;
                btnRemove.Enabled = true;
            }
            else
            {
                tbInstructorName.Enabled = false;
                tbLastName.Enabled = false;
                tbDesignation.Enabled = false;
                btnAdd.Enabled = false;
                btnRemove.Enabled = false;
            }
        }




    
        private void chbFixedSalary_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFixedSalary.Checked)
            {
                lblTotalSalaryToReduct.Text = "Fixed salary amount: ";
                numericUpDownPercentage.Enabled = false;
                numericUpDownPercentage.Value = 0;

            }
            else
            {
                lblTotalSalaryToReduct.Text = "Total amount to reduct: ";
                numericUpDownPercentage.Enabled = true;

            }


        }



        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbInstructorName.Text))
            {
                tbInstructorName.Focus();
                MessageBox.Show("Instructor name and last name is required!!!", "Required Fields");
                return;
            }

            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                tbLastName.Focus();
                MessageBox.Show("Instructor name and last name is required!!!", "Required Fields");
                return;
            }


            iID = tbInstructorID.Text.Trim();
            iName = tbInstructorName.Text.Trim();
            iLastName = tbLastName.Text.Trim();
            iDesignation = tbDesignation.Text.Trim();

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

                string query = "INSERT INTO " + Dashboard.paymentTableName + " (instructorID, instructorName, lastName, designation) " +
                          "VALUES (@iID, @iName, @iLastName, @iDesignation)";
                OleDbCommand insertCommand = new OleDbCommand(query);
                insertCommand.Parameters.AddWithValue("@instructorID", iID);
                insertCommand.Parameters.AddWithValue("@instructorName", iName);
                insertCommand.Parameters.AddWithValue("@lastName", iLastName);
                insertCommand.Parameters.AddWithValue("@designation", iDesignation);


                try
                {
                    database.executeQuery(insertCommand);

                    fillListBox();

                    // reset some controls
                    tbInstructorID.Text = functions.getNewInstructorID().ToString();
                    tbInstructorName.Text = "";
                    tbLastName.Text = "";
                    tbDesignation.Text = "";

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error!!! Can't insert instructor to database\n" + ex.Message);

                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }


            }


        }
        private void lbInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbInstructors.Items.Count > 0)
            {
                string id = lbInstructors.Text.Substring(0, lbInstructors.Text.LastIndexOf(":"));

                DataTable mInstructors = new DataTable();
                string query = "Select * from " + Dashboard.paymentTableName + " Where instructorID = '" + id + "'";

                database.readDatathroughAdapter(query, mInstructors);

                if (mInstructors.Rows.Count > 0)
                {
                    lblInstructorID.Text = mInstructors.Rows[0]["instructorID"].ToString();
                    lblInstructorName.Text = mInstructors.Rows[0]["instructorName"].ToString();
                    lblLastName.Text = mInstructors.Rows[0]["lastName"].ToString();

                    string desig = mInstructors.Rows[0]["designation"].ToString();
                    lblDesignation.Text = desig;
                }

                fillHistoryRTB();
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (lbInstructors.Items.Count > 0)
            {

                DialogResult result = MessageBox.Show("Do you really want to remove " +
                        lbInstructors.Text.Substring(lbInstructors.Text.LastIndexOf(":") + 2)
                        + " from database? ", "Delete record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {

                        int getID = int.Parse(lbInstructors.Text.Substring(0, lbInstructors.Text.LastIndexOf(":")));
                        string query = "Delete From " + Dashboard.paymentTableName +
                            " where instructorID = '" + getID.ToString() + "'";


                        OleDbCommand deleteCommand = new OleDbCommand(query);
                        int row = database.executeQuery(deleteCommand);

                        if (row > 0)
                        {
                            fillListBox();
                            tbInstructorID.Text = functions.getNewInstructorID().ToString();
                            rtbHistory.Text = "";
                            fillHistoryRTB();
                            MessageBox.Show("Instructor with ID " + getID + " removed successfully from database", "Delete Instructor");

                        }
                        else
                        {
                            MessageBox.Show("Error!!!\nInstructor with ID" + getID + " can't be deleted");

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

                }

            }
        }

        private void btnPaySalary_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to pay instructor's salary? ", "Pay Salary", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                string id = lblInstructorID.Text;
                string name = lblInstructorName.Text;
                string lastName = lblLastName.Text;
                string designation = lblDesignation.Text;
                string paymentDate = dtpCurrentDate.Text;
                string percentage = numericUpDownPercentage.Value.ToString() + "%";
                string totalAmount = tbTotalAmountToReduct.Text;
                string reward = tbReward.Text;
                string expenses = tbExpenses.Text;
                string netSalary = tbNetSalary.Text;
                string paidSalary = tbPaidAmount.Text;
                string unpaidSalary = tbUnpaidAmount.Text;

                if (chbFixedSalary.Checked)
                {

                    string query1 = "INSERT INTO " + Dashboard.paymentTableName + " (instructorID, instructorName, lastName," +
                        " designation, paymentDate, totalAmountToReduct," +
                        " allowances, deductions, netsalary, paidAmount, unpaidAmount) " +
                              "VALUES (@id, @name, @lastName, @designation, @paymentDate, @totalAmount," +
                              " @reward, @expenses, @netSalary, @paidSalary, @unpaidSalary)";
                    OleDbCommand insertCommand1 = new OleDbCommand(query1);
                    insertCommand1.Parameters.AddWithValue("@instructorID", id);
                    insertCommand1.Parameters.AddWithValue("@instructorName", name);
                    insertCommand1.Parameters.AddWithValue("@lastName", lastName);
                    insertCommand1.Parameters.AddWithValue("@designation", designation);
                    insertCommand1.Parameters.AddWithValue("@paymentDate", paymentDate);
                    insertCommand1.Parameters.AddWithValue("@totalAmountToReduct", totalAmount);
                    insertCommand1.Parameters.AddWithValue("@allowances", reward);
                    insertCommand1.Parameters.AddWithValue("@expenses", expenses);
                    insertCommand1.Parameters.AddWithValue("@netSalary", netSalary);
                    insertCommand1.Parameters.AddWithValue("@paidAmount", paidSalary);
                    insertCommand1.Parameters.AddWithValue("@unpaidAmount", unpaidSalary);


                    try
                    {
                        database.executeQuery(insertCommand1);

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error!!! Can't insert instructor to database\n" + ex.Message);

                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                }
                else
                {
                    string query = "INSERT INTO " + Dashboard.paymentTableName + " (instructorID, instructorName, lastName," +
                     " designation, paymentDate, totalAmountToReduct," +
                      "percentage, allowances, deductions, netsalary, paidAmount, unpaidAmount) " +
                    "VALUES (@id, @name, @lastName, @designation, @paymentDate, @totalAmount," +
                    "@percentage, @reward, @expenses, @netSalary, @paidSalary, @unpaidSalary)";
                    OleDbCommand insertCommand = new OleDbCommand(query);
                    insertCommand.Parameters.AddWithValue("@instructorID", id);
                    insertCommand.Parameters.AddWithValue("@instructorName", name);
                    insertCommand.Parameters.AddWithValue("@lastName", lastName);
                    insertCommand.Parameters.AddWithValue("@designation", designation);
                    insertCommand.Parameters.AddWithValue("@paymentDate", paymentDate);
                    insertCommand.Parameters.AddWithValue("@totalAmountToReduct", totalAmount);
                    insertCommand.Parameters.AddWithValue("@percentage", percentage);
                    insertCommand.Parameters.AddWithValue("@allowances", reward);
                    insertCommand.Parameters.AddWithValue("@expenses", expenses);
                    insertCommand.Parameters.AddWithValue("@netSalary", netSalary);
                    insertCommand.Parameters.AddWithValue("@paidAmount", paidSalary);
                    insertCommand.Parameters.AddWithValue("@unpaidAmount", unpaidSalary);


                    try
                    {
                        database.executeQuery(insertCommand);

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error!!! Can't insert instructor to database\n" + ex.Message);

                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }


                database.closeConn();
                fillHistoryRTB();
            }

        }

        private void numericUpDownPercentage_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownPercentage.Value > 100) numericUpDownPercentage.Value = 100;
            else if (numericUpDownPercentage.Value < 0) numericUpDownPercentage.Value = 0;
        }

        private void tbPaidSalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double netSalary = double.Parse(tbNetSalary.Text.Trim());
                double paidSalary = double.Parse(tbPaidAmount.Text.Trim());


                tbUnpaidAmount.Text = (netSalary - paidSalary).ToString();

            }
            catch (FormatException)
            {
                return;
            }
        }

        private void btnCalculateSalary_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(tbTotalAmountToReduct.Text)) totalAmount = 0.0;
                else totalAmount = double.Parse(tbTotalAmountToReduct.Text.Trim());

                if (string.IsNullOrWhiteSpace(tbReward.Text)) allowance = 0.0f;
                else allowance = float.Parse(tbReward.Text.Trim());

                if (string.IsNullOrWhiteSpace(tbExpenses.Text)) deductions = 0.0f;
                else deductions = float.Parse(tbExpenses.Text.Trim());

                if (chbFixedSalary.Checked)
                {
                    netSalary = (totalAmount + allowance) - deductions;

                    tbNetSalary.Text = String.Format("{0:0.00}", netSalary);

                }
                else
                {
                    percentage = float.Parse(numericUpDownPercentage.Value.ToString());

                    netSalary = ((totalAmount * percentage / 100) + allowance) - deductions;

                    tbNetSalary.Text = String.Format("{0:0.00}", netSalary);
                }




            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error!!! Fields contain letters\nFor calculations enter numbers into fields", "Can't calculate"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void fillListBox()
        {
            lbInstructors.Items.Clear();
            HashSet<string> instructorsList = new HashSet<string>();

            DataTable dtInstructors = new DataTable();
            string query = "Select * from " + Dashboard.paymentTableName;

            try
            {
                database.createConn();
                database.readDatathroughAdapter(query, dtInstructors);

                if (dtInstructors.Rows.Count > 0)
                {
                    foreach (DataRow row in dtInstructors.Rows)
                    {


                        string instructorID = row["instructorID"].ToString();
                        string formatedRow = instructorID + ": " + row["instructorName"].ToString() +
                         ", " + row["lastName"].ToString();
                        instructorsList.Add(formatedRow);
                    }

                    foreach (var row in instructorsList)
                    {
                        lbInstructors.Items.Add(row);
                    }

                    lbInstructors.SelectedIndex = 0;
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Can't read instructorID column\n" + ex.Message);

            }
            database.closeConn();
        }

        private void fillHistoryRTB()
        {

            if (lbInstructors.Items.Count > 0)
            {
                string id = lbInstructors.Text.Substring(0, lbInstructors.Text.LastIndexOf(":"));

                DataTable mInstructors = new DataTable();
                string query = "Select * from " + Dashboard.paymentTableName + " Where instructorID = '" + id + "'";

                database.readDatathroughAdapter(query, mInstructors);

                if (mInstructors.Rows.Count > 0)
                {
                    rtbHistory.Text = "";
                    for (var index = 0; index < mInstructors.Rows.Count; index++)
                    {
                        if (!(string.IsNullOrWhiteSpace(mInstructors.Rows[index]["paymentDate"].ToString())))
                        {
                            rtbHistory.Text += "--------------------------------------------------------------------\n";
                            rtbHistory.Text += "Payment Date: " + mInstructors.Rows[index]["paymentDate"].ToString() + "\n";
                            rtbHistory.Text += "--------------------------------------------------------------------\n";

                            if (!(string.IsNullOrWhiteSpace(mInstructors.Rows[index]["percentage"].ToString())))
                            {
                                rtbHistory.Text += "Total amount to reduct: " + mInstructors.Rows[index]["totalAmountToReduct"].ToString() + "\n";
                                rtbHistory.Text += "Percentage: " + mInstructors.Rows[index]["percentage"].ToString() + "\n";
                            }
                            else
                            {
                                rtbHistory.Text += "Fixed salary amount: " + mInstructors.Rows[index]["totalAmountToReduct"].ToString() + "\n";

                            }

                            rtbHistory.Text += "Allowances: " + mInstructors.Rows[index]["allowances"].ToString() + "\n";
                            rtbHistory.Text += "Deductions: " + mInstructors.Rows[index]["deductions"].ToString() + "\n";
                            rtbHistory.Text += "Net Salary: " + mInstructors.Rows[index]["netSalary"].ToString() + "\n";
                            rtbHistory.Text += "Paid Amount: " + mInstructors.Rows[index]["paidAmount"].ToString() + "\n";
                            rtbHistory.Text += "Unpaid Amount: " + mInstructors.Rows[index]["unpaidAmount"].ToString() + "\n";
                            rtbHistory.Text += "\n\n";
                        }
        
                    }

                }

                // move the cursor to the end of rich text box
                rtbHistory.SelectionStart = rtbHistory.Text.Length;
                rtbHistory.ScrollToCaret();

            }

        } 
        

    }

}
