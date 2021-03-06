using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Models.RequestModel
{
    public class DeleteCheckInRequestModel
    {
        [Required(ErrorMessage = "Proje Id boş olamaz")]
        public string ProjectId { get; set; }

        [Required(ErrorMessage = "Id boş olamaz")]
        public string Id { get; set; }
    }
}
