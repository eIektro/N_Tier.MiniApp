using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace N_Tier.MiniApp.Data.Configuration
{
    public class SirketConfiguration : IEntityTypeConfiguration<Sirket>
    {
        public void Configure(EntityTypeBuilder<Sirket> builder)
        {
            builder.ToTable("sirket");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Adres)
                .HasColumnName("adres")
                .HasColumnType("character varying");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("character varying");

            builder.Property(e => e.Logo).HasColumnName("logo");

            builder.Property(e => e.Sirketadi)
                .IsRequired()
                .HasColumnName("sirketadi")
                .HasColumnType("character varying");

            builder.Property(e => e.Unvan)
                .HasColumnName("unvan")
                .HasColumnType("character varying");
        }
    }
}
