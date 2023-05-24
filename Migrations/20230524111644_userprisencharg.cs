using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class userprisencharg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_prisEnCharge",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "prisEnCharge",
                table: "Tickets",
                newName: "prisEnChargeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_prisEnCharge",
                table: "Tickets",
                newName: "IX_Tickets_prisEnChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_prisEnChargeId",
                table: "Tickets",
                column: "prisEnChargeId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_prisEnChargeId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "prisEnChargeId",
                table: "Tickets",
                newName: "prisEnCharge");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_prisEnChargeId",
                table: "Tickets",
                newName: "IX_Tickets_prisEnCharge");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_prisEnCharge",
                table: "Tickets",
                column: "prisEnCharge",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
