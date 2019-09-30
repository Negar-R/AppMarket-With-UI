using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contracts;
using Market.Entities.Entity;
using Market.Entities.Interfaces;

namespace Market.Services
{
    public class RackService
    {
        public IRackRepository IRackRepository { get; set; }

        public void CreateAndUpdateRackItemLevel(RackContract rackContract)
        {
            var rack = IRackRepository.Get(rackContract.Id);
            if (rack != null)
            {
                rack.Racks = rackContract.Racks;
                rack.Code = rackContract.Code;
                rack.Name = rackContract.Name;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;

                IRackRepository.Update(rack);
            }
            else
            {
                rack = new Rack();
                rack.Name = rackContract.Name;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;

                IRackRepository.Insert(rack);
            }
        }
    }
}
