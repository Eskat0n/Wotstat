namespace Domain.DataAccess.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model;
    using Model.Criteria;
    using Model.Entities;

    public class FindAccountByPlayerIdQuery : LinqQueryBase<Account, AccountPlayerIdCriterion, Account>
    {
        public FindAccountByPlayerIdQuery(ILinqProvider linq)
            : base(linq)
        {
        }

        public override Account Ask(AccountPlayerIdCriterion criterion)
        {
            return Query.SingleOrDefault(x => x.PlayerId.Equals(criterion.PlayerId));
        }
    }
}