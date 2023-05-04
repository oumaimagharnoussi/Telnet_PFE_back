using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class RenameTicketTelnetIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telnetId",
                table: "Tickets",
                newName: "TelnetId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_telnetId",
                table: "Tickets",
                newName: "IX_Tickets_TelnetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelnetId",
                table: "Tickets",
                newName: "telnetId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_TelnetId",
                table: "Tickets",
                newName: "IX_Tickets_telnetId");
        }
    }

}
