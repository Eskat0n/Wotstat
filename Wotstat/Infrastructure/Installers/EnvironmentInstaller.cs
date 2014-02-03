namespace Wotstat.Infrastructure.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Application.Annotations;

    [UsedImplicitly]
    public class EnvironmentInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                // Configuration
                //Component.For(typeof(IConfigCore), typeof(IConfig)).Instance(new Config()),
                );
        }
    }
}