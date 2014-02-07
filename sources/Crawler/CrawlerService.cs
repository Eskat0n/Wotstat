namespace Crawler
{
    using System.Configuration;
    using System.ServiceProcess;
    using EasyNetQ;
    using Messages;
    using NArms.Windsor;
    using WargamingApi;

    public partial class CrawlerService : ServiceBase
    {
        private readonly IWargamingApi _wargamingApi;
        private IBus _bus;

        public CrawlerService()
        {
            InitializeComponent();
            _wargamingApi = IoC.Resolve<IWargamingApi>();
        }

        public void Start()
        {
            _bus = RabbitHutch.CreateBus(ConfigurationManager.AppSettings["RabbitMq"]);
            _bus.Subscribe<PlayerInfoRequest>("Wotstat", OnMessage);
        }

        public new void Stop()
        {
            try
            {
                _bus.Dispose();
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
            var playerInfo = _wargamingApi.GetPlayerData(message.PlayerId);
            _bus.Publish(playerInfo);
        }

        protected override void OnStop()
        {
            Stop();
        }
    }
}