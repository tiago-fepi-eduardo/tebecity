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

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OcorrencyEntity> Ocorrency { get; set; }
        public DbSet<AboutEntity> About { get; set; }
        public DbSet<ContactEntity> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(new UserEntityMap().Configure);
            modelBuilder.Entity<OrderEntity>(new OrderEntityMap().Configure);
            modelBuilder.Entity<OcorrencyEntity>(new OcorrencyEntityMap().Configure);
            modelBuilder.Entity<AboutEntity>(new AboutEntityMap().Configure);
            modelBuilder.Entity<ContactEntity>(new ContactEntityMap().Configure);
            base.OnModelCreating(modelBuilder);
        }
    }
}
