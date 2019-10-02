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
    public class ItemRepository : IItemRepository
    {
        private ISession session;

        public List<Item> GetAll()
        {
          return  session.QueryOver<Item>().List<Item>().ToList();
        }

        public Item Get(Guid id)
        {
            Item item = session.Get<Item>(id);
            return item;
        }

        public void Insert(Item obj)
        {
            session.SaveOrUpdate(obj);           
        }

        public void Update(Item obj)
        {
            session.SaveOrUpdate(obj);
        }

        public void Delete(Item obj)
        {
            session.Delete(obj);
        }
    }
}
