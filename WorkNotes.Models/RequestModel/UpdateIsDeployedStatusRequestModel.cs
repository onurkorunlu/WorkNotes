using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Models.RequestModel
{
    public class UpdateIsDeployedStatusRequestModel
    {
        [Required(ErrorMessage = "CheckIn Id zorunludur")]
        [DisplayName("CheckIn Id")]
        public string CheckInId { get; set; }

        [Required(ErrorMessage = "Taşıma Statüsü zorunludur")]
        [DisplayName("Taşındı Mı?")]
        public bool IsDeployed { get; set; }

        [Required(ErrorMessage = "Proje Id zorunludur")]
        [DisplayName("Proje Id")]
        public string ProjectId { get; set; }
    }
}
