using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

namespace RedditProject.Pages
{
    public class DeletePostModel : PageModel
    {
        private readonly PostService _postService;

        public DeletePostModel(IPostRepository postRepository)
        {
            _postService = new PostService(postRepository);
        }

        // The BindProperty attribute specifies that the model binding system
        // should automatically map data from the HTTP request to these properties
        [BindProperty]
        public int Id { get; set; }

        public void OnGet(int id)
        {
            Id = id;
        }

        public IActionResult OnPost()
        {
            var post = _postService.GetPostById(Id);
            _postService.DeletePost(post);

            return RedirectToPage("/Index");
        }
    }
}