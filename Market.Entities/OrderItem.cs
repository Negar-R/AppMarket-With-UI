using Market.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities
{
    public abstract class OrderItem : BaseEntity
    {
        public OrderItem()
        {

        }
        public virtual decimal NetPrice { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual decimal UnitPrice { get; set; }
       

        public virtual Item Item { get; set; }
        public virtual Rack Rack { get; set; }

    }
}
