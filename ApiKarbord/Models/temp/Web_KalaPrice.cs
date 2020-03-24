namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_KalaPrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PriceCode { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
