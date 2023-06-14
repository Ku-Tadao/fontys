using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISubredditRepository _subredditRepository;
        private readonly IPostRepository _postRepository;

        public IndexModel(ISubredditRepository subredditRepository, IPostRepository postRepository)
        {
            _subredditRepository = subredditRepository;
            _postRepository = postRepository;
        }

        public List<Subreddit> Subreddits { get; set; }

        public void OnGet()
        {
            Subreddits = _subredditRepository.GetSubreddits();
            foreach (var subreddit in Subreddits)
            {
                subreddit.Posts = _postRepository.GetPostsBySubredditId(subreddit.Id);
            }
        }
    }

}