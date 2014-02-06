namespace Domain.Model.Criteria
{
    using ByndyuSoft.Infrastructure.Domain;

    public class PlayerIdAndPeriodCriterion : ICriterion
    {
        public PlayerIdAndPeriodCriterion(int playerId, int periodId)
        {
            PlayerId = playerId;
            PeriodId = periodId;
        }

        public int PlayerId { get; set; }
        public int PeriodId { get; set; }
    }
}