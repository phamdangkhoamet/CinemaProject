using CinemaProject.Controller;
using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject.View
{
    public partial class uc_editMovie : UserControl
    {
        MovieDAO movieDAO = new MovieDAO();
        public uc_editMovie()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgMovie.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void uc_editMovie_Load(object sender, EventArgs e)
        {
            LoadMovies();
            
        }
        private void ClearForm()
        {
            txtMovieID.Clear();
            txtName.Clear();
            txtGenre.Clear();
            txtDesc.Clear();
            dtpReleaseDate.Value = DateTime.Now;
            imgMovie.Image = null;
        }
        private void LoadMovies()
        {
            dataGridView1.DataSource = movieDAO.GetAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie
            {
                MovieID = txtMovieID.Text,
                Name = txtName.Text,
                Genre = txtGenre.Text,
                Desc = txtDesc.Text,
                ReleaseDate = dtpReleaseDate.Value,
                Img = ImageToByte(imgMovie.Image)
            };
            movieDAO.Update(movie);
            LoadMovies();
        }
        private byte[] ImageToByte(Image img)
        {
            if (img == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie
            {
                MovieID = txtMovieID.Text,
                Name = txtName.Text,
                Genre = txtGenre.Text,
                Desc = txtDesc.Text,
                ReleaseDate = dtpReleaseDate.Value,
                Img = ImageToByte(imgMovie.Image)
            };
            movieDAO.Insert(movie);
            LoadMovies();
        }
        private Image ByteToImage(byte[] data)
        {
            if (data == null) return null;
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMovieID.Text = row.Cells["MovieID"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtGenre.Text = row.Cells["Genre"].Value.ToString();
                txtDesc.Text = row.Cells["Desc"].Value.ToString();
                dtpReleaseDate.Value = Convert.ToDateTime(row.Cells["ReleaseDate"].Value);
                imgMovie.Image = ByteToImage((byte[])row.Cells["Img"].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            movieDAO.Delete(txtMovieID.Text);
            LoadMovies();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
