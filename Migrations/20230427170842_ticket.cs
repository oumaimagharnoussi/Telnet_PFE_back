using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class ticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Groupes_groupId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_groupId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "Tickets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_groupId",
                table: "Tickets",
                column: "groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Groupes_groupId",
                table: "Tickets",
                column: "groupId",
                principalTable: "Groupes",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
