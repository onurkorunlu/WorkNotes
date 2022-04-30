using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Models.RequestModel
{
    public class AddDeployPackageRequestModel
    {
        [Required(ErrorMessage = "Checkin Id zorunludur")]
        [DisplayName("CheckIn Id")]
        public string CheckinId { get; set; }

        [Required(ErrorMessage = "Paket Id zorunludur")]
        [DisplayName("Paket Id")]
        public string DeployId { get; set; }

        [Required(ErrorMessage = "Proje Id zorunludur")]
        [DisplayName("Proje Id")]
        public string ProjectId { get; set; }

    }
}
