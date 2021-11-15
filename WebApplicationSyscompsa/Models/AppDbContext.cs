using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationSyscompsa.Models.APCIAS_MODEL;
using WebApplicationSyscompsa.Models.ar_loscann;
using WebApplicationSyscompsa.Models.despacho_save;
using WebApplicationSyscompsa.Models.history;
using WebApplicationSyscompsa.Models.lote_foto;
using WebApplicationSyscompsa.Models.Mail_Send;
using WebApplicationSyscompsa.Models.Mod_tab;
using WebApplicationSyscompsa.Models.traspase_product;

namespace WebApplicationSyscompsa.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
        public DbSet<WebUser> WebUser { get; set; }
        public DbSet<apcias> apcias { get; set; }
        public DbSet<mensajeMod> mensajeMod { get; set; }
        public DbSet<t_invcabg> t_invcabg { get; set; }
        public DbSet<t_invdetg> t_invdetg { get; set; }
        public DbSet<Img_lote> img_lote { get; set; }
        public DbSet<Tipo_control_emps> tipo_control_emp { get; set; }
        public DbSet<Traspase_product> traspase_product { get; set; }
        public DbSet<Module_tab> module_tab { get; set; }
        public DbSet<Ar_loscann> ar_loscann { get; set; }
        public DbSet<Hist_comp_emp> hist_comp_emp { get; set; }

        //asignamos el valor de los decimales que estan truncandose mediante c#
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CAMBIAMOS EL PRIMARY KEY QUE VIEN POR DEFECTO EN ID Y ESCIFICAMOS EL QUE QUEREMOS USAR
            #region
            //t_invcabg
            modelBuilder.Entity<apcias>().HasKey(pk => pk.email_despacho_web).HasName("email_despacho_web");
            modelBuilder.Entity<t_invcabg>().HasKey(pk => pk.T_llave).HasName("T_llave");
            modelBuilder.Entity<t_invcabg>().HasKey(pk => pk.tempo).HasName("tempo");
            modelBuilder.Entity<Img_lote>().HasKey(pk =>  pk.no_parte_i).HasName("no_parte_i");
            #endregion

            //EVITAMOS EL CRASHED(COFLICTO) DE DATOS
            #region
            //t_invdetg

            modelBuilder.Entity<t_invdetg>().HasKey(pk => pk.T_llave).HasName("T_llave");
            modelBuilder.Entity<t_invdetg>().HasKey(pk => pk.tempo).HasName("tempo");
            modelBuilder.Entity<Module_tab>().HasKey(pk => pk.name_module).HasName("name_module");
            modelBuilder.Entity<t_invdetg>().HasKey(pk => pk.linea).HasName("linea");
            modelBuilder.Entity<t_invdetg>().Property(a => a.cantidad).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<t_invdetg>().Property(a => a.cant_tou).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<t_invcabg>().Property(a => a.total_mov).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<t_invcabg>().Property(a => a.total_trn).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Traspase_product>().Property(a => a.cantidad).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Traspase_product>().Property(a => a.difer_stcok).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Traspase_product>().Property(a => a.stock).HasColumnType("decimal(10,2)");

            #endregion

        }

    }
}

