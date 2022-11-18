using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeCenter.API.Migrations
{
    public partial class PokeCenterDBseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Trainers");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trainers",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Ash and his Friends", "AshCo" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "The bad guys", "Rocket" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Fresche Buschjaeger", "FBJ" });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Name", "TeamId" },
                values: new object[] { 1, "The hero of the story", "Ash", 1 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Name", "TeamId" },
                values: new object[] { 2, "The one with the pink hair", "Jessy", 2 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Name", "TeamId" },
                values: new object[] { 3, "A relentless fighter", "Hagen", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trainers",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Trainers",
                type: "TEXT",
                nullable: true);
        }
    }
}
