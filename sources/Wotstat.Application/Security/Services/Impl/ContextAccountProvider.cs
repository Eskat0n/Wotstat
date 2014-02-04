namespace Wotstat.Application.Security.Services.Impl
{
    using System;
    using System.Web;
    using Domain.Model;

    public class ContextAccountProvider : IContextAccountProvider
    {
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

        public Account ContextAccount()
        {
            if (IsAuthorized() == false)
                return null;

            var identity = HttpContext.Current.User.Identity;
            //AccountEntry.Deserialize();

            return null;
        }  
    }
}