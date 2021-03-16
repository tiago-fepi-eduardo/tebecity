using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class NewsEntityMap : IEntityTypeConfiguration<NewsEntity>
    {
        public void Configure(EntityTypeBuilder<NewsEntity> builder)
        {
            builder.ToTable("news");

            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.Title)
                .HasColumnName("title")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasColumnType("longtext");

            builder.Property(c => c.Closed)
                .HasColumnName("closed")
                .HasColumnType("bit");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            builder.Ignore(c => c.Error);
        }
    }
}
