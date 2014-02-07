namespace Wotstat.Application.Boilerplate.Filters
{
    using System.Web.Mvc;
    using Extensions.Web;
    using NArms.Windsor;
    using WargamingApi;

    public class OAuthUrlAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var helper = new UrlHelper(filterContext.RequestContext);
            var redirectUrl=helper.AbsoluteAction("Logon", "Account");
            var wargamingApi = IoC.Resolve<IWargamingApi>();
            filterContext.Controller.ViewBag.OAuthUrl=wargamingApi.GetLoginUrl(redirectUrl);
        }
    }
}