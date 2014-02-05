namespace TaskerConsole.Installers
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Domain.DataAccess;
    using Domain.DataAccess.Repositories;
    using JetBrains.Annotations;
    using NHibernate;

    [UsedImplicitly]
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(
                // NHibernate
                Component.For<INHibernateInitializer>().ImplementedBy<NHibernateInitializer>(),
                Component.For<IUnitOfWorkFactory>().ImplementedBy<NHibernateUnitOfWorkFactory>(),
                Component.For<ISessionProvider>().ImplementedBy<PerRequestSessionProvider>()
                    .LifeStyle.Transient,
                Component.For(typeof (IRepository<>)).ImplementedBy(typeof (SourcedNHibernateRepository<>)).
                    LifeStyle.Transient,
                Component.For<ILinqProvider>().ImplementedBy<NHibernateLinqProvider>()
                    .LifeStyle.Transient,
                Component.For<ISessionFactory>().UsingFactoryMethod(x => x.Resolve<INHibernateInitializer>()
                    .GetConfiguration()
                    .BuildSessionFactory())
                );
        }
    }
}