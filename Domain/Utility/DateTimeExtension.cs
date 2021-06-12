using System;

namespace Domain.Utility
{
   public static class DateTimeExtension
    {
        public static string FormatDateTime(this DateTime date)
        {
            return date.ToString("dddd, dd MMMM yyyy HH: mm tt");
        }
    }
}
