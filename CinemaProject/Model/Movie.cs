using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Model
{
    public class Movie
    {
        public string MovieID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Desc { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte[] Img { get; set; }

        public Movie() { }
        public Movie(string movieID, string name, string genre, string desc, DateTime releaseDate, byte[] img)
        {
            MovieID = movieID;
            Name = name;
            Genre = genre;
            Desc = desc;
            ReleaseDate = releaseDate;
            Img = img;
        }
    }
}
