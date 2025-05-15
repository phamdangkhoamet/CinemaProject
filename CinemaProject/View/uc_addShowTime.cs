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
    public partial class uc_addShowTime : UserControl
    {
        MovieDAO movieDAO = new MovieDAO();
        ShowtimeDAO showtimeDAO = new ShowtimeDAO();
        public uc_addShowTime()
        {
            InitializeComponent();
        }
        private void LoadMovies()
        {
            MovieDAO movieDAO = new MovieDAO();
            var list = movieDAO.GetAll();
            cbMovie.DataSource = list;
            cbMovie.DisplayMember = "Name";
            cbMovie.ValueMember = "MovieID";
        }
        private void uc_addShowTime_Load(object sender, EventArgs e)
        {
            LoadMovies();
            LoadShowtimes();
        }
        private void LoadShowtimes()
        {
            dataGridView1.DataSource = showtimeDAO.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string idShowtime = "ST" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
            string idMovie = cbMovie.SelectedValue?.ToString();
            DateTime showDate = dtpDate.Value.Date;
            string showTime = cbShowTime.SelectedItem?.ToString();
            int price = 45000;

            if (string.IsNullOrEmpty(idMovie) || string.IsNullOrEmpty(showTime))
            {
                MessageBox.Show("Please select movie and showtime!");
                return;
            }

          
            if (showtimeDAO.Exists(idMovie, showDate, showTime))
            {
                MessageBox.Show("This movie already has a showtime at this time on the selected date!");
                return;
            }
            
            Showtime st = new Showtime(idShowtime, idMovie, showDate, showTime, price);
            showtimeDAO.Insert(st);
            LoadShowtimes();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells["IDShowtime"].Value.ToString();
                showtimeDAO.Delete(id);
                LoadShowtimes();
            }
        }
    }
}
