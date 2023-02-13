using Microsoft.EntityFrameworkCore.Migrations;

namespace Socials.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FoodSchedulings",
                newName: "Launch");

            migrationBuilder.AddColumn<string>(
                name: "Breakfast",
                table: "FoodSchedulings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dinner",
                table: "FoodSchedulings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "FoodSchedulings");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "FoodSchedulings");

            migrationBuilder.RenameColumn(
                name: "Launch",
                table: "FoodSchedulings",
                newName: "Name");
        }
    }
}
