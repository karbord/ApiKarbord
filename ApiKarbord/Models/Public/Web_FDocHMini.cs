namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_FDocHMini
    {
        [Key]
        public long SerialNumber { get; set; }

        public string DocNo { get; set; }

        public double? SortDocNo { get; set; }

        [StringLength(10)]
        public string DocDate { get; set; }

        [StringLength(50)]
        public string CustCode { get; set; }

        [StringLength(100)]
        public string CustName { get; set; }

        [StringLength(250)]
        public string Spec { get; set; }

        public int? KalaPriceCode { get; set; }

        [StringLength(20)]
        public string InvCode { get; set; }

        [StringLength(100)]
        public string AddMinSpec1 { get; set; }

        [StringLength(100)]
        public string AddMinSpec2 { get; set; }

        [StringLength(100)]
        public string AddMinSpec3 { get; set; }

        [StringLength(100)]
        public string AddMinSpec4 { get; set; }

        [StringLength(100)]
        public string AddMinSpec5 { get; set; }

        [StringLength(100)]
        public string AddMinSpec6 { get; set; }

        [StringLength(100)]
        public string AddMinSpec7 { get; set; }

        [StringLength(100)]
        public string AddMinSpec8 { get; set; }

        [StringLength(100)]
        public string AddMinSpec9 { get; set; }

        [StringLength(100)]
        public string AddMinSpec10 { get; set; }


        public double? AddMinPrice1 { get; set; }

        public double? AddMinPrice2 { get; set; }

        public double? AddMinPrice3 { get; set; }

        public double? AddMinPrice4 { get; set; }

        public double? AddMinPrice5 { get; set; }

        public double? AddMinPrice6 { get; set; }

        public double? AddMinPrice7 { get; set; }

        public double? AddMinPrice8 { get; set; }

        public double? AddMinPrice9 { get; set; }

        public double? AddMinPrice10 { get; set; }

        public int? ModeCode { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public byte? PaymentType { get; set; }

        [StringLength(4000)]
        public string Footer { get; set; }


        [StringLength(10)]
        public string Tanzim { get; set; }

        [StringLength(10)]
        public string Taeed { get; set; }

        public double? FinalPrice { get; set; }

        [StringLength(20)]
        public string Eghdam { get; set; }

    }
}