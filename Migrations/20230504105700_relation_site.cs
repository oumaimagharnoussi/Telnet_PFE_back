using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class relation_site : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "telnetId",
                table: "Tickets",
                newName: "TelnetId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_telnetId",
                table: "Tickets",
                newName: "IX_Tickets_TelnetId");

            migrationBuilder.RenameColumn(
                name: "telnetId",
                table: "Telnet",
                newName: "TelnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Telnet_TelnetId",
                table: "Tickets",
                column: "TelnetId",
                principalTable: "Telnet",
                principalColumn: "TelnetId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Telnet_TelnetId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "TelnetId",
                table: "Tickets",
                newName: "telnetId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TelnetId",
                table: "Tickets",
                newName: "IX_Tickets_telnetId");

            migrationBuilder.RenameColumn(
                name: "TelnetId",
                table: "Telnet",
                newName: "telnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets",
                column: "telnetId",
                principalTable: "Telnet",
                principalColumn: "telnetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
