using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_api
{
    public class ItemsProcessor
    {
        private IRepository _repository;

        public ItemsProcessor(IRepository repository) {
            _repository = repository;
        }

        public Task<Item> GetItem(Guid playerid, Guid id)
        {
            return _repository.GetItem(playerid, id);
        }

        public Task<Item[]> GetAllItem(Guid playerid)
        {
            return _repository.GetAllItem(playerid);
        }

        public Task<Item> CreateItem(Guid playerid, NewItem item)
        {
            Player player = _repository.GetPlayer(playerid).Result;
            if (player.Level < 3 && item.Type == "sword") {
                throw new PlayerAlligatorException();
            }
            Item newItem = new Item();
            newItem.Name = item.Name;
            // set other values for new player
            newItem.Id = Guid.NewGuid();
            newItem.CreationDate = System.DateTime.Now;

            return _repository.CreateItem(playerid, newItem);
        }

        public Task<Item> ModifyItem(Guid playerid, Guid id, ModifiedItem item)
        {
            return _repository.ModifyItem(playerid, id, item);
        }

        public Task<Item> DeleteItem(Guid playerid, Guid id)
        {
            return _repository.DeleteItem(playerid, id);
        }
    }
}