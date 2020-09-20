using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class ItemCollection
    {
        [BsonElement("itemId")]
        public int ID { get; set; }

        [BsonElement("nameItem")]
        public string Name { get; set; }

        [BsonElement("itemImgUrl")]
        public string ImgUrl { get; set; }

        [BsonElement("collectionImgUrl")]
        public string CollectionImgUrl { get; set; }

        [BsonElement("cardImgUrl")]
        public string CardImgUrl { get; set; }

        [BsonElement("itemDescription")]
        public string Description { get; set; }
    }
}
