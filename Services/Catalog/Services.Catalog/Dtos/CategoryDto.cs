using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Services.Catalog.Dtos
{
    internal class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
