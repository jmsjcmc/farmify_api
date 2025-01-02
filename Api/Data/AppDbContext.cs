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

            modelBuilder.Entity<Models.Address.Province>().HasData(
                new Models.Address.Province { Id = 1, Name = "Ilocos Norte", Regionid = 1 },
                new Models.Address.Province { Id = 2, Name = "Ilocos Sur", Regionid = 1 },
                new Models.Address.Province { Id = 3, Name = "La Union", Regionid = 1 },
                new Models.Address.Province { Id = 4, Name = "Pangasinan", Regionid = 1 },

                new Models.Address.Province { Id = 5, Name = "Batanes", Regionid = 2 },
                new Models.Address.Province { Id = 6, Name = "Cagayan", Regionid = 2 },
                new Models.Address.Province { Id = 7, Name = "Isabela", Regionid = 2 },
                new Models.Address.Province { Id = 8, Name = "Nueva Vizcaya", Regionid = 2 },
                new Models.Address.Province { Id = 9, Name = "Quirino", Regionid = 2 },

                new Models.Address.Province { Id = 10, Name = "Angeles", Regionid = 3 },
                new Models.Address.Province { Id = 11, Name = "Aurora", Regionid = 3 },
                new Models.Address.Province { Id = 12, Name = "Bataan", Regionid = 3 },
                new Models.Address.Province { Id = 13, Name = "Bulacan", Regionid = 3 },
                new Models.Address.Province { Id = 14, Name = "Nueva Ecija", Regionid = 3 },
                new Models.Address.Province { Id = 15, Name = "Olongapo", Regionid = 3 },
                new Models.Address.Province { Id = 16, Name = "Pampanga", Regionid = 3 },
                new Models.Address.Province { Id = 17, Name = "Tarlac", Regionid = 3 },
                new Models.Address.Province { Id = 18, Name = "Zambales", Regionid = 3 },

                new Models.Address.Province { Id = 19, Name = "Batangas", Regionid = 4 },
                new Models.Address.Province { Id = 20, Name = "Cavite", Regionid = 4 },
                new Models.Address.Province { Id = 21, Name = "Lucena", Regionid = 4 },
                new Models.Address.Province { Id = 22, Name = "Laguna", Regionid = 4 },
                new Models.Address.Province { Id = 23, Name = "Quezon", Regionid = 4 },
                new Models.Address.Province { Id = 24, Name = "Rizal", Regionid = 4 },

                new Models.Address.Province { Id = 25, Name = "Albay", Regionid = 5 },
                new Models.Address.Province { Id = 26, Name = "Camarines Norte", Regionid = 5 },
                new Models.Address.Province { Id = 27, Name = "Camarines Sur", Regionid = 5 },
                new Models.Address.Province { Id = 28, Name = "Catanduanes", Regionid = 5 },
                new Models.Address.Province { Id = 29, Name = "Masbate", Regionid = 5 },
                new Models.Address.Province { Id = 30, Name = "Sorsogon", Regionid = 5 },

                new Models.Address.Province { Id = 31, Name = "Aklan", Regionid = 6 },
                new Models.Address.Province { Id = 32, Name = "Antique", Regionid = 6 },
                new Models.Address.Province { Id = 33, Name = "Bacolod", Regionid = 6 },
                new Models.Address.Province { Id = 34, Name = "Capiz", Regionid = 6 },
                new Models.Address.Province { Id = 35, Name = "Guimaras", Regionid = 6 },
                new Models.Address.Province { Id = 36, Name = "Iloilo", Regionid = 6 },
                new Models.Address.Province { Id = 37, Name = "Iloilo City", Regionid = 6 },
                new Models.Address.Province { Id = 38, Name = "Negros Occidental", Regionid = 6 },

                new Models.Address.Province { Id = 39, Name = "Bohol", Regionid = 7 },
                new Models.Address.Province { Id = 40, Name = "Cebu", Regionid = 7 },
                new Models.Address.Province { Id = 41, Name = "Cebu City", Regionid = 7 },
                new Models.Address.Province { Id = 42, Name = "Lapu-Lapu", Regionid = 7 },
                new Models.Address.Province { Id = 43, Name = "Mandaue", Regionid = 7 },
                new Models.Address.Province { Id = 44, Name = "Negros Oriental", Regionid = 7 },
                new Models.Address.Province { Id = 45, Name = "Siquijor", Regionid = 7 },

                new Models.Address.Province { Id = 46, Name = "Biliran", Regionid = 8 },
                new Models.Address.Province { Id = 47, Name = "Eastern Samar", Regionid = 8 },
                new Models.Address.Province { Id = 48, Name = "Leyte", Regionid = 8 },
                new Models.Address.Province { Id = 49, Name = "Northern Samar", Regionid = 8 },
                new Models.Address.Province { Id = 50, Name = "Samar", Regionid = 8 },
                new Models.Address.Province { Id = 51, Name = "Southern Leyte", Regionid = 8 },
                new Models.Address.Province { Id = 52, Name = "Tacloban", Regionid = 8 },

                new Models.Address.Province { Id = 53, Name = "Isabela City", Regionid = 9 },
                new Models.Address.Province { Id = 54, Name = "Zamboanga City", Regionid = 9 },
                new Models.Address.Province { Id = 55, Name = "Zamboanga del Norte", Regionid = 9 },
                new Models.Address.Province { Id = 56, Name = "Zamboanga del Sur", Regionid = 9 },
                new Models.Address.Province { Id = 57, Name = "Zamboanga Sibugay", Regionid = 9 },

                new Models.Address.Province { Id = 58, Name = "Bukidnon", Regionid = 10 },
                new Models.Address.Province { Id = 59, Name = "Cagayan de Oro", Regionid = 10 },
                new Models.Address.Province { Id = 60, Name = "Camiguin", Regionid = 10 },
                new Models.Address.Province { Id = 61, Name = "Iligan", Regionid = 10 },
                new Models.Address.Province { Id = 62, Name = "Lanao del Norte", Regionid = 10 },
                new Models.Address.Province { Id = 63, Name = "Misamis Occidental", Regionid = 10 },
                new Models.Address.Province { Id = 64, Name = "Misamis Oriental", Regionid = 10 },

                new Models.Address.Province { Id = 65, Name = "Davao de Oro", Regionid = 11 },
                new Models.Address.Province { Id = 66, Name = "Davao City", Regionid = 11 },
                new Models.Address.Province { Id = 67, Name = "Davao del Norte", Regionid = 11 },
                new Models.Address.Province { Id = 68, Name = "Davao del Sur", Regionid = 11 },
                new Models.Address.Province { Id = 69, Name = "Davao Occidental", Regionid = 11 },
                new Models.Address.Province { Id = 70, Name = "Davao Oriental", Regionid = 11 },

                new Models.Address.Province { Id = 71, Name = "Cotabato", Regionid = 12 },
                new Models.Address.Province { Id = 72, Name = "Cotabato City", Regionid = 12 },
                new Models.Address.Province { Id = 73, Name = "General Santos", Regionid = 12 },
                new Models.Address.Province { Id = 74, Name = "Sarangani", Regionid = 12 },
                new Models.Address.Province { Id = 75, Name = "South Cotabato", Regionid = 12 },
                new Models.Address.Province { Id = 76, Name = "Sultan Kudarat", Regionid = 12 },

                new Models.Address.Province { Id = 77, Name = "Agusan del Norte", Regionid = 13 },
                new Models.Address.Province { Id = 78, Name = "Agusan del Sur", Regionid = 13 },
                new Models.Address.Province { Id = 79, Name = "Butuan", Regionid = 13 },
                new Models.Address.Province { Id = 80, Name = "Dinagat Islands", Regionid = 13 },
                new Models.Address.Province { Id = 81, Name = "Surigao del Norte", Regionid = 13 },
                new Models.Address.Province { Id = 82, Name = "Surigao del Sur", Regionid = 13 },

                new Models.Address.Province { Id = 83, Name = "Caloocan", Regionid = 14 },
                new Models.Address.Province { Id = 84, Name = "Las Piñas", Regionid = 14 },
                new Models.Address.Province { Id = 85, Name = "Makati", Regionid = 14 },
                new Models.Address.Province { Id = 86, Name = "Malabon", Regionid = 14 },
                new Models.Address.Province { Id = 87, Name = "Mandaluyong", Regionid = 14 },
                new Models.Address.Province { Id = 88, Name = "Manila", Regionid = 14 },
                new Models.Address.Province { Id = 89, Name = "Marikina", Regionid = 14 },
                new Models.Address.Province { Id = 90, Name = "Muntinlupa", Regionid = 14 },
                new Models.Address.Province { Id = 91, Name = "Navotas", Regionid = 14 },
                new Models.Address.Province { Id = 92, Name = "Parañaque", Regionid = 14 },
                new Models.Address.Province { Id = 93, Name = "Pasay", Regionid = 14 },
                new Models.Address.Province { Id = 94, Name = "Pasig", Regionid = 14 },
                new Models.Address.Province { Id = 95, Name = "Pateros", Regionid = 14 },
                new Models.Address.Province { Id = 96, Name = "Quezon City", Regionid = 14 },
                new Models.Address.Province { Id = 97, Name = "San Juan", Regionid = 14 },
                new Models.Address.Province { Id = 98, Name = "Taguig", Regionid = 14 },
                new Models.Address.Province { Id = 99, Name = "Valenzuela", Regionid = 14 },

                new Models.Address.Province { Id = 100, Name = "Abra", Regionid = 15 },
                new Models.Address.Province { Id = 101, Name = "Apayao", Regionid = 15 },
                new Models.Address.Province { Id = 102, Name = "Baguio", Regionid = 15 },
                new Models.Address.Province { Id = 103, Name = "Benguet", Regionid = 15 },
                new Models.Address.Province { Id = 104, Name = "Ifugao", Regionid = 15 },
                new Models.Address.Province { Id = 105, Name = "Kalinga", Regionid = 15 },
                new Models.Address.Province { Id = 106, Name = "Mountain Province", Regionid = 15 },

                new Models.Address.Province { Id = 107, Name = "Basilan", Regionid = 16 },
                new Models.Address.Province { Id = 108, Name = "Lanao del Sur", Regionid = 16 },
                new Models.Address.Province { Id = 109, Name = "Maguindanao", Regionid = 16 },
                new Models.Address.Province { Id = 110, Name = "Sulu", Regionid = 16 },
                new Models.Address.Province { Id = 111, Name = "Tawi-Tawi", Regionid = 16 },

                new Models.Address.Province { Id = 112, Name = "Marinduque", Regionid = 17 },
                new Models.Address.Province { Id = 113, Name = "Occidental Mindoro", Regionid = 17 },
                new Models.Address.Province { Id = 114, Name = "Oriental Mindoro", Regionid = 17 },
                new Models.Address.Province { Id = 115, Name = "Palawan", Regionid = 17 },
                new Models.Address.Province { Id = 116, Name = "Puerto Princesa", Regionid = 17 },
                new Models.Address.Province { Id = 117, Name = "Romblon", Regionid = 17 }
            );
        }

    }
}
