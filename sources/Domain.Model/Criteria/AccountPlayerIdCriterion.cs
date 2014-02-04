namespace Domain.Model.Criteria
{
    using ByndyuSoft.Infrastructure.Domain;

    public class AccountPlayerIdCriterion : ICriterion
    {
        public AccountPlayerIdCriterion(int playerId)
        {
            PlayerId = playerId;
        }

        public int PlayerId { get; set; }
    }
}