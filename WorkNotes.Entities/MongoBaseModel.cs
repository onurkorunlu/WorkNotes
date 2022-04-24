using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WorkNotes.Entities
{
    public class MongoBaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool RecordStatus { get; set; } = true;
    }
}
