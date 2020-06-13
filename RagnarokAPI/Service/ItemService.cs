using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using RagnarokAPI.Models;
using RagnarokAPI.DataBaseSettings;
using IItemDatabaseSettings = RagnarokAPI.DataBaseSettings.IItemDatabaseSettings;

namespace RagnarokAPI.Service
{
    public class ItemService
    {
        private readonly IMongoCollection<ItemCollection> _item;

        public ItemService(IItemDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _item = database.GetCollection<ItemCollection>(settings.ItemsCollectionName);
        }

        public List<ItemCollection> Get() =>
            _item.Find(item => true).ToList();

        public ItemCollection Get(int id) =>
            _item.Find<ItemCollection>(item => item.ItemId == id).FirstOrDefault();
    }
}
