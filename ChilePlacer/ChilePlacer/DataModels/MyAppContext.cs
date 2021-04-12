using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChilePlacer.DataModels
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Girls> Girls { get; set; }
        public virtual DbSet<TypeSex> TypeSex { get; set; }
        public virtual DbSet<TypeGirls> TypeGirls { get; set; }
        public virtual DbSet<GaleriaGirls> GaleriaGirls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=EMCSERVERI7;Database=ChilePlacer;User Id=sa;password=1234santiago;Trusted_Connection=False;");
            }

        }


    }
}
