using System.Data.SqlClient;
using System.Collections.Generic;
using RedditDataLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditDataLayer;

namespace RedditBusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseHelper _databaseHelper;

        public UserService(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public void UpdateUser(int userId, string newUsername, string newPassword, string newEmail)
        {
            // Retrieve the user from the database
            var user = _databaseHelper.GetUserById(userId);

            // Update the user using the new methods
            user?.UpdateUsername(newUsername);
            user?.UpdatePassword(newPassword);
            user?.UpdateEmail(newEmail);

            // Save the changes to the database
            _databaseHelper.UpdateUser(user);
        }

        public List<User> GetUsers()
        {
            return _databaseHelper.GetUsers();
        }
    }
}