using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Model
{
    public class Staff
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Salary { get; set; }

        public Staff(string email, string password, decimal salary)
        {
            Email = email;
            Password = password;
            Salary = salary;
        }
    }
}
