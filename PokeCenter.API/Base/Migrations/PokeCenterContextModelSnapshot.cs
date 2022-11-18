﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokeCenter.API.Base.DbContexts;

#nullable disable

namespace PokeCenter.API.Migrations
{
    [DbContext(typeof(PokeCenterContext))]
    partial class PokeCenterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("PokeCenter.API.Base.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ash and his Friends",
                            Name = "AshCo"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The bad guys",
                            Name = "Rocket"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fresche Buschjaeger",
                            Name = "FBJ"
                        });
                });

            modelBuilder.Entity("PokeCenter.API.Base.Entities.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Origin")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Trainers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The hero of the story",
                            Name = "Ash",
                            Origin = "Alabasta",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Arenaleiterin von Azuria City",
                            Name = "Misty",
                            Origin = "Azuria City",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "The one with the pink hair",
                            Name = "Jessie",
                            Origin = "Kanto",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "The one with the purple hair",
                            Name = "James",
                            Origin = "Kanto",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "A relentless fighter",
                            Name = "Hagen",
                            Origin = "Sayn",
                            TeamId = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "A brilliant personality",
                            Name = "Cassi",
                            Origin = "Freiburg",
                            TeamId = 3
                        });
                });

            modelBuilder.Entity("PokeCenter.API.Base.Entities.Trainer", b =>
                {
                    b.HasOne("PokeCenter.API.Base.Entities.Team", "Team")
                        .WithMany("Trainers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("PokeCenter.API.Base.Entities.Team", b =>
                {
                    b.Navigation("Trainers");
                });
#pragma warning restore 612, 618
        }
    }
}
