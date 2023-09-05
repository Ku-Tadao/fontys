using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditBusinessLayer.Entities;
using RedditBusinessLayer.Interfaces;
using RedditBusinessLayer.Services;

namespace RedditProject.Pages
{
    public class PostsModel : PageModel
    {
        private readonly PostService _postService;

        public PostsModel(IPostRepository postRepository)
        {
            _postService = new PostService(postRepository);
        }

        public List<Post> Posts { get; set; }

        public void OnGet()
        {
            Posts = _postService.GetPostsWithSubredditAndUser();
        }
    }
}