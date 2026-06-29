using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "AspNetUsers",
                newName: "IsActive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "AspNetUsers",
                newName: "isActive");
        }
    }
}
