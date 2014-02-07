namespace Calc
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
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
            using (_unitOfWorkFactory.Create())
            {
                _periods = _periodsRepository.All();
            }
            _bus = RabbitHutch.CreateBus(ConfigurationManager.AppSettings["RabbitMq"]);
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
                var newStatisticalData = Convert(message);
                _statisticDataRepository.Add(newStatisticalData);
                
                _periods.ForEach(period =>
                {
                    var oldStatisticalData = _query.For<StatisticalData>().With(new PlayerIdAndDateCriterion(message.PlayerId, newStatisticalData.Date.AddDays(-period.DaysCount)));
                    if (oldStatisticalData == null)
                        return;

                    var oldDynamicData = _query.For<DynamicData>().With(new PlayerIdAndPeriodCriterion(message.PlayerId, period.Id));
                    if (oldDynamicData != null) {
                        oldDynamicData.Update(newStatisticalData, oldStatisticalData);
                        return;
                    }
                    
                    var nowPeriodData = new DynamicData(message.PlayerId, period);
                    nowPeriodData.Update(newStatisticalData, oldStatisticalData);
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

        protected override void OnStop()
        {
            Stop();
        }
    }
}