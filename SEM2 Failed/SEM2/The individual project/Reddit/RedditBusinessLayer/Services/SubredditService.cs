using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditBusinessLayer.Services
{
    public class SubredditService
    {
        private readonly ISubredditRepository _subredditRepository;

        public SubredditService(ISubredditRepository subredditRepository)
        {
            // If the subredditRepository is null, an ArgumentNullException will be thrown with a message indicating that the subredditRepository cannot be null.
            _subredditRepository = subredditRepository ?? throw new ArgumentNullException();
        }

        public Subreddit GetSubredditById(int subredditId)
        {
            // If the subredditId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the subredditId must be greater than 0.
            if (subredditId <= 0) throw new ArgumentOutOfRangeException();
            return _subredditRepository.GetSubredditById(subredditId);
        }

        // No parameters, meaning no need to validate anything.
        public List<Subreddit> GetSubreddits()
        {
            return _subredditRepository.GetSubreddits();
        }

        // TODO: Implement page
        public void UpdateSubreddit(Subreddit subreddit)
        {
            // If the subreddit is null, an ArgumentNullException will be thrown with a message indicating that the subreddit cannot be null.
            if (subreddit == null) throw new ArgumentNullException();
            _subredditRepository.UpdateSubreddit(subreddit);
        }
    }
}