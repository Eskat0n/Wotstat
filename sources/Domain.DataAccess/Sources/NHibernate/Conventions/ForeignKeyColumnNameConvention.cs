namespace Domain.DataAccess.Sources.NHibernate.Conventions
{
    using System;
    using FluentNHibernate;
    using FluentNHibernate.Conventions;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class ForeignKeyColumnNameConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member member, Type type)
        {
            return string.Format("{0}Id", member == null ? type.Name : member.Name);
        }
    }
}