using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditBusinessLayer.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            // If the postRepository is null, an ArgumentNullException will be thrown with a message indicating that the postRepository cannot be null.
            _postRepository = postRepository ?? throw new ArgumentNullException();
        }

        public void CreatePost(Post post)
        {
            // If the post is not found, an ArgumentException will be thrown with a message indicating that the post was not found.
            if (post == null) throw new ArgumentException("Post not found.");

            if (post.UserId > 0 && post.SubredditId > 0)
            {
                try
                {
                    _postRepository.CreatePost(post);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Could not create Post");
                }
            }


        }


        public Post GetPostById(int postId)
        {
            // If the postId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the postId must be greater than 0.
            if (postId <= 0) throw new ArgumentOutOfRangeException();
            return _postRepository.GetPostById(postId);
        }

        public List<Post> GetPostsBySubredditId(int subredditId)
        {
            if (subredditId <= 0) throw new ArgumentOutOfRangeException();
            return _postRepository.GetPostsBySubredditId(subredditId);
        }
        
        public List<Post> GetPostsWithSubredditAndUser()
        {
            return _postRepository.GetPostsWithSubredditAndUser();
        }

        public void DeletePost(Post post)
        {
            // If the postId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the postId must be greater than 0.
            if (post.Id <= 0) throw new ArgumentOutOfRangeException();
            _postRepository.DeletePost(post);
        }


        public void UpdatePost(Post post)
        {
            // If the postId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the postId must be greater than 0.
            if (post.Id<= 0) throw new ArgumentOutOfRangeException();
            
            // If the post is not found, an ArgumentException will be thrown with a message indicating that the post was not found.
            if (post == null) throw new ArgumentException("Post not found.");
            post.UpdateTitle(post.Title);
            post.UpdateContent(post.Content);
            _postRepository.UpdatePost(post);
        }


    }
}
