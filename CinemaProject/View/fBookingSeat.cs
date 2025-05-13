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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinemaProject.View
{
    public partial class fBookingSeat : Form
    {
        private ShowtimeDAO showtimeDAO;
        private Movie movie;
        private TicketDAO ticketDAO;
        private List<string> selectedSeats = new List<string>();
        public fBookingSeat(Movie movie)
        {
            InitializeComponent();
            this.movie = movie;
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void click(string time)
        {
            
            string selectedTime = time; 
            string idShowtime = showtimeDAO.GetShowtimeIDByMovieDateTime(movie.MovieID, selectedTime);

            if (idShowtime == null)
            {
                MessageBox.Show("Không tìm thấy suất chiếu!");
                return;
            }

            LoadBookedSeats(idShowtime);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void LoadBookedSeats(string idShowtime)
        {
            var bookedSeats = ticketDAO.GetBookedSeatsByShowtime(idShowtime);

            foreach (Control ctrl in seatPanel.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button seatButton)
                {
                    if (bookedSeats.Contains(seatButton.Text))
                    {
                        seatButton.FillColor = Color.Gray;
                        seatButton.Enabled = false;
                    }
                    else
                    {
                        seatButton.FillColor = Color.LightGray;
                        seatButton.Enabled = true;
                    }
                }
            }
        }
        private void AddSeatClickEvents()
        {
            foreach (Control ctrl in seatPanel.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.Click += SeatButton_Click;
                }
            }
        }
        private void SeatButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna.UI2.WinForms.Guna2Button;
            if (btn == null) return;

            string seatName = btn.Text;

            if (selectedSeats.Contains(seatName))
            {
             
                selectedSeats.Remove(seatName);
                btn.FillColor = Color.LightGray; // màu mặc định
            }
            else
            {
                // Chọn ghế
                selectedSeats.Add(seatName);
                btn.FillColor = Color.LightGreen; // màu ghế được chọn
            }

            // Cập nhật label hiển thị ghế đã chọn
            lblSelectedSeats.Text = "Ghế đã chọn: " + string.Join(", ", selectedSeats);
        }
        private void fBookingSeat_Load(object sender, EventArgs e)
        {

        }

        private void seatPanel_Click(object sender, EventArgs e)
        {

        }

        private void seatPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
