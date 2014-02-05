namespace Domain.Model.Entities
{
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    public class Account: IEntity
    {
        private string _token;

        [UsedImplicitly]
        public Account()
        {
        }

        [UsedImplicitly]
        public Account(string token)
        {
            _token = token;
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; protected set; }

        public virtual int PlayerId { get; protected set; }

        [CanBeNull]
        public virtual string GetToken()
        {
            return _token;
        }

        public virtual void SetToken(string token)
        {
            _token = token;
        }
    }
}