using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Migrations
{
    /// <inheritdoc />
    public partial class addingPropertiesToUserAndRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipePicture",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "recipePhotoss",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipePicture",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "recipePhotoss",
                table: "Recipes");
        }
    }
}
