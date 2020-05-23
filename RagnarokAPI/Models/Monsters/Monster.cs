using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Monster
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id")]
        public string IdMonstro { get; set; }

        [BsonElement("name")]
        public MonsterName Name { get; set; }

        [BsonElement("image")]
        public MonsterImage Image { get; set; }

        [BsonElement("stats")]
        public MonsterStats Stats{ get; set; }

        [BsonElement("drop")]
        public MonsterDrop Drop { get; set; }

        [BsonElement("spawn")]
        public List<MonsterSpawn> Spawns { get; set; }
    }
}
