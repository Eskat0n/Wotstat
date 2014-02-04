namespace Crawler
{
    using System;
    using System.IO;
    using System.ServiceProcess;
    using System.Threading;
    using System.Threading.Tasks;
    using EasyNetQ;
    using Messages;

    public partial class PlayerInfoProvideService : ServiceBase
    {
        private IBus bus;
        private IPlayerInfoProvider playerInfoProvider;

        public PlayerInfoProvideService()
        {
            InitializeComponent();
        }

        public void Start()
        {
            try
            {
                bus = RabbitHutch.CreateBus("host=localhost");
                bus.Subscribe<PlayerInfoRequest>("Wotstat", OnMessage);
            }
            catch (Exception e)
            {
                File.WriteAllText(@"E:\Projects\Wotstat\Crawler\bin\Debug\test.txt", "OnStart" + e.ToString());
                throw e;
            }

            playerInfoProvider = new PlayerInfoProvider();
        }

        public new void Stop()
        {
            try
            {
                bus.Dispose();
            }
            catch (Exception e)
            {
                File.WriteAllText(@"E:\Projects\Wotstat\Crawler\bin\Debug\test.txt", "OnStop" + e.ToString());
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
