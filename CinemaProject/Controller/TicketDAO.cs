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
    }
}
