using System.Collections.Generic;
using System.Linq;
using Domain;
using Persistence;

namespace Application.Service.Impl
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void RemoveUser(int userId)
        {
            _userRepository.Remove(userId);
        }

        public User GetUserByUserId(int userId)
        {
           return _userRepository.GetUserByUserId(userId);
        }

    }
}
