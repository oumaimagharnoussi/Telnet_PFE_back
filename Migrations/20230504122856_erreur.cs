using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class erreur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TelnetId_Telnet_telnetId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets",
                column: "telnetId",
                principalTable: "Telnet",
                principalColumn: "telnetId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TelnetId_Telnet_telnetId",
                table: "Tickets",
                column: "telnetId",
                principalTable: "Telnet",
                principalColumn: "telnetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
