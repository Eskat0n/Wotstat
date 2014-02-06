namespace Wotstat.Infrastructure.Installers
{
    using Application.Security.Services;
    using Application.Security.Services.Impl;
    using Application.Statistics.Services;
    using Application.Statistics.Services.Impl;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;


    [UsedImplicitly]
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // Authentication and authorization
                Component.For<IAuthenticationService>().ImplementedBy<AutithicationService>().LifestyleTransient(),
                Component.For<IContextAccountProvider>().ImplementedBy<ContextAccountProvider>().LifestyleTransient(),
                Component.For<IGraphicStatisticService>().ImplementedBy<GraphicStatisticService>().LifestyleTransient()
            );
        }
    }
}