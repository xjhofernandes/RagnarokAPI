using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class MonsterSpawn
    {
        [BsonElement("map")]
        public MonsterMap Map { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class MonsterMap
    {
        [BsonElement("id")]
        public string MapId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}