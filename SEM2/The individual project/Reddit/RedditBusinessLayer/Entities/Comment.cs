namespace RedditBusinessLayer.Entities
{
    public class Comment
    {
        public Comment(int id, string content, DateTime dateCreated, int userId, int postId)
        {
            Id = id;
            UpdateContent(content);
            DateCreated = dateCreated;
            UserId = userId;
            PostId = postId;
        }

        public int Id { get; set; }
        public string Content { get; private set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public void UpdateContent(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
                throw new ArgumentException("Content cannot be empty or whitespace.");
            Content = newContent;
        }
    }
}