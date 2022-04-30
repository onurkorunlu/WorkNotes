using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WorkNotes.Entities
{
    public class Application : MongoBaseModel
    {
        [Required]
        [DisplayName("Ugulama Adı")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Db Paketi Mi?")]
        public bool IsDbMigration { get; set; }
    }
}
