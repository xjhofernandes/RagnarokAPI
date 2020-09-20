using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class MonsterCollection
    {
        [BsonElement("monsterId")]
        public string ID { get; set; }

        [BsonElement("monsterName")]
        public string Name { get; set; }

        [BsonElement("monsterGifUrl")]
        public string GifUrl { get; set; }

        [BsonElement("monsterDrops")]
        public List<ItemCollection> Drops { get; set; }

        [BsonElement("monsterStats")]
        public Stats Stats { get; set; }

        [BsonElement("elementExtraDamage")]
        public Element ElementExtraDamage { get; set; }

        [BsonElement("monsterSpawnMaps")]
        public List<Spawn> SpawnMaps { get; set; }
    }

    public class Spawn
    {
        [BsonElement("mapId")]
        public string MapId { get; set; }
        
        [BsonElement("mapName")]
        public string MapName { get; set; }
    }

    public class Stats
    {
        [BsonElement("monsterLevel")]
        public int? Level { get; set; }

        [BsonElement("monsterHp")]
        public int? Hp { get; set; }

        [BsonElement("monsterSize")]
        public int? Size { get; set; }

        [BsonElement("monsterRace")]
        public int? Race { get; set; }
    }

    public class Element
    {
        [BsonElement("neutral")]
        public int Neutral { get; set; }

        [BsonElement("water")]
        public int Water { get; set; }

        [BsonElement("earth")]
        public int Earth { get; set; }

        [BsonElement("fire")]
        public int Fire { get; set; }

        [BsonElement("wind")]
        public int Wind { get; set; }

        [BsonElement("poison")]
        public int Poison { get; set; }

        [BsonElement("holy")]
        public int Holy { get; set; }

        [BsonElement("dark")]
        public int Dark { get; set; }

        [BsonElement("ghost")]
        public int Ghost { get; set; }

        [BsonElement("undead")]
        public int Undead { get; set; }
    }
}