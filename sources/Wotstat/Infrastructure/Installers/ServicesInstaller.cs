namespace Wotstat.Infrastructure.Installers
{
    using Application;
    using Application.Security.Services;
    using Application.Security.Services.Impl;
    using Application.Statistics.Services;
    using Application.Statistics.Services.Impl;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Domain.Model;
    using JetBrains.Annotations;
    using TaskService;
    using WargamingApi;


    [UsedImplicitly]
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // Authentication and authorization
                Component.For<IAuthenticationService>().ImplementedBy<AutithicationService>().LifestyleTransient(),
                Component.For<IContextAccountProvider>().ImplementedBy<ContextAccountProvider>().LifestyleTransient(),
                Component.For<IGraphicStatisticService>().ImplementedBy<GraphicStatisticService>().LifestyleTransient(),
                Component.For<ITaskCreator>().ImplementedBy<TaskCreator>().LifestyleTransient(),
                Component.For<IConfig>().ImplementedBy<Config>().LifestyleSingleton(),
                Component.For<IWargamingApi>().ImplementedBy<WargamingApi>().LifestyleTransient()
            );
        }
    }
}