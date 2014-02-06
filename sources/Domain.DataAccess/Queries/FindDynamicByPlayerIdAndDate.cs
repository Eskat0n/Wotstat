namespace Domain.DataAccess.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model.Criteria;
    using Model.Entities;

    public class FindDynamicByPlayerIdAndDate : LinqQueryBase<DynamicData, PlayerIdAndPeriodCriterion, DynamicData>
    {
        public FindDynamicByPlayerIdAndDate(ILinqProvider linq)
            : base(linq)
        { }

        public override DynamicData Ask(PlayerIdAndPeriodCriterion criterion)
        {
            return Query.SingleOrDefault(x => (x.Period.Id == criterion.PeriodId) && (x.PlayerId == criterion.PlayerId));
        }
    }
}