using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class suppidsite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "telnetId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "telnetId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Telnet_telnetId",
                table: "Tickets",
                column: "telnetId",
                principalTable: "Telnet",
                principalColumn: "telnetId");
        }
    }
}
