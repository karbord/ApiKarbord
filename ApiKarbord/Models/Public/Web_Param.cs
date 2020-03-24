namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_Param
    {
        [Key]
        public int id { get; set; }

        public string Node { get; set; }
  
        public string Key { get; set; }

        public string Param { get; set; }
    }
}