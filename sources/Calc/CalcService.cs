namespace Calc
{
    using System.Collections.Generic;
    using System.ServiceProcess;
    using ByndyuSoft.Infrastructure.Domain;
    using Domain.Model.Criteria;
    using Domain.Model.Entities;
    using EasyNetQ;
    using Messages;
    using NArms.Windsor;
    using NHibernate.Linq;

    public partial class CalcService : ServiceBase
    {
        private IBus _bus;
        private readonly IQueryBuilder _query;
        private readonly IRepository<Period> _periodsRepository;
        private readonly IRepository<StatisticalData> _statisticDataRepository;
        private readonly IRepository<DynamicData> _dynamicDataRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private IEnumerable<Period> _periods;
        

        public CalcService()
        {
            InitializeComponent();

            IoC.Init();
            _query = IoC.Resolve<IQueryBuilder>();
            _periodsRepository = IoC.Resolve<IRepository<Period>>();
            _statisticDataRepository = IoC.Resolve<IRepository<StatisticalData>>();
            _dynamicDataRepository = IoC.Resolve<IRepository<DynamicData>>();
            _unitOfWorkFactory = IoC.Resolve<IUnitOfWorkFactory>();
        }

        public void Start()
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                _periods = _periodsRepository.All();
            }
            _bus = RabbitHutch.CreateBus("host=localhost");
            _bus.Subscribe<PlayerInfo>("Wotstat", OnMessage);
        }

        public new void Stop()
        {
            try
            {
                _bus.Dispose();
            }
            catch {}
        }

        protected override void OnStart(string[] args)
        {
            Start();
        }

        private void OnMessage(PlayerInfo message)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var nowData = Convert(message);
                _statisticDataRepository.Add(nowData);
                
                _periods.ForEach(period =>
                {
                    var oldData = _query.For<StatisticalData>().With(new PlayerIdAndDateCriterion(message.PlayerId, nowData.Date.AddDays(-period.DaysCount)));
                    if (oldData == null)
                        return;

                    var wasPeriodData = _query.For<DynamicData>().With(new PlayerIdAndPeriodCriterion(message.PlayerId, period.Id));
                    if (wasPeriodData != null) {
                        Subtraction(nowData, oldData, wasPeriodData);
                        return;
                    }

                    var nowPeriodData = new DynamicData {Period = period, PlayerId = message.PlayerId};
                    Subtraction(nowData, oldData, nowPeriodData);
                    _dynamicDataRepository.Add(nowPeriodData);
                });
                unitOfWork.Commit();
            }
        }

        private StatisticalData Convert(PlayerInfo a)
        {
            return new StatisticalData
            {
                BattleAvgXp = a.BattleAvgXp,
                Battles = a.Battles,
                DamageDealt = a.DamageDealt,
                Frags = a.Frags,
                HitsPercents = a.HitsPercents,
                MaxXp = a.MaxXp,
                Date = a.Time.Date,
                PlayerId = a.PlayerId,
                WinsPercents = ((double) a.Wins)/(a.Wins + a.Losses + a.Draws)*100
            };
        }
        private void Subtraction(StatisticalData a, StatisticalData b, DynamicData res)
        {
            res.BattleAvgXp = a.BattleAvgXp - b.BattleAvgXp;
            res.Battles = a.Battles - b.Battles;
            res.DamageDealt = a.DamageDealt - b.DamageDealt;
            res.Frags = a.Frags - b.Frags;
            res.HitsPercents = a.HitsPercents - b.HitsPercents;
            res.WinsPercents = a.WinsPercents - b.WinsPercents;
            res.MaxXp = a.MaxXp - b.MaxXp;
        }

        protected override void OnStop()
        {
            Stop();
        }
    }
}