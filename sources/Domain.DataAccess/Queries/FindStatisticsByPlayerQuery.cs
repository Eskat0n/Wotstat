namespace Domain.DataAccess.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model.Criteria;
    using Model.Entities;

    public class FindStatisticsByPlayerQuery : LinqQueryBase<StatisticalData, StatisticSearchCriterion, IEnumerable<StatisticalData>>
    {
        public FindStatisticsByPlayerQuery(ILinqProvider linq) : base(linq)
        {
        }

        public override IEnumerable<StatisticalData> Ask(StatisticSearchCriterion criterion)
        {
            return Query.Where(x => x.PlayerId == criterion.PlayerId);
        }
    }
}