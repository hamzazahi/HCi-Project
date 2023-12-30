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
    
    public partial class AdminPanel : Form
    {
        private CustomerDetails _customerDetails;
        private Authentication _authentication = new Authentication();

        abstract_class a = new abstract_class();
        public AdminPanel()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            products a = new products();
            a.Show();
            this.Hide();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            customers a = new customers();
            a.Show();
            this.Hide();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
            this.Hide();
        }
    }
}
