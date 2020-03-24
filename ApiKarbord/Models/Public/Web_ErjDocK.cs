namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_ErjDocK 
    {
        [Key]
        public long SerialNumber { get; set; }

        public long? DocNo { get; set; }

        [StringLength(10)]
        public string DocDate { get; set; }

        [StringLength(250)] 
        public string Spec { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string CustCode { get; set; }

        public int? KhdtCode { get; set; }

        [StringLength(20)]
        public string Eghdam { get; set; }

        [StringLength(20)]
        public string Tanzim { get; set; }

        [Column(TypeName = "ntext")]
        public string DocDesc { get; set; }

        [Column(TypeName = "ntext")]
        public string FinalComm { get; set; }

        [Column(TypeName = "ntext")]
        public string EghdamComm { get; set; }

        [StringLength(10)]
        public string MhltDate { get; set; }

        [StringLength(10)]
        public string AmalDate { get; set; }

        [StringLength(10)]
        public string EndDate { get; set; }

        [Key]
        [StringLength(1)]
        public string SpecialComm { get; set; }

        public short? Mahramaneh { get; set; }

        [StringLength(50)]
        public string F01 { get; set; }

        [StringLength(50)]
        public string F02 { get; set; }

        [StringLength(50)]
        public string F03 { get; set; }

        [StringLength(50)]
        public string F04 { get; set; }

        [StringLength(50)]
        public string F05 { get; set; }

        [StringLength(50)]
        public string F06 { get; set; }

        [StringLength(50)]
        public string F07 { get; set; }

        [StringLength(50)]
        public string F08 { get; set; }

        [StringLength(50)]
        public string F09 { get; set; }

        [StringLength(50)]
        public string F10 { get; set; }

        [StringLength(50)]
        public string F11 { get; set; }

        [StringLength(50)]
        public string F12 { get; set; }

        [StringLength(50)]
        public string F13 { get; set; }

        [StringLength(50)]
        public string F14 { get; set; }

        [StringLength(50)]
        public string F15 { get; set; }

        [StringLength(50)]
        public string F16 { get; set; }

        [StringLength(50)]
        public string F17 { get; set; }

        [StringLength(50)]
        public string F18 { get; set; }

        [StringLength(50)]
        public string F19 { get; set; }

        [StringLength(50)]
        public string F20 { get; set; }

        [StringLength(100)]
        public string CustName { get; set; }

        [StringLength(100)]
        public string KhdtName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HasNewErja { get; set; }

        [StringLength(20)]
        public string ToUserCode { get; set; }
    }
}
