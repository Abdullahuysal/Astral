using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Astral.Membership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenMigrationnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tokens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tokens");
        }
    }
}
