namespace Domain.Model
{
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    public class Account: IEntity
    {
        [UsedImplicitly]
        public Account()
        {
        }

        [UsedImplicitly]
        public Account(string token)
        {
            Token = token;
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; protected set; }

        public virtual long PlayerId { get; protected set; }

        public virtual string Token { get; protected set; }

    }
}