using System.Collections.Generic;
using RedditDataLayer.Entities;

namespace RedditBusinessLayer.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}