﻿namespace Domain.DataAccess.Sources.NHibernate.Conventions
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;
    using Utilites;

    [UsedImplicitly]
    public class EntityMapConvention : IClassConvention, IJoinedSubclassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name.ToPlural());
            instance.BatchSize(250);
        }

        public void Apply(IJoinedSubclassInstance instance)
        {
            instance.Table(instance.EntityType.Name.ToPlural());
            instance.BatchSize(250);
        }
    }
}