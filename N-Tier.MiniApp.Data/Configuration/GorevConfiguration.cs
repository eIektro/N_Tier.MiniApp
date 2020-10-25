using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N_Tier.MiniApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace N_Tier.MiniApp.Data.Configuration
{
    public class GorevConfiguration : IEntityTypeConfiguration<Gorev>
    {
        public void Configure(EntityTypeBuilder<Gorev> builder)
        {
            builder.ToTable("gorev");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Gorevadi)
                .IsRequired()
                .HasColumnName("gorevadi")
                .HasColumnType("character varying");

            builder.Property(e => e.Gorevtanimi)
                .HasColumnName("gorevtanimi")
                .HasColumnType("character varying");
        }
    }
}
