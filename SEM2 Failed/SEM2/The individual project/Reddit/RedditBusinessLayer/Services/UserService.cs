using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditBusinessLayer.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            // If the userRepository is null, an ArgumentNullException will be thrown with a message indicating that the userRepository cannot be null.
            _userRepository = userRepository ?? throw new ArgumentNullException();
        }

        // No parameters, meaning no need to validate anything.
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User GetUserById(int userId)
        {
            // If the userId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the userId must be greater than 0.
            if (userId <= 0) throw new ArgumentOutOfRangeException();
            return _userRepository.GetUserById(userId);
        }

        public void UpdateUser(int userId, string newUsername, string newPassword, string newEmail)
        {
            // If the userId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the userId must be greater than 0.
            if (userId <= 0) throw new ArgumentOutOfRangeException();

            // If the newUsername is null or whitespace, an ArgumentException will be thrown with a message indicating that the newUsername cannot be null or whitespace.
            if (string.IsNullOrWhiteSpace(newUsername)) throw new ArgumentException("New username cannot be null or whitespace.");

            // If the newPassword is null or whitespace, an ArgumentException will be thrown with a message indicating that the newPassword cannot be null or whitespace.
            if (string.IsNullOrWhiteSpace(newPassword)) throw new ArgumentException("New password cannot be null or whitespace.");

            // If the newEmail is null or whitespace, an ArgumentException will be thrown with a message indicating that the newEmail cannot be null or whitespace.
            if (string.IsNullOrWhiteSpace(newEmail)) throw new ArgumentException("New email cannot be null or whitespace.");

            var user = _userRepository.GetUserById(userId);

            // If the user is not found, an ArgumentException will be thrown with a message indicating that the user was not found.
            if (user == null) throw new ArgumentException("User not found.");
            user.UpdateUsername(newUsername);
            user.UpdatePassword(newPassword);
            user.UpdateEmail(newEmail);
            _userRepository.UpdateUser(user);
        }
    }
}
