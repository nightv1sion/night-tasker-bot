using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Planner.Plans.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlansUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "user_id",
                schema: "plans",
                table: "plans",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                schema: "plans",
                table: "plans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
