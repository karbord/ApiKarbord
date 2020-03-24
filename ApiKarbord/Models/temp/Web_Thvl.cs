namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_Thvl
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string Spec { get; set; }
    }
}
