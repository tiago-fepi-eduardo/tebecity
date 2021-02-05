using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class UserEntityMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("user");

            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("firstName")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("lastName")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Username)
                .IsRequired()
                .HasColumnName("userName")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Active)
                .HasColumnName("active")
                .HasColumnType("bit");

            builder.Property(c => c.Block)
                .HasColumnName("block")
                .HasColumnType("bit");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            builder.Ignore(c => c.Token);

            builder.Ignore(c => c.Error);
        }
    }
}
