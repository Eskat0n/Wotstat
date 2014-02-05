namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;
    using Domain.Model;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class AutithicationService : IAuthenticationService
    {
        public void LogIn(Account account)
        {
            var accountEntry = new AccountEntry(account);

            var authTicket = new FormsAuthenticationTicket(1,
                account.Name,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                true,
                accountEntry.Serialize());

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };

            HttpContext.Current.Response.Cookies.Add(authCookie);
            var identity = new CustomIdentity(accountEntry, authTicket.Name);
            HttpContext.Current.User = new GenericPrincipal(identity, null);
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}