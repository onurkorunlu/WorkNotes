using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkNotes.Models.RequestModel
{
    public class DeleteNoteRequestModel
    {
        [Required(ErrorMessage = "Proje Id boş olamaz")]
        public string ProjectId { get; set; }
        
        [Required(ErrorMessage = "Id boş olamaz")]
        public string Id { get; set; }
    }
}
