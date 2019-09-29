using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Market.Entities.Contracts;
using Market.Entities.Entity;
using Market.Entities.Interfaces;

namespace Market.Services
{
    public class ItemService
    {
        // Soal : Line 16
        public IItemRepository ItemRepository { get; set; }

        public void CreateAndUpdateItem(ItemContract itemContract)
        {
            var item = ItemRepository.Get(itemContract.Id);
            if (item != null)
            {
                //Update
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                ItemRepository.Update(item);
            }
            else
            {
                //Insert OR Create
                item = new Item();
                item.Code = itemContract.Code;
                item.Name = itemContract.Name;
                item.Unit = itemContract.Unit;

                ItemRepository.Insert(item);
            }
        }
    }
}
