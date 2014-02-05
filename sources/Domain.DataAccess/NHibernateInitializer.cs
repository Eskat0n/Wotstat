namespace Domain.DataAccess
{
    using ByndyuSoft.Infrastructure.NHibernate;
    using ByndyuSoft.Infrastructure.NHibernate.Conventions;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Conventions.Helpers;
    using Model;
    using Model.Entities;
    using NHibernate.Cfg;
    using NHibernate.Context;

    public class NHibernateInitializer: INHibernateInitializer
    {
        public Configuration GetConfiguration()
        {
            var config = MsSqlConfiguration.MsSql2008
                .ConnectionString(x => x.FromConnectionStringWithKey("Main"))
                .UseReflectionOptimizer()
                .AdoNetBatchSize(100);

            var persistenceModel = AutoMap
                .AssemblyOf<Account>(new AutomappingConfiguration())
                .UseOverridesFromAssemblyOf<NHibernateInitializer>()
                .Conventions.Add<CustomManyToManyTableNameConvention>()
                .Conventions.Add<ForeignKeyConstraintNameConvention>()
                .Conventions.Add<NotNullPropertyConvention>()
                .Conventions.AddFromAssemblyOf<NHibernateInitializer>();

            var autoPersistenceModel = persistenceModel.Conventions
                .Setup(z => z.Add(AutoImport.Never()));

            var fluentConfiguration = Fluently.Configure()
                .CurrentSessionContext<ThreadStaticSessionContext>()
                .Database(config)
                .Mappings(x => x.AutoMappings.Add(autoPersistenceModel));

            return fluentConfiguration
                .BuildConfiguration();
        }
    }
}
