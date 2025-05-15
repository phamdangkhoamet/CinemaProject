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
                        reader["Gmail"].ToString(),
                        reader["Password"].ToString(),
                        reader["Name"].ToString(),
                        reader["PhoneNumber"].ToString()
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
                string query = "INSERT INTO Users (Gmail, Password, Name, PhoneNumber) VALUES (@Gmail, @Password, @Name, @PhoneNumber)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", user.Gmail);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateUser(string gmail, User updatedUser)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @Password, Name = @Name, PhoneNumber = @PhoneNumber WHERE Gmail = @Gmail";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", gmail);
                cmd.Parameters.AddWithValue("@Password", updatedUser.Password); // Sử dụng mật khẩu từ updatedUser
                cmd.Parameters.AddWithValue("@Name", updatedUser.Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", updatedUser.PhoneNumber);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                // Có thể thêm kiểm tra rowsAffected > 0 để xác nhận cập nhật thành công
            }
        }
        public bool Login(string username, string password)
        {
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
        public string GetNameCurrentUser(string gmail)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Name FROM Users WHERE Gmail = @Gmail";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", gmail);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["Name"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        public string GetPhoneCurrentUser(string gmail)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PhoneNumber FROM Users WHERE Gmail = @Gmail";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", gmail);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["PhoneNumber"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        public string GetEmailCurrentUser(string gmail)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Gmail FROM Users WHERE Gmail = @Gmail";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", gmail);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["Gmail"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }
        public User GetCurrentUser(string gmail)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Gmail = @Gmail";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Gmail", gmail);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User(
                        reader["Gmail"].ToString(),
                        reader["Password"].ToString(),
                        reader["Name"].ToString(),
                        reader["PhoneNumber"].ToString()
                    );
                }
                else
                {
                    return null;
                }
            }
        }
        public bool ChangePassword(string email, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Password = @NewPassword WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0; // Trả về true nếu cập nhật thành công
            }
        }
        public bool UpdatePassword(string newPassword)
        {
            if (!string.IsNullOrEmpty(Session.LoggedInUserEmail))
            {
                UserDAO userDAO = new UserDAO();
                return userDAO.ChangePassword(Session.LoggedInUserEmail, newPassword);
            }
            else
            {
                Console.WriteLine("No user is logged in.");
                return false;
            }
        }
    }
}
