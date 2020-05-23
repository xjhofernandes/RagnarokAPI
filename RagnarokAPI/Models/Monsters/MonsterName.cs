using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    public class MonsterName
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("slug")]
        public string Slug { get; set; }
    }
}