namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_UnitPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }

        [StringLength(100)]
        public string KalaCode { get; set; }

        public double? Price1 { get; set; }

        public double? Price2 { get; set; }

        public double? Price3 { get; set; }
    }
}
