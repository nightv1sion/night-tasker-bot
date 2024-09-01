using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Challenges.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChallengeReminders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "challenge_reminders",
                schema: "challenges",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    challenge_id = table.Column<Guid>(type: "uuid", nullable: false),
                    remind_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_challenge_reminders", x => x.id);
                    table.ForeignKey(
                        name: "fk_challenge_reminders_challenges_challenge_id",
                        column: x => x.challenge_id,
                        principalSchema: "challenges",
                        principalTable: "challenges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_challenge_reminders_challenge_id",
                schema: "challenges",
                table: "challenge_reminders",
                column: "challenge_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "challenge_reminders",
                schema: "challenges");
        }
    }
}
