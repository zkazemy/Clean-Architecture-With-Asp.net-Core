using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Persistence
{
    public class UserRepository:ICrudRepository<User,int>
    {
        private List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(new User(1, "Zahra", "Kazemi"));
            _users.Add(new User(2, "Amir", "Karimi"));
            _users.Add(new User(3, "Mina", "Rezaei"));
            _users.Add(new User(4, "Bob", "Morgan"));
            _users.Add(new User(5, "Kate", "Hubscher"));
            _users.Add(new User(6, "Zahra", "Kazemi"));
        }
        
        public User GetUserByUserId(int userId)
        {
            return _users.Find(x => x.UserId == userId);
        }

        public ICollection<User> GetAll()
        {
            return _users;
        }

        public void Add(User user)
        {
            _users.Add(new User(user.UserId, user.FirstName, user.LastName));
        }
        
        public void Remove(int userId)
        {
            User user = _users.FirstOrDefault(x => x.UserId == userId);
            _users.Remove(user);
        }
    }
}
