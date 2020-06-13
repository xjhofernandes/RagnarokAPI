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
    public class MonsterService
    {
        private readonly IMongoCollection<MonsterCollection> _monster;

        public MonsterService(IMonsterDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _monster = database.GetCollection<MonsterCollection>(settings.MonstersCollectionName);
        }

        public List<MonsterCollection> Get() =>
            _monster.Find(monster => true).ToList();

        public MonsterCollection Get(string id) =>
            _monster.Find<MonsterCollection>(monster => monster.MonsterId == id).FirstOrDefault();
    }
}
