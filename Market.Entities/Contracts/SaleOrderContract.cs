﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities.Contracts
{
    public class SaleOrderContract : OrderContract
    {
        //List SaleOrderItem
        public SaleOrderContract()
        {
            SaleOrderItemContracts = new List<SaleOrderItemContract>();
        }
        public List<SaleOrderItemContract> SaleOrderItemContracts{ get; set; }
    }
}
