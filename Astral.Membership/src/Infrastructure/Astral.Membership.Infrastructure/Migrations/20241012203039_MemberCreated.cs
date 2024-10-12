using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Astral.Membership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MemberCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExternalId",
                table: "Members",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentMemberId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Iban",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ParentMemberId",
                table: "Members");
        }
    }
}
