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
        public virtual DbSet<TypeSex> TypeSex { get; set; }
        public virtual DbSet<TypeGirls> TypeGirls { get; set; }
        public virtual DbSet<GaleriaGirls> GaleriaGirls { get; set; }
        public virtual DbSet<PortadaGirls> PortadaGirls { get; set; }
        public virtual DbSet<ChangePassword> ChangePassword { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(EngineData.ConnectionDb);
            }

        }
    }
}
