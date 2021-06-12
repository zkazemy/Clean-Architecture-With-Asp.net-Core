using System;
using System.Collections.Generic;
using System.Linq;
using ChatHistory.Domain;
using Domain.Entities;
using Domain.Enums;

namespace Persistence
{
    public class EventRepository : ICrudRepository<Event, int>
    {
        private List<Event> _events = new List<Event>();
        private UserRepository _userRepository;
        public EventRepository(UserRepository userRepository)
        {
            _userRepository = userRepository;
            DataInitialization();
        }

        private void DataInitialization()
        {
            var userZahra = _userRepository.GetUserByUserId(1);
            var userBob = _userRepository.GetUserByUserId(4);
            var userKate = _userRepository.GetUserByUserId(5);
            _events.Add(new Event(1, userBob, ActionType.EnterTheRoom, new DateTime(2021, 06, 10, 17, 0, 0), string.Empty));
            _events.Add(new Event(3, userKate, ActionType.EnterTheRoom, new DateTime(2021, 06, 10, 17, 5, 0), string.Empty));
            _events.Add(new Event(5, userBob, ActionType.Comment, new DateTime(2021, 06, 10, 17, 15, 0), "Hey, Kate - high five "));
            _events.Add(new Event(6, userKate, ActionType.HighFive, new DateTime(2021, 06, 10, 17, 16, 0), string.Empty, userBob));
            _events.Add(new Event(6, userKate, ActionType.HighFive, new DateTime(2021, 06, 10, 17, 17, 0), string.Empty, userBob));
            _events.Add(new Event(6, userBob, ActionType.HighFive, new DateTime(2021, 06, 10, 17, 18, 0), string.Empty, userKate));
            _events.Add(new Event(7, userBob, ActionType.LeaveTheRoom, new DateTime(2021, 06, 10, 17, 19, 0), string.Empty));
            _events.Add(new Event(8, userKate, ActionType.Comment, new DateTime(2021, 06, 10, 17, 20, 0), "Oh, typical"));
            _events.Add(new Event(9, userKate, ActionType.LeaveTheRoom, new DateTime(2021, 06, 10, 17, 21, 0), string.Empty));
            _events.Add(new Event(10, userZahra, ActionType.EnterTheRoom, new DateTime(2021, 06, 10, 18, 0, 0), string.Empty));
            _events.Add(new Event(11, userZahra, ActionType.Comment, new DateTime(2021, 06, 10, 18, 3, 0), "Hello guys..."));
            _events.Add(new Event(12, userZahra, ActionType.LeaveTheRoom, new DateTime(2021, 06, 10, 18, 4, 0), string.Empty));
            _events.Add(new Event(13, userZahra, ActionType.EnterTheRoom, new DateTime(2022, 04, 1, 10, 0, 0), string.Empty));
            _events.Add(new Event(14, userZahra, ActionType.LeaveTheRoom, new DateTime(2022, 04, 1, 11, 2, 0), string.Empty));

        }
        public ICollection<Event> GetAll()
        {
            return _events;
        }

        public void Add(Event eventItem)
        {
            _events.Add(eventItem);
        }

        public void Remove(int eventId)
        {
            Event eventItem = _events.FirstOrDefault(x => x.EventId == eventId);
            _events.Remove(eventItem);
        }

        public IEnumerable<IGrouping<DateTime, Event>> GetEventHistoryByMinute()
        {
            var eventHistoryByMinute = from eventItem in _events
                                       group eventItem by eventItem.PunchDate.AddMinutes(-(eventItem.PunchDate.Minute % 1))
                into newGroup
                                       orderby newGroup.Key ascending
                                       select newGroup;
            return eventHistoryByMinute;
        }

        public IEnumerable<AggregatedHistory> GetEventHistoryHourly()
        {
            IEnumerable<AggregatedHistory> aggregatedHistory = from eventItem in _events
                                                               group eventItem by eventItem.PunchDate.AddMinutes(-(eventItem.PunchDate.Minute % 60))
                into grouped
                                                               orderby grouped.Key ascending
                                                               select new AggregatedHistory
                                                               {
                                                                   Hour = grouped.Key,
                                                                   AggregatedItems = new AggregatedItem()
                                                                   {
                                                                       EnterTheRoomCounts =
                                                                           (from groupItem in grouped
                                                                            where groupItem.ActionType == ActionType.EnterTheRoom
                                                                            group groupItem by groupItem.ActionType
                                                                           into g2
                                                                            select g2.Count()).FirstOrDefault(),

                                                                       LeaveTheRoomCounts = (from groupItem in grouped
                                                                                             where groupItem.ActionType == ActionType.LeaveTheRoom
                                                                                             group groupItem by groupItem.ActionType
                                                                           into g2
                                                                                             select g2.Count()).FirstOrDefault(),

                                                                       HighFiveCounts = (from groupItem in grouped
                                                                                         where groupItem.ActionType == ActionType.HighFive
                                                                                         group groupItem by new { groupItem.ActionType, groupItem.User.UserId }
                                                                           into g2
                                                                                         select g2.Count()).FirstOrDefault(),

                                                                       CommentsCounts = (from groupItem in grouped
                                                                                         where groupItem.ActionType == ActionType.Comment
                                                                                         group groupItem by groupItem.ActionType
                                                                           into g2
                                                                                         select g2.Count()).FirstOrDefault(),
                                                                   }

                                                               };

            return aggregatedHistory;
        }
    }
}
