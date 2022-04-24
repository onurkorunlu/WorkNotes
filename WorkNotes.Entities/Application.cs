namespace WorkNotes.Entities
{
    public class Application : MongoBaseModel
    {
        public string Name { get; set; }

        public bool IsDbMigration { get; set; }
    }
}
