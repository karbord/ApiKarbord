namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Web_Kala
    {
        [Key]
        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Spec { get; set; }

        [StringLength(30)]
        public string UnitName1 { get; set; }

        [StringLength(30)]
        public string UnitName2 { get; set; }

        [StringLength(30)]
        public string UnitName3 { get; set; }

        [StringLength(50)]
        public string KGruCode { get; set; }
    }
}
