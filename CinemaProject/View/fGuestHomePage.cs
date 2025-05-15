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
        private string email;
        public fGuestHomePage(string email)
        {
            InitializeComponent();
            this.email = email;
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
            LoadMovies("");
        }
        private void LoadMovies(string keyword)
        {
            flowLayoutPanel1.Controls.Clear();
            MovieDAO dao = new MovieDAO();
            List<Movie> movies = string.IsNullOrWhiteSpace(keyword) ? dao.GetAll() : dao.SearchByName(keyword);

            foreach (Movie movie in movies)
            {
                uc_product product = new uc_product(email);
                product.SetMovie(movie);
                flowLayoutPanel1.Controls.Add(product);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            fLogin fLogin = new fLogin();
            fLogin.Show();
            this.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadMovies(keyword);
        }
    }
}
