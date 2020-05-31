using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using RagnarokAPI.Models;
using RagnarokAPI.DataBaseSettings;
using IItemDatabaseSettings = RagnarokAPI.DataBaseSettings.IItemDatabaseSettings;

namespace RagnarokAPI.Service
{
    public class ItemsService
    {
        private readonly IMongoCollection<ItemsCollection> _items;

        public ItemsService(IItemDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _items = database.GetCollection<ItemsCollection>(settings.ItemsFixCollectionName);
        }

        public List<ItemsCollection> Get() =>
            _items.Find(item => true).ToList();

        internal List<ItemsCollection> Create(List<ItemsCollection> item)
        {
            _items.InsertMany(item);
            return item;
        }

        internal ItemsCollection Create(ItemsCollection item)
        {
            _items.InsertOne(item);
            return item;
        }


        public ItemsCollection Get(int id) =>
            _items.Find<ItemsCollection>(item => item.ItemId == id).FirstOrDefault();

        public void Update(int id, ItemsCollection itemIn) =>
            _items.ReplaceOne(item => item.ItemId == id, itemIn);

        public void Remove(ItemsCollection itemIn) =>
            _items.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _items.DeleteOne(item => item.Id == id);
    }
}
