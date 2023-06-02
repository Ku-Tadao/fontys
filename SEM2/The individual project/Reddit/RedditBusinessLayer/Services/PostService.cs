using System.Data.SqlClient;
using System.Collections.Generic;
using RedditDataLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditDataLayer;

namespace RedditBusinessLayer.Services
{
    public class PostService : IPostService
    {
        private readonly DatabaseHelper _databaseHelper;

        public PostService(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public void UpdatePost(int postId, string newTitle, string newContent)
        {
            // Retrieve the post from the database
            var post = _databaseHelper.GetPostById(postId);

            // Update the post using the new methods
            post?.UpdateTitle(newTitle);
            post?.UpdateContent(newContent);

            // Save the changes to the database
            _databaseHelper.UpdatePost(post);
        }

        public List<Post> GetPosts()
        {
            return _databaseHelper.GetPosts();
        }

    }
}