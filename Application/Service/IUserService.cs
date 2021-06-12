using System.Collections.Generic;
using Domain;

namespace Application.Service
{
    public interface IUserService
    {
        public List<User> GetAllUsers();
        public void AddUser(User user);
        public void RemoveUser(int userId);
        public User GetUserByUserId(int userId);
    }
}
