using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Market.Data.NhibernateConfiguration;

namespace Market.DependencyInjection
{
    public class CastleWinsorInstance
    {
        public static IWindsorContainer WindsorContainer { get; set; }

        public static T Resolve<T>()
        {
            return WindsorContainer.Resolve<T>();
        }
        public static T Resolve<T>(string name)
        {
            return WindsorContainer.Resolve<T>(name);
        }
    }
   public class Windsor
    {
        private static IWindsorContainer container;
        public static void Register()
        {
            container = new WindsorContainer();
            container.Install(FromAssembly.Containing<DependencyInstaller>());
            container.Install(FromAssembly.Containing<DataDependencyInstaller>());
            container.Install(FromAssembly.This());

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            CastleWinsorInstance.WindsorContainer = container;
          //  return container;

        }
    }
}
