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
    public class PurchaseOrderMap : IAutoMappingOverride<PurchaseOrder>
    {
        public void Override(AutoMapping<PurchaseOrder> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.Map(x => x.Code);
            mapping.Map(x => x.CreationDate);
            mapping.Map(x => x.Title);
            mapping.HasMany(x => x.PurchaseOrderItems).Cascade.All();
        }
    }
}
