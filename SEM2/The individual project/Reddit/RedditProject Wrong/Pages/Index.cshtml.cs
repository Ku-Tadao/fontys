using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditProject.Models;

namespace RedditProject.Pages
{
    public class IndexModel : PageModel
    {
        public List<Post> Posts { get; set; }
        public List<User> Users { get; set; }
        public List<Subreddit> Subreddits { get; set; }

        public void OnGet()
        {
            var databaseHelper = new DatabaseHelper();
            Posts = databaseHelper.GetPosts();
            Users = databaseHelper.GetUsers();
            Subreddits = databaseHelper.GetSubreddits();
        }
    }
}