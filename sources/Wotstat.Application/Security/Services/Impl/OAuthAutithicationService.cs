namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;
    using Annotations;
    using Domain.Model;

    [UsedImplicitly]
    public class OAuthAutithicationService : IAuthenticationService
    {
        public void LogIn(Account account, bool createPersistentCookie)
        {
            /*
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };


            HttpContext.Current.Response.Cookies.Add(authCookie);
            var identity = new CustomIdentity(accountEntry, authTicket.Name);
            HttpContext.Current.User = new GenericPrincipal(identity, null);
            */
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}