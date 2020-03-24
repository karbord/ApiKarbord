namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_ADocH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SerialNumber { get; set; }

        public long? DocNo { get; set; }

        [StringLength(10)]
        public string DocDate { get; set; }

        public DateTime? mDocDate { get; set; }

        [StringLength(8)]
        public string DocTime { get; set; }

        public long? RSerialNumber { get; set; }

        [StringLength(250)]
        public string Spec { get; set; }

        public int? ModeCode { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(10)]
        public string Tanzim { get; set; }

        [StringLength(10)]
        public string Taeed { get; set; }

        [StringLength(10)]
        public string TahieShode { get; set; }

        [StringLength(4000)]
        public string Footer { get; set; }

        public byte? PaymentType { get; set; }

        public double? TotalValue { get; set; }

        [StringLength(50)]
        public string VstrCode { get; set; }

        public double? VstrPer { get; set; }

        [StringLength(50)]
        public string CustCode { get; set; }

        [StringLength(50)]
        public string PakhshCode { get; set; }

        [StringLength(100)]
        public string hCustCity { get; set; }

        [StringLength(100)]
        public string hCustRegion { get; set; }

        [StringLength(100)]
        public string hCustStreet { get; set; }

        [StringLength(100)]
        public string hCustAlley { get; set; }

        [StringLength(20)]
        public string hCustPlack { get; set; }

        [StringLength(20)]
        public string hCustZipCode { get; set; }

        [StringLength(50)]
        public string hCustTel { get; set; }

        [StringLength(50)]
        public string hCustMobile { get; set; }

        [StringLength(250)]
        public string F01 { get; set; }

        [StringLength(250)]
        public string F02 { get; set; }

        [StringLength(250)]
        public string F03 { get; set; }

        [StringLength(250)]
        public string F04 { get; set; }

        [StringLength(250)]
        public string F05 { get; set; }

        [StringLength(250)]
        public string F06 { get; set; }

        [StringLength(250)]
        public string F07 { get; set; }

        [StringLength(250)]
        public string F08 { get; set; }

        [StringLength(250)]
        public string F09 { get; set; }

        [StringLength(250)]
        public string F10 { get; set; }

        [StringLength(250)]
        public string F11 { get; set; }

        [StringLength(250)]
        public string F12 { get; set; }

        [StringLength(250)]
        public string F13 { get; set; }

        [StringLength(250)]
        public string F14 { get; set; }

        [StringLength(250)]
        public string F15 { get; set; }

        [StringLength(250)]
        public string F16 { get; set; }

        [StringLength(250)]
        public string F17 { get; set; }

        [StringLength(250)]
        public string F18 { get; set; }

        [StringLength(250)]
        public string F19 { get; set; }

        [StringLength(250)]
        public string F20 { get; set; }

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

        [StringLength(20)]
        public string InvCode { get; set; }

        public long? OrderNumber { get; set; }

        public long? OMoveSerialNumber { get; set; }

        [StringLength(50)]
        public string AccCode { get; set; }

        public int? KalaPriceCode { get; set; }

        public double? PishDaryaft { get; set; }

        [StringLength(10)]
        public string TasviyeDate { get; set; }

        [StringLength(20)]
        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public short? Branch { get; set; }

        public bool? RelatedGroupActive { get; set; }

        public int? RelatedGroup_FromGroup { get; set; }

        public long? RelatedGroup_FromSerialNumber { get; set; }

        [StringLength(20)]
        public string PrintDate { get; set; }

        public int? PrintCount { get; set; }

        [StringLength(10)]
        public string InvRegDocDate { get; set; }

        public short? RYear { get; set; }

        [StringLength(20)]
        public string Eghdam { get; set; }

        public DateTime? EghdamDate { get; set; }

        public short? EghdamBranch { get; set; }

        [Column(TypeName = "ntext")]
        public string Attach { get; set; }

        public byte? LegalRoozNoMode { get; set; }

        public int? LegalRoozNo { get; set; }

        [StringLength(10)]
        public string ValidDate { get; set; }

        public long? LinkNumber { get; set; }
    }
}
