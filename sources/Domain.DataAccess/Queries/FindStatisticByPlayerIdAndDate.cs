namespace Domain.DataAccess.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model.Criteria;
    using Model.Entities;

    public class FindStatisticByPlayerIdAndDate : LinqQueryBase<StatisticData, PlayerIdAndDateCriterion, StatisticData>
    {
        public FindStatisticByPlayerIdAndDate(ILinqProvider linq) : base(linq)
        {}

        public override StatisticData Ask(PlayerIdAndDateCriterion criterion)
        {
            return Query.OrderByDescending(x => x.Id).SingleOrDefault(x => (x.Date == criterion.Date) && (x.User == criterion.PlayerId));
        }
    }
}
