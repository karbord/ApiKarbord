namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_DocBDocCUser 
    {
        [Key]
        public long SerialNumber { get; set; }

        public int DocBMode { get; set; }

        public int? BandNo { get; set; }

        [StringLength(10)] 
        public string RjDate { get; set; }

        [StringLength(50)]
        public string RjStatus { get; set; }

        [StringLength(10)]
        public string RjEndDate { get; set; }

        [StringLength(10)]
        public string RjMhltDate { get; set; }

        [Column(TypeName = "ntext")]
        public string RjComm { get; set; }

        public int? ErjaCount { get; set; }

        public double? RjTime { get; set; }

        [StringLength(39)]
        public string FromUserCode { get; set; }

        [StringLength(69)]
        public string FromUserName { get; set; }

        [StringLength(33)]
        public string ToUserCode { get; set; }

        [StringLength(63)]
        public string ToUserName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string RooneveshtUserCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string RooneveshtUserName { get; set; }

        public bool? RjRead { get; set; }

        [StringLength(10)]
        public string Radif { get; set; }
    }
}
