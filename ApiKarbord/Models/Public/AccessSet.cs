namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccessSet")]
    public partial class AccessSet
    {
        public int Id { get; set; }

        public string lockNumber { get; set; }

        public string access { get; set; }

        public bool active { get; set; }

        public DateTime? fromDate { get; set; }

        public DateTime? untilDate { get; set; }

        public string progAccess { get; set; }

        public int? userCount { get; set; }

        public string ACC_Group { get; set; }

        public string INV_Group { get; set; }

        public string FCT_Group { get; set; }

        public string AFI_Group { get; set; }

        public string CSH_Group { get; set; }

        public string MVL_Group { get; set; }

        public string PAY_Group { get; set; }

        public string ConnectionString { get; set; }

        public string Pass { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string ERJ_Group { get; set; }
    }
}