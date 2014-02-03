namespace Wotstat.Infrastructure.Installers
{
    using Application.Annotations;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    [UsedImplicitly]
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //ORM
                );
        }
    }
}