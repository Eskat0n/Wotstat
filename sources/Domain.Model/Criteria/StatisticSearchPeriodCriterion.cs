namespace Domain.Model.Criteria
{
    using System;
    using ByndyuSoft.Infrastructure.Domain;

    public class StatisticSearchPeriodCriterion : ICriterion
    {
        public StatisticSearchPeriodCriterion(int playerId, DateTime startDate, DateTime endDate)
        {
            PlayerId = playerId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}