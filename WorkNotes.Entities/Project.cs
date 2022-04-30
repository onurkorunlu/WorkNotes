using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Entities
{
    public class Project : MongoBaseModel
    {
        [Required]
        [DisplayName("Proje Kodu")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Proje Adı")] 
        public string Title { get; set; }

        [Required]
        [DisplayName("Açıklama")] 
        public string Description { get; set; }

        [Required]
        [DisplayName("Hedeflenen Bitiş Tarihi")] 
        public DateTime? TargetDate { get; set; }

        [Required]
        [DisplayName("Proje Tipi")] 
        public ProjectType Type { get; set; }

        [Required]
        [DisplayName("Proje Statüsü")] 
        public ProjectStatus Status { get; set; }

        [Required]
        [DisplayName("Proje Notları")] 
        public List<Note> Notes { get; set; } = new List<Note>();
        
        [Required]
        [DisplayName("Proje Checkin'leri")] 
        public List<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
    }
}
