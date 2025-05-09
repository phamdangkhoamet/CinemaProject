using CinemaProject.Controller;
using CinemaProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPw.Text;
            //su dung userDAO de kiem tra dang nhap
            UserDAO userDAO = new UserDAO();
            if (userDAO.Login(email, password))
            {
                //neu dang nhap thanh cong thi mo fAdminHomePage
                fAdminHomePage loadf = new fAdminHomePage();
                loadf.Show();
                this.Hide();
            }
            else
            {
                //neu dang nhap khong thanh cong thi hien thi thong bao
                MessageBox.Show("Email hoặc mật khẩu không đúng!");
            }
        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtPw_TextChanged(object sender, EventArgs e)
        {
            txtPw.UseSystemPasswordChar = true;
        }

        private void checkboxShowPW_CheckedChanged(object sender, EventArgs e)
        {
            txtPw.UseSystemPasswordChar = !checkboxShowPW.Checked;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            fSignUp loadf = new fSignUp();
            loadf.Show();
            this.Hide();
        }
    }
}
