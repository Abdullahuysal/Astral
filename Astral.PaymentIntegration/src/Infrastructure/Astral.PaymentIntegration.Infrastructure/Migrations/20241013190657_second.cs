using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Astral.PaymentIntegration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Payment_BankId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_BankId",
                table: "Card");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Payment_Id",
                table: "Card",
                column: "Id",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Payment_Id",
                table: "Card");

            migrationBuilder.CreateIndex(
                name: "IX_Card_BankId",
                table: "Card",
                column: "BankId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Payment_BankId",
                table: "Card",
                column: "BankId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
