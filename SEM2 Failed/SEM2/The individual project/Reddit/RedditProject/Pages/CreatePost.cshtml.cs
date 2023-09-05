using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

namespace RedditProject.Pages
{
    public class CreatePostModel : PageModel
    {
        private readonly PostService _postService;
        private readonly SubredditService _subredditService;

        public CreatePostModel(IPostRepository postRepository, ISubredditRepository subredditRepository)
        {
            _postService = new PostService(postRepository);
            _subredditService = new SubredditService(subredditRepository);
        }

        // The BindProperty attribute specifies that the model binding system
        // should automatically map data from the HTTP request to these properties
        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }

        [BindProperty]
        public int SubredditId { get; set; }

        public SelectList SubredditSelectList { get; set; }

        public void OnGet()
        {
            var subreddits = _subredditService.GetSubreddits();
            SubredditSelectList = new SelectList(subreddits, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            // Check if the data from the HTTP request is valid
            // ModelState.IsValid indicates whether the model binding and validation process was successful
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var post = new Post(0, Title, Content, DateTime.Now, 1, SubredditId);
            _postService.CreatePost(post);

            return RedirectToPage("/Index");
        }

    }
}