using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Entity;

namespace Market.Entities
{
    public abstract class Order : BaseEntity
    {
        public Order()
        {
            //OrderItem = new List<OrderItem>();
        } 
        public virtual int Code { get; set; }
        public virtual string CreationDate { get; set; }
        public virtual string Title { get; set; }


        //public virtual ICollection<OrderItem> OrderItem { get; set; }

    }

}
