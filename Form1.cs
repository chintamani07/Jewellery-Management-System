using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JwelleryManagementSystem
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=G:\SofsytProjectAsp.Net\JwelleryManagementSystem\JwelleryManagementSystem\JewelleryDatabase1.mdf;Integrated Security=True;User Instance=True");
        public Form1()
        {
            InitializeComponent();
        }
        public static string UserName;

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Width = this.Width / 2;
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == "" || txtpassword.Text.Trim() == "")
            {
                MessageBox.Show("Please fill missing values");
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from LoginTable where username = '" + txtuser.Text + "' and password='" + txtpassword.Text + "'", con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //    int count = ds.Tables[0].Rows.Count;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Login Successfully");
                    UserName = txtuser.Text;
                    Home h1 = new Home();
                    h1.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username and Password is not Correct");
                }
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpassword.Text = "";
        }
    }
}
