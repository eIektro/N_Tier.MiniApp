using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace N_Tier.MiniApp.Data.Configuration
{
    public class KullaniciConfiguration : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.ToTable("kullanici");

            builder.HasIndex(e => e.Gorev)
                .HasName("fki_kullanicigorev_foreign");

            builder.HasIndex(e => e.Sirket)
                .HasName("fki_kullanicisirket_foreign");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Dogumtarihi)
                .HasColumnName("dogumtarihi")
                .HasColumnType("date");

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("character varying");

            builder.Property(e => e.Gorev).HasColumnName("gorev");

            builder.Property(e => e.Isim)
                .IsRequired()
                .HasColumnName("isim")
                .HasColumnType("character varying");

            builder.Property(e => e.Pasword)
                .HasColumnName("pasword")
                .HasColumnType("character varying");

            builder.Property(e => e.Sirket).HasColumnName("sirket");

            builder.Property(e => e.Soyisim)
                .IsRequired()
                .HasColumnName("soyisim")
                .HasColumnType("character varying");

            builder.HasOne(d => d.GorevNavigation)
                .WithMany(p => p.Kullanici)
                .HasForeignKey(d => d.Gorev)
                .HasConstraintName("kullanicigorev_foreign");

            builder.HasOne(d => d.SirketNavigation)
                .WithMany(p => p.Kullanici)
                .HasForeignKey(d => d.Sirket)
                .HasConstraintName("kullanicisirket_foreign");
        }
    }
}
