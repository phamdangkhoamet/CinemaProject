using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Controller
{
    public class StaffDAO
    {
        private string connectionString = "Data Source=PHAMPHA\\PHAMPHA;Initial Catalog=laptrinh;User ID=sa;Password=123456";

        public List<Staff> GetAllStaff()
        {
            List<Staff> staffList = new List<Staff>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Staff";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Staff staff = new Staff(
                        reader["Email"].ToString(),
                        reader["Password"].ToString(),
                        Convert.ToDecimal(reader["Salary"])
                    );
                    staffList.Add(staff);
                }
                conn.Close();
            }

            return staffList;
        }

        public void AddStaff(Staff staff)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Staff (Email, Password, Salary) VALUES (@Email, @Password, @Salary)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", staff.Email);
                cmd.Parameters.AddWithValue("@Password", staff.Password);
                cmd.Parameters.AddWithValue("@Salary", staff.Salary);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public bool UpdateStaff(string email, Staff updatedStaff)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Staff SET Password = @Password, Salary = @Salary WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", updatedStaff.Password);
                cmd.Parameters.AddWithValue("@Salary", updatedStaff.Salary);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                return rows > 0;
            }
        }

        public bool DeleteStaff(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Staff WHERE Email = @Email";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                return rows > 0;
            }
        }
        public bool LoginasStaff(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Staff WHERE Email = @Email AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                   
                    return true;
                }
                else
                {
                 
                    return false;
                }
                conn.Close();
            }
        }
    }
}
