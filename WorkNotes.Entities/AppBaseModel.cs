using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Entities
{
    public class AppBaseModel
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [DisplayName("Kayıt Tarihi")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [DisplayName("Güncelleme Tarihi")]
        public DateTime? UpdateDate { get; set; } = null;

        [Required]
        [DisplayName("Kayıt Statüsü")]
        public bool RecordStatus { get; set; } = true;
    }
}
