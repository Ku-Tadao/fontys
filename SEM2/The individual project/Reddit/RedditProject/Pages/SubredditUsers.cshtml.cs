using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditProject.Pages
{
    public class SubredditUsersModel : PageModel
    {
        private readonly IPostRepository _postRepository;
        private readonly ISubredditRepository _subredditRepository;

        public SubredditUsersModel(IPostRepository postRepository, ISubredditRepository subredditRepository)
        {
            _postRepository = postRepository;
            _subredditRepository = subredditRepository;
        }

        public List<Subreddit> Subreddits { get; set; }

        public void OnGet()
        {
            var posts = _postRepository.GetPostsWithSubredditAndUser();
            Subreddits = _subredditRepository.GetSubreddits();

            foreach (var subreddit in Subreddits)
            {
                subreddit.Users = posts.Where(p => p.SubredditId == subreddit.Id).Select(p => p.User).Distinct().ToList();
            }

            
        }
    }
}
