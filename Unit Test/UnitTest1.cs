using System;
using System.Security.Cryptography.X509Certificates;
using Market.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Market.Entities;
using Market.Entities.Entity;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ItemTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var itemId = GetItemId();
                    Item item = session.Get<Item>(itemId);

                    var res = session.Get<Item>(item.Id);
                    Assert.AreEqual(item.Name , "Book");
                }
            }

        }
        private Guid GetItemId()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    Item item = new Item
                    {
                        Name = "Book",
                        Unit = Unit.Number
                    };

                    session.Save(item);
                    transaction.Commit();

                    //var d =  session.CreateSQLQuery("select * from dbo.item").List();

                    item = session.Get<Item>(item.Id);
                    return item.Id;
                }
            }
        }

        [TestMethod]
        public void RackTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    /*var rack = new Rack
                    {
                        Name = "First",
                        Code = 10,
                        Limit = 700,
                        Location = "First Flat"
                    };*/

                    Guid racckId = GetRackId();
                    Rack rack = session.Get<Rack>(racckId);

                    session.Save(rack);
                    transaction.Commit();

                    var res = session.Get<Rack>(rack.Id);
                    Assert.AreEqual(rack.Limit, 700);
                }
            }
        }
        private Guid GetRackId()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var rack = new Rack
                    {
                        Name = "First",
                        Code = 10,
                        Limit = 700,
                        Location = "First Flat"
                    };

                    session.Save(rack);
                    transaction.Commit();

                    rack = session.Get<Rack>(rack.Id);
                    return rack.Id;
                }
            }
        }


        [TestMethod]
        public void PurchaseOrderItemTest()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var itemId = GetItemId();
                    Item item = session.Get<Item>(itemId);

                    var racckId = GetRackId();
                    Rack rack = session.Get<Rack>(racckId);

                    PurchaseOrderItem purchaseOrderItem = new PurchaseOrderItem
                    {
                        NetPrice = 30,
                        UnitPrice = 50,
                        Quantity = 900,
                        Item = item ,
                        Rack = rack
                    };

                    session.Save(purchaseOrderItem);
                    transaction.Commit();

                    var res = session.Get<PurchaseOrderItem>(purchaseOrderItem.Id);
                    Assert.AreEqual(purchaseOrderItem.NetPrice, res.NetPrice);
                }
            }
        }
    }
}
