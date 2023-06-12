using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using System.Data.SqlClient;

public class PostRepository : IPostRepository
{
    private readonly string _connectionString;

    public PostRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Post> GetPosts()
    {
        // gebruik Try-Catch, geen Finally
        var posts = new List<Post>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("SELECT * FROM Posts", connection))
            {
                using (var reader = command.ExecuteReader())
                {
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
                        posts.Add(post);
                    }
                }
            }
        }
        return posts;
    }

    public Post GetPostById(int postId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("SELECT * FROM Posts WHERE Id= @postId", connection))
            {
                command.Parameters.AddWithValue("@postId", postId);
                using (var reader = command.ExecuteReader())
                {
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
                        return post;
                    }
                }
            }
        }
        return null;
    }

    public List<Post> GetPostsBySubredditId(int subredditId)
    {
        var posts = new List<Post>();
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("SELECT * FROM Posts WHERE SubredditId = @subredditId", connection))
            {
                command.Parameters.AddWithValue("@subredditId", subredditId);
                using (var reader = command.ExecuteReader())
                {
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
                        posts.Add(post);
                    }
                }
            }
        }
        return posts;
    }

    public void UpdatePost(Post post)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("UPDATE Posts SET Title= @title, Content= @content WHERE Id= @id", connection))
            {
                command.Parameters.AddWithValue("@title", post.Title);
                command.Parameters.AddWithValue("@content", post.Content);
                command.Parameters.AddWithValue("@id", post.Id);
                command.ExecuteNonQuery();
            }
        }
    }

    public void CreatePost(Post post)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("INSERT INTO Posts (Title, Content, DateCreated, UserId, SubredditId) VALUES (@title, @content, @dateCreated, @userId, @subredditId)", connection))
            {
                command.Parameters.AddWithValue("@title", post.Title);
                command.Parameters.AddWithValue("@content", post.Content);
                command.Parameters.AddWithValue("@dateCreated", post.DateCreated);
                command.Parameters.AddWithValue("@userId", post.UserId);
                command.Parameters.AddWithValue("@subredditId", post.SubredditId);
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeletePost(Post post)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("DELETE FROM Posts WHERE Id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", post.Id);
                command.ExecuteNonQuery();
            }
        }
    }

    public List<Post> GetPostsWithSubredditAndUser()
    {
        var posts = new List<Post>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand("SELECT p.Id, p.Title, p.Content, p.DateCreated, s.Name AS SubredditName, s.Description AS SubredditDescription FROM Posts p INNER JOIN Subreddits s ON p.SubredditId = s.Id", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var post = new Post(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Title")),
                            reader.GetString(reader.GetOrdinal("Content")),
                            reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                            0,
                            0
                        );

                        post.Subreddit = new Subreddit(
                            0,
                            reader.GetString(reader.GetOrdinal("SubredditName")),
                            reader.GetString(reader.GetOrdinal("SubredditDescription"))
                        );

                        // Use static data for User because Timo said don't create a Login page
                        post.User = new User(
                            1,
                            "ExampleUser1",
                            "ExamplePassword1",
                            "example1@example.com"
                        );

                        posts.Add(post);
                    }
                }
            }
        }

        return posts;
    }

}
