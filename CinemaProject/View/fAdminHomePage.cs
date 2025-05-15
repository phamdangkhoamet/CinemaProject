using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject.View
{
    public partial class fAdminHomePage : Form
    {
        public fAdminHomePage()
        {
            InitializeComponent();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
               uc_dashBoard1.Visible = true;
               uc_dashBoard1.BringToFront();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            uc_addStaff1.Visible = true;
            uc_addStaff1.BringToFront();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            uc_editGuest1.Visible = true;
            uc_editGuest1.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uc_editGuest1_Load(object sender, EventArgs e)
        {

        }

        private void uc_editGuest1_Load_1(object sender, EventArgs e)
        {

        }

        private void uc_adminHomePage_Load(object sender, EventArgs e)
        {
            uc_dashBoard1.Visible=true;
            uc_dashBoard1.BringToFront();
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            uc_editMovie1.Visible=true;
            uc_editMovie1.BringToFront();
        }

        private void uc_editMovie1_Load(object sender, EventArgs e)
        {

        }

        private void uc_dashBoard1_Load(object sender, EventArgs e)
        {

        }

        private void uc_addStaff1_Load(object sender, EventArgs e)
        {

        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            uc_addShowTime1.Visible=true;
            uc_addShowTime1.BringToFront();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            fLogin fLogin = new fLogin();
            fLogin.Show();
            this.Close();
        }
    }
}
