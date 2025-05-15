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
using System.Windows.Forms;

namespace CinemaProject.View
{
    public partial class fChangeInfo : Form
    {
        public fChangeInfo()
        {
            InitializeComponent();
        }

        private void Changebtn_Click(object sender, EventArgs e)
        {
            string newname = txtNamechange.Text;
            string newphone = txtPhonenew.Text;
            string newpassword = txtPassnew.Text; // Lưu ý: Tên biến 'newemail' có thể gây nhầm lẫn vì nó lấy từ txtPassnew (có thể là mật khẩu?)

            UserDAO userDAO = new UserDAO();
            User updatedUser = new User(Session.LoggedInUserEmail, newpassword, newname, newphone); // Tạo đối tượng User mới

            try
            {
                userDAO.UpdateUser(Session.LoggedInUserEmail, updatedUser);
                MessageBox.Show("Cập nhật thông tin thành công");
                this.Hide();
                fLogin loadF = new fLogin();
                loadF.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cập nhật thông tin thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void txtPassnew_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
