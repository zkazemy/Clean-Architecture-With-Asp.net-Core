using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatHistory.Domain;
using Domain;
using Domain.Enums;
using NUnit.Framework;
using Persistence;

namespace UnitTest
{
    [TestFixture]
    public class EventTest
    {
        private EventRepository _eventRepository;
        private UserRepository _userRepository;
        private User _sampleUser;

        [SetUp]
        protected void SetUp()
        {
            _userRepository = new UserRepository();
            _eventRepository = new EventRepository(_userRepository);
            _sampleUser = _userRepository.GetUserByUserId(4);
        }

        [Test]
        public void GetAllEvents()
        {
            int currentCount = _eventRepository.GetAll().Count;
            _eventRepository.Add(new Event()
            {
                ActionType = ActionType.Test,
                Comment = "Hello",
                EventId = 355,
                HighFiveToUser = null,
                PunchDate = new DateTime(),
                User = _sampleUser
            });
            Assert.AreEqual(_eventRepository.GetAll().Count, currentCount + 1);
        }

        [Test]
        public void AddEvent()
        {
            _eventRepository.Add(new Event()
            {
                ActionType = ActionType.Test,
                Comment = "Hello",
                EventId = 77,
                HighFiveToUser = null,
                PunchDate = new DateTime(),
                User = _sampleUser
            }); 
            Assert.AreEqual(_eventRepository.GetAll().Count(x => x.EventId == 12), 1);
        }

        [Test]
        public void RemoveEvent()
        {
            _eventRepository.Add(new Event()
            {
                ActionType = ActionType.Test,
                Comment = "Hello",
                EventId = 66,
                HighFiveToUser = null,
                PunchDate = new DateTime(),
                User = _sampleUser
            });
            _eventRepository.Remove(12);
            Assert.AreEqual(_eventRepository.GetAll().Count(x => x.EventId == 12), 0);
        }

    }
}
