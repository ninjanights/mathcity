using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChatMessageContextNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChapterName",
                table: "ChatMessages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonTitle",
                table: "ChatMessages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "ChatMessages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopicName",
                table: "ChatMessages",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterName",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "LessonTitle",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "TopicName",
                table: "ChatMessages");
        }
    }
}
