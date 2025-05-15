using CinemaProject.Controller;
using CinemaProject.Model;
using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QRCoder;
using System.Net.Mail;
using System.Net;


namespace CinemaProject.View
{
    public partial class fBookingSeat : Form
    {
        private ShowtimeDAO showtimeDAO;
        private Movie movie;
        private TicketDAO ticketDAO;
        private List<string> selectedSeats = new List<string>();
        private string selectedShowTime;
        private string email;
        public fBookingSeat(Movie movie, string email)
        {
            InitializeComponent();
            this.movie = movie;
            this.showtimeDAO = new ShowtimeDAO(); 
            this.ticketDAO = new TicketDAO();
            this.email = email;
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
            click("18:00");
            selectedShowTime = "18:00";
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
                        seatButton.FillColor = Color.Red;
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
        private void LoadMovieData(Movie movie)
        {
            lblName.Text = movie.Name;
            lblGenre.Text = "Thể loại: " + movie.Genre;
            lblDate.Text = "Ngày chiếu: " + movie.ReleaseDate.ToShortDateString();

    
        }

        private void fBookingSeat_Load(object sender, EventArgs e)
        {
            LoadMovieData(movie);
            foreach (Control ctrl in seatPanel.Controls)
            {
                if (ctrl is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.Click += guna2Button25_Click;
                }
            }
        }

        private void seatPanel_Click(object sender, EventArgs e)
        {

        }

        private void seatPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            click("19:00");
            selectedShowTime = "19:00";
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            string seat = btn.Text;

            if (selectedSeats.Contains(seat))
            {
                
                selectedSeats.Remove(seat);
                btn.FillColor = Color.LightGray; 
            }
            else
            {
                selectedSeats.Add(seat);
                btn.FillColor = Color.LightGreen; 
            }
            int pricePerSeat = 45000;
            int total =  selectedSeats.Count * pricePerSeat;
            lblSelectedSeats.Text = "Ghế đã chọn: " + string.Join(", ", selectedSeats);
            lblTotal.Text = "Tổng tiền: " + total.ToString("N0") + " VNĐ";
        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn ghế nào.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Xác nhận thanh toán:\nChủ tài khoản: PhamDangKhoa\nSTK: 12345590\nNgân hàng: XYZ",
                "Xác nhận thanh toán",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                string selectedTime = selectedShowTime;
                DateTime selectedDate = DateTime.Today;
                int price = 45000;

                string idShowtime = showtimeDAO.GetOrCreateShowtime(movie.MovieID, selectedDate, selectedTime, price);

                if (string.IsNullOrEmpty(idShowtime))
                {
                    MessageBox.Show("Không thể tạo hoặc lấy suất chiếu.");
                    return;
                }

                ticketDAO.AddTickets(idShowtime, selectedSeats);

                // Gửi email
                SendTicketEmail(
                    email,     
                    movie.Name,
                    selectedTime,
                    selectedSeats,
                    selectedSeats.Count * price
                );

                MessageBox.Show("Đặt vé thành công!");

                selectedSeats.Clear();
                lblSelectedSeats.Text = "Ghế đã chọn:";
                lblTotal.Text = "Tổng tiền:";
                LoadBookedSeats(idShowtime);
            }
            else
            {
                MessageBox.Show("Đã huỷ thanh toán. Vé chưa được đặt.");
            }
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            click("20:00");
            selectedShowTime = "20:00";
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            click("21:00");
            selectedShowTime = "21:00";
        }
        private void SendTicketEmail(string toEmail, string movieName, string time, List<string> seats, int total)
        {
            try
            {
                string body = $"<h2>Đặt vé xem phim thành công!</h2>" +
                              $"<p><b>Phim:</b> {movieName}</p>" +
                              $"<p><b>Suất chiếu:</b> {time} - Ngày: {DateTime.Today.ToShortDateString()}</p>" +
                              $"<p><b>Ghế:</b> {string.Join(", ", seats)}</p>" +
                              $"<p><b>Tổng tiền:</b> {total.ToString("N0")} VNĐ</p>";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("youremail@gmail.com");      
                mail.To.Add(toEmail);
                mail.Subject = "Xác nhận đặt vé xem phim";
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("tipoffkill307@gmail.com", "ronkdzkjwzatrhid"), 
                    EnableSsl = true,
                };

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi email thất bại: " + ex.Message);
            }
        }
    }
 }

