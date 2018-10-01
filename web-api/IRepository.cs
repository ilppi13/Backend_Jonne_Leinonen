using System;
using System.Threading.Tasks;

namespace web_api
{
    public interface IRepository
    {
        Task<Player> GetPlayer(Guid id);
        Task<Player[]> GetPlayerByTag(string tag);
        Task<Player[]> GetPlayerByName(string name);
        Task<Player[]> GetAllPlayer();
        Task<Player> CreatePlayer(Player player);
        Task<Player> ModifyPlayer(Guid id, ModifiedPlayer player);
        Task UpdatePlayerName(Guid id, ModifiedPlayerName player);
        Task<Player> DeletePlayer(Guid id);
        Task<Player[]> GetPlayerMoreScore(int minScore);

        Task<Item> GetItem(Guid playerid, Guid id);
        Task<Item[]> GetAllItem(Guid playerid);
        Task<Item> CreateItem(Guid playerid, Item item);
        Task<Item> ModifyItem(Guid playerid, Guid id, ModifiedItem item);
        Task<Item> DeleteItem(Guid playerid, Guid id);
        
    }
}