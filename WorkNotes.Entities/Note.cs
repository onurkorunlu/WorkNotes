using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Entities
{
    public class Note : AppBaseModel
    {
        [Required]
        [DisplayName("Not")]
        public string Text { get; set; }
    }
}