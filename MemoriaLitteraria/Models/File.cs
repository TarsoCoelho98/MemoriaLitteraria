using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MemoriaLitteraria.Models
{
    public class File
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("file_id")]
        public int FileId { get; set; }

        [BsonElement("author_id")]
        public int AuthorId { get; set; }

        [BsonElement("title")] 
        public string Title { get; set; }

        [BsonElement("publication_year")]
        public int PublicationYear { get; set; }
        
        [BsonElement("reference")]
        public string Reference { get; set; }
        [BsonElement("source_url")]
        public string SourceUrl { get; set; }
    }
}
