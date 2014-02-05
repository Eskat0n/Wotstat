namespace Domain.Model.Criteria
{
    using System;
    using ByndyuSoft.Infrastructure.Domain;

    public class PlayerIdAndDateCriterion : ICriterion
    {
        public PlayerIdAndDateCriterion(int playerId, DateTime date)
        {
            PlayerId = playerId;
            Date = date;
        }

        public int PlayerId { get; set; }
        public DateTime Date { get; set; }
    }
}