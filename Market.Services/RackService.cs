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
                rack.Code = rackContract.Code;
                rack.Name = rackContract.Name;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;

                for (int i = 0; i < rackContract.RackContracts.Count; i++)
                {
                    var temp = rackContract.RackContracts[i];
                    if (rack.Racks.Any(x => x.Id == temp.Id))
                    {
                        var InDatabaseRack = rack.Racks.FirstOrDefault(x => x.Id == temp.Id);
                        InDatabaseRack.Name = temp.Name;
                        InDatabaseRack.Code = temp.Code;
                        InDatabaseRack.Limit = temp.Limit;
                        InDatabaseRack.Location = temp.Location;
                    }
                    else
                    {
                        var InDatabaseRack = new Rack();

                        InDatabaseRack.Name = temp.Name;
                        InDatabaseRack.Code = temp.Code;
                        InDatabaseRack.Limit = temp.Limit;
                        InDatabaseRack.Location = temp.Location;

                        rack.Racks.Add(InDatabaseRack);
                    }
                }

                IRackRepository.Update(rack);
            }
            else
            {
                rack = new Rack();
                rack.Name = rackContract.Name;
                rack.Limit = rackContract.Limit;
                rack.Location = rackContract.Location;

                for (int i = 0; i < rackContract.RackContracts.Count; i++)
                {
                    var temp = rackContract.RackContracts[i];
                    var InDatabaseRack = new Rack();

                    InDatabaseRack.Name = temp.Name;
                    InDatabaseRack.Code = temp.Code;
                    InDatabaseRack.Limit = temp.Limit;
                    InDatabaseRack.Location = temp.Location;

                    rack.Racks.Add(InDatabaseRack);
                }

                IRackRepository.Insert(rack);
            }
        }
    }
}
