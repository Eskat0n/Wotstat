namespace Wotstat.Application.Home
{
    using System.Web.Mvc;
    using JetBrains.Annotations;
    using Security.Services;

    public class HomeController : Controller
    {
        public IContextAccountProvider ContextAccountProvider { get; set; }
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult Test()
        {
            
            var account = ContextAccountProvider.ContextAccount();
            return View();
        }
            
    }
}