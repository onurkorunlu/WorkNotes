﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WorkNotes.Entities.Enums;

namespace WorkNotes.Entities
{
    public class CheckIn : AppBaseModel
    {
        [Required]
        [DisplayName("CheckIn Id")]
        public string CheckinId { get; set; }

        [Required]
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Taşındı Mı?")]
        public bool IsDeployed { get; set; }

        [Required]
        [DisplayName("Geliştirme Ortamı")]
        public Enviroment Enviroment { get; set; }

        [DisplayName("Taşıma Paket Id")]
        public string DeployPackageId { get; set; }

        [Required]
        [DisplayName("Db Paketi Mi?")]
        public bool IsDbMigration { get; set; }

        [Required]
        [DisplayName("Ugulama")]
        public Application Application { get; set; }
    }
}
