using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem
{
    public class abstract_class : Form
    {
        
        public void Home()
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
        public void Exit()
        {
            Application.Exit();
        }
        public void SignIn()
        {
            login a = new login();
            a.Show();
            this.Hide();
        }
        public void SignUp ()
        {
            SignUp a = new SignUp();
            a.Show();
            this.Hide();
        }
        public void Menu()
        {
            Menu a = new Menu();
            a.Show();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // abstract_class
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "abstract_class";
            this.Load += new System.EventHandler(this.abstract_class_Load);
            this.ResumeLayout(false);

        }

        private void abstract_class_Load(object sender, EventArgs e)
        {

        }
    }
}
