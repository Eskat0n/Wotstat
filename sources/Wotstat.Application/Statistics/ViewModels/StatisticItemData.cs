namespace Wotstat.Application.Statistics.ViewModels
{
    using System;

    public class StatisticItemData
    {
        public StatisticItemData(DateTime date, double value)
        {
            DateTicks = DateTimeToUnixTimestamp(date);
            Value = value;
        }

        public double DateTicks { get; set; }
        public double Value { get; set; }

        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }
    }
}