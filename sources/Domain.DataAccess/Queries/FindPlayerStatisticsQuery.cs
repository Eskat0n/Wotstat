﻿namespace Domain.DataAccess.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model.Criteria;
    using Model.Entities;

    public class FindPlayerStatisticsQuery : LinqQueryBase<DynamicData, StatisticSearchCriterion, IEnumerable<DynamicData>>
    {
        public FindPlayerStatisticsQuery(ILinqProvider linq) : base(linq)
        {
        }

        public override IEnumerable<DynamicData> Ask(StatisticSearchCriterion criterion)
        {
            return Query.Where(x => x.PlayerId==criterion.PlayerId);
        }
    }
}