namespace Wotstat.Application.Security.Services
{
    using Domain.Model;

    public interface IAuthenticationService
    {
        void LogIn(Account account);
        void LogOut();
    }
}