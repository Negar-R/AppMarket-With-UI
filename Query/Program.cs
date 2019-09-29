using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Data;
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
                    PurchaseOrderItem purchaseOrderItem = new PurchaseOrderItem
                    {
                        NetPrice = 30,
                        UnitPrice = 50,
                        Quantity = 900
                    };

                    session.Save(purchaseOrderItem);
                    transaction.Commit();

                    List<PurchaseOrderItem> purchase = session.Query<PurchaseOrderItem>()
                        .Where(x => x.Quantity == 900).ToList();

                    foreach (var p in purchase)
                    {
                        Console.WriteLine(p.Id);
                    }

                    Console.WriteLine(typeof(SaleOrderItem));
                    Console.WriteLine(typeof(Order));


                    Console.ReadKey();
                    

                 }
            }
        }
    }
}
