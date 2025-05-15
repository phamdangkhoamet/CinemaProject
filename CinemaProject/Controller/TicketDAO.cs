using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Controller
{
    public class TicketDAO
    {
        private string connectionString = "Data Source=PHAMPHA\\PHAMPHA;Initial Catalog=laptrinh;User ID=sa;Password=123456";
        public List<string> GetBookedSeatsByShowtime(string idShowtime)
        {
            List<string> bookedSeats = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SeatCode FROM Ticket WHERE IDShowtime = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idShowtime);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookedSeats.Add(reader.GetString(0));
                }
            }
            return bookedSeats;
        }
        public void AddTickets(string idShowtime, List<string> selectedSeats)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (string seat in selectedSeats)
                {
                    // Kiểm tra nếu đã tồn tại thì không thêm lại
                    string checkQuery = "SELECT COUNT(*) FROM Ticket WHERE IDShowtime = @id AND SeatCode = @seat";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id", idShowtime);
                    checkCmd.Parameters.AddWithValue("@seat", seat);
                    int exists = (int)checkCmd.ExecuteScalar();

                    if (exists == 0)
                    {
                        string insertQuery = "INSERT INTO Ticket (IDShowtime, SeatCode) VALUES (@id, @seat)";
                        SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@id", idShowtime);
                        insertCmd.Parameters.AddWithValue("@seat", seat);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
