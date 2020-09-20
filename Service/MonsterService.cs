using System.Collections.Generic;
using MongoDB.Driver;
using RagnarokAPI.Models;
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
            _monster.Find<MonsterCollection>(monster => monster.ID == id).FirstOrDefault();
    }
}
