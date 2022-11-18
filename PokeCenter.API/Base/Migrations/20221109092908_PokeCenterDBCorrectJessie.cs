using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeCenter.API.Migrations
{
    public partial class PokeCenterDBCorrectJessie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jessie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jessy");
        }
    }
}
