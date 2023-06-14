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

        // No parameters, meaning no need to validate anything.
        public List<Post> GetPosts()
        {
            return _postRepository.GetPosts();
        }

        public Post GetPostById(int postId)
        {
            // If the postId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the postId must be greater than 0.
            if (postId <= 0) throw new ArgumentOutOfRangeException();
            return _postRepository.GetPostById(postId);
        }

        // Not being used yet
        public void UpdatePost(int postId, string newTitle, string newContent)
        {
            // If the postId is less than or equal to 0, an ArgumentOutOfRangeException will be thrown with a message indicating that the postId must be greater than 0.
            if (postId <= 0) throw new ArgumentOutOfRangeException();
            
            // If the newTitle is null or whitespace, an ArgumentException will be thrown with a message indicating that the newTitle cannot be null or whitespace.
            if (string.IsNullOrWhiteSpace(newTitle)) throw new ArgumentException("New title cannot be null or whitespace.");
            
            // If the newContent is null or whitespace, an ArgumentException will be thrown with a message indicating that the newContent cannot be null or whitespace.
            if (string.IsNullOrWhiteSpace(newContent)) throw new ArgumentException("New content cannot be null or whitespace.");

            var post = _postRepository.GetPostById(postId);
            
            // If the post is not found, an ArgumentException will be thrown with a message indicating that the post was not found.
            if (post == null) throw new ArgumentException("Post not found.");
            post.UpdateTitle(newTitle);
            post.UpdateContent(newContent);
            _postRepository.UpdatePost(post);
        }
    }
}
