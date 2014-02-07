namespace TaskService
{
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Entities;
    using EasyNetQ;
    using Messages;

    public class TaskCreator : ITaskCreator
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public TaskCreator(IRepository<Account> accountRepository, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _accountRepository = accountRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }
        public void CreateTaskForAllAccounts()
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            using (_unitOfWorkFactory.Create())
            {
                var accounts = _accountRepository.All();
                foreach (var account in accounts)
                    bus.Publish(new PlayerInfoRequest {PlayerId = account.PlayerId});
            }

            bus.Dispose();
        }

        public void CreateTaskForAccount(Account account)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");

            using (_unitOfWorkFactory.Create())
            {
                bus.Publish(new PlayerInfoRequest { PlayerId = account.PlayerId });
            }

            bus.Dispose();
        }
    }
}