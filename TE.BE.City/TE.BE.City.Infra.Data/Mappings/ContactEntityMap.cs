using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TE.BE.City.Domain.Entity;

namespace TE.BE.City.Infra.Data.Mappings
{
    public class ContactEntityMap : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.ToTable("contact");

            builder.HasKey(c => c.Id)
                .HasName("id");

            builder.Property(c => c.Subject)
                .HasColumnName("subject")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Message)
                .HasColumnName("message")
                .HasColumnType("longtext");

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt")
                .HasColumnType("datetime");

            builder.Ignore(c => c.Error);
        }
    }
}
