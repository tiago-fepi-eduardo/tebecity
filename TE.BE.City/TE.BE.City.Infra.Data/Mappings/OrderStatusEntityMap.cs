using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class OrderStatusEntityMap : IEntityTypeConfiguration<OrderStatusEntity>
    {
        public void Configure(EntityTypeBuilder<OrderStatusEntity> builder)
        {
            builder.ToTable("orderStatus");

            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Closed)
               .IsRequired()
               .HasColumnName("closed")
               .HasColumnType("boolean");


            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            builder.Ignore(c => c.Error);
        }
    }
}
