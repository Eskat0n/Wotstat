﻿namespace Wotstat.Infrastructure.Installers
{
    using Application.Home;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using JetBrains.Annotations;

    //[UsedImplicitly]
    //public class FormHandlersInstaller : IWindsorInstaller
    //{
    //    public void Install(IWindsorContainer container, IConfigurationStore store)
    //    {
    //        container.AddFacility<TypedFactoryFacility>();

    //        var formHandlers = Classes.FromAssemblyContaining(typeof(HomeController))
    //            .BasedOn(typeof(IFormHandler<>))
    //            .WithService.AllInterfaces()
    //            .LifestyleTransient();

    //        container.Register(
    //            formHandlers,
    //            Component.For<IFormHandlerFactory>().AsFactory().LifeStyle.Transient
    //            );
    //    }
    //}
}