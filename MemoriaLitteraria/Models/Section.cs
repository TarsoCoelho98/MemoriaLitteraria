using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemoriaLitteraria.Models
{
    public class Section
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("section_id")]
        public int SectionId { get; set; }

        [BsonElement("file_id")]
        public int FileId { get; set; }
        
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }
    }
}
