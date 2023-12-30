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
    public partial class SignUp : Form
    {
        string constring = "Data Source=LAPTOP-T\\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True";
        abstract_class a = new abstract_class();
        public SignUp()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox2;
            textBox1.Enabled = false; 
            textBox1.Text = "2";
            textBox1.ReadOnly = true;
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
      "Are you sure you want to close the app? All previous progress will be lost.",
      "Warning",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Code to close the application
                a.Exit();
                this.Hide();
            }
            // If 'No' is clicked, nothing happens and the form stays open
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.Home();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            a.SignIn();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            string pname = "LoginUser";
            con.Open();
            SqlCommand cmd = new SqlCommand(pname, con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@roleid", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@username", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@fullname", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@passwordd", textBox4.Text.ToString());
            cmd.Parameters.AddWithValue("@address_", textBox5.Text.ToString());
            cmd.Parameters.AddWithValue("@phone", textBox6.Text.ToString());
            cmd.Parameters.AddWithValue("@cnic", textBox7.Text.ToString());

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success!");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();   
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            a.SignIn();
            this.Hide();
        }
    }
}
