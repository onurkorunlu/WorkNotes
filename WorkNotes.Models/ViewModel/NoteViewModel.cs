using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WorkNotes.Entities;

namespace WorkNotes.Models.ViewModel
{
    public class NoteViewModel : AppBaseModel
    {
        [Required]
        [DisplayName("Not")]
        public string Text { get; set; }

        public string ProjectId { get; set; }
    }
}
