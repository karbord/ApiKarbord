namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_Thvl
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Spec { get; set; }

       // public int? KalaPriceCode_P { get; set; }

       // public int? KalaPriceCode_S { get; set; }

        public int? CGruKalaPriceCode_P { get; set; }

        public int? CGruKalaPriceCode_S { get; set; }
    }
}
