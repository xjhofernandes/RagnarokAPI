using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models.Items
{
    [BsonIgnoreExtraElements]
    public class ImageInformation
    {
        [BsonElement("item")]
        public string itemImgUrl { get; set; }
        [BsonElement("collection")]
        public string CollectionImgUrl { get; set; }
        [BsonElement("card")]
        public string CardImgUrl { get; set; }
    }
}