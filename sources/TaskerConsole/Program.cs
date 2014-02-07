namespace TaskerConsole
{
    using NArms.Windsor;
    using TaskService;

    internal class Program
    {
        private static void Main(string[] args)
        {
            IoC.Init();
            IoC.Resolve<ITaskCreator>().CreateTaskForAllAccounts();
        }
    }
}