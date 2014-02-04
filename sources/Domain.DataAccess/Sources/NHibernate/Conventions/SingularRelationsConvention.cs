namespace ByndyuSoft.Digit.Domain.DataAccess.Sources.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class SingularRelationsConvention : IReferenceConvention, IHasOneConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.LazyLoad();
            instance.NotFound.Ignore();
        }

        public void Apply(IOneToOneInstance instance)
        {
            instance.LazyLoad();
        }
    }
}