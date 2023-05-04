using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class relation_site_ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Ajoutez le code pour créer la clé étrangère
            migrationBuilder.AddColumn<int>(
                name: "telnetId",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_telnetId",
                table: "Tickets",
                column: "telnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets",
                column: "telnetId",
                principalTable: "Telnet",
                principalColumn: "telnetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Ajoutez le code pour supprimer la clé étrangère
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_telnetId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "telnetId",
                table: "Tickets");
        }
    }
}
