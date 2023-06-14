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
                subreddit.Users = posts.Where(p => p.SubredditId == subreddit.Id).Select(p => p.User).Distinct().ToList();
            }
        }
    }
}