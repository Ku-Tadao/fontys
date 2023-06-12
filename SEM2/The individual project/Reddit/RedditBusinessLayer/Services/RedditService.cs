using System.Data.SqlClient;
using System.Collections.Generic;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditBusinessLayer.Services
{
    public class RedditService
    {
        private readonly IPostRepository _postRepository;
        private readonly ISubredditRepository _subredditRepository;
        private readonly IUserRepository _userRepository;

        public RedditService(IPostRepository postRepository, ISubredditRepository subredditRepository,
            IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _subredditRepository = subredditRepository;
            _userRepository = userRepository;
        }

        // No parameters, meaning no need to validate anything.
        public List<Post> GetPosts()
        {
            return _postRepository.GetPosts();
        }

        // No parameters, meaning no need to validate anything.
        public List<Subreddit> GetSubreddits()
        {
            return _subredditRepository.GetSubreddits();
        }

        // No parameters, meaning no need to validate anything.
        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}