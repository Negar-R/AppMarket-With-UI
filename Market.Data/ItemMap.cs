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
    public class ItemMap : IAutoMappingOverride<Item>
    {
        public void Override(AutoMapping<Item> mapping)
        {
            mapping.Id(x => x.Id);
            mapping.Map(x => x.Code);
            mapping.Map(x => x.Name);
            mapping.Map(x => x.Unit);
            
        }
    }
}
