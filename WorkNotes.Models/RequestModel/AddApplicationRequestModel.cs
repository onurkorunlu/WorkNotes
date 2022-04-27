using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkNotes.Models.RequestModel
{
    public class AddApplicationRequestModel
    {
        public string Name { get; set; }

        public bool IsDbMigration { get; set; }
    }
}
