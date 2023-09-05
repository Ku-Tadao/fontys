using System.Data;
using System.Data.SqlClient;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditDataLayer.Repos;

public class PostRepository : IPostRepository
{
    private readonly string _connectionString;

    public PostRepository(string connectionString)
    {
        _connectionString = connectionString;
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
                reader.GetInt32("Id"),
                reader.GetString("Title"),
                reader.GetString("Content"),
                reader.GetDateTime("DateCreated"),
                reader.GetInt32("UserId"),
                reader.GetInt32("SubredditId")
            );
            posts.Add(post);
        }

        return posts;
    }

    public Post GetPostById(int postId)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Posts WHERE Id= @postId", connection);
        command.Parameters.AddWithValue("@postId", postId);
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        var post = new Post(
            reader.GetInt32("Id"),
            reader.GetString("Title"),
            reader.GetString("Content"),
            reader.GetDateTime("DateCreated"),
            reader.GetInt32("UserId"),
            reader.GetInt32("SubredditId")
        );
        return post;

    }

    public List<Post> GetPostsBySubredditId(int subredditId)
    {
        var posts = new List<Post>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT * FROM Posts WHERE SubredditId = @subredditId", connection);
        command.Parameters.AddWithValue("@subredditId", subredditId);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var post = new Post(
                reader.GetInt32("Id"),
                reader.GetString("Title"),
                reader.GetString("Content"),
                reader.GetDateTime("DateCreated"),
                reader.GetInt32("UserId"),
                reader.GetInt32("SubredditId")
            );
            posts.Add(post);
        }

        return posts;
    }

    public void UpdatePost(Post post)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("UPDATE Posts SET Title= @title, Content= @content WHERE Id= @id", connection);
        command.Parameters.AddWithValue("@title", post.Title);
        command.Parameters.AddWithValue("@content", post.Content);
        command.Parameters.AddWithValue("@id", post.Id);
        command.ExecuteNonQuery();
    }

    public void CreatePost(Post post)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("INSERT INTO Posts (Title, Content, DateCreated, UserId, SubredditId) VALUES (@title, @content, @dateCreated, @userId, @subredditId)", connection);
        command.Parameters.AddWithValue("@title", post.Title);
        command.Parameters.AddWithValue("@content", post.Content);
        command.Parameters.AddWithValue("@dateCreated", post.DateCreated);
        command.Parameters.AddWithValue("@userId", post.UserId);
        command.Parameters.AddWithValue("@subredditId", post.SubredditId);
        command.ExecuteNonQuery();
    }

    public void DeletePost(Post post)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("DELETE FROM Posts WHERE Id = @id", connection);
        command.Parameters.AddWithValue("@id", post.Id);
        command.ExecuteNonQuery();
    }

    public List<Post> GetPostsWithSubredditAndUser()
    {
        var posts = new List<Post>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = new SqlCommand("SELECT p.Id, p.Title, p.Content, p.DateCreated, s.Id as SubredditId, s.Name AS SubredditName, s.Description AS SubredditDescription, u.Id AS UserId, u.Username FROM Posts p INNER JOIN Subreddits s ON p.SubredditId = s.Id INNER JOIN Users u ON p.UserId = u.Id", connection);
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var userId = reader.GetInt32(reader.GetOrdinal("UserId"));
            var subredditId = reader.GetInt32(reader.GetOrdinal("SubredditId"));

            var post = new Post(
                reader.GetInt32("Id"),
                reader.GetString("Title"),
                reader.GetString("Content"),
                reader.GetDateTime("DateCreated"),
                userId,
                subredditId)
            {
                Subreddit = new Subreddit(
                    subredditId,
                    reader.GetString("SubredditName"),
                    reader.GetString("SubredditDescription")),
                User = new User(
                    userId,
                    reader.GetString("Username"),
                    null,
                    null)
            };
            posts.Add(post);
        }

        return posts;
    }



}