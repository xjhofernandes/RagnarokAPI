using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    public class ItemCollection
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("itemId")]
        public int ItemId { get; set; }

        [BsonElement("nameItem")]
        public string NameItem { get; set; }

        [BsonElement("itemImgUrl")]
        public string ItemImgUrl { get; set; }

        [BsonElement("collectionImgUrl")]
        public string CollectionImgUrl { get; set; }

        [BsonElement("cardImgUrl")]
        public string CardImgUrl { get; set; }

        [BsonElement("itemDescription")]
        public string ItemDescription { get; set; }
    }
}
