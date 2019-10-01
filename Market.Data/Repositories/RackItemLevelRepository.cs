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
    public class RackItemLevelRepository : IRackItemLevelRepository
    {
        private ISession session;
        public List<RackItemLevel> GetAll()
        {
            return session.QueryOver<RackItemLevel>().List<RackItemLevel>().ToList();
        }

        public RackItemLevel Get(Guid id)
        {
            return session.Get<RackItemLevel>(id);
        }

        public void Insert(RackItemLevel obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Update(RackItemLevel obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Delete(RackItemLevel obj)
        {
            session.Delete(obj);
        }
    }
}
