using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaProject.Model
{
    public class User
    {
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
      

        public User(string email, string password, string name, string phone)
        {
            Gmail = email;
            Password = password;
            Name = name;
            PhoneNumber = phone;
          
        }

    }
}
