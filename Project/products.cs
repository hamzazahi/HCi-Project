using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Data.SqlClient;

namespace BakeryManagementSystem
{
    public partial class products : Form
    {
        abstract_class a = new abstract_class();
        string constring = "Data Source=LAPTOP-T\\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True";
        int cat_id;

        public products()
        {
            InitializeComponent();
            //  BindGridView();
        }

        private void products_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "--Select--";
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

        private void Startapp_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {
            clearBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse = new OpenFileDialog();
            browse.Title = "Select Image";
            browse.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.GIF)|*.PNG;*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";

            if (browse.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(browse.FileName);
            }
        }
        public void insertCake()
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "InsertProduct";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            int cat_id = 1;

            cmd.Parameters.AddWithValue("@cat_id", cat_id);
            cmd.Parameters.AddWithValue("@name", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@price", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@quantity", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@descp", textBox4.Text.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success!");
            clearBoxes();
        }
        public void insertPasteries()
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "InsertProduct";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            int cat_id = 3;

            cmd.Parameters.AddWithValue("@cat_id", cat_id);
            cmd.Parameters.AddWithValue("@name", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@price", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@quantity", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@descp", textBox4.Text.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success!");
            clearBoxes();
        }
        public void insertBeverages()
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "InsertProduct";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            int cat_id = 2;

            cmd.Parameters.AddWithValue("@cat_id", cat_id);
            cmd.Parameters.AddWithValue("@name", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@price", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@quantity", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@descp", textBox4.Text.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success!");
            clearBoxes();
        }
        public void insertBakeryItems()
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "InsertProduct";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            int cat_id = 4;

            cmd.Parameters.AddWithValue("@cat_id", cat_id);
            cmd.Parameters.AddWithValue("@name", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@price", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@quantity", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@descp", textBox4.Text.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success!");
            clearBoxes();
        }

        void clearBoxes()
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "---Select---";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            pictureBox1.Image = null;
            ID.Text = "";

        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Cakes")
            {
                insertCake();
                BindGridView();
            }
            else if (comboBox1.SelectedItem.ToString() == "Beverages")
            {
                insertBeverages();
                BindGridView();
            }
            else if (comboBox1.SelectedItem.ToString() == "Pastries")
            {
                insertPasteries();
                BindGridView();
            }
            else if (comboBox1.SelectedItem.ToString() == "Bakery Items")
            {
                insertBakeryItems();
                BindGridView();
            }
            else
            {
                MessageBox.Show("ERROR!");
                clearBoxes();
            }
        }
        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("ViewProducts", con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Cakes_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("ViewCakes", con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void pastry_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("ViewPast", con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Bakery_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("ViewBI", con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void beverages_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("ViewBev", con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void all_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlDataAdapter DA = new SqlDataAdapter("ViewProducts", con);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void delete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show(
      "Are you sure you want to close the app? All previous progress will be lost.",
      "Warning",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(constring);
                string query = "delete from Products where p_id=@id";
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
            // If 'No' is clicked, nothing happens and the form stays open

            //   SqlConnection con = new SqlConnection(constring);
            //  string query = "delete from Products where p_id=@id";
            //  SqlCommand cmd = new SqlCommand(query, con);
            //   cmd.Parameters.AddWithValue("@id", ID.Text);

            //  con.Open();
            //   int a = cmd.ExecuteNonQuery();
            //   if (a > 0)
            //   {
            //       MessageBox.Show("Successfully Deleted!");
            //       BindGridView();
            //       clearBoxes();
            //   }
            // else
            // {
            // MessageBox.Show("Delete Failed!");
            // BindGridView();
            // clearBoxes();
            // }
            // con.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Cakes")
            {
                this.cat_id = 1;
            }
            else if (comboBox1.SelectedItem.ToString() == "Beverages")
            {
                this.cat_id = 2;
            }
            else if (comboBox1.SelectedItem.ToString() == "Pastries")
            {
                this.cat_id = 3;
            }
            else if (comboBox1.SelectedItem.ToString() == "Bakery Items")
            {
                this.cat_id = 4;
            }
            SqlConnection con = new SqlConnection(constring);
            string query = "update Products set p_name=@p_name, price=@price, quantity=@quantity, p_description=@p_description, cat_id=@cat_id where p_id=@p_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@p_id", ID.Text);
            cmd.Parameters.AddWithValue("@p_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@quantity", textBox3.Text);
            cmd.Parameters.AddWithValue("@p_description", textBox4.Text);
            cmd.Parameters.AddWithValue("@cat_id", this.cat_id);
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

        private void button4_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customers a = new customers();
            a.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
