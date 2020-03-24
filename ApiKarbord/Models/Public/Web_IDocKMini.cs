namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_IDocHMini
    {
        [Key]
        public long SerialNumber { get; set; }

        public string DocNo { get; set; }

        public double? SortDocNo { get; set; }

        [StringLength(10)]
        public string DocDate { get; set; }


        [StringLength(50)]
        public string ThvlCode { get; set; }


        [StringLength(100)]
        public string thvlname { get; set; }

        [StringLength(250)]
        public string Spec { get; set; }

        public int? KalaPriceCode { get; set; }

        [StringLength(20)]
        public string InvCode { get; set; }

        public int? ModeCode { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public byte PaymentType { get; set; }

        [StringLength(4000)]
        public string Footer { get; set; }


        [StringLength(10)]
        public string Tanzim { get; set; }


        [StringLength(10)]
        public string Taeed { get; set; }

        public double? FinalPrice { get; set; }

        [StringLength(20)]
        public string Eghdam { get; set; }

        public string ModeName { get; set; }

        public string InvName { get; set; }

    }
}