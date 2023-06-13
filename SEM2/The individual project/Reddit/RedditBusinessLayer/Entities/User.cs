namespace RedditBusinessLayer.Entities
{
    public class User
    {
        public User(int id, string username, string password, string email)
        {
            Id = id;
            UpdateUsername(username);
            UpdatePassword(password);
            UpdateEmail(email);
        }

        public int Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public void UpdateUsername(string newUsername)
        {
            if (string.IsNullOrWhiteSpace(newUsername))
                throw new ArgumentException("Username cannot be empty or whitespace.");
            if (newUsername.Length > 20)
                throw new ArgumentException("Username cannot be longer than 20 characters.");
            Username = newUsername;
        }

        public void UpdatePassword(string newPassword)
        {
            //Don't have a login system
            //if (string.IsNullOrWhiteSpace(newPassword))
            //    throw new ArgumentException("Password cannot be empty or whitespace.");
            //if (newPassword.Length < 8)
            //    throw new ArgumentException("Password must be at least 8 characters long.");
            Password = newPassword;
        }

        public void UpdateEmail(string newEmail)
        {
            //Don't have a login system
            //    if (string.IsNullOrWhiteSpace(newEmail))
            //        throw new ArgumentException("Email cannot be empty or whitespace.");
            //    if (!newEmail.Contains("@"))
            //throw new ArgumentException("Email must contain an '@' symbol.");
            Email = newEmail;
        }
    }
}