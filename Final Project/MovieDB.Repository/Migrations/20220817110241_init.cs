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
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
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
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Budget = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    Gross = table.Column<decimal>(type: "numeric(18,3)", precision: 18, scale: 3, nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                table: "Awards",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Oscar Best Picture", "Movie" },
                    { 2, "Oscar Best Director", "Director" },
                    { 3, "Oscar Best Actor", "Male" },
                    { 4, "Oscar Best Actress", "Female" },
                    { 5, "Oscar Best Cinematography", "Movie" },
                    { 6, "Oscar Best Production Desgin", "Movie" },
                    { 7, "Oscar Best Adapted Screenplay", "Movie" },
                    { 8, "Oscar Best Sound", "Movie" },
                    { 9, "Oscar Best Animated Short Film", "Movie" },
                    { 10, "Oscar Best Live Action Short Film", "Movie" },
                    { 11, "Oscar Best Film Editing", "Movie" },
                    { 12, "Oscar Best Original Score", "Movie" },
                    { 13, "Oscar Best Original Song", "Movie" },
                    { 14, "Oscar Best Supporting Actor", "Male" },
                    { 15, "Oscar Best Supporting Actress", "Female" },
                    { 16, "Oscar Best Visual Effects", "Movie" },
                    { 17, "Oscar Best Original Screenplay", "Movie" },
                    { 18, "Oscar Best Documentary Short Film", "Movie" },
                    { 19, "Oscar Best Documentary Feature Film", "Movie" },
                    { 20, "Oscar Best International Feature Film", "Movie" },
                    { 21, "Oscar Best Custome Design", "Movie" },
                    { 22, "Oscar Best Makeup and Hairstyling", "Movie" },
                    { 23, "Oscar Best Animated Feature Film", "Movie" }
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
                table: "Movies",
                columns: new[] { "Id", "Budget", "Gross", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 94000000m, 1100000000m, "Lord of the Rings: Return of the King", new DateTime(2003, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 100000000m, 425000000m, "Django Unchained", new DateTime(2013, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 135000000m, 533000000m, "The Revenant", new DateTime(2016, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "suleymankoparir@gmail.com", "Süleyman Koparır", "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a", null },
                    { 2, "johndoe@gmail.com", "John Doe", "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a", null }
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
                    { 1, 1, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(106), null, null },
                    { 2, 1, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(109), 2, null },
                    { 7, 1, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(110), null, null },
                    { 13, 1, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(111), null, null },
                    { 16, 1, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(112), null, null },
                    { 22, 1, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(112), null, null },
                    { 1, 2, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(113), null, null },
                    { 17, 2, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(114), null, null },
                    { 1, 3, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(114), null, null },
                    { 3, 3, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(116), null, 1 },
                    { 16, 3, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(115), null, null }
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
                values: new object[] { 1, 3, new DateTime(2022, 8, 17, 11, 2, 40, 764, DateTimeKind.Utc).AddTicks(1014) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "Date", "MovieId", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, "Best movie ever", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 90, 1 },
                    { 2, "Fantastic movie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 100, 2 },
                    { 3, "Good movie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 70, 1 },
                    { 4, "Bad movie", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 40, 2 }
                });

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
        }
    }
}
