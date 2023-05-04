using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class AddTelnetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Telnet",
                columns: table => new
                {
                    TelnetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telnet", x => x.TelnetId);
                });

            migrationBuilder.AddColumn<int>(
                name: "TelnetId",
                table: "users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_TelnetId",
                table: "users",
                column: "TelnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Telnet_TelnetId",
                table: "users",
                column: "TelnetId",
                principalTable: "Telnet",
                principalColumn: "TelnetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Telnet_TelnetId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_TelnetId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TelnetId",
                table: "users");

            migrationBuilder.DropTable(
                name: "Telnet");
        }
    }

}
