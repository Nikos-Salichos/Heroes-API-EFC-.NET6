﻿using HeroesAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HeroesAPI.DataContext
{
    public class MainDbContext : IdentityDbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Hero>().HasData(
                 new Hero { Id = 9, Name = "Thor", FirstName = "Thor", LastName = "Odinson", Place = "Asgard" }
                 );
        }

        //EF Commands
        // cd C:\Users\Nikos\source\repos\HeroesAPI\HeroesAPI
        // dotnet ef migrations add HeroSeeding --context MainDbContextInfo
        // dotnet ef database update --context MainDbContextInfo

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<SeriLogModel> SeriLogs { get; set; }
    }
}
