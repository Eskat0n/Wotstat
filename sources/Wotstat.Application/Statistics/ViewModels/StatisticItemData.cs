namespace Wotstat.Application.Statistics.ViewModels
{
    using System;

    public class StatisticItemData
    {
        public StatisticItemData(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}