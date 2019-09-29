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
    public class PurchaseOrderItemMap : IAutoMappingOverride<PurchaseOrderItem>
    {
        public void Override(AutoMapping<PurchaseOrderItem> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.Map(x => x.NetPrice);
            mapping.Map(x => x.Quantity);
            mapping.Map(x => x.TotalPrice);
            mapping.Map(x => x.UnitPrice);
            mapping.References(x => x.Item);
            mapping.References(x => x.Rack);
        }
    }
}
