namespace Wotstat.Application.Security.Services
{
    using Domain.Model;
    using Domain.Model.Entities;
    using JetBrains.Annotations;

    public interface IContextAccountProvider
    {
        [CanBeNull]
        Account ContextAccount();
    }
}