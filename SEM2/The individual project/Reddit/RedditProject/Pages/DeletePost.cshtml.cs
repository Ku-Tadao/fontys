using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Interfaces;

namespace RedditProject.Pages
{
    public class DeletePostModel : PageModel
    {
        private readonly IPostRepository _postRepository;

        public DeletePostModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [BindProperty]
        public int Id { get; set; }

        public void OnGet(int id)
        {
            Id = id;
        }

        public IActionResult OnPost()
        {
            var post = _postRepository.GetPostById(Id);
            _postRepository.DeletePost(post);

            return RedirectToPage("/Index");
        }
    }
}
