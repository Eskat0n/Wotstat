namespace Wotstat.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Application.Annotations;

    [UsedImplicitly]
    public class QueriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            /*var queries = Classes.FromAssemblyContaining<NHibernateInitializer>()
                .BasedOn(typeof (IQuery<,>))
                .WithService.AllInterfaces()
                .LifestyleTransient();

            container.Register(
                queries,
                Component.For<IQueryBuilder>().AsFactory().LifestyleTransient(),
                Component.For<IQueryFactory>().AsFactory().LifestyleTransient(),
                Component.For(typeof(IQueryFor<>)).ImplementedBy(typeof(QueryFor<>)).LifestyleTransient()
                );
             */

        }
    }
}