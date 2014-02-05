namespace Domain.Model.Entities
{
    using System;
    using ByndyuSoft.Infrastructure.Domain;

    public class StatisticalData : IEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int PlayerId { get; set; }
        public virtual double HitsPercents { get; set; }
        public virtual double BattleAvgXp { get; set; }
        public virtual double WinsPercents { get; set; }
        public virtual int Battles { get; set; }
        public virtual int DamageDealt { get; set; }
        public virtual int Frags { get; set; }
        public virtual int MaxXp { get; set; }
    }
}