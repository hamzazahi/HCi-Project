using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
     "Are you sure you want to close the app? All previous progress will be lost.",
     "Warning",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                // Code to close the application
                Application.Exit();
            }
            // If 'No' is clicked, nothing happens and the form stays open
        }

        private void Startapp_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}