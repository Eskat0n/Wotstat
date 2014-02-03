namespace Wotstat.Infrastructure.Installers
{
    using Application.Annotations;
    using Application.Security.Services;
    using Application.Security.Services.Impl;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;


    [UsedImplicitly]
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // Authentication and authorization
                Component.For<IAuthenticationService>().ImplementedBy<OAuthAutithicationService>().LifeStyle.Transient,
                Component.For<IContextAccountProvider>().ImplementedBy<ContextAccountProvider>().LifeStyle.Transient
            );
        }
    }
}