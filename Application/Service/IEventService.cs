using System.Collections.Generic;
using ChatHistory.Domain;
using Domain;

namespace Application.Service
{
    public interface IEventService
    {
        public List<Event> GetAllEvents();
        public void AddEvent(Event eventItem);
        public void RemoveEvent(int eventId);
        public List<EventHistory> GetEventHistoryByMinute();
        Dictionary<string, List<string>> GetEventHistoryHourly();
    }
}
