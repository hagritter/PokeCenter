using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeCenter.API.Base.Entities;

namespace PokeCenter.API.Base.DbContexts
{
    public class PokeCenterContext : DbContext
    {
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Trainer> Trainers { get; set; } = null!;
        
        public PokeCenterContext(DbContextOptions<PokeCenterContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team("AshCo")
                {
                    Id = 1,
                    Description = "Ash and his Friends"
                },
                new Team("Rocket")
                {
                    Id = 2,
                    Description = "The bad guys"
                },
                new Team("FBJ")
                {
                    Id = 3,
                    Description = "Fresche Buschjaeger"
                });


            modelBuilder.Entity<Trainer>().HasData(
                new Trainer("Ash")
                {
                    Id = 1,
                    Description = "The hero of the story",
                    TeamId = 1,
                    Origin = "Alabasta",
                },
                new Trainer("Misty")
                {
                    Id = 2,
                    Description = "Arenaleiterin von Azuria City",
                    TeamId = 1,
                    Origin = "Azuria City",
                },
                new Trainer("Jessie")
                {
                    Id = 3,
                    Description = "The one with the pink hair",
                    TeamId = 2,
                    Origin = "Kanto",
                },
                new Trainer("James")
                {
                    Id = 4,
                    Description = "The one with the purple hair",
                    TeamId = 2,
                    Origin = "Kanto",
                },
                new Trainer("Hagen")
                {
                    Id = 5,
                    Description = "A relentless fighter",
                    TeamId = 3,
                    Origin = "Sayn",
                },
                new Trainer("Cassi")
                {
                    Id = 6,
                    Description = "A brilliant personality",
                    TeamId = 3,
                    Origin = "Freiburg",
                }
                );          
            base.OnModelCreating(modelBuilder);
        }





    }
}