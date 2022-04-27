using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkNotes.Models.RequestModel
{
    public class DeleteCheckInRequestModel
    {
        public string ProjectId { get; set; }
        public string ApplicationId { get; set; }
        public string CheckInId { get; set; }
    }
}
