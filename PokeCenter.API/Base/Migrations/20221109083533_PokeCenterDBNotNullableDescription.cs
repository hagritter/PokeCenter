﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeCenter.API.Migrations
{
    public partial class PokeCenterDBNotNullableDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trainers",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);
        }
    }
}
