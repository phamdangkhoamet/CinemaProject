using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Model
{
    public class Showtime
    {
        public string IDShowtime { get; set; }
        public string IDMovie { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowTime { get; set; }
        public int Price { get; set; } = 45000;

        public Showtime()
        {
            Price = 45000;
        }

        public Showtime(string idShowtime, string idMovie, DateTime showDate, string showTime, int price = 45000)
        {
            IDShowtime = idShowtime;
            IDMovie = idMovie;
            ShowDate = showDate;
            ShowTime = showTime;
            Price = price;
        }

    }
}
