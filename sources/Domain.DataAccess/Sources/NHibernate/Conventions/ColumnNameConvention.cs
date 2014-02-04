namespace ByndyuSoft.Digit.Domain.DataAccess.Sources.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class ColumnNameConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(instance.Name);
        }
    }
}