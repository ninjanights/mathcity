using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathCity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChatSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "ChatSessions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "ChatSessions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "character varying(8000)",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Context",
                table: "ChatMessages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChatMessageSource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ChatMessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    LessonVectorEmbeddingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessageSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessageSource_ChatMessages_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "ChatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessageSource_LessonVectorEmbeddings_LessonVectorEmbedd~",
                        column: x => x.LessonVectorEmbeddingId,
                        principalTable: "LessonVectorEmbeddings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatSessions_SessionId",
                table: "ChatSessions",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChapterId",
                table: "ChatMessages",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_LessonId",
                table: "ChatMessages",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SubjectId",
                table: "ChatMessages",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_TopicId",
                table: "ChatMessages",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessageSource_ChatMessageId",
                table: "ChatMessageSource",
                column: "ChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessageSource_LessonVectorEmbeddingId",
                table: "ChatMessageSource",
                column: "LessonVectorEmbeddingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessageSource");

            migrationBuilder.DropIndex(
                name: "IX_ChatSessions_SessionId",
                table: "ChatSessions");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_ChapterId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_LessonId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SubjectId",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_TopicId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "ChatSessions");

            migrationBuilder.DropColumn(
                name: "Context",
                table: "ChatMessages");

            migrationBuilder.AlterColumn<string>(
                name: "SessionId",
                table: "ChatSessions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8000)",
                oldMaxLength: 8000);
        }
    }
}
