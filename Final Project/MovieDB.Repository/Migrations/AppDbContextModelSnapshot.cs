﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieDB.Repository;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieDB.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MovieDB.Core.Models.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Awards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Oscar Best Picture",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Oscar Best Director",
                            Type = "Director"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Oscar Best Actor",
                            Type = "Male"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Oscar Best Actress",
                            Type = "Female"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Oscar Best Cinematography",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Oscar Best Production Desgin",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Oscar Best Adapted Screenplay",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Oscar Best Sound",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Oscar Best Animated Short Film",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Oscar Best Live Action Short Film",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Oscar Best Film Editing",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Oscar Best Original Score",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Oscar Best Original Song",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Oscar Best Supporting Actor",
                            Type = "Male"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Oscar Best Supporting Actress",
                            Type = "Female"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Oscar Best Visual Effects",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Oscar Best Original Screenplay",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Oscar Best Documentary Short Film",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Oscar Best Documentary Feature Film",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Oscar Best International Feature Film",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Oscar Best Custome Design",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Oscar Best Makeup and Hairstyling",
                            Type = "Movie"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Oscar Best Animated Feature Film",
                            Type = "Movie"
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Mistery"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Western"
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1969, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Quentin Tarantino"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1961, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Peter Jackson"
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1963, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Alejandro González Iñárritu"
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Budget")
                        .HasPrecision(18, 3)
                        .HasColumnType("numeric(18,3)");

                    b.Property<decimal>("Gross")
                        .HasPrecision(18, 3)
                        .HasColumnType("numeric(18,3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Budget = 94000000m,
                            Gross = 1100000000m,
                            Name = "Lord of the Rings: Return of the King",
                            ReleaseDate = new DateTime(2003, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Budget = 100000000m,
                            Gross = 425000000m,
                            Name = "Django Unchained",
                            ReleaseDate = new DateTime(2013, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Budget = 135000000m,
                            Gross = 533000000m,
                            Name = "The Revenant",
                            ReleaseDate = new DateTime(2016, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieAward", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("AwardId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("integer");

                    b.Property<int?>("PerformerId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "AwardId");

                    b.HasIndex("AwardId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("PerformerId");

                    b.ToTable("MoviesAwards");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            AwardId = 1,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(106)
                        },
                        new
                        {
                            MovieId = 1,
                            AwardId = 2,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(109),
                            DirectorId = 2
                        },
                        new
                        {
                            MovieId = 1,
                            AwardId = 7,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(110)
                        },
                        new
                        {
                            MovieId = 1,
                            AwardId = 13,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(111)
                        },
                        new
                        {
                            MovieId = 1,
                            AwardId = 16,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(112)
                        },
                        new
                        {
                            MovieId = 1,
                            AwardId = 22,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(112)
                        },
                        new
                        {
                            MovieId = 2,
                            AwardId = 1,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(113)
                        },
                        new
                        {
                            MovieId = 2,
                            AwardId = 17,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(114)
                        },
                        new
                        {
                            MovieId = 3,
                            AwardId = 1,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(114)
                        },
                        new
                        {
                            MovieId = 3,
                            AwardId = 16,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(115)
                        },
                        new
                        {
                            MovieId = 3,
                            AwardId = 3,
                            Date = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(116),
                            PerformerId = 1
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieCategory", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MoviesCategories");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            CategoryId = 4
                        },
                        new
                        {
                            MovieId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            CategoryId = 9
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 1
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 9
                        },
                        new
                        {
                            MovieId = 3,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieDirector", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("DirectorId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("MovieDirectors");

                    b.HasData(
                        new
                        {
                            MovieId = 2,
                            DirectorId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            DirectorId = 2
                        },
                        new
                        {
                            MovieId = 3,
                            DirectorId = 3
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.MoviePerformer", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("PerformerId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "PerformerId");

                    b.HasIndex("PerformerId");

                    b.ToTable("MoviePerformers");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            PerformerId = 2
                        },
                        new
                        {
                            MovieId = 1,
                            PerformerId = 3
                        },
                        new
                        {
                            MovieId = 2,
                            PerformerId = 4
                        },
                        new
                        {
                            MovieId = 2,
                            PerformerId = 5
                        },
                        new
                        {
                            MovieId = 3,
                            PerformerId = 1
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieProducer", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("ProducerId")
                        .HasColumnType("integer");

                    b.HasKey("MovieId", "ProducerId");

                    b.HasIndex("ProducerId");

                    b.ToTable("MovieProducers");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            ProducerId = 5
                        },
                        new
                        {
                            MovieId = 1,
                            ProducerId = 6
                        },
                        new
                        {
                            MovieId = 2,
                            ProducerId = 3
                        },
                        new
                        {
                            MovieId = 2,
                            ProducerId = 4
                        },
                        new
                        {
                            MovieId = 3,
                            ProducerId = 1
                        },
                        new
                        {
                            MovieId = 3,
                            ProducerId = 2
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.Performer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Performers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Leonardo Dicaprio"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1981, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Elijah Wood"
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1972, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Karl Urban"
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(1956, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Christoph Waltz"
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(1967, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Gender = "Male",
                            Name = "Jamie Foxx"
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.Popularity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Since")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("Populatiries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovieId = 3,
                            Since = new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(1014)
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.ToTable("Producers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Regency Enterprises"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dune Entertainment"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Columbia Pictures"
                        },
                        new
                        {
                            Id = 4,
                            Name = "The Weinstein Company"
                        },
                        new
                        {
                            Id = 5,
                            Name = "New Line Cinema"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Wingnut Films"
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "Best movie ever",
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 1,
                            Score = 90,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Comment = "Fantastic movie",
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 1,
                            Score = 100,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Comment = "Good movie",
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 2,
                            Score = 70,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            Comment = "Bad movie",
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 3,
                            Score = 40,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "suleymankoparir@gmail.com",
                            Name = "Süleyman Koparır",
                            Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a"
                        },
                        new
                        {
                            Id = 2,
                            Email = "johndoe@gmail.com",
                            Name = "John Doe",
                            Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a"
                        });
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieAward", b =>
                {
                    b.HasOne("MovieDB.Core.Models.Award", "Award")
                        .WithMany("MovieAward")
                        .HasForeignKey("AwardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDB.Core.Models.Director", "Director")
                        .WithMany("MovieAward")
                        .HasForeignKey("DirectorId");

                    b.HasOne("MovieDB.Core.Models.Movie", "Movie")
                        .WithMany("MovieAward")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDB.Core.Models.Performer", "Performer")
                        .WithMany("MovieAward")
                        .HasForeignKey("PerformerId");

                    b.Navigation("Award");

                    b.Navigation("Director");

                    b.Navigation("Movie");

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieCategory", b =>
                {
                    b.HasOne("MovieDB.Core.Models.Category", "Category")
                        .WithMany("MovieCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDB.Core.Models.Movie", "Movie")
                        .WithMany("MovieCategory")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieDirector", b =>
                {
                    b.HasOne("MovieDB.Core.Models.Director", "Director")
                        .WithMany("MovieDirector")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDB.Core.Models.Movie", "Movie")
                        .WithMany("MovieDirector")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieDB.Core.Models.MoviePerformer", b =>
                {
                    b.HasOne("MovieDB.Core.Models.Movie", "Movie")
                        .WithMany("MoviePerformer")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDB.Core.Models.Performer", "Performer")
                        .WithMany("MoviePerformer")
                        .HasForeignKey("PerformerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Performer");
                });

            modelBuilder.Entity("MovieDB.Core.Models.MovieProducer", b =>
                {
                    b.HasOne("MovieDB.Core.Models.Movie", "Movie")
                        .WithMany("MovieProducer")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDB.Core.Models.Producer", "Producer")
                        .WithMany("MovieProducer")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Popularity", b =>
                {
                    b.HasOne("MovieDB.Core.Models.Movie", "Movie")
                        .WithOne("Populatiry")
                        .HasForeignKey("MovieDB.Core.Models.Popularity", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Review", b =>
                {
                    b.HasOne("MovieDB.Core.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieDB.Core.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Award", b =>
                {
                    b.Navigation("MovieAward");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Category", b =>
                {
                    b.Navigation("MovieCategory");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Director", b =>
                {
                    b.Navigation("MovieAward");

                    b.Navigation("MovieDirector");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Movie", b =>
                {
                    b.Navigation("MovieAward");

                    b.Navigation("MovieCategory");

                    b.Navigation("MovieDirector");

                    b.Navigation("MoviePerformer");

                    b.Navigation("MovieProducer");

                    b.Navigation("Populatiry");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Performer", b =>
                {
                    b.Navigation("MovieAward");

                    b.Navigation("MoviePerformer");
                });

            modelBuilder.Entity("MovieDB.Core.Models.Producer", b =>
                {
                    b.Navigation("MovieProducer");
                });

            modelBuilder.Entity("MovieDB.Core.Models.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
