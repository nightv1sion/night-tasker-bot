using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Plans.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "plans");

            migrationBuilder.CreateTable(
                name: "plans",
                schema: "plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plan_reminders",
                schema: "plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    plan_id = table.Column<Guid>(type: "uuid", nullable: false),
                    remind_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plan_reminders", x => x.id);
                    table.ForeignKey(
                        name: "fk_plan_reminders_plans_plan_id",
                        column: x => x.plan_id,
                        principalSchema: "plans",
                        principalTable: "plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_plan_reminders_plan_id",
                schema: "plans",
                table: "plan_reminders",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_plans_user_id",
                schema: "plans",
                table: "plans",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plan_reminders",
                schema: "plans");

            migrationBuilder.DropTable(
                name: "plans",
                schema: "plans");
        }
    }
}
