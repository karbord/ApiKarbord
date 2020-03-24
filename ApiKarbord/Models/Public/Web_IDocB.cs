namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_IDocB
    {
        [Key]
        public long SerialNumber { get; set; }

        public int BandNo { get; set; }

        [StringLength(100)]
        public string KalaCode { get; set; }

        [StringLength(250)]
        public string KalaName { get; set; }

        public int? MainUnit { get; set; }

        public string MainUnitName { get; set; }

        public double? Amount1 { get; set; }

        public double? Amount2 { get; set; }

        public double? Amount3 { get; set; }

        public double? UnitPrice { get; set; }

        public double? TotalPrice { get; set; }

        public string Comm { get; set; }

        public bool UP_Flag { get; set; }

        public int? DeghatR1 { get; set; }

        public int? DeghatR2 { get; set; }

        public int? DeghatR3 { get; set; }

        public int? DeghatM1 { get; set; }

        public int? DeghatM2 { get; set; }

        public int? DeghatM3 { get; set; }

        public int? DeghatR { get; set; }
    }
}