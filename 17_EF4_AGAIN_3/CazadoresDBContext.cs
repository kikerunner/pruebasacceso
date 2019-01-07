using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _17_EF4_AGAIN_3
{
    public class CazadoresDBContext : DbContext
    {
        public DbSet<Cazador> Cazadores { get; set; }
        public DbSet<Arma> Armas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cazador>().MapToStoredProcedures();
            modelBuilder.Entity<Arma>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
    }
}