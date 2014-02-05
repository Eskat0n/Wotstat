namespace Domain.DataAccess.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model.Criteria;
    using Model.Entities;

    public class FindStatisticByPlayerIdAndDate : LinqQueryBase<StatisticalData, PlayerIdAndDateCriterion, StatisticalData>
    {
        public FindStatisticByPlayerIdAndDate(ILinqProvider linq) : base(linq)
        {}

        public override StatisticalData Ask(PlayerIdAndDateCriterion criterion)
        {
            return Query.OrderByDescending(x => x.Id).SingleOrDefault(x => (x.Date == criterion.Date) && (x.PlayerId == criterion.PlayerId));
        }
    }
}
