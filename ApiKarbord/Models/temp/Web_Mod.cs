namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_Mod
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(19)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string Spec { get; set; }
    }
}
