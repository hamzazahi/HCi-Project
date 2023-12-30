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

    public partial class Menu : Form
    {

        abstract_class a = new abstract_class();
        string constring = "Data Source=LAPTOP-T\\SQLEXPRESS;Initial Catalog=Bakery_Management_System;Integrated Security=True";
        decimal p1;
        decimal p2;
        decimal p3;
        decimal p4;
        decimal total;

        Guid obj = Guid.NewGuid();

        DataTable dtb;


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Menu()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            label2.Font = new Font("Microsoft Sans Serif", 12!, FontStyle.Strikeout);
            label3.Font = new Font("Microsoft Sans Serif", 12!, FontStyle.Strikeout);
            label4.Font = new Font("Microsoft Sans Serif", 12!, FontStyle.Strikeout);
            label5.Font = new Font("Microsoft Sans Serif", 12!, FontStyle.Strikeout);

            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string query = "select * from Products";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            cake.Text = (string)dt.Rows[4]["p_name"];
            Beverage.Text = (string)dt.Rows[1]["p_name"];
            pastry.Text = (string)dt.Rows[5]["p_name"];
            Bakery.Text = (string)dt.Rows[3]["p_name"];
            this.p1 = (decimal)dt.Rows[0]["price"];
            price1.Text = "PKR" + this.p1.ToString();
            this.p2 = (decimal)dt.Rows[5]["price"];
            price2.Text = "PKR" + this.p2.ToString();
            this.p3 = (decimal)dt.Rows[6]["price"];
            price3.Text = "PKR" + this.p3.ToString();
            this.p4 = (decimal)dt.Rows[3]["price"];
            price4.Text = "PKR" + this.p4.ToString();

            CalculateTotal();

            dataGridView1.AutoGenerateColumns = true;
            dtb = new DataTable();

            dtb.Columns.Add("ORDER ID");
            dtb.Columns.Add("PRODUCT NAME");
            dtb.Columns.Add("PRICE");
            dtb.Columns.Add("QUANTITY", typeof(int));

            //result = GUID.NewGuid;
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

        void CalculateTotal()
        {
            int q1 = (int)numericUpDown1.Value;
            int q2 = (int)numericUpDown2.Value;
            int q3 = (int)numericUpDown3.Value;
            int q4 = (int)numericUpDown4.Value;

            decimal t1 = (decimal)q1 * this.p1;
            decimal t2 = (decimal)q2 * this.p2;
            decimal t3 = (decimal)q3 * this.p3;
            decimal t4 = (decimal)q4 * this.p4;

            this.total = t1 + t2 + t3 + t4;
            totalprice.Text = total.ToString();

        }

        private void insert_Click(object sender, EventArgs e)
        {
            CalculateTotal();

            DataRow dtr = dtb.NewRow();

            dtr["ORDER ID"] = obj.ToString();
            dtr["PRODUCT NAME"] = "CHEESE CAKE";
            dtr["PRICE"] = this.p1;
            dtr["QUANTITY"] = (int)numericUpDown1.Value;

            dtb.Rows.Add(dtr);

            dataGridView1.DataSource = dtb;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculateTotal();

            DataRow dtr = dtb.NewRow();

            dtr["ORDER ID"] = obj.ToString();
            dtr["PRODUCT NAME"] = "CHOCOLATE CAKE";
            dtr["PRICE"] = this.p2;
            dtr["QUANTITY"] = (int)numericUpDown2.Value;

            dtb.Rows.Add(dtr);

            dataGridView1.DataSource = dtb;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CalculateTotal();

            DataRow dtr = dtb.NewRow();

            dtr["ORDER ID"] = obj.ToString();
            dtr["PRODUCT NAME"] = "BISCUITS";
            dtr["PRICE"] = this.p3;
            dtr["QUANTITY"] = (int)numericUpDown3.Value;
            dtb.Rows.Add(dtr);

            dataGridView1.DataSource = dtb;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CalculateTotal();


            DataRow dtr = dtb.NewRow();

            dtr["ORDER ID"] = obj.ToString();
            dtr["PRODUCT NAME"] = "DEW";
            dtr["PRICE"] = this.p4;
            dtr["QUANTITY"] = (int)numericUpDown4.Value;
            dtb.Rows.Add(dtr);

            dataGridView1.DataSource = dtb;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            {
                DialogResult dialogResult = MessageBox.Show(
           "Are you sure you want to close the app? All previous progress will be lost.",
           "Warning",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    dtb.Clear();
                    totalprice.Text = "0";
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    numericUpDown3.Value = 0;
                    numericUpDown4.Value = 0;
                    this.total = 0;
                }
                // If 'No' is clicked, nothing happens and the form stays open
            }
               
        }

        public void ResetOrderForm()
        {
            // Clear the DataGridView
            dtb.Clear();

            // Reset the numericUpDown controls
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;

            // Reset the total price label
            totalprice.Text = "0";
            this.total = 0; // If 'total' is a field representing the total price
        }

        private void ShowOrderSummary()
        {
            StringBuilder orderSummary = new StringBuilder();
            decimal totalPrice = 0;

            foreach (DataRow row in dtb.Rows)
            {
                string productName = row["PRODUCT NAME"].ToString();
                // Assuming quantity is stored in your data grid view as well
                int quantity = Convert.ToInt32(row["QUANTITY"]); // Replace with your actual quantity field
                decimal price = Convert.ToDecimal(row["PRICE"]);

                // Calculate the total price for each item line
                decimal lineTotal = quantity * price;
                totalPrice += lineTotal;

                // Append each line item to the order summary
                orderSummary.AppendLine($"{productName} x{quantity} - {price}PKR each, Total: {lineTotal}PKR");
            }

            // Append the grand total at the end
            orderSummary.AppendLine($"Total Price: {totalPrice}PKR");

            MessageBox.Show(orderSummary.ToString(), "Order Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            ///   MessageBox.Show("TOTAL BILL: " + this.total);
            //  totalprice.Text = "0";
            //  numericUpDown1.Value = 0;
            // numericUpDown2.Value = 0;
            // numericUpDown3.Value = 0;
            //  numericUpDown4.Value = 0;
            // this.total = 0;
            // Transcrip a = new Transcrip();
            //  a.Show();

            // ShowOrderSummary();

            CalculateTotal();

            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.FormClosing += ReceiptForm_FormClosing;
            receiptForm.Show();

            // Call the method to generate the receipt
            receiptForm.GenerateReceipt(dtb, total);
        }

        private void ReceiptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetOrderForm();
        }

        private void cake_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void price3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
