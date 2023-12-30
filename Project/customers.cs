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
    public partial class customers : Form
    {
        abstract_class a = new abstract_class();
        string constring = "Data Source=LAPTOP-T\\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True";

        public customers()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            products a = new products();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
            this.Hide();
        }
        void clearBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            ID.Text = "";

        }
        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("ViewCustomers", con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void ID_Click(object sender, EventArgs e)
        {

        }

        private void customers_Load(object sender, EventArgs e)
        {
            BindGridView();
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
            this.Hide();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "delete from loginn where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ID.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Deleted!");
                BindGridView();
                clearBoxes();
            }
            else
            {
                MessageBox.Show("Delete Failed!");
                BindGridView();
                clearBoxes();
            }
            con.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "update loginn set username=@username, FullName=@fullname, passwordd=@passwordd, address_=@address, phone=@phone, cnic=@cnic where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ID.Text);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text);
            cmd.Parameters.AddWithValue("@passwordd", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@cnic", textBox6.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Successfully Updated!");
                BindGridView();
                clearBoxes();
            }
            else
            {
                MessageBox.Show("Update Failed!");
                BindGridView();
                clearBoxes();
            }
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            Role.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }
        public void RegUser ()
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "LoginUser";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            int role_id = 2;

            cmd.Parameters.AddWithValue("@roleid", role_id);
            cmd.Parameters.AddWithValue("@username", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@fullname", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@passwordd", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@address_", textBox4.Text.ToString());
            cmd.Parameters.AddWithValue("@phone", textBox5.Text.ToString());
            cmd.Parameters.AddWithValue("@cnic", textBox6.Text.ToString());

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success!");
            clearBoxes();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            RegUser();
            clearBoxes();
            BindGridView();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearBoxes();
        }
    }
}
