namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_Cust
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Spec { get; set; }
        public int CustMode { get; set; }
        public string SAddMin1 { get; set; }
        public string SAddMin2 { get; set; }
        public string SAddMin3 { get; set; }
        public string SAddMin4 { get; set; }
        public string SAddMin5 { get; set; }
        public string SAddMin6 { get; set; }
        public string SAddMin7 { get; set; }
        public string SAddMin8 { get; set; }
        public string SAddMin9 { get; set; }
        public string SAddMin10 { get; set; }
        public string PAddMin1 { get; set; }
        public string PAddMin2 { get; set; }
        public string PAddMin3 { get; set; }
        public string PAddMin4 { get; set; }
        public string PAddMin5 { get; set; }
        public string PAddMin6 { get; set; }
        public string PAddMin7 { get; set; }
        public string PAddMin8 { get; set; }
        public string PAddMin9 { get; set; }
        public string PAddMin10 { get; set; }
        public int? KalaPriceCode_P { get; set; }
        public int? KalaPriceCode_S { get; set; }
        public int? CGruKalaPriceCode_P { get; set; }
        public int? CGruKalaPriceCode_S { get; set; }
    }
}