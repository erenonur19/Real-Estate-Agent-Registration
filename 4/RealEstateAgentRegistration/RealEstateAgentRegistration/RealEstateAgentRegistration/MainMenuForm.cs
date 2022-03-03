using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateAgentRegistration
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            ToolTip tt1 = new ToolTip();
           


            tt1.SetToolTip(btnAdd, "Houses");
            tt1.SetToolTip(btnEdit, "Owners");
            tt1.SetToolTip(btnOut, "Return to Homepage");
            tt1.SetToolTip(btnExit, "Exit");
            

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            HouseDetailsForm objChild = new HouseDetailsForm();
            objChild.Show();
            


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            HouseOwnerForm houseowner = new HouseOwnerForm();
            houseowner.Show();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to Log Out?";
            string title = "LOG OUT";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoginForm form1sec = new LoginForm();
                form1sec.Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to Exit?";
            string title = "EXIT";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.Goldenrod;
            label4.BackColor = Color.Black;


            timer1.Enabled = true;

            timer2.Enabled = true;
            welcoming.Text = "WELCOME TO THE REGISTRATION SYSTEM!                                     ";
            if (DateTime.Now.Hour>6 && DateTime.Now.Hour <= 12)
            {
                label1.Text = "Good Morning!";
            }
            else if(DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 18)
            {
                label1.Text = "Good Afternoon!";
            }
            else if (DateTime.Now.Hour > 18 && DateTime.Now.Hour <= 23)
            {
                label1.Text = "Good Evenings!";
            }
            else
                label1.Text = "Good Night!";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            welcoming.Text = welcoming.Text.Substring(1) + welcoming.Text.Substring(0, 1);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
