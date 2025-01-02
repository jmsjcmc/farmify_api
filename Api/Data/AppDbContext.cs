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
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Models.Address.Region> Regions { get; set; }
        public DbSet<Models.Address.Province> Provinces { get; set; }
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

            modelBuilder.Entity<Models.Address.Region>().HasData(
               new Models.Address.Region { Id = 1, Name = "Region I - Ilocos Region" },
               new Models.Address.Region { Id = 2, Name = "Region II - Cagayan Valley" },
               new Models.Address.Region { Id = 3, Name = "Region III - Central Luzon" },
               new Models.Address.Region { Id = 4, Name = "Region IV-A - CALABARZON" },
               new Models.Address.Region { Id = 5, Name = "Region V - Bicol Region" },
               new Models.Address.Region { Id = 6, Name = "Region VI - Western Visayas" },
               new Models.Address.Region { Id = 7, Name = "Region VII - Central Visayas" },
               new Models.Address.Region { Id = 8, Name = "Region VIII - Eastern Visayas" },
               new Models.Address.Region { Id = 9, Name = "Region IX - Zamboanga Peninsula" },
               new Models.Address.Region { Id = 10, Name = "Region X - Northern Mindanao" },
               new Models.Address.Region { Id = 11, Name = "Region XI - Davao Region" },
               new Models.Address.Region { Id = 12, Name = "Region XII - SOCCSKSARGEN" },
               new Models.Address.Region { Id = 13, Name = "Region XIII - Caraga" },
               new Models.Address.Region { Id = 14, Name = "NCR - National Capital Region" },
               new Models.Address.Region { Id = 15, Name = "CAR - Cordillera Administrative Region" },
               new Models.Address.Region { Id = 16, Name = "BARMM - Bangsamoro Autonomous Region in Muslim Mindanao" },
               new Models.Address.Region { Id = 17, Name = "MIMAROPA Region" });
        }

    }
}
