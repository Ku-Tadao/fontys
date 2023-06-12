using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditProject.Pages
{
    public class CreatePostModel : PageModel
    {
        private readonly IPostRepository _postRepository;
        private readonly ISubredditRepository _subredditRepository;

        public CreatePostModel(IPostRepository postRepository, ISubredditRepository subredditRepository)
        {
            _postRepository = postRepository;
            _subredditRepository = subredditRepository;
        }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }

        [BindProperty]
        public int SubredditId { get; set; }

        public SelectList SubredditSelectList { get; set; }

        public void OnGet()
        {
            var subreddits = _subredditRepository.GetSubreddits();
            SubredditSelectList = new SelectList(subreddits, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var post = new Post(0, Title, Content, DateTime.Now, 1, SubredditId);
            _postRepository.CreatePost(post);

            return RedirectToPage("/Index");
        }

    }
}
