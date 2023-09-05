using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

namespace RedditProject.Pages
{
    public class SubredditUsersModel : PageModel
    {
        private readonly PostService _postService;
        private readonly SubredditService _subredditService;

        public SubredditUsersModel(IPostRepository postRepository, ISubredditRepository subredditRepository)
        {
            _postService = new PostService(postRepository);
            _subredditService = new SubredditService(subredditRepository);
        }

        public List<Subreddit> Subreddits { get; set; }

        public void OnGet()
        {
            var posts = _postService.GetPostsWithSubredditAndUser();
            Subreddits = _subredditService.GetSubreddits();

            foreach (var subreddit in Subreddits)
            {
                var users = new List<User>();
                foreach (var post in posts)
                {
                    if (post.SubredditId == subreddit.Id)
                    {
                        users.Add(post.User);
                    }
                }
                subreddit.Users = users.Distinct().ToList();
            }
        }
    }
}