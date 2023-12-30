using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BakeryManagementSystem
{
    public partial class login : Form
    {
        public string ConnectionString = "Data Source=DESKTOP-J5N6AFS\\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True";
        abstract_class a = new abstract_class();

        private Authentication authentication = new Authentication();

        public login()
        {

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Admin" )
            {
                adminlogin();
            }
            else if (comboBox1.SelectedItem.ToString() == "Client")
            {

                clientlogin();
            }
            else if (textBox1.Text.ToString() == "" || textBox2.Text.ToString() == "")
            {
                MessageBox.Show("Invalid Username or Password!");
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void signup_Click(object sender, EventArgs e)
        {
            SignUp reg = new SignUp();
            reg.Show();
            this.Hide();
        }

        public void adminlogin()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-T\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True");
                using (SqlCommand cmd = new SqlCommand("adminlogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@passwordd", textBox2.Text.Trim());

                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        MessageBox.Show("Login Successfull!");
                        this.Hide();
                        // AdminPanel a = new AdminPanel();
                        AdminPanel a = new AdminPanel();
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter username and password!");
            }
        }

        public void clientlogin()
        {
            if (textBox1.Text != "" || textBox2.Text != "" || comboBox1.Text == "")
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-T\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True");
                using (SqlCommand cmd = new SqlCommand("userlogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@passwordd", textBox2.Text.Trim());

                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        MessageBox.Show("Login Successfull!");
                        this.Hide();
                        Menu a = new Menu();

                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter username and password!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
