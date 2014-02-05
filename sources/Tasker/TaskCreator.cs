namespace Tasker
{
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Entities;
    using EasyNetQ;
    using Messages;
    using NArms.Windsor;

    public class TaskCreator
    {
        public void Execute()
        {
            var accountRepository = IoC.Resolve<IRepository<Account>>();
            var unitOfWorkFactory = IoC.Resolve<IUnitOfWorkFactory>();
            var bus = RabbitHutch.CreateBus("host=localhost");

            using (unitOfWorkFactory.Create())
            {
                var accounts = accountRepository.All();
                foreach (var account in accounts)
                    bus.Publish(new PlayerInfoRequest {PlayerId = account.PlayerId});
            }

            bus.Dispose();
        }
    }
}