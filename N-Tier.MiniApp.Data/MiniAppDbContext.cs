using Microsoft.EntityFrameworkCore;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace N_Tier.MiniApp.Data
{
    public class MiniAppDbContext : DbContext
    {
        public virtual DbSet<Gorev> Gorev { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Sirket> Sirket { get; set; }

        public MiniAppDbContext(DbContextOptions<MiniAppDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GorevConfiguration());
            builder.ApplyConfiguration(new KullaniciConfiguration());
            builder.ApplyConfiguration(new SirketConfiguration());
        }
    }
}
