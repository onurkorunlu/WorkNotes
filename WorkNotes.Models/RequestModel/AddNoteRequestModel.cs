using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Models.RequestModel
{
    public class AddNoteRequestModel
    {
        [Required(ErrorMessage = "Proje Id boş olamaz")]
        [DisplayName("Proje Id")]
        public string ProjectId { get; set; }

        [Required(ErrorMessage = "Açıklama boş olamaz")]
        [DisplayName("Açıklama")]
        public string Text { get; set; }
    }
}
