using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Run
{
    using EasyNetQ;
    using Messages;

    class Program
    {
        private const int PlayerId = 100;

        static void Main(string[] args)
        {
            var bus = RabbitHutch.CreateBus("host=localhost");
            bus.Publish(new PlayerInfoRequest() { PlayerId = 100 });
            Crawler.Program.Main();
            bus.Dispose();
        }
    }
}