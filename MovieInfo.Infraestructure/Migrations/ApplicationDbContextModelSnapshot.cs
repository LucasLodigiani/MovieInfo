﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieInfo.Infraestructure.Persistence;

#nullable disable

namespace MovieInfo.Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovieId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenresId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("GenreSerie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SerieId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GenresId", "SerieId");

                    b.HasIndex("SerieId");

                    b.ToTable("GenreSerie");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FavListId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FavListId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.FavList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FavLists");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedia"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Aventura"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Ciencia Ficción"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Terror"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Acción"
                        });
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EpisodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EpisodeId")
                        .IsUnique();

                    b.ToTable("Media");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FavListId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieCoverUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieVideoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShowCaseImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FavListId");

                    b.HasIndex("MovieVideoId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "User"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Employee"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SerieId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExpirationDate = new DateTime(2029, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3505),
                            StartDate = new DateTime(2024, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3502),
                            State = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExpirationDate = new DateTime(2029, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3513),
                            StartDate = new DateTime(2024, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3513),
                            State = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            ExpirationDate = new DateTime(2029, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3515),
                            StartDate = new DateTime(2024, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3515),
                            State = 0,
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            ExpirationDate = new DateTime(2029, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3516),
                            StartDate = new DateTime(2024, 10, 26, 14, 15, 32, 968, DateTimeKind.Utc).AddTicks(3516),
                            State = 1,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.SubscriptionPreference", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionPreferences");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "administrador@gmail.com",
                            Name = "Administrador",
                            Password = "Administrador1",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 2,
                            Email = "empleado@gmail.com",
                            Name = "Empleado",
                            Password = "Empleado1",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "usuario1@gmail.com",
                            Name = "Usuario1",
                            Password = "Usuario1",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "usuario2@gmail.com",
                            Name = "Usuario2",
                            Password = "Usuario2",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieInfo.Domain.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreSerie", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieInfo.Domain.Entities.Serie", null)
                        .WithMany()
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Episode", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.FavList", null)
                        .WithMany("Episodes")
                        .HasForeignKey("FavListId");

                    b.HasOne("MovieInfo.Domain.Entities.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.FavList", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Media", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.Episode", "Episode")
                        .WithOne("Media")
                        .HasForeignKey("MovieInfo.Domain.Entities.Media", "EpisodeId");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Movie", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.FavList", null)
                        .WithMany("Movies")
                        .HasForeignKey("FavListId");

                    b.HasOne("MovieInfo.Domain.Entities.Media", "MovieVideo")
                        .WithMany()
                        .HasForeignKey("MovieVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieVideo");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Season", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.Serie", "Serie")
                        .WithMany("Seasons")
                        .HasForeignKey("SerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.User", "User")
                        .WithOne("Subscription")
                        .HasForeignKey("MovieInfo.Domain.Entities.Subscription", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.User", b =>
                {
                    b.HasOne("MovieInfo.Domain.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Episode", b =>
                {
                    b.Navigation("Media")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.FavList", b =>
                {
                    b.Navigation("Episodes");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Season", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.Serie", b =>
                {
                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("MovieInfo.Domain.Entities.User", b =>
                {
                    b.Navigation("Subscription");
                });
#pragma warning restore 612, 618
        }
    }
}
