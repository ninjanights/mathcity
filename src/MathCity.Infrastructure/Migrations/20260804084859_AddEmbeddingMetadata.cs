using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEmbeddingMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChapterId",
                table: "LessonVectorEmbeddings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ChapterName",
                table: "LessonVectorEmbeddings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LessonTitle",
                table: "LessonVectorEmbeddings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "LessonVectorEmbeddings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "LessonVectorEmbeddings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string[]>(
                name: "Tags",
                table: "LessonVectorEmbeddings",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "TopicId",
                table: "LessonVectorEmbeddings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "TopicName",
                table: "LessonVectorEmbeddings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "ChapterName",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "LessonTitle",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "LessonVectorEmbeddings");

            migrationBuilder.DropColumn(
                name: "TopicName",
                table: "LessonVectorEmbeddings");
        }
    }
}
