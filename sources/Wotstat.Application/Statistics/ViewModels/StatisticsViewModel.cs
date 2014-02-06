namespace Wotstat.Application.Statistics.ViewModels
{
    using System.Collections.Generic;
    using Domain.Model.Entities;

    public class StatisticsViewModel
    {
        public StatisticsViewModel(StatisticalData lastStatistic, IEnumerable<DynamicData> dynamicData)
        {
            LastStatistic = lastStatistic;
            Dynamic = dynamicData;
        }

        public StatisticalData LastStatistic { get; set; }
        public IEnumerable<DynamicData> Dynamic { get; set; }
    }
}