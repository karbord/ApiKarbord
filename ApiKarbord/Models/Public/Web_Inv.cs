namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_Inv
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }

        public string Spec { get; set; }
    }
}