﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class OrderEntityMap : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("order");

            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.Latitude)
                .IsRequired()
                .HasColumnName("latitude")
                .HasColumnType("varchar(24)");
            
            builder.Property(c => c.Longitude)
                .IsRequired()
                .HasColumnName("longitude")
                .HasColumnType("varchar(24)");

            builder.Property(c => c.OcorrencyId)
                .HasColumnName("ocorrency")
                .HasColumnType("int");

            builder.Property(c => c.OcorrencyDetailId)
                .IsRequired()
                .HasColumnName("ocorrencyDetail")
                .HasColumnType("int");

            builder.Property(c => c.OrderStatusId)
                .IsRequired()
                .HasColumnName("orderStatus")
                .HasColumnType("int");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            builder.Ignore(c => c.StartDate);
            builder.Ignore(c => c.EndDate);
            builder.Ignore(c => c.Error);
            builder.Ignore(c => c.OrderStatus);
            builder.Ignore(c => c.Ocorrency);
        }
    }
}