using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Utils;
using Market.Entities;
using Market.Entities.Entity;
using NHibernate.Criterion;
using NHibernate.Mapping.ByCode;

namespace Market.Data
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return typeof(BaseEntity).IsAssignableFrom(type) && !type.IsAbstract;
        }
    }
}
