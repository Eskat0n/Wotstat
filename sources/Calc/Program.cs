namespace Calc
{
    using System;
    using System.ServiceProcess;

    public static class Program
    {
        public static void Main()
        {
            var service = new CalcService();
            var servicesToRun = new ServiceBase[] {service};
            if (Environment.UserInteractive == false)
            {
                ServiceBase.Run(servicesToRun);
                return;
            }
            Console.CancelKeyPress += (x, y) => service.Stop();
            service.Start();
            Console.WriteLine("Service started");
            Console.ReadKey();
            service.Stop();
            Console.WriteLine("Service stopped");
        }
    }
}