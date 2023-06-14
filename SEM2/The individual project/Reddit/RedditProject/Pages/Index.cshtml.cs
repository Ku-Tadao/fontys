using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

namespace RedditProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PostService postService;
        private readonly SubredditService subredditService;
        public List<Subreddit> Subreddits { get; set; }


        public IndexModel(ISubredditRepository subredditRepository, IPostRepository postRepository)
        {
            postService = new PostService(postRepository);
            subredditService = new SubredditService(subredditRepository);
        }

        public void OnGet()
        {
            Subreddits = subredditService.GetSubreddits();
            foreach (var subreddit in Subreddits)
            {
                subreddit.Posts = postService.GetPostsBySubredditId(subreddit.Id);
            }
        }
    }
}