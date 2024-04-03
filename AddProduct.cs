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
    public partial class AddProduct : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=G:\SofsytProjectAsp.Net\JwelleryManagementSystem\JwelleryManagementSystem\JewelleryDatabase1.mdf;Integrated Security=True;User Instance=True");
        public AddProduct()
        {
            InitializeComponent();
            SrNoAUTO();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            panel1.Height = (62 * this.Height) / 100;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 12.75F, FontStyle.Bold);
            datagridShow();
            SrNoAUTO();
        }
        private void SrNoAUTO()
        {
            // int SrNo=0;
            try
            {
                con.Close();
                con.Open();
                DataSet ds = new DataSet();
                ds.Tables.Clear();
                SqlDataAdapter sda = new SqlDataAdapter("Select max(prodid) From product ", con);
                sda.Fill(ds);

                string a1 = ds.Tables[0].Rows[0][0].ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (a1.Trim() != "")
                    {
                        txtuser.Text = (int.Parse(ds.Tables[0].Rows[0][0].ToString()) + 1).ToString();
                    }
                    else
                    {
                        txtuser.Text = "1";
                    }
                }
                else
                {
                    txtuser.Text = "1";
                }
            }
            catch
            {
                txtuser.Text = "1";
            }
            finally
            {
                con.Close();
            }
        }
        public void datagridShow()
        {
            try
            {
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Product ", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.Rows.Clear();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        //    dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = ds.Tables[0].Rows[i][6].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
            catch
            {
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product where prodid = '" + txtuser.Text + "'", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i > 0)
            {
                MessageBox.Show("These Id is Already Exists");

                ds.Clear();
            }
            else if (txtuser.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Please fill Missing Values");
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Product(ProdId,name,description,pergram,price,quantity)values(@ProdId,@name,@description,@pergram,@price,@quantity)", con);
                cmd.Parameters.AddWithValue("@ProdId", txtuser.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@description", textBox2.Text);
                cmd.Parameters.AddWithValue("@pergram", textBox5.Text);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.Parameters.AddWithValue("@quantity", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("Data Inserted Successfully");
                MessageBox.Show("Successfully Added ", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            datagridShow();
            SrNoAUTO();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from product Where prodid = '" + txtuser.Text.ToString() + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Deleted Successfully");
            con.Close();
            datagridShow();
            SrNoAUTO();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Please fill Missing Values");
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("update Product set ProdId=@ProdId,name=@name,description=@description,pergram=@pergram,price=@price,quantity=@quantity where prodid = '"+txtuser.Text+"'", con);
                cmd.Parameters.AddWithValue("@ProdId", txtuser.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@description", textBox2.Text);
                cmd.Parameters.AddWithValue("@pergram", textBox5.Text);
                cmd.Parameters.AddWithValue("@price", textBox3.Text);
                cmd.Parameters.AddWithValue("@quantity", textBox4.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                //MessageBox.Show("Data Inserted Successfully");
                MessageBox.Show("Successfully Updated ", "Product Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            datagridShow();
            SrNoAUTO();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtuser.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch { }
        }
    }
}
