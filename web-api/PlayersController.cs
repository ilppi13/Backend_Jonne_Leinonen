using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController
    {

        PlayersProcessor _processor;

        public PlayersController(PlayersProcessor processor)
        {
            _processor = processor;
        }
        [HttpGet("{id:Guid}")]
        public Task<Player> GetPlayer(Guid id) {
            return _processor.GetPlayer(id);
        }
        [HttpGet]
        public Task<Player[]> GetAllPlayer() {
            return _processor.GetAllPlayer();
        }
        [HttpPost]
        public Task<Player> CreatePlayer(NewPlayer player) {
            return _processor.CreatePlayer(player);
        }
        [HttpPut("{id:Guid}")]
        public Task<Player> ModifyPlayer(Guid id, ModifiedPlayer player) {
            return _processor.ModifyPlayer(id, player);
        }
        [HttpDelete("{id:Guid}")]
        public Task<Player> DeletePlayer(Guid id) {
            return _processor.DeletePlayer(id);
        }
}
    }