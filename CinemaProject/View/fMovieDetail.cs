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
    public partial class fMovieDetail : Form
    {
        public fMovieDetail(Movie movie)
        {
            InitializeComponent();
            LoadMovieData(movie);
        }
        private void LoadMovieData(Movie movie)
        {
            lblName.Text = movie.Name;
            lblGenre.Text = "Thể loại: " + movie.Genre;
            lblDesc.Text = "Mô tả: " + movie.Desc;
            lblDate.Text = "Ngày phát hành: " + movie.ReleaseDate.ToShortDateString();

            if (movie.Img != null)
            {
                using (MemoryStream ms = new MemoryStream(movie.Img))
                {
                    guna2PictureBox1.Image = Image.FromStream(ms);
                }
            }
        }


        private void fMovieDetail_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
