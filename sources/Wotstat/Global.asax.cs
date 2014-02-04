﻿namespace Wotstat
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using Infrastructure.BootstrapperTasks;
    using MvcExtensions;
    using MvcExtensions.Windsor;

    public class MvcApplication : WindsorMvcApplication
    {
        public MvcApplication()
        {
            Bootstrapper.BootstrapperTasks
                .Include<RunMigrations>()
                .Include<RegisterModelMetadata>()
                .Include<RegisterControllers>()
                .Include<RegisterRoutes>()
                .Include<RegisterProfiles>()
                .Include<RegisterModelBinders>();

            StringMetadataItemBuilder.EmailErrorMessage = "Неправильный формат адреса электронной почты";
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           /* filters.Add(new CustomHandleErrorAttribute());
            filters.Add(new ContextAccountAttribute());
            filters.Add(new ConfigAttribute());
            filters.Add(new VersionAttribute());
             */
        }

        protected override void OnStart()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
