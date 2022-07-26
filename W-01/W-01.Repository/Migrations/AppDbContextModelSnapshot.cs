﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using W_01.Repository;

#nullable disable

namespace W_01.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("W_01.Core.Models.BaseCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Door")
                        .HasColumnType("int");

                    b.Property<int>("Engine")
                        .HasColumnType("int");

                    b.Property<int>("Wheel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BaseCars");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseCar");
                });

            modelBuilder.Entity("W_01.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a",
                            UserName = "suleymankoparir"
                        },
                        new
                        {
                            Id = 2,
                            Password = "d7d378fbcffdcfa759ba2681d51e5e695f0078e56d4a2e2c0e539dc61e1a67e7",
                            UserName = "user2"
                        });
                });

            modelBuilder.Entity("W_01.Core.Models.Audi", b =>
                {
                    b.HasBaseType("W_01.Core.Models.BaseCar");

                    b.HasDiscriminator().HasValue("Audi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Door = 5,
                            Engine = 1,
                            Wheel = 4
                        });
                });

            modelBuilder.Entity("W_01.Core.Models.Bmw", b =>
                {
                    b.HasBaseType("W_01.Core.Models.BaseCar");

                    b.HasDiscriminator().HasValue("Bmw");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Door = 2,
                            Engine = 2,
                            Wheel = 6
                        });
                });

            modelBuilder.Entity("W_01.Core.Models.Mercedes", b =>
                {
                    b.HasBaseType("W_01.Core.Models.BaseCar");

                    b.HasDiscriminator().HasValue("Mercedes");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Door = 2,
                            Engine = 2,
                            Wheel = 8
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
