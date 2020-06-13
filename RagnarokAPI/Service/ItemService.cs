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
            var client = new MongoClient(GetMongoConnectionStringWithIps(settings.ConnectionString));
            
            var database = client.GetDatabase(settings.DatabaseName);

            _item = database.GetCollection<ItemCollection>(settings.ItemsCollectionName);
        }

        private string GetMongoConnectionStringWithIps(string connectionString)
        {
            var builder = new MongoUrlBuilder(connectionString);
            //var servers = new List<MongoServerAddress>();
            //foreach (var server in builder.Servers)
            //{
            //    //var address = Dns.GetHostAddresses(server.Host).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            //    servers.Add(new MongoServerAddress(connectionString));
            //}
            //builder.Servers = servers;
            return builder.ToMongoUrl().ToString();
        }

        public List<ItemCollection> Get() =>
            _item.Find(item => true).ToList();

        internal List<ItemCollection> Create(List<ItemCollection> item)
        {
            _item.InsertMany(item);
            return item;
        }

        internal ItemCollection Create(ItemCollection item)
        {
            _item.InsertOne(item);
            return item;
        }


        public ItemCollection Get(int id) =>
            _item.Find<ItemCollection>(item => item.ItemId == id).FirstOrDefault();

        public void Update(int id, ItemCollection itemIn) =>
            _item.ReplaceOne(item => item.ItemId == id, itemIn);

        public void Remove(ItemCollection itemIn) =>
            _item.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) =>
            _item.DeleteOne(item => item.Id == id);
    }
}
