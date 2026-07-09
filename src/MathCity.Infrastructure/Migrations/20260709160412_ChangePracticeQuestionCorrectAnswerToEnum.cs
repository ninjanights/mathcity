using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathCity.Infrastructure.Migrations
{
    public partial class ChangePracticeQuestionCorrectAnswerToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE "PracticeQuestions"
                ALTER COLUMN "CorrectAnswer"
                TYPE integer
                USING CASE "CorrectAnswer"
                    WHEN 'A' THEN 0
                    WHEN 'B' THEN 1
                    WHEN 'C' THEN 2
                    WHEN 'D' THEN 3
                    ELSE 0
                END;
                """);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE "PracticeQuestions"
                ALTER COLUMN "CorrectAnswer"
                TYPE text
                USING CASE "CorrectAnswer"
                    WHEN 0 THEN 'A'
                    WHEN 1 THEN 'B'
                    WHEN 2 THEN 'C'
                    WHEN 3 THEN 'D'
                    ELSE 'A'
                END;
                """);
        }
    }
}