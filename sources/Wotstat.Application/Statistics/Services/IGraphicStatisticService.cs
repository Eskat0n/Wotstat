namespace Wotstat.Application.Statistics.Services
{
    using System;
    using System.Collections.Generic;
    using Domain.Model.Entities;
    using ViewModels;

    public interface IGraphicStatisticService
    {
        IEnumerable<StatisticItemData> GetGraphicData(Account account, Func<StatisticalData, double> propertyFunc,
            DateTime startDate, DateTime endDate);
    }
}