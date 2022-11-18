using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeCenter.API.Migrations
{
    public partial class PokeCenterDBSeedMoreCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Origin", "TeamId" },
                values: new object[] { "Arenaleiterin von Azuria City", "Misty", "Azuria City", 1 });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Origin", "TeamId" },
                values: new object[] { "The one with the pink hair", "Jessie", "Kanto", 2 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Name", "Origin", "TeamId" },
                values: new object[] { 4, "The one with the purple hair", "James", "Kanto", 2 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Name", "Origin", "TeamId" },
                values: new object[] { 5, "A relentless fighter", "Hagen", "Sayn", 3 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Name", "Origin", "TeamId" },
                values: new object[] { 6, "A brilliant personality", "Cassi", "Freiburg", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Origin", "TeamId" },
                values: new object[] { "The one with the pink hair", "Jessie", "Kanto", 2 });

            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Origin", "TeamId" },
                values: new object[] { "A relentless fighter", "Hagen", "Sayn", 3 });
        }
    }
}
