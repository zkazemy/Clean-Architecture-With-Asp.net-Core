using System;
using System.Collections.Generic;
using System.Text;
using ChatHistory.Domain;
using Domain.Enums;

namespace Domain.Utility
{
    public static class StringExtension
    {
        public static string GetHistoryHourlyInText(this string str, int actionCount, ActionType actionType)
        {
            return actionType switch
            {
                ActionType.EnterTheRoom => actionCount + " " +
                                           (actionCount > 1 ? " people " : " person ") + " entered ",

                ActionType.LeaveTheRoom => actionCount + " " +
                                           (actionCount > 1 ? " people " : " person ") + " left ",

                ActionType.HighFive => actionCount + " " +
                                       (actionCount > 1 ? " people " : " person ") + " high-fived ",

                ActionType.Comment => actionCount + " " +
                                      (actionCount > 1 ? " comments " : " comment "),

                _ => throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null)
            };
        }

        
    }
}
