namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class AFI_IDocHi
    {

        [Key]
        public long SerialNumber { get; set; }

        public byte? DocNoMode { get; set; }

        public byte? InsertMode { get; set; }

        public int? ModeCode { get; set; }

        public int? DocNo { get; set; }

        public int? StartNo { get; set; }

        public int? EndNo { get; set; }

        public byte? BranchCode { get; set; }

        public string UserCode { get; set; }

        public string DocDate { get; set; }

        public string DocTime { get; set; }

        public string Spec { get; set; }

        public string mDocDate { get; set; }

        public string Tanzim { get; set; }

        public string TahieShode { get; set; }

        public string CustCode { get; set; }

        public string InvCode { get; set; }

        public string Eghdam { get; set; }

        public int? KalaPriceCode { get; set; }

        public string Status { get; set; }

        public string Taeed { get; set; }

        public string Footer { get; set; }

        public int? DocNo_Out { get; set; }
    }
}


