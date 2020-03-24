namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_GFDoc1
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tag { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BandNo { get; set; }

        [StringLength(50)]
        public string KGruCode { get; set; }

        [StringLength(100)]
        public string KalaCode { get; set; }

        [StringLength(250)]
        public string KalaName { get; set; }

        [StringLength(50)]
        public string KalaFanniNo { get; set; }

        [StringLength(50)]
        public string MainUnitName { get; set; }

        [Column(TypeName = "ntext")]
        public string Comm { get; set; }

        [StringLength(250)]
        public string BandSpec { get; set; }

        [StringLength(250)]
        public string ExtraComm { get; set; }

        [StringLength(30)]
        public string KalaUnitName1 { get; set; }

        [StringLength(30)]
        public string KalaUnitName2 { get; set; }

        [StringLength(30)]
        public string KalaUnitName3 { get; set; }

        public double? UnitPrice { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SerialNumber { get; set; }

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

        [StringLength(20)]
        public string PaymentTypeSt { get; set; }

        public double? VstrPer { get; set; }

        public int? ModeCode { get; set; }

        [StringLength(50)]
        public string CGruCode { get; set; }

        [StringLength(50)]
        public string CustCode { get; set; }

        [StringLength(100)]
        public string CustName { get; set; }

        [StringLength(50)]
        public string VGruCode { get; set; }

        [StringLength(50)]
        public string VstrCode { get; set; }

        [StringLength(100)]
        public string VstrName { get; set; }

        public double? Amount1 { get; set; }

        public double? Amount2 { get; set; }

        public double? Amount3 { get; set; }

        public double? Discount { get; set; }

        public double? TotalPrice { get; set; }

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

        public double? FinalPrice { get; set; }

        public double? Tag_AddMin1 { get; set; }

        public double? Tag_AddMin2 { get; set; }

        public double? Tag_AddMin3 { get; set; }

        public double? Tag_AddMin4 { get; set; }

        public double? Tag_AddMin5 { get; set; }

        public double? Tag_AddMin6 { get; set; }

        public double? Tag_AddMin7 { get; set; }

        public double? Tag_AddMin8 { get; set; }

        public double? Tag_AddMin9 { get; set; }

        public double? Tag_AddMin10 { get; set; }

        public double? Tag_Amount1 { get; set; }

        public double? Tag_Amount2 { get; set; }

        public double? Tag_Amount3 { get; set; }

        public double? Tag_TotalPrice { get; set; }

        public double? Tag_Discount { get; set; }

        public double? Tag_FinalPrice { get; set; }
    }
}
