using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChilePlacer.Application;
using Microsoft.EntityFrameworkCore;

namespace ChilePlacer.DataModels
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AppLog> AppLog { get; set; }
        public virtual DbSet<Girls> Girls { get; set; }
        public virtual DbSet<ProfileGirls> ProfileGirls { get; set; }
        public virtual DbSet<GaleriaGirls> GaleriaGirls { get; set; }
        public virtual DbSet<PortadaGirls> PortadaGirls { get; set; }
        public virtual DbSet<ChangePassword> ChangePassword { get; set; }


        /// <summary>
        /// TABLAS CATALOGOS /////////////
        /// </summary>

        //__________________________________________________________________________________
        public virtual DbSet<TypeAtencion> TypeAtencion { get; set; }
        public virtual DbSet<TypeAtencionGirl> TypeAtencionGirl { get; set; }
        //_______________________________________________________________________________
        public virtual DbSet<TypeCountry> TypeCountry { get; set; }
        public virtual DbSet<TypeLocation> TypeLocation { get; set; }
        public virtual DbSet<TypeNacionalidad> TypeNacionalidad { get; set; }
        //________________________________________________________________________________
        public virtual DbSet<TypeContextura> TypeContextura{ get; set; }
        public virtual DbSet<TypeDepilacion> TypeDepilacion { get; set; }
        public virtual DbSet<TypeDrink> TypeDrink { get; set; }
        public virtual DbSet<TypeEscort> TypeEscort { get; set; }
        public virtual DbSet<TypeEyes> TypeEyes { get; set; }
        public virtual DbSet<TypeGirls> TypeGirls { get; set; }
        //_____________________________________________________________________
        public virtual DbSet<TypeGirlServices> TypeGirlServices { get; set; }
        public virtual DbSet<TypeServicesSex> TypeServicesSex { get; set; }
        //_______________________________________________________________________
        public virtual DbSet<TypeHair> TypeHair { get; set; }
        public virtual DbSet<TypePiel> TypePiel { get; set; }
        public virtual DbSet<TypeSex> TypeSex { get; set; }
        public virtual DbSet<TypeSmoke> TypeSmoke{ get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(EngineData.ConnectionDb);
            }

        }
    }
}
