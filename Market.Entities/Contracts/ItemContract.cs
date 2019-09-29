using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities.Contracts
{
    public class ItemContract
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
    }
}
