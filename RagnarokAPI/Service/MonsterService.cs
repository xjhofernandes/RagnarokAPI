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

        internal List<MonsterCollection> Create(List<MonsterCollection> monsters)
        {
            _monster.InsertMany(monsters);
            return monsters;
        }

        internal MonsterCollection Create(MonsterCollection monster)
        {
            _monster.InsertOne(monster);
            return monster;
        }

        public MonsterCollection Get(string id) =>
            _monster.Find<MonsterCollection>(monster => monster.MonsterId == id).FirstOrDefault();

        public void Update(string id, MonsterCollection monsterIn) =>
            _monster.ReplaceOne(monster => monster.MonsterId == id, monsterIn);

        public void Remove(MonsterCollection monsterIn) =>
            _monster.DeleteOne(monster => monster.MonsterId == monsterIn.Id);

        public void Remove(string id) =>
            _monster.DeleteOne(monster => monster.MonsterId == id);
    }
}
