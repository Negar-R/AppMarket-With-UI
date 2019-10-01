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
    public class RackRepository : IRackRepository
    {
        private ISession session;
        public List<Rack> GetAll()
        {
            return session.QueryOver<Rack>().List<Rack>().ToList();
        }

        public Rack Get(Guid id)
        {
            return session.Get<Rack>(id);
        }

        public void Insert(Rack obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Update(Rack obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Delete(Rack obj)
        {
            session.Delete(obj);
        }
    }
}
