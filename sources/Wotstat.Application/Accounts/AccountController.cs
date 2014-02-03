namespace Wotstat.Application.Accounts
{
    using System.Web.Mvc;
    using ViewModels;

    public class AccountController : Controller
    {

        public ActionResult LogOn(AccountResponseModel accountResponseModel)
        {
            return RedirectToAction("Index");
        }
    }
}