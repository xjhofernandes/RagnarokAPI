using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using RagnarokAPI.Models;
using RagnarokAPI.Models.Items;

namespace RagnarokAPI.Service
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _items;

        public ItemService(IItemDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<Item>(settings.ItemsCollectionName);
        }

        public List<Item> Get() =>
            _items.Find(item => true).ToList();

        public Item Get(int id) =>
            _items.Find<Item>(item => item.IdItem.ItemIdentification == id).FirstOrDefault();

        public void Update(int id, Item itemIn) =>
            _items.ReplaceOne(item => item.IdItem.ItemIdentification == id, itemIn);

        public void Remove(Item itemIn) =>
            _items.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _items.DeleteOne(item=> item.Id == id);

    }
}
