using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities.Contracts
{
    public class PurchaseOrderContract : OrderContract
    {
        // List PurchaseOrderItem
        public List<PurchaseOrderItemContract> PurchaseOrderItemContracts { get; set; }

        public PurchaseOrderContract()
        {
            PurchaseOrderItemContracts = new List<PurchaseOrderItemContract>();
        }
    }
}
