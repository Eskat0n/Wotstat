namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.Web;
    using System.Web.Security;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model;
    using JetBrains.Annotations;

    public class ContextAccountProvider : IContextAccountProvider
    {
        [UsedImplicitly]
        public IRepository<Account> AccountRepository { get; set; }

        public Account ContextAccount()
        {
            if (IsAuthorized() == false)
                return null;

            var formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;

            if (formsIdentity == null)
                return null;

            var ticket = formsIdentity.Ticket;
            var accontEntry = AccountEntry.Deserialize(ticket.UserData);

            var account = AccountRepository.Get(accontEntry.Id);

            if (account != null)
                account.SetToken(accontEntry.Token);

            return account;
        }

        public bool IsAuthorized()
        {
            var identity = HttpContext.Current.User.Identity;
            return identity.IsAuthenticated;
        }

        public void CheckAuthorization()
        {
            if (IsAuthorized() == false)
                throw new AccessViolationException("Not authorized");
        }
    }
}