namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_LoadDocB
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SerialNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BandNo { get; set; }

        public long? LinkSerialNumber { get; set; }

        public int? LinkBandNo { get; set; }

        public byte? LinkMode { get; set; }

        [StringLength(50)]
        public string AccCode { get; set; }

        public long? AccZCode { get; set; }

        [StringLength(100)]
        public string KalaCode { get; set; }

        [StringLength(50)]
        public string BVstrCode { get; set; }

        public double? BVstrPer { get; set; }

        public double? Bede { get; set; }

        public double? Best { get; set; }

        public int? MainUnit { get; set; }

        public double? Amount1 { get; set; }

        public double? Amount2 { get; set; }

        public double? Amount3 { get; set; }

        public double? UnitPrice { get; set; }

        public double? TotalPrice { get; set; }

        public double? DimX { get; set; }

        public double? DimY { get; set; }

        public double? DimZ { get; set; }

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

        [StringLength(50)]
        public string TrafCode { get; set; }

        public long? TrafZCode { get; set; }

        public short? CheckMode { get; set; }

        public double? AddMin1 { get; set; }

        public double? AddMin2 { get; set; }

        public double? AddMin3 { get; set; }

        public double? AddMin4 { get; set; }

        public double? AddMin5 { get; set; }

        public double? AddMin6 { get; set; }

        public double? AddMin7 { get; set; }

        public double? AddMin8 { get; set; }

        public double? AddMin9 { get; set; }

        public double? AddMin10 { get; set; }

        public bool? UP_Flag { get; set; }

        [StringLength(20)]
        public string ArzCode { get; set; }

        public double? ArzRate { get; set; }

        public double? ArzValue { get; set; }

        [StringLength(250)]
        public string ExtraComm { get; set; }

        [StringLength(250)]
        public string BandSpec { get; set; }

        public double? VstrDiscount { get; set; }

        public bool? Residegi { get; set; }

        public double? FifoLifoAmount { get; set; }

        [Column(TypeName = "ntext")]
        public string Comm { get; set; }

        [StringLength(50)]
        public string MkzCode { get; set; }

        [StringLength(50)]
        public string OprCode { get; set; }

        public int? CheckRadif { get; set; }

        [StringLength(250)]
        public string CheckComm { get; set; }

        [StringLength(10)]
        public string CheckVosoolDate { get; set; }

        [StringLength(100)]
        public string PrdCode { get; set; }

        public double? Discount { get; set; }

        public long? DocNo { get; set; }

        public long? SortDocNo { get; set; }

        [StringLength(10)]
        public string DocDate { get; set; }

        public DateTime? mDocDate { get; set; }

        [StringLength(250)]
        public string Spec { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(20)]
        public string Eghdam { get; set; }

        [StringLength(10)]
        public string Tanzim { get; set; }

        [StringLength(10)]
        public string Taeed { get; set; }

        public byte? PaymentType { get; set; }

        public double? VstrPer { get; set; }

        public int? ModeCode { get; set; }

        [StringLength(50)]
        public string CustCode { get; set; }

        [StringLength(50)]
        public string VstrCode { get; set; }

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

        [StringLength(250)]
        public string KalaName { get; set; }

        [StringLength(50)]
        public string KalaFanniNo { get; set; }

        public double? KalaZarib1 { get; set; }

        public double? KalaZarib2 { get; set; }

        public double? KalaZarib3 { get; set; }

        [StringLength(30)]
        public string KalaUnitName1 { get; set; }

        [StringLength(30)]
        public string KalaUnitName2 { get; set; }

        [StringLength(30)]
        public string KalaUnitName3 { get; set; }

        [StringLength(50)]
        public string KGruCode { get; set; }

        [StringLength(100)]
        public string CustName { get; set; }

        [StringLength(50)]
        public string CGruCode { get; set; }

        [StringLength(100)]
        public string VstrName { get; set; }

        [StringLength(50)]
        public string VGruCode { get; set; }

        [StringLength(50)]
        public string MainUnitName { get; set; }

        [StringLength(20)]
        public string PaymentTypeSt { get; set; }

        public double? FinalPrice { get; set; }
    }
}
