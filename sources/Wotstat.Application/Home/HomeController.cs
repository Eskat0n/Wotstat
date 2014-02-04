namespace Wotstat.Application.Home
{
    using System.Web.Mvc;
    using JetBrains.Annotations;
    using Security.Services;

    public class HomeController : Controller
    {
        [UsedImplicitly]
        public IContextAccountProvider ContextAccountProvider { get; set; }
        public ActionResult Index()
        {
            var account = ContextAccountProvider.ContextAccount();
            
            return View();
        }

    }
}