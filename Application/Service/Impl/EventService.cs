using System;
using System.Collections.Generic;
using System.Linq;
using ChatHistory.Domain;
using Domain;
using Domain.Entities;
using Domain.Enums;
using Domain.Utility;
using Persistence;

namespace Application.Service.Impl
{
    public class EventService : IEventService
    {
        private EventRepository _eventRepository;

        public EventService(EventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public List<Event> GetAllEvents()
        {
            return _eventRepository.GetAll().ToList();
        }
        public void AddEvent(Event eventItem)
        {
            _eventRepository.Add(eventItem);
        }
        public void RemoveEvent(int eventId)
        {
            _eventRepository.Remove(eventId);
        }
        public List<EventHistory> GetEventHistoryByMinute()
        {
            var eventHistoryByMinute = _eventRepository.GetEventHistoryByMinute().ToList();

            if (!eventHistoryByMinute.Any())
                return new List<EventHistory>();

            var result = new List<EventHistory>();

            foreach (var nameGroup in eventHistoryByMinute)
            {
                foreach (var item in nameGroup)
                {
                    var eventHistory = new EventHistory
                    {
                        Value = nameGroup.Key.FormatDateTime(),
                        Text = item.GetHistoryMinuteByMinuteInText()
                    };
                    result.Add(eventHistory);
                }
            }

            return result;
        }
        public Dictionary<string, List<string>> GetEventHistoryHourly()
        {
            var aggregatedHistory = _eventRepository.GetEventHistoryHourly().ToList();

            if (!aggregatedHistory.Any())
                return new Dictionary<string, List<string>>();

            var aggregatedItems = aggregatedHistory
                .ToDictionary(o => o.Hour,
                    o => o.AggregatedItems);

            var result = new Dictionary<string, List<string>>();

            foreach (var item in aggregatedItems)
            {
                var texts = new List<string>
                {
                    "".GetHistoryHourlyInText(item.Value.CommentsCounts, ActionType.Comment),
                    "".GetHistoryHourlyInText(item.Value.EnterTheRoomCounts, ActionType.EnterTheRoom),
                    "".GetHistoryHourlyInText(item.Value.HighFiveCounts, ActionType.HighFive),
                    "".GetHistoryHourlyInText(item.Value.LeaveTheRoomCounts, ActionType.LeaveTheRoom)
                };
                result.Add(item.Key.FormatDateTime(), texts);
            }

            return result;
        }
    }
}
