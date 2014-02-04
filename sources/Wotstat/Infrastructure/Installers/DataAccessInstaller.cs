namespace Wotstat.Infrastructure.Installers
{
    using ByndyuSoft.Infrastructure.Domain;
    using ByndyuSoft.Infrastructure.NHibernate;
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
            container.Register(
                   // NHibernate
                    Component.For<INHibernateInitializer>().ImplementedBy<NHibernateInitializer>(),
                    Component.For<IUnitOfWorkFactory>().ImplementedBy<NHibernateUnitOfWorkFactory>(),
                    Component.For<ISessionProvider>().ImplementedBy<PerRequestSessionProvider>()
                        .LifeStyle.PerWebRequest,
                    Component.For(typeof(IRepository<>)).ImplementedBy(typeof(SourcedNHibernateRepository<>)).
                        LifeStyle.PerWebRequest,
                    Component.For<ILinqProvider>().ImplementedBy<NHibernateLinqProvider>()
                        .LifeStyle.PerWebRequest,
                    Component.For<ISessionFactory>().UsingFactoryMethod(x => x.Resolve<INHibernateInitializer>()
                                                                             .GetConfiguration()
                                                                             .BuildSessionFactory())
                );
        }
    }
}