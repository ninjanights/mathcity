using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompositeDisplayOrderIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_ChapterId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_PracticeQuestions_LessonId",
                table: "PracticeQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TopicId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_LessonResources_LessonId",
                table: "LessonResources");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_SubjectId",
                table: "Chapters");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ChapterId_DisplayOrder",
                table: "Topics",
                columns: new[] { "ChapterId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PracticeQuestions_LessonId_DisplayOrder",
                table: "PracticeQuestions",
                columns: new[] { "LessonId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TopicId_DisplayOrder",
                table: "Lessons",
                columns: new[] { "TopicId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonResources_LessonId_DisplayOrder",
                table: "LessonResources",
                columns: new[] { "LessonId", "DisplayOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SubjectId_DisplayOrder",
                table: "Chapters",
                columns: new[] { "SubjectId", "DisplayOrder" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Topics_ChapterId_DisplayOrder",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_PracticeQuestions_LessonId_DisplayOrder",
                table: "PracticeQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_TopicId_DisplayOrder",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_LessonResources_LessonId_DisplayOrder",
                table: "LessonResources");

            migrationBuilder.DropIndex(
                name: "IX_Chapters_SubjectId_DisplayOrder",
                table: "Chapters");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ChapterId",
                table: "Topics",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_PracticeQuestions_LessonId",
                table: "PracticeQuestions",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TopicId",
                table: "Lessons",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonResources_LessonId",
                table: "LessonResources",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_SubjectId",
                table: "Chapters",
                column: "SubjectId");
        }
    }
}
