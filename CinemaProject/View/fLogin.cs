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
            if(CheckboxStaff.Checked)
            {
                StaffDAO staffDAO = new StaffDAO();
                if (staffDAO.LoginasStaff(email, password))
                {
                    fAdminHomePage loadf = new fAdminHomePage();
                    loadf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }
            else
            {
                UserDAO userDAO = new UserDAO();
                if (userDAO.Login(email, password))
                {
                    fGuestHomePage loadf = new fGuestHomePage();
                    loadf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
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

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
