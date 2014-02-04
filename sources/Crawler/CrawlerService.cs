namespace Crawler
{
    using System;
    using System.IO;
    using System.ServiceProcess;
    using System.Threading;
    using System.Threading.Tasks;
    using EasyNetQ;
    using Messages;

    public partial class CrawlerService : ServiceBase
    {
        private IBus bus;
        private IPlayerInfoProvider playerInfoProvider;

        public CrawlerService()
        {
            InitializeComponent();
        }

        public void Start()
        {
            playerInfoProvider = new PlayerInfoProvider();

            bus = RabbitHutch.CreateBus("host=localhost");
            bus.Subscribe<PlayerInfoRequest>("Wotstat", OnMessage);
        }

        public new void Stop()
        {
            try
            {
                bus.Dispose();
            }
            catch
            {
            }
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        private void OnMessage(PlayerInfoRequest message)
        {
            var playerInfo = playerInfoProvider.GetPlayerInfo(message.PlayerId);
            bus.Publish(playerInfo);
        }

        protected override void OnStop()
        {
            Stop();
        }
    }
}
