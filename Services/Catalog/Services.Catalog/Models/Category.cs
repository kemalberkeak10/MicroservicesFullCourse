using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.Catalog.Models
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
