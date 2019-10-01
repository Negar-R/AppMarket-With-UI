using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;
using Market.Entities.Interfaces;
using NHibernate;

namespace Market.Data.Repositories
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private ISession session;
        public List<PurchaseOrder> GetAll()
        {
            return session.QueryOver<PurchaseOrder>().List<PurchaseOrder>().ToList();
        }

        public PurchaseOrder Get(Guid id)
        {
            return session.Get<PurchaseOrder>(id);
        }

        public void Insert(PurchaseOrder obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Update(PurchaseOrder obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Delete(PurchaseOrder obj)
        {
            session.Delete(obj);
            // dige nabayad be OrderItem kari dashte bashim chon tu service Esh umadim 
            // tu Order add kardimeshun.
        }
    }
}
