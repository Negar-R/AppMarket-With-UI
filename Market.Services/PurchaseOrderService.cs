﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contracts;
using Market.Entities.Entity;
using Market.Entities.Interfaces;

namespace Market.Services
{
    public class PurchaseOrderService 
    {
        public IPurchaseOrderRepository IPurchaseOrderRepository { get; set; }
        public IItemRepository IitemRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }

        public void CreateAndUpdatePurchaseOrder(PurchaseOrderContract purchaseOrderContract)
        {
                //db
            var purchaseOrder = IPurchaseOrderRepository.Get(purchaseOrderContract.Id);
            if (purchaseOrder != null)
            {
                //purchaseOrder.Code = purchaseOrderContract.Code;
                //purchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                purchaseOrder.Title = purchaseOrderContract.Title;

                for (int i = 0 ; i < purchaseOrderContract.PurchaseOrderItemContracts.Count ; i++)
                {
                    var temp = purchaseOrderContract.PurchaseOrderItemContracts[i];
                    if (purchaseOrderContract.PurchaseOrderItemContracts.Any(x => x.Id == temp.Id))
                    {
                        //Update OrderItem
                        var InDatabaseOrderItem = purchaseOrder.PurchaseOrderItems.FirstOrDefault(x => x.Id == temp.Id);
                        InDatabaseOrderItem.NetPrice = temp.NetPrice;
                        InDatabaseOrderItem.Quantity = temp.Quantity;
                        InDatabaseOrderItem.UnitPrice = temp.UnitPrice;
                        InDatabaseOrderItem.TotalPrice = temp.TotalPrice;
                        InDatabaseOrderItem.Item = IitemRepository.Get(temp.ItemId);
                        InDatabaseOrderItem.Rack = IRackRepository.Get(temp.RackId);
                    }
                    else
                    {
                        //Create OrderItem
                        var InDatabaseOrderItem = new PurchaseOrderItem();

                        InDatabaseOrderItem.NetPrice = temp.NetPrice;
                        InDatabaseOrderItem.Quantity = temp.Quantity;
                        InDatabaseOrderItem.UnitPrice = temp.UnitPrice;
                        InDatabaseOrderItem.TotalPrice = temp.TotalPrice;
                        InDatabaseOrderItem.Item = IitemRepository.Get(temp.ItemId);
                        InDatabaseOrderItem.Rack = IRackRepository.Get(temp.RackId);

                        purchaseOrder.PurchaseOrderItems.Add(InDatabaseOrderItem);

                    }
                }

                for (int i = 0; i < purchaseOrder.PurchaseOrderItems.Count; i++)
                {
                    var temp = purchaseOrder.PurchaseOrderItems[i];
                    DeleteIndexBinder();

                }

                IPurchaseOrderRepository.Update(purchaseOrder);
            }
            else
            {
                purchaseOrder = new PurchaseOrder();
                purchaseOrder.Code = purchaseOrderContract.Code;
                purchaseOrder.CreationDate = purchaseOrderContract.CreationDate;
                purchaseOrder.Title = purchaseOrderContract.Title;

                IPurchaseOrderRepository.Insert(purchaseOrder);
            }
        }
    }
}