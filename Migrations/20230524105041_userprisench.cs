using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class userprisench : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "prisEnCharge",
                table: "Tickets",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_prisEnCharge",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_prisEnCharge",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_prisEnCharge",
                table: "Tickets",
                column: "prisEnCharge");

            // Add the foreign key constraint if it does not exist
            if (!migrationBuilder.ActiveProvider.ToLower().Contains("sqlite"))
            {
                migrationBuilder.AddForeignKey(
                    name: "FK_Tickets_users_prisEnCharge", table: "Tickets", column: "prisEnCharge", principalTable: "users",
                    principalColumn: "userId",
                    onDelete: ReferentialAction.Restrict);
            }
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the foreign key constraint if it exists
            if (!migrationBuilder.ActiveProvider.ToLower().Contains("sqlite"))
            {
                migrationBuilder.DropForeignKey(
                    name: "FK_Tickets_users_prisEnCharge",
                    table: "Tickets");
            }

            migrationBuilder.DropIndex(
                name: "IX_Tickets_prisEnCharge",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "prisEnCharge",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_prisEnCharge",
                table: "Tickets",
                column: "prisEnCharge");
        }
    }
}
