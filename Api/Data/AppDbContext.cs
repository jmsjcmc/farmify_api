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
        public DbSet<Models.Address.Region> Regions { get; set; }
        public DbSet<Models.Address.Province> Provinces {  get; set; }
        public DbSet<Models.Address.CityMunicipality> CityMunicipalities { get; set; }
        public DbSet<Models.Address.Barangay> Barangays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
