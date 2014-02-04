namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using Domain.Model;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class AutithicationService : IAuthenticationService
    {
        public void LogIn(Account account, TimeSpan expires)
        {
            var accountEntry = new AccountEntry(account);

            var authCookie = new HttpCookie("wot", accountEntry.Serialize())
            {
                Expires = DateTime.Now.Add(expires)
            };

            HttpContext.Current.Response.Cookies.Add(authCookie);
            var identity = new CustomIdentity(accountEntry, accountEntry.Name);
            HttpContext.Current.User = new GenericPrincipal(identity, null);
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}