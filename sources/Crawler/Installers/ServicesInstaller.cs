namespace Crawler.Installers
{
    using Annotations;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Domain.Model;
    using WargamingApi;

    [UsedImplicitly]
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IWargamingApi>().ImplementedBy<WargamingApi>().LifestyleTransient(),
                Component.For<IConfig>().ImplementedBy<Config>().LifestyleTransient()
                );
        }
    }
}