using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject.View
{
    public partial class uc_product : UserControl
    {
        private Movie currentMovie;
        private string email;
        public uc_product(string email)
        {
            InitializeComponent();
            this.email = email; 
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void SetMovie(Movie movie)
        {
            label1.Text = movie.Name;
            currentMovie = movie;

            if (movie.Img != null)
            {
                using (MemoryStream ms = new MemoryStream(movie.Img))
                {
                    guna2PictureBox1.Image = Image.FromStream(ms);
                }
            }
            this.Click += Uc_product_Click;
            guna2ShadowPanel1.Click += Uc_product_Click;
            guna2PictureBox1.Click += Uc_product_Click;
            label1.Click += Uc_product_Click;
        }
        private void Uc_product_Click(object sender, EventArgs e)
        {
            if (currentMovie != null)
            {
                fMovieDetail detailForm = new fMovieDetail(currentMovie, email);
                detailForm.ShowDialog(); 
            }
        }
        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
