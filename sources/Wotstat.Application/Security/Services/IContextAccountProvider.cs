namespace Wotstat.Application.Security.Services
{
    using Domain.Model;

    public interface IContextAccountProvider
    {
        Account ContextAccount();
    }
}