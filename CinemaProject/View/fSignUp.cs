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
    public partial class fSignUp : Form
    {
        public fSignUp()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            fLogin loadF = new fLogin();
            this.Hide();
            loadF.Show();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            txtPW_SignUp.UseSystemPasswordChar = true;
        }

        private void btnSignUp_fSignUp_Click(object sender, EventArgs e)
        {
            
        }

        private void checkboxShowPW_SU_CheckedChanged(object sender, EventArgs e)
        {
            txtPW_SignUp.UseSystemPasswordChar = !checkboxShowPW_SU.Checked;
        }
    }
}
