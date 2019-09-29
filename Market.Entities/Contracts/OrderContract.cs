using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Entities.Contracts
{
    public class OrderContract
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string CreationDate { get; set; }
        public string Title { get; set; }
    }
}
