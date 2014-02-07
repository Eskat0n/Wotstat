namespace Wotstat.Application.Boilerplate.Filters
{
    using System.Web.Mvc;
    using Enviroment;
    using NArms.Windsor;

    public class ConfigAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Config = IoC.Resolve<IConfig>();
        }
    }
}