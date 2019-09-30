using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities.Interfaces
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : BaseEntity
    {
        List<T> GetAll();
        T Get(Guid id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
