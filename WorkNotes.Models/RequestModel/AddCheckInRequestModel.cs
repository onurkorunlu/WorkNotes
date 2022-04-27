using WorkNotes.Entities;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Models.RequestModel
{
    public class AddCheckInRequestModel
    {
        public string ProjectId { get; set; }
        public Enviroment Enviroment { get; set; }

        public bool IsDbMigration { get; set; }

        public string CheckinId { get; set; }

        public string ApplicationId { get; set; }
        public string Description { get; set; }

        public string DeployPackageId { get; set; }
        public bool IsDeployed { get; set; }
    }
}
