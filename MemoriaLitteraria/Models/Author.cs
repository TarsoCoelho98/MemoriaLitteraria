using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemoriaLitteraria.Models
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("author_id")]
        public int AuthorId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
