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
            var rackitemLevel = IRackItemLevelRepository.Get(rackItemLevelContract.Id);
            if (rackitemLevel != null)
            {
                //save
                rackitemLevel.Item = IitemRepository.Get(rackItemLevelContract.ItemId);
                rackitemLevel.Rack = IRackRepository.Get(rackItemLevelContract.RackId);
                rackitemLevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackitemLevel.InQuantity = rackItemLevelContract.InQuantity;
                rackitemLevel.OutQuantity = rackItemLevelContract.OutQuantity;

                IRackItemLevelRepository.Update(rackitemLevel);
            }
            else
            {
                //creat
                rackitemLevel = new RackItemLevel();

                rackitemLevel.Item = IitemRepository.Get(rackItemLevelContract.ItemId);
                rackitemLevel.Rack = IRackRepository.Get(rackItemLevelContract.RackId);
                rackitemLevel.CurrentQuantity = rackItemLevelContract.CurrentQuantity;
                rackitemLevel.InQuantity = rackItemLevelContract.InQuantity;
                rackitemLevel.OutQuantity = rackItemLevelContract.OutQuantity;

                IRackItemLevelRepository.Insert(rackitemLevel);
            }
        }
    }
}
