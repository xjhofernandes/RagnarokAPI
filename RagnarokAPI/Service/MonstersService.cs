using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using RagnarokAPI.Models;
using RagnarokAPI.DataBaseSettings;
using IMonsterDatabaseSettings = RagnarokAPI.DataBaseSettings.IMonsterDatabaseSettings;

namespace RagnarokAPI.Service
{
    public class MonstersService
    {
        private readonly IMongoCollection<MonstersCollection> _monsters;

        public MonstersService(IMonsterDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _monsters = database.GetCollection<MonstersCollection>(settings.MonstersFixCollectionName);
        }

        public List<MonstersCollection> Get() =>
            _monsters.Find(monster => true).ToList();

        public MonstersCollection Get(string id) =>
            _monsters.Find<MonstersCollection>(monster => monster.MonsterId == id).FirstOrDefault();

        public void Update(string id, MonstersCollection monsterIn) =>
            _monsters.ReplaceOne(monster => monster.MonsterId == id, monsterIn);

        public void Remove(MonstersCollection monsterIn) =>
            _monsters.DeleteOne(monster => monster.MonsterId == monsterIn.Id);

        public void Remove(string id) =>
            _monsters.DeleteOne(monster => monster.MonsterId == id);
    }
}
