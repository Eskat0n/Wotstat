namespace Wotstat.Application.Home
{
    using System.Web.Mvc;
    using JetBrains.Annotations;
    using Security.Services;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
        }


    }
}