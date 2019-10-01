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
    public class SaleOrderRepository : ISaleOrderRepository
    {
        private ISession session;

        public List<SaleOrder> GetAll()
        {
            return session.QueryOver<SaleOrder>().List<SaleOrder>().ToList();
        }

        public SaleOrder Get(Guid id)
        {
            return session.Get<SaleOrder>(id);
        }

        public void Insert(SaleOrder obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Update(SaleOrder obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Delete(SaleOrder obj)
        {
            session.Delete(obj);
        }
    }
}
