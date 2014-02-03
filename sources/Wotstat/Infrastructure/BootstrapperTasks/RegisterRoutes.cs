namespace Wotstat.Infrastructure.BootstrapperTasks
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcExtensions;
    using Application.Annotations;

    [UsedImplicitly]
    public class RegisterRoutes : RegisterRoutesBase
    {
        public RegisterRoutes(RouteCollection routes)
            : base(routes)
        {
        }

        protected override void Register()
        {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Routes.MapRoute("Default", "{controller}/{action}/{id}",
                            new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }
    }
}