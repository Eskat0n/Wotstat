namespace TaskScheduler.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;
    using TaskService;

    [UsedImplicitly]
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ITaskCreator>().ImplementedBy<TaskCreator>().LifestyleTransient()
            );
        }
    }
}