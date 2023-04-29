using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class prisen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_prisEnChargePar",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_prisEnChargePar",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "prisEnChargePar",
                table: "Tickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prisEnChargePar",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
