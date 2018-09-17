using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace web_api
{
    public class PlayersProcessor
    {
        private IRepository _repository;

        public PlayersProcessor(IRepository repository) {
            _repository = repository;
        }

        public Task<Player> GetPlayer(Guid id)
        {
            return _repository.GetPlayer(id);
        }

        public Task<Player[]> GetAllPlayer()
        {
            return _repository.GetAllPlayer();
        }

        public Task<Player> CreatePlayer(NewPlayer player)
        {
            Player newPlayer = new Player();
            newPlayer.Name = player.Name;
            newPlayer.Id = Guid.NewGuid();
            newPlayer.CreationTime = System.DateTime.Now;
            newPlayer.Level = player.Level;
            newPlayer.items = new List<Item>();

            return _repository.CreatePlayer(newPlayer);
        }

        public Task<Player> ModifyPlayer(Guid id, ModifiedPlayer player)
        {
            return _repository.ModifyPlayer(id, player);
        }

        public Task<Player> DeletePlayer(Guid id)
        {
            return _repository.DeletePlayer(id);
        }
    }
}