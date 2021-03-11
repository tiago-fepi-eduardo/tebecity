using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class RoleEntityMap : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("role");

            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(100)");
            
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            builder.Ignore(c => c.Error);
        }
    }
}
