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
        public virtual DbSet<ProfileGirls> ProfileGirls { get; set; }
        public virtual DbSet<TypeSex> TypeSex { get; set; }
        public virtual DbSet<TypeGirls> TypeGirls { get; set; }
        public virtual DbSet<GaleriaGirls> GaleriaGirls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL5104.site4now.net;Initial Catalog=db_a72b76_chileplacer;User Id=db_a72b76_chileplacer_admin;Password=1234santiago");
            }

        }
    }
}
