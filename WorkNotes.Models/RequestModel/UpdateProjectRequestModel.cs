using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Models.RequestModel
{
    public class UpdateProjectRequestModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Proje Kodu zorunludur")]
        [MinLength(5, ErrorMessage = "Proje Kodu alanı en az 5 karakter olmalıdır.")]
        [MaxLength(20, ErrorMessage = "Proje Kodu alanı en fazla 20 karakter olmalıdır.")]
        [DisplayName("Proje Kodu")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Proje Adı zorunludur")]
        [MinLength(5, ErrorMessage = "Proje Adı alanı en az 5 karakter olmalıdır.")]
        [MaxLength(100, ErrorMessage = "Proje Adı alanı en fazla 100 karakter olmalıdır.")]
        [DisplayName("Proje Kodu")]
        public string Title { get; set; }

        [DisplayName("Proje Açıklaması")]
        public string Description { get; set; }

        [DisplayName("Hedeflenen Bitiş Tarihi")]
        public DateTime? TargetDate { get; set; }

        [DisplayName("Proje Tipi")]
        public ProjectType Type { get; set; }

        [Required(ErrorMessage = "Proje Statüsü zorunludur")]
        [DisplayName("Proje Statüsü")]
        public ProjectStatus Status { get; set; }

    }
}
