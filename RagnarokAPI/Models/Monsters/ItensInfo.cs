using MongoDB.Bson.Serialization.Attributes;

namespace RagnarokAPI.Models
{
    [BsonIgnoreExtraElements]
    public class ItensInfo
    {
        [BsonElement("id")]
        public int IdItem { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("image")]
        public ImageItem Image { get; set; }
    }

    public class ImageItem
    {
        [BsonElement("item")]
        public string UrlImagem { get; set; }
    }
}