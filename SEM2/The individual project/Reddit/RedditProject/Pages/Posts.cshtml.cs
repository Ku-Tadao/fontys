using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;

namespace RedditProject.Pages
{
    public class PostsModel : PageModel
    {
        private readonly IPostRepository _postRepository;

        public PostsModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public List<Post> Posts { get; set; }

        public void OnGet()
        {
            Posts = _postRepository.GetPostsWithSubredditAndUser();
        }
    }
}
