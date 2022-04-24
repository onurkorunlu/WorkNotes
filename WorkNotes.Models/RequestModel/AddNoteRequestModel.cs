using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkNotes.Models.RequestModel
{
    public class AddNoteRequestModel
    {
        public string ProjectId { get; set; }
        public string Text { get; set; }
    }
}
