namespace ApiKarbord.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Web_Kala
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

        public double? zarib1 { get; set; }

        public double? zarib2 { get; set; }

        public double? zarib3 { get; set; }

        public string FanniNo { get; set; }

        public int? DeghatR1 { get; set; }

        public int? DeghatR2 { get; set; }

        public int? DeghatR3 { get; set; }

        public int? DeghatM1 { get; set; }

        public int? DeghatM2 { get; set; }

        public int? DeghatM3 { get; set; }

        public double? PPrice1 { get; set; }

        public double? PPrice2 { get; set; }

        public double? PPrice3 { get; set; }

        public double? SPrice1 { get; set; }

        public double? SPrice2 { get; set; }

        public double? SPrice3 { get; set; }

        //  public byte? SAddMin1 { get; set; }
        //  public byte? SAddMin2 { get; set; }
        //  public byte? SAddMin3 { get; set; }
        //  public byte? SAddMin4 { get; set; }
        //  public byte? SAddMin5 { get; set; }
        //  public byte? SAddMin6 { get; set; }
        // public byte? SAddMin7 { get; set; }
        //  public byte? SAddMin8 { get; set; }
        //   public byte? SAddMin9 { get; set; }
        //   public byte? SAddMin10 { get; set; }

        //  public byte? PAddMin1 { get; set; }
        // public byte? PAddMin2 { get; set; }
        //   public byte? PAddMin3 { get; set; }
        //  public byte? PAddMin4 { get; set; }
        //  public byte? PAddMin5 { get; set; }
        //  public byte? PAddMin6 { get; set; }
        //  public byte? PAddMin7 { get; set; }
        //  public byte? PAddMin8 { get; set; }
        //  public byte? PAddMin9 { get; set; }
        //  public byte? PAddMin10 { get; set; }


        public string SAddMin1 { get; set; }
        public string SAddMin2 { get; set; }
        public string SAddMin3 { get; set; }
        public string SAddMin4 { get; set; }
        public string SAddMin5 { get; set; }
        public string SAddMin6 { get; set; }
        public string SAddMin7 { get; set; }
        public string SAddMin8 { get; set; }
        public string SAddMin9 { get; set; }
        public string SAddMin10 { get; set; }

        public string PAddMin1 { get; set; }
        public string PAddMin2 { get; set; }
        public string PAddMin3 { get; set; }
        public string PAddMin4 { get; set; }
        public string PAddMin5 { get; set; }
        public string PAddMin6 { get; set; }
        public string PAddMin7 { get; set; }
        public string PAddMin8 { get; set; }
        public string PAddMin9 { get; set; }
        public string PAddMin10 { get; set; }
    }
}