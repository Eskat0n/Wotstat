namespace Domain.DataAccess.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model.Criteria;
    using Model.Entities;

    public class FindLastStatisticQuery : LinqQueryBase<StatisticalData, StatisticSearchCriterion, StatisticalData>
    {
        public FindLastStatisticQuery(ILinqProvider linq) : base(linq)
        {
        }

        public override StatisticalData Ask(StatisticSearchCriterion criterion)
        {
            return Query.OrderByDescending(x => x.Id).FirstOrDefault(x => x.PlayerId == criterion.PlayerId);
        }
    }
}