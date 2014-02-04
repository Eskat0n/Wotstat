namespace Wotstat.Application.Accounts
{
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model;
    using JetBrains.Annotations;
    using NArms.AutoMapper;
    using ViewModels;

    public class AccountController : Controller
    {
        [UsedImplicitly]
        public IRepository<Account> AccountRepository { get; set; }

        public ActionResult LogOn(UserResponseModel userResponseModel)
        {
            if (userResponseModel.Status != "ok") 
                return RedirectToAction("Index");
            
            //ToDo check accountExist

            var account = userResponseModel.MapTo(new Account());
            AccountRepository.Add(account);

            return RedirectToAction("Index");
        }
    }
}