namespace Domain.DataAccess.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model.Criteria;
    using Model.Entities;

    public class FindStatisticByDateQuery : LinqQueryBase<StatisticalData, StatisticSearchPeriodCriterion, IEnumerable<StatisticalData>>
    {
        public FindStatisticByDateQuery(ILinqProvider linq) : base(linq)
        {
        }

        public override IEnumerable<StatisticalData> Ask(StatisticSearchPeriodCriterion criterion)
        {
            return
                Query.Where(x => x.PlayerId == criterion.PlayerId);
            /* && x.Date >= criterion.StartDate
                                 && x.Date <= criterion.EndDate);*/
        }
    }
}