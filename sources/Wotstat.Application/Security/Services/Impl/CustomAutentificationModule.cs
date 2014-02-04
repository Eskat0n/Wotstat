namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;

    public class CustomAutentificationModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnAuthenticateRequest;
        }

        private static void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var context = app.Context;

            if (context.User != null && context.User.Identity.IsAuthenticated)
                return;

            var cookieName = "wot";
            var cookie = app.Request.Cookies[cookieName.ToUpper()];
            if (cookie == null)
                return;

            try
            {
                var accountEntry = AccountEntry.Deserialize(cookie.Value);
                var identity = new CustomIdentity(accountEntry, accountEntry.Name);
                var principal = new GenericPrincipal(identity, null);
                context.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {
            }
        }

        public void Dispose()
        {
        }
    }
}