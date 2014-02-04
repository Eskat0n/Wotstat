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
        public virtual int Id { get; set; }
   
        public virtual string Name { get; set; }

        public virtual int PlayerId { get; set; }

    }
}