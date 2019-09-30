using System;
using System.CodeDom;
using System.CodeDom.Compiler;
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
        public IItemRepository IitemRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }
        public void CreateAndUpdatePurchaseOrder(SaleOrderContract saleOrderContract)
        {
            var saleOrder = ISaleOrderRepository.Get(saleOrderContract.Id);
            if (saleOrder != null)
            {
               // Update Order
                saleOrder.Title = saleOrderContract.Title;
                for (int i = 0; i < saleOrderContract.SaleOrderItemContracts.Count; i++)
                {
                    var temp = saleOrderContract.SaleOrderItemContracts[i];
                    if (saleOrder.SaleOrderItems.Any(x => x.Id == temp.Id))
                    {
                        // Update OrdetItem ..
                        var InDatabaseOrderItem = saleOrder.SaleOrderItems.FirstOrDefault(x => x.Id == temp.Id);
                        InDatabaseOrderItem.NetPrice = temp.NetPrice;
                        InDatabaseOrderItem.Quantity = temp.Quantity;
                        InDatabaseOrderItem.UnitPrice = temp.UnitPrice;
                        InDatabaseOrderItem.TotalPrice = temp.TotalPrice;
                        InDatabaseOrderItem.Item = IitemRepository.Get(temp.ItemId);
                        InDatabaseOrderItem.Rack = IRackRepository.Get(temp.RackId);
                    }
                    else
                    {
                        // Create OrderItem
                        var InDatabaseOrderItem  = new SaleOrderItem();

                        InDatabaseOrderItem.NetPrice = temp.NetPrice;
                        InDatabaseOrderItem.Quantity = temp.Quantity;
                        InDatabaseOrderItem.UnitPrice = temp.UnitPrice;
                        InDatabaseOrderItem.TotalPrice = temp.TotalPrice;
                        InDatabaseOrderItem.Item = IitemRepository.Get(temp.ItemId);
                        InDatabaseOrderItem.Rack = IRackRepository.Get(temp.RackId);

                        saleOrder.SaleOrderItems.Add(InDatabaseOrderItem);
                    }
                }

                //Delete extra orderItems in order(DB)
                for (int i = 0; i < saleOrder.SaleOrderItems.Count; i++)
                {
                    var temp = saleOrder.SaleOrderItems[i];
                    if (!saleOrderContract.SaleOrderItemContracts.Any(x => x.Id == temp.Id))
                    {
                        saleOrder.SaleOrderItems.Remove(temp);
                    }
                }

                ISaleOrderRepository.Update(saleOrder);
            }
            else
            {
                // Create Order
                saleOrder = new SaleOrder();
                saleOrder.Code = saleOrderContract.Code;
                saleOrder.CreationDate = saleOrderContract.CreationDate;
                saleOrder.Title = saleOrderContract.Title;

                for (int i = 0; i < saleOrderContract.SaleOrderItemContracts.Count; i++)
                {
                    var temp = saleOrderContract.SaleOrderItemContracts[i];

                    var InDatabaseOrderItem = new SaleOrderItem();

                    InDatabaseOrderItem.NetPrice = temp.NetPrice;
                    InDatabaseOrderItem.Quantity = temp.Quantity;
                    InDatabaseOrderItem.UnitPrice = temp.UnitPrice;
                    InDatabaseOrderItem.TotalPrice = temp.TotalPrice;
                    InDatabaseOrderItem.Item = IitemRepository.Get(temp.ItemId);
                    InDatabaseOrderItem.Rack = IRackRepository.Get(temp.RackId);

                    saleOrder.SaleOrderItems.Add(InDatabaseOrderItem);
                }

                ISaleOrderRepository.Insert(saleOrder);
            }
        }
    }
}
