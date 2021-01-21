using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class OcorrencyEntityMap : IEntityTypeConfiguration<OcorrencyEntity>
    {
        public void Configure(EntityTypeBuilder<OcorrencyEntity> builder)
        {
            builder.ToTable("ocorrency");
                
            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(100)");
            
            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnName("description")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");
        }
    }
}
