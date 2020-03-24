namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class AddMin
    {
        public int? Code { get; set; }
        public string Name { get; set; }
        public double? AddMinPrice { get; set; }

        public int? Mode { get; set; }
        public bool Auto { get; set; }
        public double? MablaghMoaser { get; set; }
        public double? SumDiscount { get; set; }

    }
}