namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_AddMin
    {
        [Key]
        [Column(Order = 0)]
        public byte Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int? Mode { get; set; }

        public bool? Auto { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool ForSale { get; set; }

        public double? Per { get; set; }
    }
}
