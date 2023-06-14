using RedditBusinessLayer.Entities;

namespace RedditBusinessLayer.Interfaces;

public interface IPostRepository
{
    List<Post> GetPostsBySubredditId(int subredditId);
    List<Post> GetPostsWithSubredditAndUser();
    Post GetPostById(int postId);
    void UpdatePost(Post post);
    void CreatePost(Post post);
    void DeletePost(Post post);
}