namespace Tasker
{
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Entities;
    using EasyNetQ;
    using JetBrains.Annotations;
    using Messages;
    using NArms.Windsor;

    public class TaskCreator
    {
        [UsedImplicitly]
        public IRepository<Account> AccountRepository { get; set; }

        public void Execute()
        {
            AccountRepository = IoC.Resolve<IRepository<Account>>();
            var bus = RabbitHutch.CreateBus("host=localhost");

            var accounts = AccountRepository.All();
            foreach (var account in accounts)
                bus.Publish(new PlayerInfoRequest {PlayerId = account.PlayerId});

            bus.Dispose();
        }
    }
}