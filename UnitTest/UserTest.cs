using System.Linq;
using Domain;
using NUnit.Framework;
using Persistence;

namespace UnitTest
{
    [TestFixture]
    public class UserTest
    {
        private UserRepository _userRepository;

        [SetUp]
        protected void SetUp()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        public void GetAllUsers()
        {
            int currentCount = _userRepository.GetAll().Count;
            _userRepository.Add(new User() {FirstName = "Ali", LastName = "Rezaei", UserId = 12});
            _userRepository.Add(new User() { FirstName = "Mohsen", LastName = "Ebrahimi", UserId = 13 });
            Assert.AreEqual(_userRepository.GetAll().Count, currentCount + 2);
        }

        [Test]
        public void AddUser()
        {
            _userRepository.Add(new User() { FirstName = "Ali", LastName = "Rezaei", UserId = 12 });
            Assert.AreEqual(_userRepository.GetAll().Count(x => x.UserId ==  12), 1);
        }

        [Test]
        public void RemoveUser()
        {
            _userRepository.Add(new User() { FirstName = "Ali", LastName = "Rezaei", UserId = 12 });
            _userRepository.Remove(12);
            Assert.AreEqual(_userRepository.GetAll().Count(x => x.UserId == 12), 0);
        }

    }
}
