using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Models.RequestModel
{
    public class AddDefinitionRequestModel
    {
        public string ProjectId { get; set; }
        public Enviroment Enviroment { get; set; }

        public bool IsDbMigration { get; set; }

        public string CheckinId { get; set; }

        public string ApplicationId { get; set; }
        public string Description { get; set; }
        public bool IsDeployed { get; set; }
    }
}
