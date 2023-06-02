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
                            var post = new Post(
                                reader.GetInt32(reader.GetOrdinal("Id")),
                                reader.GetString(reader.GetOrdinal("Title")),
                                reader.GetString(reader.GetOrdinal("Content")),
                                reader.GetDateTime(reader.GetOrdinal("DateCreated")),
                                reader.GetInt32(reader.GetOrdinal("UserId")),
                                reader.GetInt32(reader.GetOrdinal("SubredditId"))
                            ); ;
                            posts.Add(post);
                        }
                    }
                }
            }

            return posts;
        }
    }
}