using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foody.Migrations
{
    /// <inheritdoc />
    public partial class addingValidationtoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descriptionn",
                table: "Users",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Users",
                newName: "Descriptionn");
        }
    }
}
