using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    public class MonsterImage
    {
        [BsonElement("gif")]
        public string GifUrl { get; set; }

        [BsonElement("small")]
        public string SmallUrl { get; set; }
    }
}