namespace RedditBusinessLayer.Entities
{
    public class Subreddit
    {
        public Subreddit(int id, string name, string description)
        {
            Id = id;
            UpdateName(name);
            UpdateDescription(description);

        }

        public List<Post> Posts { get; set; }
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty or whitespace.");
            Name = newName;
        }

        public void UpdateDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("Description cannot be empty or whitespace.");
            Description = newDescription;
        }
    }
}
