using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Models.RequestModel
{
    public class AddCheckInRequestModel
    {
        [Required(ErrorMessage = "Checkin Id zorunludur")]
        [MinLength(1, ErrorMessage = "Checkin Id alanı en az 5 karakter olmalıdır.")]
        [MaxLength(20, ErrorMessage = "Checkin Id alanı en fazla 20 karakter olmalıdır.")]
        [DisplayName("CheckIn Id")]
        public string CheckinId { get; set; }

        [Required(ErrorMessage = "Geliştirme Ortamı zorunludur")]
        [DisplayName("Geliştirme Ortamı")]
        public Enviroment Enviroment { get; set; }

        [Required(ErrorMessage = "Proje Id zorunludur")]
        [MinLength(1, ErrorMessage = "Proje Id alanı en az 5 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Proje Id alanı en fazla 20 karakter olmalıdır.")]
        [DisplayName("Proje Id")]
        public string ProjectId { get; set; }

        [Required(ErrorMessage = "Uygulama Id zorunludur")]
        [MinLength(1, ErrorMessage = "Uygulama Id alanı en az 5 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Uygulama Id alanı en fazla 20 karakter olmalıdır.")]
        [DisplayName("Uygulama Id")]
        public string ApplicationId { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur")]
        [MinLength(1, ErrorMessage = "Açıklama alanı en az 5 karakter olmalıdır.")]
        [MaxLength(500, ErrorMessage = "Açıklama alanı en fazla 20 karakter olmalıdır.")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [MinLength(1, ErrorMessage = "Taşıma Paket Id alanı en az 5 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Taşıma Paket Id alanı en fazla 20 karakter olmalıdır.")]
        [DisplayName("Taşıma Paket Id")]
        public string DeployPackageId { get; set; }

        [DisplayName("Taşındı Mı?")]
        public bool IsDeployed { get; set; }

        [Required(ErrorMessage = "DB Paketi Mi? alanı zorunludur")]
        [DisplayName("DB Paketi Mi?")]
        public bool IsDbMigration { get; set; }
    }
}
