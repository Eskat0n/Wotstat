using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var service = new CalcService();
            var servicesToRun = new ServiceBase[] { service };
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
