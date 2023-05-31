using System.Data.SqlClient;
using System.Collections.Generic;
using RedditDataLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditBusinessLayer.Services
{
    public class SubredditService : ISubredditService
    {
        private readonly string _connectionString;

        public SubredditService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Subreddit> GetSubreddits()
        {
            var subreddits = new List<Subreddit>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Subreddits", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var subreddit = new Subreddit
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Description = reader.GetString(reader.GetOrdinal("Description"))
                            };
                            subreddits.Add(subreddit);
                        }
                    }
                }
            }

            return subreddits;
        }
    }
}