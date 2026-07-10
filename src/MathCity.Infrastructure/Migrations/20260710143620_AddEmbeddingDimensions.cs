using Microsoft.EntityFrameworkCore.Migrations;
using Pgvector;

#nullable disable

namespace MathCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmbeddingDimensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Vector>(
                name: "Embedding",
                table: "LessonVectorEmbeddings",
                type: "vector(768)",
                nullable: false,
                oldClrType: typeof(Vector),
                oldType: "vector(1536)");

            migrationBuilder.AddColumn<int>(
                name: "Dimensions",
                table: "LessonVectorEmbeddings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "LessonVectorEmbeddings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensions",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "LessonVectorEmbeddings");

            migrationBuilder.AlterColumn<Vector>(
                name: "Embedding",
                table: "LessonVectorEmbeddings",
                type: "vector(1536)",
                nullable: false,
                oldClrType: typeof(Vector),
                oldType: "vector(768)");
        }
    }
}
