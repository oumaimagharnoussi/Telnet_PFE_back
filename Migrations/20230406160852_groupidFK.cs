using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketback.Migrations
{
    /// <inheritdoc />
    public partial class groupidFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_groupId",
                table: "users",
                column: "groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Groupe_groupId",
                table: "users",
                column: "groupId",
                principalTable: "Groupes",
                principalColumn: "groupId",
                onDelete: ReferentialAction.Restrict);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
