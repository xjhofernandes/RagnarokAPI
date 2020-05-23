using System;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class MonsterStats
    {
        [BsonElement("lv")] 
        public int? Level { get; set; }

        [BsonElement("hp")]
        public int?  Hp { get; set; }

        [BsonElement("scale")] 
        public int? Scale { get; set; }

        [BsonElement("race")] 
        public int? Race { get; set; }

        [BsonElement("element")] 
        public MonsterElement Element { get; set; }
    }
}