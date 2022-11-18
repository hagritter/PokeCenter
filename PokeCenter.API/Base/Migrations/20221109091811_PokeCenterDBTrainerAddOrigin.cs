using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeCenter.API.Migrations
{
    public partial class PokeCenterDBTrainerAddOrigin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Trainers",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Trainers");
        }
    }
}
