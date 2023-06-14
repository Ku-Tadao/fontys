using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

namespace RedditProject.Pages
{
    public class SubredditModel : PageModel
    {
        private readonly SubredditService _subredditService;
        private readonly PostService _postService;


        public SubredditModel(ISubredditRepository subredditRepository, IPostRepository postRepository)
        {
            _subredditService = new SubredditService(subredditRepository);
            _postService = new PostService(postRepository);
        }

        public string SubredditName { get; set; }
        public List<Post> Posts { get; set; }

        public void OnGet(int subredditId)
        {
            var subreddit = _subredditService.GetSubredditById(subredditId);
            SubredditName = subreddit.Name;
            Posts = _postService.GetPostsBySubredditId(subredditId);
        }
    }
}