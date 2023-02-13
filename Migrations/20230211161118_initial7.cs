using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Socials.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "FoodSchedulings");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "FoodSchedulings");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "FoodSchedulings",
                newName: "MealDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MealDate",
                table: "FoodSchedulings",
                newName: "StartDate");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "FoodSchedulings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "FoodSchedulings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
