using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditDataLayer.Entities
{
    public class Post
    {
        public Post(int id, string title, string content, DateTime dateCreated, int userId, int subredditId)
        {
            Id = id;
            Title = title;
            Content = content;
            DateCreated = dateCreated;
            UserId = userId;
            SubredditId = subredditId;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public int SubredditId { get; set; }

        public void UpdateTitle(string newTitle)
        {
            // Perform any necessary validation or other logic here
            Title = newTitle;
        }

        public void UpdateContent(string newContent)
        {
            // Perform any necessary validation or other logic here
            Content = newContent;
        }
    }
}
