using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Entities
{
    public class CheckIn : MongoBaseModel
    {
        public string CheckinId { get; set; }
        public string Description { get; set; }
        public bool IsDeployed { get; set; }
        public Enviroment Enviroment { get; set; }
        public string DeployPackageId { get; set; }
        public bool IsDbMigration { get; set; }
        public Application Application { get; set; }
    }
}
