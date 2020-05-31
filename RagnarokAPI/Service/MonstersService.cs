﻿using System;
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

            _monsters = database.GetCollection<MonstersCollection>(settings.MonstersCollectionName);
        }

        public List<MonstersCollection> Get() =>
            _monsters.Find(monster => true).ToList();

        internal List<MonstersCollection> Create(List<MonstersCollection> monsters)
        {
            _monsters.InsertMany(monsters);
            return monsters;
        }

        internal MonstersCollection Create(MonstersCollection monster)
        {
            _monsters.InsertOne(monster);
            return monster;
        }

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
