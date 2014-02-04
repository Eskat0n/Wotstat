namespace Wotstat.Application.Accounts
{
    using System;
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
                account = userResponseModel.MapTo(new Account());
                AccountRepository.Add(account);
            }

            AuthenticationService.LogIn(account, TimeSpan.Parse(userResponseModel.Expires_At));

            return RedirectToAction("Index");
        }
    }
}