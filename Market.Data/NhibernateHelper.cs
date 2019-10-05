//using FluentNHibernate.Automapping;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FluentNHibernate.Cfg;
//using FluentNHibernate.Cfg.Db;
//using Market.Data;
//using Market.Entities;
//using NHibernate;
//using NHibernate.Tool.hbm2ddl;
//using Market.Entities.Entity;

//namespace Market.Data
//{
//    public class NhibernateHelper : DefaultAutomappingConfiguration
//    {
//        private static ISessionFactory _factory;

//        private static ISessionFactory SessionFactory
//        {
//            get
//            {
//                if (_factory == null)
//                {
//                    var connectionString = String.Empty;

//                    var cfgi = new StoreConfiguration();

//                    var fluentConfiguration = Fluently.Configure()
//                        .Database(MsSqlConfiguration.MsSql2012
//                            .ConnectionString(@"Data Source=.;Initial Catalog=store;User ID=sa;Password=sa123")
//                            .ShowSql()
//                        );

//                    var configuration =
//                        fluentConfiguration.Mappings(m =>
//                            m.AutoMappings.Add(AutoMap.AssemblyOf<Item>(cfgi)
//                                .UseOverridesFromAssemblyOf<ItemMap>())
//                        );
//                    var buildSessionFactory = configuration.ExposeConfiguration(cfg =>
//                        {
//                            new SchemaUpdate(cfg).Execute(false, false);
//                            new SchemaExport(cfg)
//                                .Create(true, true);
//                        })
//                        .BuildSessionFactory();



//                    _factory = buildSessionFactory;
//                }

//                return _factory;
//            }
//        }

//        public static ISession OpenSession()
//        {
//            return SessionFactory.OpenSession();
//        }
//    }
//}
