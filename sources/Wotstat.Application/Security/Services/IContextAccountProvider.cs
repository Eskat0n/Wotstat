namespace Wotstat.Application.Security.Services
{
    using Domain.Model;
    using JetBrains.Annotations;

    public interface IContextAccountProvider
    {
        [CanBeNull]
        Account ContextAccount();
    }
}