namespace Wotstat.Application.Accounts
{
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model;
    using Domain.Model.Criteria;
    using JetBrains.Annotations;
    using NArms.AutoMapper;
    using Security.Services;
    using ViewModels;

    public class AccountController : Controller
    {
        [UsedImplicitly]
        public IQueryBuilder Query { get; set; }

        [UsedImplicitly]
        public IRepository<Account> AccountRepository { get; set; }

        [UsedImplicitly]
        public IAuthenticationService AuthenticationService { get; set; }

        [HttpGet]
        public ActionResult LogOn(UserResponseModel userResponseModel)
        {
            if (userResponseModel.Status != "ok")
                return RedirectToAction("Index");

            var account = Query.For<Account>()
                .With(new AccountPlayerIdCriterion(userResponseModel.Account_Id));
            
            if (account == null)
            {
                account = userResponseModel.MapTo(new Account(userResponseModel.Access_Token));
                AccountRepository.Add(account);
            }
            else
            {
                account.SetToken(userResponseModel.Access_Token);
            }

            AuthenticationService.LogIn(account);

            return RedirectToAction("Index", "Home");
        }
    }
}