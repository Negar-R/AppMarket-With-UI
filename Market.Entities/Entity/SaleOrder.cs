using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class SaleOrder : Order
    {
        public SaleOrder()
        {
            SaleOrderItems = new List<SaleOrderItem>();
        }

        public virtual ICollection<SaleOrderItem> SaleOrderItems { get; set; }
    }
}
