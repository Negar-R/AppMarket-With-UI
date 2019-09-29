using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Market.Entities;
using Market.Entities.Entity;

namespace Market.Data
{
    public class SaleOrderMap : IAutoMappingOverride<SaleOrder>
    {
        public void Override(AutoMapping<SaleOrder> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.Map(x => x.Code);
            mapping.Map(x => x.CreationDate);
            mapping.Map(x => x.Title);
            mapping.HasMany(x => x.SaleOrderItems).Cascade.All();
        }
    }
}
