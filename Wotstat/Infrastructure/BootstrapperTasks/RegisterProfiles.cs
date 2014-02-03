﻿namespace Wotstat.Infrastructure.BootstrapperTasks
{
    using Application.Annotations;
    using Application.Home;
    using AutoMapper;
    using MvcExtensions;
    using NArms.AutoMapper.Bootstrapping;

    [UsedImplicitly]
    public class RegisterProfiles : BootstrapperTask
    {
  

        public override TaskContinuation Execute()
        {
            ProfileLoader.FromAssemblyContaining<HomeController>().LoadAll();
            Mapper.AssertConfigurationIsValid();
            
            return TaskContinuation.Continue;
        }
    }
}