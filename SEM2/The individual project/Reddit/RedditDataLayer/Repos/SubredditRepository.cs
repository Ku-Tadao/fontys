using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using System.Data.SqlClient;

public class SubredditRepository : ISubredditRepository
{
    private readonly string _connectionString;

    public SubredditRepository(string connectionString)
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
                        var subreddit = new Subreddit(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetString(reader.GetOrdinal("Description"))
                        );
                        subreddits.Add(subreddit);
                    }
                }
            }
        }
        return subreddits;
    }

    public Subreddit GetSubredditById(int subredditId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("SELECT * FROM Subreddits WHERE Id= @subredditId", connection))
            {
                command.Parameters.AddWithValue("@subredditId", subredditId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var subreddit = new Subreddit(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("Name")),
                            reader.GetString(reader.GetOrdinal("Description"))
                        );
                        return subreddit;
                    }
                }
            }
        }
        return null;
    }

    public void UpdateSubreddit(Subreddit subreddit)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (var command = new SqlCommand("UPDATE Subreddits SET Name= @name, Description= @description WHERE Id= @id", connection))
            {
                command.Parameters.AddWithValue("@name", subreddit.Name);
                command.Parameters.AddWithValue("@description", subreddit.Description);
                command.Parameters.AddWithValue("@id", subreddit.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
