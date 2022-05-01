using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Models.RequestModel
{
    public class UpdateDeployPackageIdRequestModel
    {
        [Required(ErrorMessage = "CheckIn Id zorunludur")]
        [DisplayName("CheckIn Id")]
        public string CheckInId { get; set; }

        [DisplayName("Paket Id")]
        public string DeployPackageId { get; set; }

        [Required(ErrorMessage = "Proje Id zorunludur")]
        [DisplayName("Proje Id")]
        public string ProjectId { get; set; }

    }
}
