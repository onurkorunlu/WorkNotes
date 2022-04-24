using System;
using System.Collections.Generic;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Entities
{
    public class Project : MongoBaseModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public ProjectType Type { get; set; }
        public ProjectStatus Status { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<CheckIn> CheckIns { get; set; } = new List<CheckIn>();
    }
}
