using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Entities
{
    public class MongoBaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required]
        [DisplayName("Kayıt Tarihi")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }

        [Required]
        [DisplayName("Kayıt Statüsü")]
        public bool RecordStatus { get; set; } = true;
    }
}
