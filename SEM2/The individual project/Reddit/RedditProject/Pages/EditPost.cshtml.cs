using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Interfaces;

namespace RedditProject.Pages
{
    public class EditPostModel : PageModel
    {
        private readonly IPostRepository _postRepository;

        public EditPostModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Content { get; set; }

        public void OnGet(int id)
        {
            var post = _postRepository.GetPostById(id);
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var post = _postRepository.GetPostById(Id);
            post.UpdateTitle(Title);
            post.UpdateContent(Content);
            _postRepository.UpdatePost(post);

            return RedirectToPage("/Index");
        }
    }
}
