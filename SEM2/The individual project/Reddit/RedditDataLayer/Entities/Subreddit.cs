using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditDataLayer.Entities
{
    public class Subreddit
    {
        public Subreddit(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public void UpdateName(string newName)
        {
            // Perform any necessary validation or other logic here
            Name = newName;
        }

        public void UpdateDescription(string newDescription)
        {
            // Perform any necessary validation or other logic here
            Description = newDescription;
        }
    }
}
