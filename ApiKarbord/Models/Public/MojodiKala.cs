namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class MojodiKala
    {
        [Key]
        public string Code { get; set; }
        public string KalaName { get; set; }
        public string KalaUnitName1 { get; set; }
        public string InvName { get; set; }
        public string KGruName { get; set; }
        /* public double? AAmount1 { get; set; }
          public double? ATotalPrice { get; set; }
          public double? VAmount1 { get; set; }
          public double? VTotalPrice { get; set; }
          public double? SAmount1 { get; set; }
          public double? STotalPrice { get; set; }
          public double? MAmount1 { get; set; }
          public double? MTotalPrice { get; set; }*/
    }
}