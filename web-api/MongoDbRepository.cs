using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace web_api
{
    public class MongoDbRepository : IRepository
    {
        private MongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Player> collection;
        public MongoDbRepository() {
            
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("game");
            collection = database.GetCollection<Player>("players");
        }
        

        public async Task<Player> CreatePlayer(Player player)
        {
            await collection.InsertOneAsync(player);
            return player;
        }

        public async Task<Player> DeletePlayer(Guid id)
        {
            var filter = Builders<Player>.Filter.Eq("Id", id);
            Player player = await collection.FindOneAndDeleteAsync(filter);
            return player;
        }

        public async Task<Player> GetPlayer(Guid id)
        {
            var filter = Builders<Player>.Filter.Eq("Id", id);
            var cursor = await collection.FindAsync(filter);
            Player player = cursor.Single();
            return player;
        }

        public async Task<Player[]> GetPlayerByTag(String tag)
        {
            var filter = Builders<Player>.Filter.Eq("tag", tag);
            var cursor = await collection.FindAsync(filter);
            var player = cursor.ToList();
            return player.ToArray();
        }

        public async Task<Player[]> GetPlayerByName(String name)
        {
            var filter = Builders<Player>.Filter.Eq("Name", name);
            var cursor = await collection.FindAsync(filter);
            var player = cursor.ToList();
            return player.ToArray();
        }

        public async Task<Player[]> GetAllPlayer()
        {
            var filter = Builders<Player>.Filter.Empty;
            var cursor = await collection.FindAsync(filter);
            Player[] player = cursor.ToList().ToArray();
            return player;
        }

        public async Task<Player> ModifyPlayer(Guid id, ModifiedPlayer player)
        {
            var filter = Builders<Player>.Filter.Eq("Id", id);
            var update = Builders<Player>.Update.Set("Score", player.Score);
            var player2 = await collection.FindOneAndUpdateAsync(filter, update);
            return player2;
        }

        public async Task UpdatePlayerName(Guid id, ModifiedPlayerName player)
        {
            var filter = Builders<Player>.Filter.Eq("Id", id);
            var update = Builders<Player>.Update.Set("Name", player.name);
            var player2 = await collection.UpdateOneAsync(filter, update);
        }

        public async Task<Item> GetItem(Guid playerid, Guid id)
        {
            var filter = Builders<Player>.Filter.Eq("Id", playerid);
            var cursor = await collection.FindAsync(filter);
            Player player = cursor.First();
            foreach (Item item in player.items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;

        }

        public async Task<Item[]> GetAllItem(Guid playerid)
        {
            var filter = Builders<Player>.Filter.Eq("Id", playerid);
            var cursor = await collection.FindAsync(filter);
            Player player = cursor.First();
            return player.items.ToArray();
        }

        public async Task<Item> CreateItem(Guid playerid, Item item)
        {
            var update = Builders<Player>.Update.AddToSet("items", item);
            var filter = Builders<Player>.Filter.Eq("Id", playerid);
            var cursor = await collection.FindOneAndUpdateAsync(filter, update);
            
            return item;
        }

        public async Task<Item> ModifyItem(Guid playerid, Guid id, ModifiedItem item)
        {
            var filter = Builders<Player>.Filter.Eq("Id", playerid);
            var cursor = await collection.FindAsync(filter);
            Player player = cursor.First();
            foreach (Item item2 in player.items)
            {
                if (item2.Id == id)
                {
                    if (item2 != null)
                    {
                        item2.Level = item.Level;
                        await collection.FindOneAndReplaceAsync(filter, player);
                    }
                    return item2;
                }
            }
            return null;
            
        }

        public async Task<Item> DeleteItem(Guid playerid, Guid id)
        {
            var filter = Builders<Player>.Filter.Eq("Id", playerid);
            var cursor = await collection.FindAsync(filter);
            Player player = cursor.First();
            Item found = null;
            foreach (Item item in player.items)
            {
                if (item.Id == id)
                {
                    found = item;
                    break;
                }
            }
            player.items.Remove(found);
            await collection.FindOneAndReplaceAsync(filter, player);
            return found;
        }

        public async Task<Player[]> GetPlayerMoreScore(int minScore)
        {
            var filter = Builders<Player>.Filter.Gt("Score", minScore);
            var cursor = await collection.FindAsync(filter);
            var player = cursor.ToList();
            return player.ToArray();
        }
    }
}