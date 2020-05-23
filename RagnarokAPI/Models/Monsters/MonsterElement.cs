using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class MonsterElement
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