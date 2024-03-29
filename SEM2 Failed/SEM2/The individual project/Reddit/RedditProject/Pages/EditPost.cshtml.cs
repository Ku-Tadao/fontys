using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

namespace RedditProject.Pages
{
    public class EditPostModel : PageModel
    {
        private readonly PostService _postService;

        public EditPostModel(IPostRepository postRepository)
        {
            _postService = new PostService(postRepository);
        }

        // Bind data from the HTTP request to these properties
        // The BindProperty attribute specifies that the model binding system
        // should automatically map data from the HTTP request to these properties        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }

        public void OnGet(int id)
        {
            var post = _postService.GetPostById(id);
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
        }

        public IActionResult OnPost()
        {
            // Check if the data from the HTTP request is valid
            // ModelState.IsValid indicates whether the model binding and validation process was successful
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var post = _postService.GetPostById(Id);
            post.UpdateTitle(Title);
            post.UpdateContent(Content);
            _postService.UpdatePost(post);

            return RedirectToPage("/Index");
        }
    }
}