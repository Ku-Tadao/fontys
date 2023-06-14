using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditProject.Pages
{
    public class SubredditModel : PageModel
    {
        private readonly ISubredditRepository _subredditRepository;
        private readonly IPostRepository _postRepository;

        public SubredditModel(ISubredditRepository subredditRepository, IPostRepository postRepository)
        {
            _subredditRepository = subredditRepository;
            _postRepository = postRepository;
        }

        public string SubredditName { get; set; }
        public List<Post> Posts { get; set; }

        public void OnGet(int subredditId)
        {
            var subreddit = _subredditRepository.GetSubredditById(subredditId);
            SubredditName = subreddit.Name;
            Posts = _postRepository.GetPostsBySubredditId(subredditId);
        }
    }
}
