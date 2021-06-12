using System;
using ChatHistory.Domain;
using Domain.Enums;

namespace Domain.Utility
{
    public static class EventExtension
    {
        public static string GetHistoryMinuteByMinuteInText(this  Event eventItem)
        {
            return eventItem.ActionType switch
            {
                ActionType.EnterTheRoom => eventItem.User.FirstName + " enters the room ",
                ActionType.LeaveTheRoom => eventItem.User.FirstName + " leaves ",
                ActionType.HighFive => eventItem.User.FirstName + " high-fives " + eventItem.HighFiveToUser.FirstName,
                ActionType.Comment => eventItem.User.FirstName + " comments: " + eventItem.Comment,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
