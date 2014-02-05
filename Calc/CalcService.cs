namespace Calc
{
    using System.Collections.Generic;
    using System.ServiceProcess;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Entities;
    using EasyNetQ;
    using Messages;
    using NArms.Windsor;

    public partial class CalcService : ServiceBase
    {
        private IBus _bus;
        private readonly IQueryBuilder _query;
        private readonly IRepository<Period> _periodsRepository;
        private IEnumerable<Period> _periods;

        public CalcService()
        {
            InitializeComponent();

            IoC.Init();
            _query = IoC.Resolve<IQueryBuilder>();
            _periodsRepository = IoC.Resolve<IRepository<Period>>();
        }

        public void Start()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
            _bus.Subscribe<PlayerInfo>("Wotstat", OnMessage);
            _periods = _periodsRepository.All();
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