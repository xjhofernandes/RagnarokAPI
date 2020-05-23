using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class MonsterDrop
    {
        [BsonElement("normal")]
        public List<ItemsDrop> Normal { get; set; }

        [BsonElement("mvp")]
        public List<ItemsDrop> Mvp { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class ItemsDrop
    {
        [BsonElement("item")]
        public ItensInfo Item { get; set; }
    }
}