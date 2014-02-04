namespace Domain.DataAccess.Repositories
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using NHibernate.Linq;

    public class SourcedNHibernateRepository<TEntity> : NHibernateRepositoryBase<TEntity> where TEntity : class, IEntity
    {
        public SourcedNHibernateRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }

        public IQueryable<TEntity> Queryable()
        {
            return Session.Query<TEntity>();
        }
    }
}