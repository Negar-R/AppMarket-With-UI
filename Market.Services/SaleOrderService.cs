using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contracts;
using Market.Entities.Entity;
using Market.Entities.Interfaces;

namespace Market.Services
{
    public class SaleOrderService
    {
        public ISaleOrderRepository ISaleOrderRepository { get; set; }
        public void CreateAndUpdatePurchaseOrder(SaleOrder saleOrderContract)
        {
            var saleOrder = ISaleOrderRepository.Get(saleOrderContract.Id);
            if (saleOrder != null)
            {
                saleOrder.SaleOrderItems = saleOrderContract.SaleOrderItems;
                saleOrder.Code = saleOrderContract.Code;
                saleOrder.CreationDate = saleOrderContract.CreationDate;
                saleOrder.Title = saleOrderContract.Title;

                ISaleOrderRepository.Update(saleOrder);
            }
            else
            {
                saleOrder = new SaleOrder();
                saleOrder.Code = saleOrderContract.Code;
                saleOrder.CreationDate = saleOrderContract.CreationDate;
                saleOrder.Title = saleOrderContract.Title;

                ISaleOrderRepository.Insert(saleOrder);
            }
        }
    }
}
