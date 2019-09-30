using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class PurchaseOrder: Order
    {
        public PurchaseOrder()
        {
            PurchaseOrderItems = new List<PurchaseOrderItem>();

        }
        public virtual List<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
