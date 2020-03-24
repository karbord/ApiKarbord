namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_Dftr
    {
        public long? SerialNumber { get; set; }

        public int? BandNo { get; set; }

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

        public double? Discount { get; set; }

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

        public long? DocBId { get; set; }

        [StringLength(66)]
        public string CheckId { get; set; }

        [StringLength(100)]
        public string AccName { get; set; }

        [StringLength(100)]
        public string AccZName { get; set; }

        [StringLength(50)]
        public string AccModeName { get; set; }

        public long? AccCode1 { get; set; }

        public long? AccCode2 { get; set; }

        public long? AccCode3 { get; set; }

        public long? AccCode4 { get; set; }

        public long? AccCode5 { get; set; }

        public short? AccMode { get; set; }

        public int? AGruMode { get; set; }

        public long? AGruCode1 { get; set; }

        public long? AGruCode2 { get; set; }

        public long? AGruCode3 { get; set; }

        public long? AGruCode4 { get; set; }

        public long? AGruCode5 { get; set; }

        public int? PDMode { get; set; }

        [StringLength(250)]
        public string AccZGru { get; set; }

        public short? AccMahiat { get; set; }

        public short? AccLevel { get; set; }

        public bool? AccHasChild { get; set; }

        public int? AccDeghat { get; set; }

        [StringLength(20)]
        public string AccVahed { get; set; }

        public bool? AccArzi { get; set; }

        public bool? AccNextLevelFromZAcc { get; set; }

        [StringLength(100)]
        public string AccLastLevelName { get; set; }

        [StringLength(100)]
        public string TrafName { get; set; }

        [StringLength(100)]
        public string TrafZName { get; set; }

        public long? TrafCode1 { get; set; }

        public long? TrafCode2 { get; set; }

        public long? TrafCode3 { get; set; }

        public long? TrafCode4 { get; set; }

        public long? TrafCode5 { get; set; }

        public short? TrafMode { get; set; }

        [StringLength(250)]
        public string TrafZGru { get; set; }

        public short? TrafLevel { get; set; }

        public bool? TrafHasChild { get; set; }

        public bool? TrafNextLevelFromZAcc { get; set; }

        [StringLength(100)]
        public string TrafLastLevelName { get; set; }

        [StringLength(100)]
        public string BVstrName { get; set; }

        public double? BVstrVstrPer { get; set; }

        [StringLength(50)]
        public string BVGruCode { get; set; }

        [StringLength(100)]
        public string BVGruName { get; set; }

        public long? BVGruCode1 { get; set; }

        public long? BVGruCode2 { get; set; }

        public long? BVGruCode3 { get; set; }

        public long? BVGruCode4 { get; set; }

        public long? BVGruCode5 { get; set; }

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

        [StringLength(52)]
        public string CheckOrder { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long hSerialNumber { get; set; }

        public long? DocNo { get; set; }

        [StringLength(10)]
        public string DocDate { get; set; }

        public DateTime? mDocDate { get; set; }

        [StringLength(250)]
        public string Spec { get; set; }

        [StringLength(10)]
        public string TasviyeDate { get; set; }

        [StringLength(10)]
        public string Tanzim { get; set; }

        [StringLength(10)]
        public string Taeed { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public int? ModeCode { get; set; }

        [StringLength(50)]
        public string ModeName { get; set; }

        [StringLength(50)]
        public string Acc_Code { get; set; }

        [StringLength(100)]
        public string Acc_Name { get; set; }

        [StringLength(20)]
        public string Check_No { get; set; }

        [StringLength(10)]
        public string Check_Date { get; set; }

        public double? Amount { get; set; }
    }
}
