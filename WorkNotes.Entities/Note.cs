using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkNotes.Entities
{
    public class Note
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Text { get; set; }
    }
}