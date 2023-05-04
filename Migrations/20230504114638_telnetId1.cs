using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class telnetId1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Telnet_telnetId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "TelnetId",
                table: "users",
                newName: "telnetId");

            migrationBuilder.RenameIndex(
                name: "IX_users_TelnetId",
                table: "users",
                newName: "IX_users_telnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Telnet_telnetId",
                table: "users",
                column: "telnetId",
                principalTable: "Telnet",
                principalColumn: "telnetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Telnet_telnetId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "TelnetId",
                table: "users",
                newName: "telnetId");

            migrationBuilder.RenameIndex(
                name: "IX_users_TelnetId",
                table: "users",
                newName: "IX_users_telnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Telnet_telnetId",
                table: "users",
                column: "telnetId",
                principalTable: "Telnet",
                principalColumn: "telnetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
