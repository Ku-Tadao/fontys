﻿namespace RedditProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
        public int SubredditId { get; set; }
    }
}