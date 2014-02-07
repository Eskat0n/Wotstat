namespace Crawler
{
    using System;
    using System.ServiceProcess;
    using NArms.Windsor;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            IoC.Init();
            var service = new CrawlerService();
            var servicesToRun = new ServiceBase[]  { service };
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
