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
    public partial class fGuestHomePage : Form
    {
        public fGuestHomePage()
        {
            InitializeComponent();
        }

        private void btnMovie_Click(object sender, EventArgs e)
        {
            
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fGuestHomePage_Load(object sender, EventArgs e)
        {
            MovieDAO dao = new MovieDAO();
            List<Movie> movies = dao.GetAll();

            foreach (Movie movie in movies)
            {
                uc_product product = new uc_product();
                product.SetMovie(movie);
                flowLayoutPanel1.Controls.Add(product);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Email hiện tại khi nhấp avatar: {Session.LoggedInUserEmail}");
            if (string.IsNullOrEmpty(Session.LoggedInUserEmail))
            {
                MessageBox.Show("Vui lòng đăng nhập trước.");
                fLogin loginForm = new fLogin();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                fUserInfo fUserInfo = new fUserInfo();
                fUserInfo.Show();
                this.Hide();
            }

        }
    }
}
