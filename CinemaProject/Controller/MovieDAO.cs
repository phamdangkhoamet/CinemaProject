using CinemaProject.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CinemaProject.Controller
{
    public class MovieDAO
    {
        private string connectionString = "Data Source=PHAMPHA\\PHAMPHA;Initial Catalog=laptrinh;User ID=sa;Password=123456";

        public List<Movie> GetAll()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Movie", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(ReadMovie(reader));
                }
            }
            return movies;
        }

        public List<Movie> SearchByName(string keyword)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Movie WHERE Name LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(ReadMovie(reader));
                }
            }
            return movies;
        }

        private Movie ReadMovie(SqlDataReader reader)
        {
            return new Movie
            {
                MovieID = reader["MovieID"].ToString(),
                Name = reader["Name"].ToString(),
                Genre = reader["Genre"].ToString(),
                Desc = reader["Desc"].ToString(),
                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
                Img = (byte[])reader["Img"]
            };
        }

        public void Insert(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Movie VALUES (@ID, @Name, @Genre, @Desc, @ReleaseDate, @Img)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", movie.MovieID);
                cmd.Parameters.AddWithValue("@Name", movie.Name);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Desc", movie.Desc);
                cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                cmd.Parameters.AddWithValue("@Img", movie.Img);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Movie SET Name=@Name, Genre=@Genre, [Desc]=@Desc, ReleaseDate=@ReleaseDate, Img=@Img WHERE MovieID=@ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", movie.MovieID);
                cmd.Parameters.AddWithValue("@Name", movie.Name);
                cmd.Parameters.AddWithValue("@Genre", movie.Genre);
                cmd.Parameters.AddWithValue("@Desc", movie.Desc);
                cmd.Parameters.AddWithValue("@ReleaseDate", movie.ReleaseDate);
                cmd.Parameters.AddWithValue("@Img", movie.Img);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string movieID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Movie WHERE MovieID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", movieID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
