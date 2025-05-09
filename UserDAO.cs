using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Controller
{
    public class UserDAO
    {
        private string connectionString = "Data Source=DESKTOP-HPRPTG8\\DATAHAHA;Initial Catalog=TestCinema;Integrated Security=True";

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User(
                        reader["Email"].ToString(),
                        reader["Password"].ToString(),
                        reader["Name"].ToString(),
                        reader["Phone"].ToString(),
                        Convert.ToDateTime(reader["DateOfBirth"])
                    );
                    users.Add(user);
                }
            }
            return users;
        }
        public void AddUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Email, Password, Name, Phone, DateOfBirth) VALUES (@Email, @Password, @Name, @Phone, @DateOfBirth)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
