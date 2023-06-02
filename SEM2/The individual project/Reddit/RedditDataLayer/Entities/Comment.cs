using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditDataLayer.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; private set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public void UpdateContent(string newContent)
        {
            // Perform any necessary validation or other logic here
            Content = newContent;
        }
    }
}
