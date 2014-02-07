namespace Domain.Model.Entities
{
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    public class DynamicData : IEntity
    {
        [UsedImplicitly]
        public DynamicData()
        {
            
        }

        public DynamicData(int playerId, Period period)
        {
            Period = period;
            PlayerId = playerId;
        }
        public virtual int Id { get; set; }
        public virtual Period Period { get; protected set; }
        public virtual int PlayerId { get; protected set; }
        public virtual double HitsPercents { get; protected set; }
        public virtual double BattleAvgXp { get; protected set; }
        public virtual double WinsPercents { get; protected set; }
        public virtual int Battles { get; protected set; }
        public virtual int DamageDealt { get; protected set; }
        public virtual int Frags { get; protected set; }
        public virtual int MaxXp { get; protected set; }

        public void Update(StatisticalData newData, StatisticalData olData)
        {
            BattleAvgXp = newData.BattleAvgXp - olData.BattleAvgXp;
            Battles = newData.Battles - olData.Battles;
            DamageDealt = newData.DamageDealt - olData.DamageDealt;
            Frags = newData.Frags - olData.Frags;
            HitsPercents = newData.HitsPercents - olData.HitsPercents;
            WinsPercents = newData.WinsPercents - olData.WinsPercents;
            MaxXp = newData.MaxXp - olData.MaxXp;
        }
    }
}
