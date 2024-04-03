using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JwelleryManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
       
        private void Home_Load(object sender, EventArgs e)
        {

        }
        private void registrationToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            registrationToolStripMenuItem.ForeColor = Color.Goldenrod;
        }

        private void registrationToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            registrationToolStripMenuItem.ForeColor = Color.White;
        }

        private void manageEmployeeToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            manageEmployeeToolStripMenuItem.ForeColor = Color.Goldenrod;

        }
        private void manageEmployeeToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            manageEmployeeToolStripMenuItem.ForeColor = Color.White;
        }

        private void dailyExpensiveToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            dailyExpensiveToolStripMenuItem.ForeColor = Color.White;
        }

        private void dailyExpensiveToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            dailyExpensiveToolStripMenuItem.ForeColor = Color.Goldenrod;
        }

        private void salaryReportToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            salaryReportToolStripMenuItem.ForeColor = Color.Goldenrod;
        }

        private void salaryReportToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            salaryReportToolStripMenuItem.ForeColor = Color.White;
        }

        private void salaryReportsToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            salaryReportsToolStripMenuItem.ForeColor = Color.White;
        }

        private void salaryReportsToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            salaryReportsToolStripMenuItem.ForeColor = Color.Goldenrod;
        }

        private void designationToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            designationToolStripMenuItem.ForeColor = Color.Goldenrod;
        }

        private void designationToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            designationToolStripMenuItem.ForeColor = Color.White;
        }

        private void exitToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            exitToolStripMenuItem.ForeColor = Color.Goldenrod;
        }

        private void exitToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            exitToolStripMenuItem.ForeColor = Color.White;
        }
        AddProduct ob1 = new AddProduct();
        customerdetail ob2 = new customerdetail();
        AddOrder ob3 = new AddOrder();
        private void employeeToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            ob1.TopLevel = false;
            panel5.Controls.Add(ob1);
            ob1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ob1.Dock = DockStyle.Fill;
            ob1.Show();
            ob2.Hide();
            ob3.Hide();
        }

        private void exitToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 currentForm = new Form1();
            //currentForm.Show();
            DialogResult result = MessageBox.Show("Do You Want to Exit", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void viewProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dailyExpensiveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ob2.TopLevel = false;
            panel5.Controls.Add(ob2);
            ob2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ob2.Dock = DockStyle.Fill;
            ob2.Show();
            ob1.Hide();
            ob3.Hide();
        }

        private void addOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ob3.TopLevel = false;
            panel5.Controls.Add(ob3);
            ob3.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            ob3.Dock = DockStyle.Fill;
            ob3.Show();
            ob1.Hide();
            ob2.Hide();

        }

    }
}
