using RedditBusinessLayer.Entities;

namespace RedditBusinessLayer.Interfaces;

public interface IUserRepository
{
    List<User> GetUsers();
    User GetUserById(int userId);
    void UpdateUser(User user);
}