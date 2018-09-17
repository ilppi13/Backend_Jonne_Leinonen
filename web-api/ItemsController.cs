using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    [Route("api/players/{playerId:Guid}/items")]
    [ApiController]
    public class ItemsController
    {

        ItemsProcessor _processor;

        public ItemsController(ItemsProcessor processor)
        {
            _processor = processor;
        }
        [HttpGet("{id:Guid}")]
        public Task<Item> GetItem(Guid playerid, Guid id) {
            return _processor.GetItem(playerid, id);
        }
        [HttpGet]
        public Task<Item[]> GetAllItem(Guid playerid) {
            return _processor.GetAllItem(playerid);
        }
        [HttpPost]
        [CatchException]
        public Task<Item> CreateItem(Guid playerid, NewItem item) {
            return _processor.CreateItem(playerid, item);
        }
        [HttpPut("{id:Guid}")]
        public Task<Item> ModifyItem(Guid playerid, Guid id, ModifiedItem item) {
            return _processor.ModifyItem(playerid, id, item);
        }
        [HttpDelete("{id:Guid}")]
        public Task<Item> DeleteItem(Guid playerid, Guid id) {
            return _processor.DeleteItem(playerid, id);
        }
}
    }