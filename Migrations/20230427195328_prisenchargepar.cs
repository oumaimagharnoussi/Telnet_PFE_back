using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class prisenchargepar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets");

           

            

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets");

           

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_users_userId",
                table: "Tickets",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
