namespace RedditBusinessLayer.Entities
{
    public class Post
    {
        public Post(int id, string title, string content, DateTime dateCreated, int userId, int subredditId)
        {
            Id = id;
            UpdateTitle(title);
            UpdateContent(content);
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

        public Subreddit Subreddit { get; set; }
        public User User { get; set; }

        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty or whitespace.");
            Title = newTitle;
        }

        public void UpdateContent(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Content cannot be empty or whitespace.");
            Content = newContent;
        }
    }
}