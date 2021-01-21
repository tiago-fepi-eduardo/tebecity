using Microsoft.EntityFrameworkCore;
using TE.BE.City.Domain.Entity;
using TE.BE.City.Infra.Data.Mappings;

namespace TE.BE.City.Infra.Data
{
    public class TEBECityContext : DbContext
    {
        public TEBECityContext(DbContextOptions options) : base(options)
        {
            //Empty
        }

        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OcorrencyEntity> Ocorrency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>(new OrderEntityMap().Configure);
            modelBuilder.Entity<OcorrencyEntity>(new OcorrencyEntityMap().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }
}
