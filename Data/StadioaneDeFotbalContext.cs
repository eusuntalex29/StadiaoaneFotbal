using Microsoft.EntityFrameworkCore;
using StadioaneDeFotbal.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StadioaneDeFotbal.Models;

namespace StadioaneDeFotbal.Data
{
    public class StadioaneDeFotbalContext : DbContext
    {
        public StadioaneDeFotbalContext(DbContextOptions<StadioaneDeFotbalContext> options)
            : base(options)
        {
        }

        public DbSet<Stadion> Stadioane { get; set; }
        public DbSet<Echipa> Echipe { get; set; }
        public DbSet<Meci> Meciuri { get; set; }
        public DbSet<Spectator> Spectatori { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meci>()
                .HasOne(m => m.EchipaGazda)
                .WithMany(e => e.MeciuriAcasa)
                .HasForeignKey(m => m.EchipaGazdaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meci>()
                .HasOne(m => m.EchipaOaspeti)
                .WithMany(e => e.MeciuriDeplasare)
                .HasForeignKey(m => m.EchipaOaspetiId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

