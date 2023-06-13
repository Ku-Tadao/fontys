// In the RedditDataLayer project

using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using System.Data;
using System.Data.SqlClient;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<User> GetUsers()
    {
        var users = new List<User>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Users", connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var user = new User(
                reader.GetInt32("Id"),
                reader.GetString("Username"),
                reader.GetString("Password"),
                reader.GetString("Email")
            );
            users.Add(user);
        }

        return users;
    }

    public User GetUserById(int userId)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Users WHERE Id= @userId", connection);
        command.Parameters.AddWithValue("@userId", userId);
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        var user = new User(
            reader.GetInt32("Id"),
            reader.GetString("Username"),
            reader.GetString("Password"),
            reader.GetString("Email")
        );
        return user;

    }

    public void UpdateUser(User user)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("UPDATE Users SET Username= @username, Password= @password, Email= @email WHERE Id= @id", connection);
        command.Parameters.AddWithValue("@username", user.Username);
        command.Parameters.AddWithValue("@password", user.Password);
        command.Parameters.AddWithValue("@email", user.Email);
        command.Parameters.AddWithValue("@id", user.Id);
        command.ExecuteNonQuery();
    }
}
