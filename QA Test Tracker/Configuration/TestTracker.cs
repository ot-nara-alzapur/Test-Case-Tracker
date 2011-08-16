using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using QA_Test_Tracker.FluentConventions;
using QA_Test_Tracker.FluentMappings;

namespace QA_Test_Tracker.Configuration
{
    public class TestTracker
    {
        private static ISessionFactory sessionFactory;
        private static readonly object configLock = new object();
        private static readonly object sessionLock = new object();
        private static FluentConfiguration configuration;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    lock (sessionLock)
                    {
                        if (sessionFactory == null)
                        {
                            sessionFactory = Configuration.BuildSessionFactory();
                        }
                    }
                }

                return sessionFactory;
            }
        }

        public static FluentConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    lock (configLock)
                    {
                        if (configuration == null)
                        {
                            configuration = Fluently.Configure()
                                .Database(
                                    MsSqlConfiguration.MsSql2005.ConnectionString(
                                        c => c.FromConnectionStringWithKey("TestTracker")))
                                .Mappings(m => m.FluentMappings
                                                   .AddFromAssemblyOf<TestPlanMap>()
                                                   .Conventions.AddFromAssemblyOf<ClassConvention>());
                            //.ExposeConfiguration(BuildSchema);
                        }
                    }
                }

                return configuration;
            }
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration cfg)
        {
            new SchemaExport(cfg)
                .SetOutputFile(@"c:\version1.sql")
                .Execute(true, true, false);
        }
    }
}