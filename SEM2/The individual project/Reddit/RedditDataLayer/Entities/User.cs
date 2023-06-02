using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditDataLayer.Entities
{

    public class User
    {
        public User(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public void UpdateUsername(string newUsername)
        {
            // Perform any necessary validation or other logic here
            Username = newUsername;
        }

        public void UpdatePassword(string newPassword)
        {
            // Perform any necessary validation or other logic here
            Password = newPassword;
        }

        public void UpdateEmail(string newEmail)
        {
            // Perform any necessary validation or other logic here
            Email = newEmail;
        }
    }
}
