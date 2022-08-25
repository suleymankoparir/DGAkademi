using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieDB.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwardsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Birthday = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AwardTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_AwardsType_AwardTypeId",
                        column: x => x.AwardTypeId,
                        principalTable: "AwardsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    Gross = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    MovieTypeId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_MoviesTypes_MovieTypeId",
                        column: x => x.MovieTypeId,
                        principalTable: "MoviesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    TokenEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirectors",
                columns: table => new
                {
                    DirectorId = table.Column<int>(type: "integer", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => new { x.MovieId, x.DirectorId });
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviePerformers",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    PerformerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePerformers", x => new { x.MovieId, x.PerformerId });
                    table.ForeignKey(
                        name: "FK_MoviePerformers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePerformers_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieProducers",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    ProducerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProducers", x => new { x.MovieId, x.ProducerId });
                    table.ForeignKey(
                        name: "FK_MovieProducers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProducers_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesAwards",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    AwardId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DirectorId = table.Column<int>(type: "integer", nullable: true),
                    PerformerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesAwards", x => new { x.MovieId, x.AwardId });
                    table.ForeignKey(
                        name: "FK_MoviesAwards_Awards_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesAwards_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MoviesAwards_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesAwards_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MoviesCategories",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesCategories", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MoviesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesCategories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Populatiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    Since = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Populatiries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Populatiries_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AwardsType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Movie" },
                    { 2, "Male" },
                    { 3, "Female" },
                    { 4, "Director" },
                    { 5, "Tv Series" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Fantasy" },
                    { 5, "Horror" },
                    { 6, "Mistery" },
                    { 7, "Romance" },
                    { 8, "Thriller" },
                    { 9, "Western" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Birthday", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1969, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quentin Tarantino" },
                    { 2, new DateTime(1961, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter Jackson" },
                    { 3, new DateTime(1963, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alejandro González Iñárritu" }
                });

            migrationBuilder.InsertData(
                table: "MoviesTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Movie" },
                    { 2, "Tv Series" }
                });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "Birthday", "Gender", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Leonardo Dicaprio" },
                    { 2, new DateTime(1981, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Elijah Wood" },
                    { 3, new DateTime(1972, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Karl Urban" },
                    { 4, new DateTime(1956, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Christoph Waltz" },
                    { 5, new DateTime(1967, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Jamie Foxx" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Regency Enterprises" },
                    { 2, "Dune Entertainment" },
                    { 3, "Columbia Pictures" },
                    { 4, "The Weinstein Company" },
                    { 5, "New Line Cinema" },
                    { 6, "Wingnut Films" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "AwardTypeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Oscar Best Picture" },
                    { 2, 4, "Oscar Best Director" },
                    { 3, 2, "Oscar Best Actor" },
                    { 4, 3, "Oscar Best Actress" },
                    { 5, 1, "Oscar Best Cinematography" },
                    { 6, 1, "Oscar Best Production Desgin" },
                    { 7, 1, "Oscar Best Adapted Screenplay" },
                    { 8, 1, "Oscar Best Sound" },
                    { 9, 1, "Oscar Best Animated Short Film" },
                    { 10, 1, "Oscar Best Live Action Short Film" },
                    { 11, 1, "Oscar Best Film Editing" },
                    { 12, 1, "Oscar Best Original Score" },
                    { 13, 1, "Oscar Best Original Song" },
                    { 14, 2, "Oscar Best Supporting Actor" },
                    { 15, 3, "Oscar Best Supporting Actress" },
                    { 16, 1, "Oscar Best Visual Effects" },
                    { 17, 1, "Oscar Best Original Screenplay" },
                    { 18, 1, "Oscar Best Documentary Short Film" },
                    { 19, 1, "Oscar Best Documentary Feature Film" },
                    { 20, 1, "Oscar Best International Feature Film" },
                    { 21, 1, "Oscar Best Custome Design" },
                    { 22, 1, "Oscar Best Makeup and Hairstyling" },
                    { 23, 1, "Oscar Best Animated Feature Film" },
                    { 24, 5, "Best Tv Series" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Budget", "Gross", "MovieTypeId", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 94000000m, 1100000000m, 1, "Lord of the Rings: Return of the King", new DateTime(2003, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 100000000m, 425000000m, 1, "Django Unchained", new DateTime(2013, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 135000000m, 533000000m, 1, "The Revenant", new DateTime(2016, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3000000m, 10000000m, 2, "Breaking Bad", new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "RefreshToken", "RoleId", "TokenEndDate", "Username" },
                values: new object[,]
                {
                    { 1, "suleymankoparir@gmail.com", "Süleyman Koparır", "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a", null, 1, null, "suleymankoparir" },
                    { 2, "johndoe@gmail.com", "John Doe", "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a", null, 2, null, "johndoe" }
                });

            migrationBuilder.InsertData(
                table: "MovieDirectors",
                columns: new[] { "DirectorId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "MoviePerformers",
                columns: new[] { "MovieId", "PerformerId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "MovieProducers",
                columns: new[] { "MovieId", "ProducerId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 1, 6 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "MoviesAwards",
                columns: new[] { "AwardId", "MovieId", "Date", "DirectorId", "PerformerId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7866), null, null },
                    { 2, 1, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7871), 2, null },
                    { 7, 1, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7872), null, null },
                    { 13, 1, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7873), null, null },
                    { 16, 1, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7874), null, null },
                    { 22, 1, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7875), null, null },
                    { 1, 2, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7876), null, null },
                    { 17, 2, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7876), null, null },
                    { 1, 3, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7877), null, null },
                    { 3, 3, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7879), null, 1 },
                    { 16, 3, new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7878), null, null }
                });

            migrationBuilder.InsertData(
                table: "MoviesCategories",
                columns: new[] { "CategoryId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 9, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 9, 3 }
                });

            migrationBuilder.InsertData(
                table: "Populatiries",
                columns: new[] { "Id", "MovieId", "Since" },
                values: new object[] { 1, 3, new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(2356) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "Date", "MovieId", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, "Best movie ever", new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3153), 1, 90, 1 },
                    { 2, "Fantastic movie", new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3156), 1, 100, 2 },
                    { 3, "Good movie", new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3157), 2, 70, 1 },
                    { 4, "Bad movie", new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3158), 3, 40, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Awards_AwardTypeId",
                table: "Awards",
                column: "AwardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_DirectorId",
                table: "MovieDirectors",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePerformers_PerformerId",
                table: "MoviePerformers",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProducers_ProducerId",
                table: "MovieProducers",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieTypeId",
                table: "Movies",
                column: "MovieTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesAwards_AwardId",
                table: "MoviesAwards",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesAwards_DirectorId",
                table: "MoviesAwards",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesAwards_PerformerId",
                table: "MoviesAwards",
                column: "PerformerId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesCategories_CategoryId",
                table: "MoviesCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesTypes_Name",
                table: "MoviesTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Populatiries_MovieId",
                table: "Populatiries",
                column: "MovieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MoviePerformers");

            migrationBuilder.DropTable(
                name: "MovieProducers");

            migrationBuilder.DropTable(
                name: "MoviesAwards");

            migrationBuilder.DropTable(
                name: "MoviesCategories");

            migrationBuilder.DropTable(
                name: "Populatiries");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AwardsType");

            migrationBuilder.DropTable(
                name: "MoviesTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
