namespace TaskerConsole
{
    using NArms.Windsor;
    using Tasker;

    internal class Program
    {
        private static void Main(string[] args)
        {
            IoC.Init();
            new TaskCreator().Execute();
        }
    }
}