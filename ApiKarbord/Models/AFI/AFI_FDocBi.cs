namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class AFI_FDocBi
    {

        [Key]
        public long SerialNumber { get; set; }

        public int? BandNo { get; set; }

        public string KalaCode { get; set; }

        public double? Amount1 { get; set; }

        public double? Amount2 { get; set; }

        public double? Amount3 { get; set; }

        public double? UnitPrice { get; set; }

        public double? TotalPrice { get; set; }

        public double? Discount { get; set; }

        public int? MainUnit { get; set; }

        public string Comm { get; set; }

        public bool Up_Flag { get; set; }
    }
}