using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Services.Catalog.Dtos
{
    public class CategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
