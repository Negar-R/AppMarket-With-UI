using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Market.Data.Repositories;
using Market.Entities.Entity;
using Market.Entities.Interfaces;
using NHibernate;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;

namespace Market.Data.NhibernateConfiguration
{
  
    

        public class DataDependencyInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                container.Kernel.ComponentRegistered += Kernel_ComponentRegisterd;
                container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(CreateNhSessionFactory).LifeStyle.Singleton, 
                    Classes.FromAssembly(Assembly.GetAssembly(typeof(ItemRepository))).BasedOn(typeof(RepositoryBase)).WithService.DefaultInterfaces().LifestyleTransient());
            }

            void Kernel_ComponentRegisterd(string key, Castle.MicroKernel.IHandler handler)
            {
                if (UnitOfWorkHelper.IsRepositoryClass(handler.ComponentModel.Implementation))
                {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
                }

                foreach (var method in handler.ComponentModel.Implementation.GetMethods())
                {
                    if (UnitOfWorkHelper.HasUnitOfWorkAttribute(method))
                    {
                        handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(NhUnitOfWorkInterceptor)));
                        return;
                    }
                }
            }

            private static ISessionFactory CreateNhSessionFactory()
            {


                var dbProtocol = ConfigurationManager.AppSettings["DB"];
                if (dbProtocol == "sql")
                {
                    var connectionString = "Data Source=n-rezaei;Initial Catalog=store;User ID=sa;Password=sa123";
                    var cfgi = new StoreConfiguration();
                    var fluentConfiguration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(connectionString)
                            .ShowSql()
                        );

                    var configuration =
                        fluentConfiguration.Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<Item>(cfgi).
                            UseOverridesFromAssemblyOf<ItemMap>()
                     //       .Conventions.Add(typeof(PropertyConvention)).Conventions.Add(typeof(BasePropertyConvention))
                            ));

                    var buildSessionFactory = configuration.ExposeConfiguration(cfg =>
                    {
                        new SchemaUpdate(cfg).Execute(false, true);
                        new SchemaExport(cfg)
                            .Create(false, false);
                    })
                        .BuildSessionFactory();


                    #region Create MasterData

                   

                    #endregion

                    return buildSessionFactory;
                }
              
                return null;


            }

        }

        public static class UnitOfWorkHelper
        {
            public static bool IsRepositoryMethod(MethodInfo methodInfo)
            {
                return IsRepositoryClass(methodInfo.DeclaringType);
            }

            public static bool IsRepositoryClass(Type type)
            {
                return typeof(IRepository).IsAssignableFrom(type);
            }

            public static bool HasUnitOfWorkAttribute(MethodInfo methodInfo)
            {
                return methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
            }
        }
    }

