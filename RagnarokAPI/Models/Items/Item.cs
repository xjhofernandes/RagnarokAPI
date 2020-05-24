using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models.Items
{
    [BsonIgnoreExtraElements]
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("id")]
        public IdItem IdItem { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class IdItem
    {
        [BsonElement("id")] public int ItemIdentification { get; set; }
    }
}
