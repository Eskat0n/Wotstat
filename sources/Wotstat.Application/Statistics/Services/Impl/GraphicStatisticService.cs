namespace Wotstat.Application.Statistics.Services.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Criteria;
    using Domain.Model.Entities;
    using ViewModels;

    public class GraphicStatisticService : IGraphicStatisticService
    {
        public IQueryBuilder Query { get; set; }


        public IEnumerable<StatisticItemData> GetGraphicData(Account account, Func<StatisticalData, double> propertyFunc,
            DateTime startDate, DateTime endDate)
        {
            var statistics = Query
                .For<IEnumerable<StatisticalData>>()
                .With(new StatisticSearchPeriodCriterion(account.PlayerId, startDate, endDate));

            return statistics != null
                ? statistics.Select(x => new StatisticItemData(x.Date, propertyFunc(x)))
                : Enumerable.Empty<StatisticItemData>();
        }
    }
}