using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities.Contracts
{
    public class RackContract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int Limit { get; set; }
        public string Location { get; set; }
        // List Rack
        public List<Rack> Racks { get; set; }
    }
}
