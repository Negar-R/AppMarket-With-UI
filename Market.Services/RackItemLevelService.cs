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
    public class RackItemLevelService
    {
        public IRackItemLevelRepository IRackItemLevelRepository { get; set; }
        public IItemRepository IitemRepository { get; set; }
        public IRackRepository IRackRepository { get; set; }

        public void CreateAndUpdateRackItemLevel(RackItemLevelContract rackItemLevelContract)
        {
            var rackitemLevelContract = IRackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackitemLevelContract != null)
            {
                //save
                rackitemLevelContract.Item = IitemRepository.Get(rackItemLevelContract.ItemId);//!
                rackitemLevelContract.Rack = IRackRepository.Get(rackItemLevelContract.RackId);
                rackitemLevelContract.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackitemLevelContract.InQuantity = rackItemLevelContract.InQuantity;
                rackitemLevelContract.OutQuantity = rackItemLevelContract.OutQuantity;

                IRackItemLevelRepository.Update(rackitemLevelContract);
            }
            else
            {
                //creat
                rackitemLevelContract = new RackItemLevel();
                rackitemLevelContract.Item = IitemRepository.Get(rackItemLevelContract.ItemId);
                rackitemLevelContract.Rack = IRackRepository.Get(rackItemLevelContract.RackId);
                rackitemLevelContract.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackitemLevelContract.InQuantity = rackItemLevelContract.InQuantity;
                rackitemLevelContract.OutQuantity = rackItemLevelContract.OutQuantity;

                IRackItemLevelRepository.Insert(rackitemLevelContract);
            }
        }
    }
}
