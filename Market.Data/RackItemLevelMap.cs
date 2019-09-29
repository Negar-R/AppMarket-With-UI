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
    public class RackItemLevelMap : IAutoMappingOverride<RackItemLevel>
    {
        public void Override(AutoMapping<RackItemLevel> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.Map(x => x.CurrentQuantity);
            mapping.Map(x => x.InQuantity);
            mapping.Map(x => x.OutQuantity);
            mapping.References(x => x.Item).Unique();
            mapping.References(x => x.Rack).Unique();
        }
    }
}
