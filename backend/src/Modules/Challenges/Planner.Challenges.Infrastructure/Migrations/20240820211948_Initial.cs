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
                name: "challenges",
                schema: "challenges");
        }
    }
}
