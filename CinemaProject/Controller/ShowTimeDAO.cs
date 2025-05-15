using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Controller
{
    public class ShowtimeDAO
    {
        private string connectionString = "Data Source=PHAMPHA\\PHAMPHA;Initial Catalog=laptrinh;User ID=sa;Password=123456";


        public void Insert(Showtime st)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Showtime (IDShowtime, IDMovie, ShowDate, ShowTime, Price) " +
                                   "VALUES (@ID, @MovieID, @Date, @Time, @Price)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", st.IDShowtime);
                    cmd.Parameters.AddWithValue("@MovieID", st.IDMovie);
                    cmd.Parameters.AddWithValue("@Date", st.ShowDate);
                    cmd.Parameters.AddWithValue("@Time", st.ShowTime);
                    cmd.Parameters.AddWithValue("@Price", st.Price);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert error: " + ex.Message);
            }
        }

        public void Delete(string showtimeID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Showtime WHERE IDShowtime = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", showtimeID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete error: " + ex.Message);
            }
        }

        public List<Showtime> GetAll()
        {
            List<Showtime> list = new List<Showtime>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Showtime", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Showtime st = new Showtime
                        {
                            IDShowtime = reader["IDShowtime"].ToString(),
                            IDMovie = reader["IDMovie"].ToString(),
                            ShowDate = Convert.ToDateTime(reader["ShowDate"]),
                            ShowTime = reader["ShowTime"].ToString(),
                            Price = Convert.ToInt32(reader["Price"])
                        };
                        list.Add(st);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAll error: " + ex.Message);
            }
            return list;
        }
        public bool Exists(string movieID, DateTime date, string time)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Showtime WHERE IDMovie = @MovieID AND ShowDate = @Date AND ShowTime = @Time";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovieID", movieID);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Time", time);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public string GetShowtimeIDByMovieDateTime(string idMovie, string time)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IDShowtime FROM Showtime WHERE IDMovie = @idMovie AND ShowTime = @time";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idMovie", idMovie);
                cmd.Parameters.AddWithValue("@time", time);
                var result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }
        public string GetOrCreateShowtime(string movieId, DateTime showDate, string showTime, int price)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IDShowtime FROM Showtime WHERE IDMovie = @movieId AND ShowDate = @date AND ShowTime = @time";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@date", showDate);
                cmd.Parameters.AddWithValue("@time", showTime);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
                string newID = Guid.NewGuid().ToString("N").Substring(0, 10); // tạo ID ngắn
                string insertQuery = "INSERT INTO Showtime (IDShowtime, IDMovie, ShowDate, ShowTime, Price) VALUES (@id, @movieId, @date, @time, @price)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@id", newID);
                insertCmd.Parameters.AddWithValue("@movieId", movieId);
                insertCmd.Parameters.AddWithValue("@date", showDate);
                insertCmd.Parameters.AddWithValue("@time", showTime);
                insertCmd.Parameters.AddWithValue("@price", price);
                insertCmd.ExecuteNonQuery();

                return newID;
            }
        }

    }
}
