﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Interfaces;
using RedditDataLayer.Entities;

namespace RedditProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly ISubredditService _subredditService;
        private readonly IUserService _userService;

        public IndexModel(IPostService postService, ISubredditService subredditService, IUserService userService)
        {
            _postService = postService;
            _subredditService = subredditService;
            _userService = userService;
        }

        public List<Post>? Posts { get; set; }
        public List<Subreddit>? Subreddits { get; set; }
        public List<User>? Users { get; set; }

        public void OnGet()
        {
            Posts = _postService.GetPosts();
            Subreddits = _subredditService.GetSubreddits();
            Users = _userService.GetUsers();
        }
    }

}