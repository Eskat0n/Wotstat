namespace Domain.Model.Criteria
{
    using ByndyuSoft.Infrastructure.Domain;

    public class StatisticSearchCriterion: ICriterion
    {
        public StatisticSearchCriterion(int playerId)
        {
            PlayerId = playerId;
        }

        public int PlayerId { get; set; }
    }
}