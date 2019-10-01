using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Data;
using Market.Data.Repositories;
using Market.Entities;
using Market.Entities.Entity;
using NHibernate.Linq;

namespace Query
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    PurchaseOrderItem purchaseOrderItem1 = new PurchaseOrderItem
                    {
                        NetPrice = 30,
                        UnitPrice = 50,
                        Quantity = 1000
                    };

                    PurchaseOrderItem purchaseOrderItem2 = new PurchaseOrderItem
                    {
                        NetPrice = 30,
                        UnitPrice = 50,
                        Quantity = 900
                    };

                    Item item = new Item
                    {
                        Name = "Pen",
                        Unit = Unit.Number
                    };

                    session.Save(item);
                    session.Save(purchaseOrderItem1);
                    session.Save(purchaseOrderItem2);
                    transaction.Commit();

                    IList<PurchaseOrderItem> purchase = session.QueryOver<PurchaseOrderItem>()
                       .List<PurchaseOrderItem>().ToList();

                    //ItemRepository it = new ItemRepository();
                    //var a = it.GetAll().Count;
                    //var b = it.Insert();
                    //Console.WriteLine("LOL " + a);
                    //var t = session.CreateSQLQuery("select * from [store].[dbo].[Item]").List();


                    //foreach (Item ite in t)
                    //{
                    //    Console.WriteLine("This is our intention : " + ite.Name);
                    //}


                    //Console.WriteLine(t);

                    foreach (var p in purchase)
                    {
                        Console.WriteLine(p.Id);
                        Console.WriteLine(p.Quantity);

                    }

                    //Console.WriteLine(typeof(SaleOrderItem));
                    //Console.WriteLine(typeof(Order));


                    Console.ReadKey();
                    

                 }
            }
        }
    }
}
