using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class commentaire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_Tickets_ticketId",
                table: "Commentaires");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_Tickets_ticketId",
                table: "Commentaires",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "ticketId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_Tickets_ticketId",
                table: "Commentaires");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_Tickets_ticketId",
                table: "Commentaires",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "ticketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
