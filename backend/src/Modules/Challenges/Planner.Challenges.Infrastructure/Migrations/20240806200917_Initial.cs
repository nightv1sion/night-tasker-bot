using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Challenges.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "challenges");

            migrationBuilder.CreateTable(
                name: "challenges",
                schema: "challenges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenges", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "challenge_messages",
                schema: "challenges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    challenge_id = table.Column<Guid>(type: "uuid", nullable: false),
                    sent_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    message_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenge_messages", x => x.id);
                    table.ForeignKey(
                        name: "fk_challenge_messages_challenges_challenge_id",
                        column: x => x.challenge_id,
                        principalSchema: "challenges",
                        principalTable: "challenges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_challenge_messages_challenge_id",
                schema: "challenges",
                table: "challenge_messages",
                column: "challenge_id");

            migrationBuilder.CreateIndex(
                name: "ix_challenge_messages_message_id",
                schema: "challenges",
                table: "challenge_messages",
                column: "message_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_challenges_user_id",
                schema: "challenges",
                table: "challenges",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "challenge_messages",
                schema: "challenges");

            migrationBuilder.DropTable(
                name: "challenges",
                schema: "challenges");
        }
    }
}
