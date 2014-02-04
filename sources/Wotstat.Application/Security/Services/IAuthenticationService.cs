namespace Wotstat.Application.Security.Services
{
    using System;
    using Domain.Model;

    public interface IAuthenticationService
    {
        void LogIn(Account account, TimeSpan expires);
        void LogOut();
    }
}