using RedditDataLayer.Entities;

namespace RedditBusinessLayer.Interfaces;

public interface IPostService
{
    List<Post> GetPosts();
}