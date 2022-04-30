using System;
using System.Collections.Generic;
using System.ComponentModel;
using WorkNotes.Entities;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Models.ViewModel
{
    public class ProjectViewModel : AppBaseModel
    {
        [DisplayName("Proje Kodu")]
        public string Code { get; set; }

        [DisplayName("Proje Adı")]
        public string Title { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Hedeflenen Bitiş Tarihi")]
        public DateTime? TargetDate { get; set; }

        [DisplayName("Proje Tipi")]
        public ProjectType Type { get; set; }

        [DisplayName("Proje Statüsü")]
        public ProjectStatus Status { get; set; }

        [DisplayName("Proje Notları")]
        public List<NoteViewModel> Notes { get; set; } = new List<NoteViewModel>();

        [DisplayName("Proje Checkin'leri")]
        public List<CheckInViewModel> CheckIns { get; set; } = new List<CheckInViewModel>();
    }
}
