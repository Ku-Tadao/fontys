using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedditProject.Models;

namespace RedditProject.Pages
{
    public class UserModel : PageModel
    {
        private readonly DatabaseHelper _databaseHelper;

        public UserModel(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }

        public IList<Post> Posts { get; set; }

        public IList<Subreddit> Subreddits { get; set; }

        public void OnGet()
        {
            var user = _databaseHelper.GetUsers().FirstOrDefault(u => u.Username == Username);
            if (user != null)
            {
                Posts = _databaseHelper.GetPosts().Where(p => p.UserId == user.Id).ToList();
            }
            Subreddits = _databaseHelper.GetSubreddits();
        }
    }


}
