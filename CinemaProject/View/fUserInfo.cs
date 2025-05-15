using CinemaProject.Controller;
using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace CinemaProject.View
{
    public partial class fUserInfo : Form
    {
        public fUserInfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fUserInfo_Load(object sender, EventArgs e)
        {
            try
            {
                string email = Session.LoggedInUserEmail;
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Bạn cần đăng nhập trước khi xem thông tin người dùng.");
                    this.Close();
                    return;
                }

                UserDAO dao = new UserDAO();
                string userName = dao.GetNameCurrentUser(email);
                namelbchange.Text = userName ?? "Không xác định";
                string phone = dao.GetPhoneCurrentUser(email);
                phonenumchange.Text = phone ?? "Không xác định";
                string emailUser = dao.GetEmailCurrentUser(email);
                emailchange.Text = emailUser ?? "Không xác định";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu có lỗi
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Changebtn_Click(object sender, EventArgs e)
        {
            fChangeInfo fChangeInfo = new fChangeInfo();
            fChangeInfo.Show();
            this.Hide();

        }
    }
}
