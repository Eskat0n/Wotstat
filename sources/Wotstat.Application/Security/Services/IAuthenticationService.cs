namespace Wotstat.Application.Security.Services
{
    using Domain.Model;
    using Domain.Model.Entities;

    public interface IAuthenticationService
    {
        void LogIn(Account account);
        void LogOut();
    }
}