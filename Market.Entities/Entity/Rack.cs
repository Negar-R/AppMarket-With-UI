using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Entity
{
    public class Rack : BaseEntity
    {
        public Rack()
        {
            Racks = new List<Rack>();
        }
        public virtual string Name { get; set; }
        public virtual int Code { get; set; }
        public virtual int Limit { get; set; }
        public virtual string Location { get; set; }

        public virtual ICollection<Rack> Racks { get; set; }
    }
}
