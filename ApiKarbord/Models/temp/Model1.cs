namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Web_Acc> Web_Acc { get; set; }
        public virtual DbSet<Web_AddMin> Web_AddMin { get; set; }
        public virtual DbSet<Web_ADocH> Web_ADocH { get; set; }
        public virtual DbSet<Web_CGru> Web_CGru { get; set; }
        public virtual DbSet<Web_CheckInf> Web_CheckInf { get; set; }
        public virtual DbSet<Web_Cust> Web_Cust { get; set; }
        public virtual DbSet<Web_Dftr> Web_Dftr { get; set; }
        public virtual DbSet<Web_FctK> Web_FctK { get; set; }
        public virtual DbSet<Web_FctK_M> Web_FctK_M { get; set; }
        public virtual DbSet<Web_FctK_M1> Web_FctK_M1 { get; set; }
        public virtual DbSet<Web_FctK_R> Web_FctK_R { get; set; }
        public virtual DbSet<Web_FctK_R_M> Web_FctK_R_M { get; set; }
        public virtual DbSet<Web_FctK_R_M1> Web_FctK_R_M1 { get; set; }
        public virtual DbSet<Web_FctR> Web_FctR { get; set; }
        public virtual DbSet<Web_FctR_M> Web_FctR_M { get; set; }
        public virtual DbSet<Web_FctR_R> Web_FctR_R { get; set; }
        public virtual DbSet<Web_FctR_R_R_M> Web_FctR_R_R_M { get; set; }
        public virtual DbSet<Web_GADoc> Web_GADoc { get; set; }
        public virtual DbSet<Web_GADoc_M> Web_GADoc_M { get; set; }
        public virtual DbSet<Web_GFDoc> Web_GFDoc { get; set; }
        public virtual DbSet<Web_GFDoc_R> Web_GFDoc_R { get; set; }
        public virtual DbSet<Web_GFDoc_R1> Web_GFDoc_R1 { get; set; }
        public virtual DbSet<Web_GFDoc1> Web_GFDoc1 { get; set; }
        public virtual DbSet<Web_GIDoc> Web_GIDoc { get; set; }
        public virtual DbSet<Web_GIDoc_M> Web_GIDoc_M { get; set; }
        public virtual DbSet<Web_GIDoc1> Web_GIDoc1 { get; set; }
        public virtual DbSet<Web_Inv> Web_Inv { get; set; }
        public virtual DbSet<Web_Kala> Web_Kala { get; set; }
        public virtual DbSet<Web_KalaPrice> Web_KalaPrice { get; set; }
        public virtual DbSet<Web_KGru> Web_KGru { get; set; }
        public virtual DbSet<Web_LoadDocB> Web_LoadDocB { get; set; }
        public virtual DbSet<Web_LoadDocB_M> Web_LoadDocB_M { get; set; }
        public virtual DbSet<Web_Mod> Web_Mod { get; set; }
        public virtual DbSet<Web_TAcc_M> Web_TAcc_M { get; set; }
        public virtual DbSet<Web_Thvl> Web_Thvl { get; set; }
        public virtual DbSet<Web_TrzIKala_M> Web_TrzIKala_M { get; set; }
        public virtual DbSet<Web_Unit> Web_Unit { get; set; }
        public virtual DbSet<Web_UnitPrice> Web_UnitPrice { get; set; }
        public virtual DbSet<Web_VGru> Web_VGru { get; set; }
        public virtual DbSet<Web_Vstr> Web_Vstr { get; set; }
        public virtual DbSet<Web_ZAcc> Web_ZAcc { get; set; }
        public virtual DbSet<Web_ZGru> Web_ZGru { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Web_CheckInf>()
                .Property(e => e.ParDar)
                .IsUnicode(false);

            modelBuilder.Entity<Web_GIDoc>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Web_GIDoc_M>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Web_GIDoc1>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Web_Mod>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Web_Mod>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Web_Mod>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Web_Thvl>()
                .Property(e => e.Spec)
                .IsUnicode(false);
        }
    }
}
