using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class AboutEntityMap : IEntityTypeConfiguration<AboutEntity>
    {
        public void Configure(EntityTypeBuilder<AboutEntity> builder)
        {
            builder.ToTable("about");

            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasColumnType("longtext");
            
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            builder.Ignore(c => c.Error);
        }
    }
}
