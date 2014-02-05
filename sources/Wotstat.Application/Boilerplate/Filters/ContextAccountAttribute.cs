namespace Wotstat.Application.Boilerplate.Filters
{
    using System.Web.Mvc;
    using NArms.Windsor;
    using Security.Services;

    public class ContextAccountAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var accountProvider = IoC.Resolve<IContextAccountProvider>();
            var account = accountProvider.ContextAccount();

            if (account == null)
                return;

            filterContext.Controller.ViewBag.AccountName = account.Name;
        } 
    }
}