namespace Domain.Model
{
    using ByndyuSoft.Infrastructure.Domain;

    public class Account: IEntity
    {
        public virtual int Id { get; set; }
   
        public virtual string Name { get; set; }

        public virtual int PlayerId { get; set; }

    }
}