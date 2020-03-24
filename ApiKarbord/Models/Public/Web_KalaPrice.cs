namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_KalaPrice
    {
        [Key]
        public int? Code { get; set; }
        public string Name { get; set; }
        public bool Cancel { get; set; }
    }
}