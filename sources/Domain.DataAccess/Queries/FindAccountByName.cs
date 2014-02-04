namespace Domain.DataAccess.Queries
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Model;
    using Model.Criteria;

    public class FindAccountByNameQuery : LinqQueryBase<Account, AccountNameCriterion, Account>
    {
        public FindAccountByNameQuery(ILinqProvider linq) : base(linq)
        {
        }

        public override Account Ask(AccountNameCriterion criterion)
        {
            return Query.SingleOrDefault(x => x.Name.Equals(criterion.Name));
        }
    }
}