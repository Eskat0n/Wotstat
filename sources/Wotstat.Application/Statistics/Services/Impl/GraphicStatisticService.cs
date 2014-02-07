namespace Wotstat.Application.Statistics.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Criteria;
    using Domain.Model.Entities;
    using JetBrains.Annotations;
    using ViewModels;

    [UsedImplicitly]
    public class GraphicStatisticService : IGraphicStatisticService
    {
        public IQueryBuilder Query { get; set; }


        public IEnumerable<StatisticItemData> GetGraphicData(Account account, Func<StatisticalData, double> getPropertyValue,
            DateTime startDate, DateTime endDate)
        {
            var statistics = Query
                .For<IEnumerable<StatisticalData>>()
                .With(new StatisticSearchPeriodCriterion(account.PlayerId, startDate, endDate));

            return statistics != null
                ? statistics.Select(x => new StatisticItemData(x.Date, getPropertyValue(x)))
                : Enumerable.Empty<StatisticItemData>();
        }
    }
}