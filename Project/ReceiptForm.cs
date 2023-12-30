using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem
{
    public partial class ReceiptForm : Form
    {
        public ReceiptForm()
        {
            InitializeComponent();
        }

        public void GenerateReceipt(DataTable orderDetails, decimal total)
        {
            richTextBoxReceipt.Clear();
            richTextBoxReceipt.Clear();
            richTextBoxReceipt.SelectionFont = new Font("Consolas", 12, FontStyle.Bold);
            richTextBoxReceipt.AppendText("PRODUCT".PadRight(20) + "QUANTITY".PadRight(6) + "PRICE\n");
            richTextBoxReceipt.AppendText(new string('-', 40) + "\n"); // Separator line

            richTextBoxReceipt.SelectionFont = new Font("Consolas", 10, FontStyle.Regular);
            foreach (DataRow row in orderDetails.Rows)
            {
                string productName = row["PRODUCT NAME"].ToString().PadRight(20);
                int quantity = Convert.ToInt32(row["QUANTITY"]);
                decimal price = Convert.ToDecimal(row["PRICE"]);
                richTextBoxReceipt.AppendText($"{productName}{quantity.ToString().PadLeft(6)}{price.ToString("0.##").PadLeft(8)}PKR\n");
            }

            richTextBoxReceipt.AppendText(new string('-', 40) + "\n");
            richTextBoxReceipt.SelectionFont = new Font("Consolas", 12, FontStyle.Bold);
            richTextBoxReceipt.AppendText($"TOTAL:".PadRight(30) + $"{total.ToString("0.##").PadLeft(10)}PKR\n");
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBoxReceipt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
