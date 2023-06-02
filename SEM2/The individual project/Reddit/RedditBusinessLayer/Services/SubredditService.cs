using System.Data.SqlClient;
using System.Collections.Generic;
using RedditDataLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditDataLayer;

namespace RedditBusinessLayer.Services
{
    public class SubredditService : ISubredditService
    {
        private readonly DatabaseHelper _databaseHelper;

        public SubredditService(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public void UpdateSubrxeddit(int subredditId, string newName, string newDescription)
        {
            // Retrieve the subreddit from the database
            var subreddit = _databaseHelper.GetSubredditById(subredditId);

            // Update the subreddit using the new methods
            subreddit?.UpdateName(newName);
            subreddit?.UpdateDescription(newDescription);

            // Save the changes to the database
            _databaseHelper.UpdateSubreddit(subreddit);
        }

        public List<Subreddit> GetSubreddits()
        {
            return _databaseHelper.GetSubreddits();
        }
    }

}