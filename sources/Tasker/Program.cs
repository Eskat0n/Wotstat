namespace TaskScheduler
{
    using NArms.Windsor;
    using NCron.Fluent.Crontab;
    using NCron.Service;
    using TaskService;

    public class Program
    {
        public static void Main(string[] args)
        {
            IoC.Init();
            Bootstrap.Init(args, ServiceSetup);
        }

        private static void ServiceSetup(ISchedulingService schedulingService)
        {
            var taskCreator = IoC.Resolve<ITaskCreator>();
            schedulingService.At("10 * * * *").Run(() => new CreateTaskJob(taskCreator));
        }
    }
}