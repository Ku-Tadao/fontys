using System.Data.SqlClient;

namespace RedditProject.Models
{
    public class DatabaseHelper
    {
        private string _connectionString = "Server=.\\SQLExpress;Database=reddit;Trusted_Connection=Yes;";
        
        public List<Post> GetPosts()
        {
            var posts = new List<Post>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Posts", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var post = new Post
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Content = reader.GetString(2),
                            DateCreated = reader.GetDateTime(3),
                            UserId = reader.GetInt32(4),
                            SubredditId = reader.GetInt32(5)
                        };

                        posts.Add(post);
                    }
                }
            }

            return posts;
        }

        public List<Subreddit> GetSubreddits()
        {
            var subreddits = new List<Subreddit>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Subreddits", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var subreddit = new Subreddit
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2)
                        };

                        subreddits.Add(subreddit);
                    }
                }
            }

            return subreddits;
        }

        public List<User> GetUsers()
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT * FROM Users", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            Id = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Password = reader.GetString(2),
                            Email = reader.GetString(3)
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }


    }
}