using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Models.Address;

namespace Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Models.Address.Region> Regions { get; set; }
        public DbSet<Models.Address.Province> Provinces {  get; set; }
        public DbSet<Models.Address.CityMunicipality> CityMunicipalities { get; set; }
        public DbSet<Models.Address.Barangay> Barangays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Address.Province>()
                .HasOne(p => p.Region)
                .WithMany(r => r.Provinces)
                .HasForeignKey(p => p.Regionid);

            modelBuilder.Entity<Models.Address.CityMunicipality>()
                .HasOne(c => c.Province)
                .WithMany(p => p.CityMunicipalities)
                .HasForeignKey(c => c.Provinceid);

            modelBuilder.Entity<Models.Address.Barangay>()
                .HasOne(b => b.CityMunicipality)
                .WithMany(c => c.Barangays)
                .HasForeignKey(b => b.Citymunicipalityid);
        }

    }
}
