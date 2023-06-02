using System.Data.SqlClient;
using RedditDataLayer.Entities;

namespace RedditDataLayer;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(string connectionString)
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
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Username")),
                reader.GetString(reader.GetOrdinal("Password")),
                reader.GetString(reader.GetOrdinal("Email"))
            );

            users.Add(user);
        }

        return users;
    }

    public User? GetUserById(int userId)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Users WHERE Id = @userId", connection);
        command.Parameters.AddWithValue("@userId", userId);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var user = new User(
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Username")),
                reader.GetString(reader.GetOrdinal("Password")),
                reader.GetString(reader.GetOrdinal("Email"))
            );
            ;
            return user;
        }

        return null;
    }

    public void UpdateUser(User? user)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command =
            new SqlCommand(
                "UPDATE Users SET Username = @username, Password = @password, Email = @email WHERE Id = @id",
                connection);
        command.Parameters.AddWithValue("@username", user?.Username);
        command.Parameters.AddWithValue("@password", user?.Password);
        command.Parameters.AddWithValue("@email", user?.Email);
        command.Parameters.AddWithValue("@id", user?.Id);
        command.ExecuteNonQuery();
    }

    public List<Post> GetPosts()
    {
        var posts = new List<Post>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Posts", connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var post = new Post(
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Title")),
                reader.GetString(reader.GetOrdinal("Content")),
                reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                reader.GetInt32(reader.GetOrdinal("UserId")),
                reader.GetInt32(reader.GetOrdinal("SubredditId"))
            );
            ;
            posts.Add(post);
        }

        return posts;
    }

    public Post? GetPostById(int postId)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Posts WHERE Id = @postId", connection);
        command.Parameters.AddWithValue("@postId", postId);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var post = new Post(
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Title")),
                reader.GetString(reader.GetOrdinal("Content")),
                reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                reader.GetInt32(reader.GetOrdinal("UserId")),
                reader.GetInt32(reader.GetOrdinal("SubredditId"))
            );
            ;
            return post;
        }

        return null;
    }

    public void UpdatePost(Post? post)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("UPDATE Posts SET Title = @title, Content = @content WHERE Id = @id",
            connection);
        command.Parameters.AddWithValue("@title", post?.Title);
        command.Parameters.AddWithValue("@content", post?.Content);
        command.Parameters.AddWithValue("@id", post?.Id);
        command.ExecuteNonQuery();
    }

    public List<Subreddit> GetSubreddits()
    {
        var subreddits = new List<Subreddit>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Subreddits", connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var subreddit = new Subreddit(
                reader.GetInt32(reader.GetOrdinal("Id")),
                reader.GetString(reader.GetOrdinal("Name")),
                reader.GetString(reader.GetOrdinal("Description"))
            );
            subreddits.Add(subreddit);
        }

        return subreddits;
    }

    public Subreddit? GetSubredditById(int subredditId)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Subreddits WHERE Id = @subredditId", connection);
        command.Parameters.AddWithValue("@subredditId", subredditId);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var subreddit = new Subreddit
            (reader.GetInt32(reader.GetOrdinal("Id")), reader.GetString(reader.GetOrdinal("Name")),
                reader.GetString(reader.GetOrdinal("Description")));
            return subreddit;
        }

        return null;
    }

    public void UpdateSubreddit(Subreddit? subreddit)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command =
            new SqlCommand("UPDATE Subreddits SET Name= @name, Description= @description WHERE Id= @id",
                connection);
        command.Parameters.AddWithValue("@name", subreddit?.Name);
        command.Parameters.AddWithValue("@description", subreddit?.Description);
        command.Parameters.AddWithValue("@id", subreddit?.Id);
        command.ExecuteNonQuery();
    }
}