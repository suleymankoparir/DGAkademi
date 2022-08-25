using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDB.Repository.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTypeId",
                table: "AwardsType",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2,
                column: "AwardTypeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3,
                column: "AwardTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4,
                column: "AwardTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 14,
                column: "AwardTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 15,
                column: "AwardTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 24,
                column: "AwardTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 1,
                column: "MovieTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MovieTypeId", "Name" },
                values: new object[] { 2, "Tv Series" });

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MovieTypeId", "Name" },
                values: new object[] { 1, "Male" });

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "MovieTypeId", "Name" },
                values: new object[] { 1, "Female" });

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "MovieTypeId", "Name" },
                values: new object[] { 1, "Director" });

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 1, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7241));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 2, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 7, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 13, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 16, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7246));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 22, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7247));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 1, 2 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 17, 2 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 1, 3 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 3, 3 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 16, 3 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Populatiries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Since",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(8189));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 8, 25, 15, 14, 16, 916, DateTimeKind.Utc).AddTicks(8437));

            migrationBuilder.CreateIndex(
                name: "IX_AwardsType_MovieTypeId",
                table: "AwardsType",
                column: "MovieTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardsType_MoviesTypes_MovieTypeId",
                table: "AwardsType",
                column: "MovieTypeId",
                principalTable: "MoviesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardsType_MoviesTypes_MovieTypeId",
                table: "AwardsType");

            migrationBuilder.DropIndex(
                name: "IX_AwardsType_MovieTypeId",
                table: "AwardsType");

            migrationBuilder.DropColumn(
                name: "MovieTypeId",
                table: "AwardsType");

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2,
                column: "AwardTypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3,
                column: "AwardTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4,
                column: "AwardTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 14,
                column: "AwardTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 15,
                column: "AwardTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 24,
                column: "AwardTypeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Director");

            migrationBuilder.UpdateData(
                table: "AwardsType",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Tv Series");

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 1, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 2, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 7, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 13, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7873));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 16, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 22, 1 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 1, 2 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 17, 2 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 1, 3 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 3, 3 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7879));

            migrationBuilder.UpdateData(
                table: "MoviesAwards",
                keyColumns: new[] { "AwardId", "MovieId" },
                keyValues: new object[] { 16, 3 },
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 988, DateTimeKind.Utc).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Populatiries",
                keyColumn: "Id",
                keyValue: 1,
                column: "Since",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(2356));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 8, 25, 14, 16, 52, 989, DateTimeKind.Utc).AddTicks(3158));
        }
    }
}
