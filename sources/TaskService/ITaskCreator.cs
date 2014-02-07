namespace TaskService
{
    using Domain.Model.Entities;

    public interface ITaskCreator
    {
        void CreateTaskForAllAccounts();
        void CreateTaskForAccount(Account account);
    }
}