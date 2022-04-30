using System.ComponentModel;
using WorkNotes.Entities;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Models.ViewModel
{
    public class CheckInViewModel : AppBaseModel
    {
        [DisplayName("CheckIn Id")]
        public string CheckinId { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Taşındı Mı?")]
        public bool IsDeployed { get; set; }

        [DisplayName("Geliştirme Ortamı")]
        public Enviroment Enviroment { get; set; }

        public string DeployPackageId { get; set; }

        [DisplayName("Db Paketi Mi?")]
        public bool IsDbMigration { get; set; }

        [DisplayName("Ugulama")]
        public Application Application { get; set; }

        [DisplayName("Proje Id")]
        public string ProjectId { get; set; }
    }
}
