namespace Domain.Model.Entities
{
    using ByndyuSoft.Infrastructure.Domain;

    public class Period : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int DaysCount { get; set; }
        public virtual string Name { get; set; }
    }
}
