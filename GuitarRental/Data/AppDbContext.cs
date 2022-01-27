using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarRental.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuitarRental.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<GuitarType> GuitarTypes { get; set; }
        public DbSet<GuitarStrings> GuitarStrings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuitarStrings>().HasData(
                    new GuitarStrings
                    {
                        Id = 1,
                        StringsName = "Nylonowe"
                    },
                    new GuitarStrings
                    {
                        Id = 2,
                        StringsName = "Stalowe"
                    }
                );
            modelBuilder.Entity<GuitarType>().HasData(
                    new GuitarType
                    {
                        Id = 1,
                        Name = "Klasyczna"
                    },
                    new GuitarType
                    {
                        Id = 2,
                        Name = "Elektryczna"
                    },
                    new GuitarType
                    {
                        Id = 3,
                        Name = "Akustyczna"
                    }
                );
            modelBuilder.Entity<Guitar>().HasData(
                    new Guitar
                    {
                        GuitarId = 1,
                        Name = "Fender Stratocaster Black",
                        ProductionYear = 2000,
                        GuitarStringsId = 2,
                        GuitarTypeId = 2
                    },
                    new Guitar
                    {
                        GuitarId = 2,
                        Name = "Takamine GD10 NS",
                        ProductionYear = 2016,
                        GuitarStringsId = 2,
                        GuitarTypeId = 3
                    },
                    new Guitar
                    {
                        GuitarId = 3,
                        Name = "Yamaha c30m 4/4",
                        ProductionYear = 2021,
                        GuitarStringsId = 1,
                        GuitarTypeId = 1
                    }
                );
        }
    }
}
