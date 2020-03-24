namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_CheckInf
    {
        [StringLength(20)]
        public string AccCode { get; set; }

        [StringLength(20)]
        public string CheckNo { get; set; }

        [StringLength(10)]
        public string CheckDate { get; set; }

        [StringLength(20)]
        public string Bank { get; set; }

        [StringLength(20)]
        public string Shobe { get; set; }

        [StringLength(20)]
        public string Jari { get; set; }

        [StringLength(20)]
        public string BaratNo { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string CheckId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PDMode { get; set; }

        public double? Value { get; set; }

        public double? FValue { get; set; }

        [StringLength(50)]
        public string TrafCode { get; set; }

        public long? TrafZCode { get; set; }

        [StringLength(50)]
        public string FTrafCode { get; set; }

        public long? FTrafZCode { get; set; }

        [StringLength(50)]
        public string VstrCode { get; set; }

        [StringLength(50)]
        public string FVstrCode { get; set; }

        public double? VstrPer { get; set; }

        public double? FVstrPer { get; set; }

        public int? InCount { get; set; }

        public int? OutCount { get; set; }

        public int? CheckStatus { get; set; }

        public int? CheckRadif { get; set; }

        [StringLength(250)]
        public string CheckComm { get; set; }

        [StringLength(10)]
        public string CheckVosoolDate { get; set; }

        [StringLength(20)]
        public string CheckStatusSt { get; set; }

        public short? SrchOrder { get; set; }

        [StringLength(100)]
        public string TrafName { get; set; }

        public long? AccZCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string ParDar { get; set; }

        [StringLength(20)]
        public string Acc_Code { get; set; }

        [StringLength(20)]
        public string Check_No { get; set; }

        [StringLength(10)]
        public string Check_Date { get; set; }
    }
}
