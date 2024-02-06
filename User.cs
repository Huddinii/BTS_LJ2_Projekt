using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS_LJ2_Projekt
{
    
    internal class User
    {
        private string username;
        private string password;
        private string name;
        private string lastname;

        public string Username { get; }
        public string Password { get; }
        public string Name { get; }
        public string Lastname { get; }

        public User(string Username,string Password, string Name, string Lastname)
        {
            username = Username;
            password = Password;
            name = Name;
            lastname = Lastname;
        }
    }
}
