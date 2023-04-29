using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class prisenchargeparid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "prisEnChargePar",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_prisEnChargePar",
                table: "Tickets",
                column: "prisEnChargePar");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_prisEnChargePar",
                table: "Tickets",
                column: "prisEnChargePar",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_prisEnChargePar",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_prisEnChargePar",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "prisEnChargePar",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

    }
}
