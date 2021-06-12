using System.Collections.Generic;
using System.Linq;
using Application.Service;
using Application.Service.Impl;
using Domain;
using NUnit.Framework;
using Persistence;

namespace UnitTest
{
    [TestFixture]
    public class EventServiceTest
    {
        private EventRepository _eventRepository;
        private IEventService _eventService;
        private UserRepository _userRepository;
        private User _sampleUser;

        [SetUp]
        protected void SetUp()
        {
            _userRepository = new UserRepository();
            _eventRepository = new EventRepository(_userRepository);
            _eventService = new EventService(_eventRepository);
            _sampleUser = _userRepository.GetUserByUserId(4);
        }

        [Test]
        public void EventHistoryByMinute_WhenHistoryIsEmpty()
        {
            var eventHistoryByMinute = _eventRepository.GetEventHistoryByMinute();
            if (eventHistoryByMinute.ToList().Count == 0)
                Assert.AreEqual(_eventService.GetEventHistoryByMinute(), new List<EventHistory>());
        }

        [Test]
        public void EventHistoryByMinute_WhenHistoryIsNotEmpty()
        {
            var eventHistoryByMinute = _eventRepository.GetEventHistoryByMinute();
            if (eventHistoryByMinute.ToList().Count > 0)
                Assert.Greater(_eventService.GetEventHistoryByMinute().ToList().Count, 0);
        }

        [Test]
        public void EventHistoryHourly_WhenHistoryIsEmpty()
        {
            var eventHistoryHourly = _eventRepository.GetEventHistoryHourly();
            if (eventHistoryHourly.ToList().Count == 0)
                Assert.AreEqual(_eventService.GetEventHistoryHourly(), new Dictionary<string, List<string>>());
        }

        [Test]
        public void EventHistoryHourly_WhenHistoryIsNotEmpty()
        {
            var eventHistoryHourly = _eventRepository.GetEventHistoryHourly();
            if (eventHistoryHourly.ToList().Count > 0)
                Assert.Greater(_eventService.GetEventHistoryHourly().ToList().Count, 0);
        }

        [Test]
        public void EventHistoryHourlyResult()
        {
            var eventHistoryHourly = _eventService.GetEventHistoryHourly();
            Assert.GreaterOrEqual(eventHistoryHourly.Values.Count, 1);
        }

        [Test]
        public void EventHistoryByMinuteResult()
        {
            var eventHistoryByMinute = _eventService.GetEventHistoryByMinute();
            Assert.GreaterOrEqual(eventHistoryByMinute.Count, 1);
        }
    }
}
