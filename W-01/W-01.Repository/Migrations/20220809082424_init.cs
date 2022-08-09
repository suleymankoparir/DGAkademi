using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W_01.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Door = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<int>(type: "int", nullable: false),
                    Wheel = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BaseCars",
                columns: new[] { "Id", "Discriminator", "Door", "Engine", "Wheel" },
                values: new object[,]
                {
                    { 1, "Audi", 5, 1, 4 },
                    { 2, "Bmw", 2, 2, 6 },
                    { 3, "Mercedes", 2, 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "c8ff7f1ad36ae9a23042f006fe88cfd1cd7587d16f0b593eb9b60741ae50899a", "suleymankoparir" },
                    { 2, "d7d378fbcffdcfa759ba2681d51e5e695f0078e56d4a2e2c0e539dc61e1a67e7", "user2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseCars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
