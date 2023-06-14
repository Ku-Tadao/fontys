using RedditBusinessLayer.Entities;

namespace RedditBusinessLayer.Interfaces;

public interface ISubredditRepository
{
    List<Subreddit> GetSubreddits();
    Subreddit GetSubredditById(int subredditId);
    void UpdateSubreddit(Subreddit subreddit);
}