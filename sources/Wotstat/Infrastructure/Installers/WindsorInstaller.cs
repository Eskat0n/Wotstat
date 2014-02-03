namespace Wotstat.Infrastructure.Installers
{
    using Application.Annotations;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using NArms.Windsor;

    [UsedImplicitly]
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            IoC.Init(container);
        }
    }
}