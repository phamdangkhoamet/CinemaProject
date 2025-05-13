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
        private string connectionString = "Data Source=PHAMPHA\\PHAMPHA;Initial Catalog=laptrinh;User ID=sa;Password=123456";
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
                        reader["Gmail"].ToString(),
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
                string query = "INSERT INTO Users (Gmail, Password, Name, Phone, DateOfBirth) VALUES (@Gmail, @Password, @Name, @Phone, @DateOfBirth)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", user.Gmail);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateUser(string gmail, User updatedUser)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @Password, Name = @Name, Phone = @Phone, DateOfBirth = @DateOfBirth WHERE Gmail = @Gmail";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", gmail);
                cmd.Parameters.AddWithValue("@Password", updatedUser.Password);
                cmd.Parameters.AddWithValue("@Name", updatedUser.Name);
                cmd.Parameters.AddWithValue("@Phone", updatedUser.Phone);
                cmd.Parameters.AddWithValue("@DateOfBirth", updatedUser.DateOfBirth);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool Login(string username, string password) {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Gmail = @Gmail AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    // User exists
                    Console.WriteLine("Login successful");
                    return true;
                }
                else
                {
                    // User does not exist
                    Console.WriteLine("Invalid username or password");
                    return false;
                }
            }
        }
    }
}
