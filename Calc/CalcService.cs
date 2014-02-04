using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    using System.IO;
    using EasyNetQ;
    using Messages;

    public partial class CalcService : ServiceBase
    {
        private IBus bus;

        public CalcService()
        {
            InitializeComponent();
        }

        public void Start()
        {
            bus = RabbitHutch.CreateBus("host=localhost");
            bus.Subscribe<PlayerInfo>("Wotstat", OnMessage);
        }

        public new void Stop()
        {
            try
            {
                bus.Dispose();
            }
            catch {}
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        private void OnMessage(PlayerInfo message)
        {
            // TODO Calculate and write to database
        }

        protected override void OnStop()
        {
            Stop();
        }
    }
}
