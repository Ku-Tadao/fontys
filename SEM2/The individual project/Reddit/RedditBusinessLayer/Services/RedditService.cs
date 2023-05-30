using System.Data.SqlClient;
using System.Collections.Generic;
using RedditDataLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditBusinessLayer.Services
{
    public class RedditService : IPostService
    {
        private readonly string _connectionString;

        public RedditService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Post> GetPosts()
        {
            var posts = new List<Post>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Post", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var post = new Post
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                SubredditId = reader.GetInt32(reader.GetOrdinal("SubredditId"))
                            };
                            posts.Add(post);
                        }
                    }
                }
            }

            return posts;
        }
    }
}