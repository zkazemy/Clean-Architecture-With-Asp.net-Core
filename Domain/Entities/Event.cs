using System;
using Domain;
using Domain.Enums;

namespace ChatHistory.Domain
{
    public class Event
    {
        public Event()
        {

        }
        public Event(int eventId, User user, ActionType actionType, DateTime punchDate, string comment)
        {
            EventId = eventId;
            User = user;
            ActionType = actionType;
            PunchDate = punchDate;
            Comment = comment;
        }

        public Event(int eventId, User user, ActionType actionType, DateTime punchDate, string comment, User highFiveToUser) :
            this(eventId, user, actionType, punchDate, comment)
        {
            HighFiveToUser = highFiveToUser;
        }

        public int EventId { get; set; }
        public User User { get; set; }
        public User HighFiveToUser { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime PunchDate { get; set; }
        public string Comment { get; set; }

    }
}
