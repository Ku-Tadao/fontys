using System.Collections.Generic;
using RedditDataLayer.Entities;

namespace RedditBusinessLayer.Interfaces
{
    public interface ISubredditService
    {
        List<Subreddit> GetSubreddits();
    }
}