using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkNotes.Models.RequestModel
{
    public class AddDeployPackageRequestModel
    {
        public string CheckinId { get; set; }
        public string DeployId { get; set; }
    }
}
