namespace Tasker
{
    using NArms.Windsor;
    using NCron.Fluent.Crontab;
    using NCron.Service;

    public class Program
    {
        public static void Main(string[] args)
        {
            IoC.Init();
            Bootstrap.Init(args, ServiceSetup);
        }

        private static void ServiceSetup(ISchedulingService schedulingService)
        {
            schedulingService.At("10 * * * *").Run(() => new CreateTaskJob());
        }
    }
}